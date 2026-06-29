using Microsoft.Data.SqlClient;
using PokeApiNet;

var client = new PokeApiClient();
string connectionString =
    "Server=localhost;Database=kyusAPTB;Trusted_Connection=True;TrustServerCertificate=True;";

using SqlConnection conn = new SqlConnection(connectionString);
await conn.OpenAsync();
for (int i = 1; i <= 151; i++)
{
    var pokemon = await client.GetResourceAsync<Pokemon>(i);
    var species = await client.GetResourceAsync(pokemon.Species);
    var evolutionChain = await client.GetResourceAsync(species.EvolutionChain);

    Console.WriteLine($"Adding {pokemon.Name}");

    // TYPES
    string? type1 = pokemon.Types.Count > 0
        ? pokemon.Types[0].Type.Name
        : null;

    string? type2 = pokemon.Types.Count > 1
        ? pokemon.Types[1].Type.Name
        : null;

    // ABILITIES
    string? ability1 = pokemon.Abilities.Count > 0
        ? pokemon.Abilities[0].Ability.Name
        : null;

    string? ability2 = pokemon.Abilities.Count > 1
        ? pokemon.Abilities[1].Ability.Name
        : null;

    string? hiddenAbility = pokemon.Abilities
        .FirstOrDefault(a => a.IsHidden)?.Ability.Name;

    // STATS
    int hp = pokemon.Stats.First(s => s.Stat.Name == "hp").BaseStat;
    int atk = pokemon.Stats.First(s => s.Stat.Name == "attack").BaseStat;
    int def = pokemon.Stats.First(s => s.Stat.Name == "defense").BaseStat;
    int spa = pokemon.Stats.First(s => s.Stat.Name == "special-attack").BaseStat;
    int spd = pokemon.Stats.First(s => s.Stat.Name == "special-defense").BaseStat;
    int speed = pokemon.Stats.First(s => s.Stat.Name == "speed").BaseStat;

    int total = hp + atk + def + spa + spd + speed;

    // EVOLUTIONS
    string? preEvolution = null;
    string? nextEvolution = null;
    int stage = 1;

    void FindEvolution(ChainLink chain, string? previous)
    {
        if (chain.Species.Name == pokemon.Name)
        {
            preEvolution = previous;

            if (chain.EvolvesTo.Count > 0)
            {
                nextEvolution = chain.EvolvesTo[0].Species.Name;
            }
        }

        foreach (var evo in chain.EvolvesTo)
        {
            FindEvolution(evo, chain.Species.Name);
        }
    }

    FindEvolution(evolutionChain.Chain, null);

    // STAGE
    if (preEvolution != null)
        stage = 2;

    if (preEvolution != null && nextEvolution == null)
        stage = 3;

    // INSERT POKEMON
    string insertPokemon = @"
INSERT INTO pokemons
(name, height, weight,
type1, type2, species,
ability1, ability2, hiddenAbility,
hp, atk, def, spa, spd, speed, total,
stage, preEvolution, nextEvolution)

OUTPUT INSERTED.pokedexID

VALUES
(@name, @height, @weight,
@type1, @type2, @species,
@ability1, @ability2, @hiddenAbility,
@hp, @atk, @def, @spa, @spd, @speed, @total,
@stage, @preEvolution, @nextEvolution)
";

    using SqlCommand cmd = new SqlCommand(insertPokemon, conn);

    cmd.Parameters.AddWithValue("@name", pokemon.Name);
    cmd.Parameters.AddWithValue("@height", pokemon.Height / 10.0);
    cmd.Parameters.AddWithValue("@weight", pokemon.Weight / 10.0);

    cmd.Parameters.AddWithValue("@type1", (object?)type1 ?? DBNull.Value);
    cmd.Parameters.AddWithValue("@type2", (object?)type2 ?? DBNull.Value);

    cmd.Parameters.AddWithValue("@species", species.Genera
        .FirstOrDefault(g => g.Language.Name == "en")?.Genus ?? "");

    cmd.Parameters.AddWithValue("@ability1", (object?)ability1 ?? DBNull.Value);
    cmd.Parameters.AddWithValue("@ability2", (object?)ability2 ?? DBNull.Value);
    cmd.Parameters.AddWithValue("@hiddenAbility", (object?)hiddenAbility ?? DBNull.Value);

    cmd.Parameters.AddWithValue("@hp", hp);
    cmd.Parameters.AddWithValue("@atk", atk);
    cmd.Parameters.AddWithValue("@def", def);
    cmd.Parameters.AddWithValue("@spa", spa);
    cmd.Parameters.AddWithValue("@spd", spd);
    cmd.Parameters.AddWithValue("@speed", speed);
    cmd.Parameters.AddWithValue("@total", total);

    cmd.Parameters.AddWithValue("@stage", stage);

    cmd.Parameters.AddWithValue(
        "@preEvolution",
        (object?)preEvolution ?? DBNull.Value
    );

    cmd.Parameters.AddWithValue(
        "@nextEvolution",
        (object?)nextEvolution ?? DBNull.Value
    );

    int pokemonID = (int)await cmd.ExecuteScalarAsync();

    // MOVES
    foreach (var moveEntry in pokemon.Moves)
    {
        var move = await client.GetResourceAsync(moveEntry.Move);

        string insertMove = @"
IF NOT EXISTS (
    SELECT 1 FROM moves WHERE name = @name
)
BEGIN
    INSERT INTO moves
    (name, type, category, power, accuracy)

    VALUES
    (@name, @type, @category, @power, @accuracy)
END
";

        using SqlCommand moveCmd = new SqlCommand(insertMove, conn);

        moveCmd.Parameters.AddWithValue("@name", move.Name);
        moveCmd.Parameters.AddWithValue("@type", move.Type.Name);
        moveCmd.Parameters.AddWithValue("@category", move.DamageClass.Name);

        moveCmd.Parameters.AddWithValue(
            "@power",
            move.Power.HasValue ? move.Power.Value : DBNull.Value
        );

        moveCmd.Parameters.AddWithValue(
            "@accuracy",
            move.Accuracy.HasValue ? move.Accuracy.Value : DBNull.Value
        );

        await moveCmd.ExecuteNonQueryAsync();

        // GET MOVE ID
        string getMoveID = "SELECT id FROM moves WHERE name = @name";

        using SqlCommand getMoveCmd = new SqlCommand(getMoveID, conn);

        getMoveCmd.Parameters.AddWithValue("@name", move.Name);

        int moveID = (int)await getMoveCmd.ExecuteScalarAsync();

        // LINK POKEMON TO MOVE
        string linkMove = @"
IF NOT EXISTS (
    SELECT 1 FROM pokemonMoves
    WHERE pokemonID = @pokemonID
    AND moveID = @moveID
)
BEGIN
    INSERT INTO pokemonMoves (pokemonID, moveID)
    VALUES (@pokemonID, @moveID)
END
";

        using SqlCommand linkCmd = new SqlCommand(linkMove, conn);

        linkCmd.Parameters.AddWithValue("@pokemonID", pokemonID);
        linkCmd.Parameters.AddWithValue("@moveID", moveID);

        await linkCmd.ExecuteNonQueryAsync();
    }
}