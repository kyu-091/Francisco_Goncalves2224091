using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyusAPTB
{
    public partial class Pokedex : Form
    {
        private readonly PokeApiClient _pokeClient;
        private List<NamedApiResource<Pokemon>> _fullPokemonList;
        private List<NamedApiResource<Pokemon>> _currentDisplayList;

        private Dictionary<string, Dictionary<string, float>> _typeEffectiveness;
        private Dictionary<string, string> _typeNameMap;
        private List<string> _allTypeNames;

        public Pokedex()
        {
            InitializeComponent();
            _pokeClient = new PokeApiClient();
            InitializeTypeNameMap();
            LoadTypeEffectiveness();
            LoadPokemonList();
        }

        private void InitializeTypeNameMap()
        {
            _typeNameMap = new Dictionary<string, string>
            {
                {"normal", "Normal"},
                {"fighting", "Fighting"},
                {"flying", "Flying"},
                {"poison", "Poison"},
                {"ground", "Ground"},
                {"rock", "Rock"},
                {"bug", "Bug"},
                {"ghost", "Ghost"},
                {"steel", "Steel"},
                {"fire", "Fire"},
                {"water", "Water"},
                {"grass", "Grass"},
                {"electric", "Electric"},
                {"psychic", "Psychic"},
                {"ice", "Ice"},
                {"dragon", "Dragon"},
                {"dark", "Dark"},
                {"fairy", "Fairy"}
            };
        }

        private async void LoadTypeEffectiveness()
        {
            try
            {
                _typeEffectiveness = new Dictionary<string, Dictionary<string, float>>();
                _allTypeNames = new List<string>();

                var typePage = await _pokeClient.GetNamedResourcePageAsync<PokeApiNet.Type>(20, 0);

                foreach (var typeResource in typePage.Results)
                {
                    if (typeResource.Name == "stellar" || typeResource.Name == "unknown")
                        continue;

                    var type = await _pokeClient.GetResourceAsync(typeResource);
                    var damageRelations = type.DamageRelations;

                    string typeDisplayName = _typeNameMap.ContainsKey(type.Name) ? _typeNameMap[type.Name] : type.Name;
                    _allTypeNames.Add(typeDisplayName);

                    var effectiveness = new Dictionary<string, float>();

                    foreach (var weakType in damageRelations.DoubleDamageTo)
                    {
                        if (weakType.Name == "stellar" || weakType.Name == "unknown") continue;
                        string typeName = _typeNameMap.ContainsKey(weakType.Name) ? _typeNameMap[weakType.Name] : weakType.Name;
                        effectiveness[typeName] = 2.0f;
                    }

                    foreach (var resistType in damageRelations.HalfDamageTo)
                    {
                        if (resistType.Name == "stellar" || resistType.Name == "unknown") continue;
                        string typeName = _typeNameMap.ContainsKey(resistType.Name) ? _typeNameMap[resistType.Name] : resistType.Name;
                        effectiveness[typeName] = 0.5f;
                    }

                    foreach (var noDamageType in damageRelations.NoDamageTo)
                    {
                        if (noDamageType.Name == "stellar" || noDamageType.Name == "unknown") continue;
                        string typeName = _typeNameMap.ContainsKey(noDamageType.Name) ? _typeNameMap[noDamageType.Name] : noDamageType.Name;
                        effectiveness[typeName] = 0.0f;
                    }

                    _typeEffectiveness[typeDisplayName] = effectiveness;
                }

                foreach (var typeName in _typeNameMap.Values)
                {
                    if (!_typeEffectiveness.ContainsKey(typeName))
                    {
                        _typeEffectiveness[typeName] = new Dictionary<string, float>();
                    }
                    if (!_allTypeNames.Contains(typeName))
                    {
                        _allTypeNames.Add(typeName);
                    }
                }

                _allTypeNames = _allTypeNames.OrderBy(t => t).ToList();
                _allTypeNames = _allTypeNames.Where(t => t != "unknown" && t != "Unknown").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading type effectiveness: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadPokemonList()
        {
            try
            {
                var pokemonPage = await _pokeClient.GetNamedResourcePageAsync<Pokemon>(1025, 0);
                _fullPokemonList = pokemonPage.Results.Take(1025).ToList();
                _currentDisplayList = _fullPokemonList;

                pokemonListBox.Items.Clear();

                for (int i = 0; i < _fullPokemonList.Count; i++)
                {
                    int id = i + 1;
                    string name = _fullPokemonList[i].Name;
                    name = char.ToUpper(name[0]) + name.Substring(1);
                    pokemonListBox.Items.Add($"#{id:D3} {name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void PokemonListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pokemonListBox.SelectedIndex >= 0 && _currentDisplayList != null)
            {
                var selectedPokemon = _currentDisplayList[pokemonListBox.SelectedIndex];
                await LoadPokemonInfo(selectedPokemon.Name);
            }
        }

        private async Task LoadPokemonInfo(string pokemonName)
        {
            try
            {
                Pokemon pokemon = await _pokeClient.GetResourceAsync<Pokemon>(pokemonName);
                PokemonSpecies species = await _pokeClient.GetResourceAsync(pokemon.Species);

                string formattedName = char.ToUpper(pokemon.Name[0]) + pokemon.Name.Substring(1);
                pokemonGroupBox.Text = $"> {formattedName}";

                string englishGenus = species.Genera
                    .FirstOrDefault(g => g.Language.Name == "en")?
                    .Genus ?? "Unknown";
                speciesBox.Text = englishGenus;

                heightBox.Text = $"{pokemon.Height / 10.0f:F1} m";
                weightBox.Text = $"{pokemon.Weight / 10.0f:F1} kg";

                description.Text = species.FlavorTextEntries
                    .FirstOrDefault(f => f.Language.Name == "en")?
                    .FlavorText.Replace("\n", " ").Replace("\f", " ") ?? "No description available.";

                foreach (var stat in pokemon.Stats)
                {
                    string statName = stat.Stat.Name.ToLower();
                    int statValue = stat.BaseStat;

                    switch (statName)
                    {
                        case "hp":
                            HP.Text = statValue.ToString();
                            break;
                        case "attack":
                            Atk.Text = statValue.ToString();
                            break;
                        case "defense":
                            Def.Text = statValue.ToString();
                            break;
                        case "special-attack":
                            SpAtk.Text = statValue.ToString();
                            break;
                        case "special-defense":
                            SpDef.Text = statValue.ToString();
                            break;
                        case "speed":
                            Speed.Text = statValue.ToString();
                            break;
                    }
                }

                List<string> pokemonTypes = new List<string>();
                if (pokemon.Types.Count > 0)
                {
                    string type1Name = _typeNameMap.ContainsKey(pokemon.Types[0].Type.Name) ?
                        _typeNameMap[pokemon.Types[0].Type.Name] :
                        char.ToUpper(pokemon.Types[0].Type.Name[0]) + pokemon.Types[0].Type.Name.Substring(1);
                    type1Box.Text = type1Name;
                    pokemonTypes.Add(type1Name);

                    if (pokemon.Types.Count > 1)
                    {
                        string type2Name = _typeNameMap.ContainsKey(pokemon.Types[1].Type.Name) ?
                            _typeNameMap[pokemon.Types[1].Type.Name] :
                            char.ToUpper(pokemon.Types[1].Type.Name[0]) + pokemon.Types[1].Type.Name.Substring(1);
                        type2Box.Text = type2Name;
                        pokemonTypes.Add(type2Name);
                    }
                    else
                    {
                        type2Box.Text = "None";
                    }
                }

                string ability1 = "";
                string ability2 = "";
                string hiddenAbility = "";

                var abilities = pokemon.Abilities.ToList();

                if (abilities.Count > 0)
                {
                    ability1 = char.ToUpper(abilities[0].Ability.Name[0]) + abilities[0].Ability.Name.Substring(1);

                    if (abilities.Count > 1 && !abilities[1].IsHidden)
                    {
                        ability2 = char.ToUpper(abilities[1].Ability.Name[0]) + abilities[1].Ability.Name.Substring(1);
                    }

                    var hidden = abilities.FirstOrDefault(a => a.IsHidden);
                    if (hidden != null)
                    {
                        hiddenAbility = char.ToUpper(hidden.Ability.Name[0]) + hidden.Ability.Name.Substring(1);
                    }
                }

                ability1Box.Text = ability1;
                ability2Box.Text = ability2;
                hiddenAbilityBox.Text = hiddenAbility;

                LoadTypeEffectivenessDisplay(pokemonTypes);

                if (pokemon.Sprites?.Other?.OfficialArtwork?.FrontDefault != null)
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        var imageBytes = await httpClient.GetByteArrayAsync(pokemon.Sprites.Other.OfficialArtwork.FrontDefault);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            var image = Image.FromStream(ms);
                            pokemonPictureBox.Image = image;
                            pokemonPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
                else if (pokemon.Sprites?.FrontDefault != null)
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        var imageBytes = await httpClient.GetByteArrayAsync(pokemon.Sprites.FrontDefault);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            var image = Image.FromStream(ms);
                            pokemonPictureBox.Image = image;
                            pokemonPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {pokemonName}: {ex.Message}");
            }
        }

        private void LoadTypeEffectivenessDisplay(List<string> pokemonTypes)
        {
            weaknessesBox.Text = "";
            resistancesBox.Text = "";
            immunitiesBox.Text = "";
            normalBox.Text = "";

            if (pokemonTypes == null || pokemonTypes.Count == 0 || _typeEffectiveness == null || _allTypeNames == null || _allTypeNames.Count == 0)
            {
                weaknessesBox.Text = "None";
                resistancesBox.Text = "None";
                immunitiesBox.Text = "None";
                normalBox.Text = "None";
                return;
            }

            if (pokemonTypes.Count == 1 && pokemonTypes[0] == "None")
            {
                weaknessesBox.Text = "None";
                resistancesBox.Text = "None";
                immunitiesBox.Text = "None";
                normalBox.Text = "None";
                return;
            }

            List<string> weaknesses = new List<string>();
            List<string> resistances = new List<string>();
            List<string> immunities = new List<string>();
            List<string> normal = new List<string>();

            var allTypes = _allTypeNames;

            foreach (var attackType in allTypes)
            {
                float effectiveness = 1.0f;

                foreach (var pokemonType in pokemonTypes)
                {
                    if (!_typeEffectiveness.ContainsKey(attackType))
                        continue;

                    if (_typeEffectiveness[attackType].ContainsKey(pokemonType))
                    {
                        effectiveness *= _typeEffectiveness[attackType][pokemonType];
                    }
                }

                if (effectiveness == 0.0f)
                {
                    immunities.Add(attackType);
                }
                else if (effectiveness == 2.0f)
                {
                    weaknesses.Add(attackType);
                }
                else if (effectiveness == 0.5f)
                {
                    resistances.Add(attackType);
                }
                else if (effectiveness == 1.0f)
                {
                    normal.Add(attackType);
                }
                else if (effectiveness == 4.0f)
                {
                    weaknesses.Add($"4x {attackType}");
                }
                else if (effectiveness == 0.25f)
                {
                    resistances.Add($"0.25x {attackType}");
                }
            }

            weaknessesBox.Text = weaknesses.Count > 0 ? string.Join(", ", weaknesses) : "None";
            resistancesBox.Text = resistances.Count > 0 ? string.Join(", ", resistances) : "None";
            immunitiesBox.Text = immunities.Count > 0 ? string.Join(", ", immunities) : "None";
            normalBox.Text = normal.Count > 0 ? string.Join(", ", normal) : "None";
        }

        private async void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                _currentDisplayList = _fullPokemonList;
                await LoadFullPokemonList();
            }
            else
            {
                try
                {
                    var filteredPokemon = _fullPokemonList
                        .Where(p => p.Name.Contains(searchTerm))
                        .ToList();

                    _currentDisplayList = filteredPokemon;
                    pokemonListBox.Items.Clear();

                    foreach (var pokemon in filteredPokemon)
                    {
                        int id = _fullPokemonList.FindIndex(p => p.Name == pokemon.Name) + 1;
                        string name = char.ToUpper(pokemon.Name[0]) + pokemon.Name.Substring(1);
                        pokemonListBox.Items.Add($"#{id:D3} {name}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Search error: {ex.Message}");
                }
            }
        }

        private async Task LoadFullPokemonList()
        {
            try
            {
                pokemonListBox.Items.Clear();

                foreach (var pokemon in _currentDisplayList)
                {
                    int id = _fullPokemonList.FindIndex(p => p.Name == pokemon.Name) + 1;
                    string name = char.ToUpper(pokemon.Name[0]) + pokemon.Name.Substring(1);
                    pokemonListBox.Items.Add($"#{id:D3} {name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Home temp1 = new Home();
            temp1.Region = this.Region;
            temp1.Show();
            this.Hide();
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchTextBox_TextChanged(sender, e);
        }

        private void TeamBuilderButton_Click(object sender, EventArgs e)
        {
            TeamBuilder temp1 = new TeamBuilder();
            temp1.Region = this.Region;
            temp1.Show();
            this.Hide();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void PictureBox1_Click(object sender, EventArgs e) { }
        private void DescriptionLabel_Click(object sender, EventArgs e) { }
        private void PokemonGroupBox_Enter(object sender, EventArgs e) { }
        private void Description_Click(object sender, EventArgs e) { }
        private void Pokedex_Load(object sender, EventArgs e) { }
    }
}