using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokeApiNet;

namespace kyusAPTB
{
    public partial class NewTeam : Form
    {
        private readonly string _connectionString = @"Server=kyu-laptop\;Database=kyusAPTB;Trusted_Connection=True";

        private readonly PokeApiClient _pokeApi = new PokeApiClient();

        private readonly int[] _selectedPokemon = new int[6];
        private readonly int _teamNumber;
        private readonly int _userId;

        private readonly List<string> _loadedItems = new List<string>();
        private readonly List<string> _loadedNatures = new List<string>();

        private readonly GroupBox[] _groupBoxes;

        public NewTeam() : this(0)
        {
        }

        public NewTeam(int teamNumber)
        {
            InitializeComponent();
            _teamNumber = teamNumber;

            if (Session.CurrentUser != null)
            {
                _userId = Session.CurrentUser.UserID;
            }
            else
            {
                _userId = 1;
            }

            _groupBoxes = new[] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6 };

            pictureBox1.Tag = 0;
            pictureBox2.Tag = 1;
            pictureBox3.Tag = 2;
            pictureBox4.Tag = 3;
            pictureBox5.Tag = 4;
            pictureBox6.Tag = 5;

            pictureBox1.Click += PictureBox_Click;
            pictureBox2.Click += PictureBox_Click;
            pictureBox3.Click += PictureBox_Click;
            pictureBox4.Click += PictureBox_Click;
            pictureBox5.Click += PictureBox_Click;
            pictureBox6.Click += PictureBox_Click;

            LoadFormData();
        }

        private async void LoadFormData()
        {
            await LoadItems();
            await LoadNatures();
            LoadSavedTeam();
        }

        private async Task LoadItems()
        {
            try
            {
                _loadedItems.Clear();
                _loadedItems.Add("None");

                int pageSize = 100;
                int offset = 0;
                int maxItems = 1000;
                int totalLoaded = 0;

                while (totalLoaded < maxItems)
                {
                    try
                    {
                        var itemPage = await _pokeApi.GetNamedResourcePageAsync<Item>(pageSize, offset);

                        if (itemPage == null || itemPage.Results == null || itemPage.Results.Count == 0)
                        {
                            break;
                        }

                        foreach (var item in itemPage.Results)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.Name))
                            {
                                string name = char.ToUpper(item.Name[0]) + item.Name.Substring(1);
                                name = name.Replace("-", " ");
                                _loadedItems.Add(name);
                            }
                        }

                        totalLoaded += itemPage.Results.Count;

                        if (itemPage.Results.Count < pageSize)
                        {
                            break;
                        }

                        offset += pageSize;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error loading item page: {ex.Message}");
                        break;
                    }
                }

                string noneItem = _loadedItems[0];
                _loadedItems.RemoveAt(0);
                _loadedItems.Sort();
                _loadedItems.Insert(0, noneItem);

                System.Diagnostics.Debug.WriteLine($"Loaded {_loadedItems.Count} items total");

                for (int i = 1; i <= 6; i++)
                {
                    SetItemsCombo(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task LoadNatures()
        {
            try
            {
                var naturePage = await _pokeApi.GetNamedResourcePageAsync<Nature>(100, 0);
                _loadedNatures.Clear();

                foreach (var nature in naturePage.Results)
                {
                    string name = char.ToUpper(nature.Name[0]) + nature.Name.Substring(1);
                    _loadedNatures.Add(name);
                }

                for (int i = 1; i <= 6; i++)
                {
                    SetNaturesCombo(i);
                }
            }
            catch (Exception)
            {
            }
        }

        private void SetItemsCombo(int slot)
        {
            try
            {
                var cb = GetComboFromGroupBox(slot, "item");
                if (cb == null) return;

                cb.Items.Clear();

                if (_loadedItems.Count > 0)
                {
                    foreach (var item in _loadedItems)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            cb.Items.Add(item);
                        }
                    }
                    if (cb.Items.Count > 0)
                        cb.SelectedIndex = 0;
                }
                else
                {
                    cb.Items.Add("None");
                    cb.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
            }
        }

        private void SetNaturesCombo(int slot)
        {
            try
            {
                var cb = GetComboFromGroupBox(slot, "nature");
                if (cb == null) return;

                cb.Items.Clear();
                foreach (var nature in _loadedNatures)
                {
                    cb.Items.Add(nature);
                }
                if (cb.Items.Count > 0)
                    cb.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        private ComboBox GetComboFromGroupBox(int slot, string name)
        {
            try
            {
                int groupBoxIndex = slot - 1;
                if (groupBoxIndex >= 0 && groupBoxIndex < _groupBoxes.Length)
                {
                    var groupBox = _groupBoxes[groupBoxIndex];
                    if (groupBox != null)
                    {
                        foreach (Control control in groupBox.Controls)
                        {
                            if (control.Name == $"{name}{slot}")
                                return control as ComboBox;
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private TextBox GetTextBoxFromGroupBox(int slot, string name)
        {
            try
            {
                int groupBoxIndex = slot - 1;
                if (groupBoxIndex >= 0 && groupBoxIndex < _groupBoxes.Length)
                {
                    var groupBox = _groupBoxes[groupBoxIndex];
                    if (groupBox != null)
                    {
                        foreach (Control control in groupBox.Controls)
                        {
                            if (control.Name == name)
                                return control as TextBox;
                        }

                        string searchName = $"{name}{slot}";
                        foreach (Control control in groupBox.Controls)
                        {
                            if (control.Name == searchName)
                                return control as TextBox;
                        }

                        foreach (Control control in groupBox.Controls)
                        {
                            if (control.Name.ToLower() == searchName.ToLower())
                                return control as TextBox;
                        }

                        foreach (Control control in this.Controls)
                        {
                            if (control.Name == name || control.Name == searchName)
                                return control as TextBox;

                            if (control.HasChildren)
                            {
                                var found = FindControlRecursive(control, name, searchName);
                                if (found != null)
                                    return found;
                            }
                        }
                    }
                }

                foreach (Control control in this.Controls)
                {
                    if (control.Name == name)
                        return control as TextBox;

                    if (control.HasChildren)
                    {
                        var found = FindControlRecursive(control, name, name);
                        if (found != null)
                            return found;
                    }
                }

                System.Diagnostics.Debug.WriteLine($"Could not find textbox {name} for slot {slot}");
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error finding textbox: {ex.Message}");
                return null;
            }
        }

        private TextBox FindControlRecursive(Control parent, string name1, string name2)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Name == name1 || child.Name == name2)
                    return child as TextBox;

                if (child.HasChildren)
                {
                    var found = FindControlRecursive(child, name1, name2);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }

        private PictureBox GetPictureBoxFromGroupBox(int slot)
        {
            try
            {
                int groupBoxIndex = slot - 1;
                if (groupBoxIndex >= 0 && groupBoxIndex < _groupBoxes.Length)
                {
                    var groupBox = _groupBoxes[groupBoxIndex];
                    if (groupBox != null)
                    {
                        foreach (Control control in groupBox.Controls)
                        {
                            if (control.Name == $"pictureBox{slot}")
                                return control as PictureBox;
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private async void LoadSavedTeam()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string checkTeamQuery = "SELECT COUNT(*) FROM teams WHERE teamID = @teamID AND userID = @userID";
                    using (var checkCmd = new SqlCommand(checkTeamQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@teamID", _teamNumber);
                        checkCmd.Parameters.AddWithValue("@userID", _userId);
                        int teamExists = (int)await checkCmd.ExecuteScalarAsync();

                        if (teamExists == 0)
                        {
                            return;
                        }
                    }

                    string getTeamQuery = @"
                        SELECT pokemon1, pokemon2, pokemon3, pokemon4, pokemon5, pokemon6
                        FROM teams 
                        WHERE teamID = @teamID AND userID = @userID";

                    int[] customPokemonIds = new int[6];
                    using (var cmd = new SqlCommand(getTeamQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@teamID", _teamNumber);
                        cmd.Parameters.AddWithValue("@userID", _userId);

                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (await r.ReadAsync())
                            {
                                customPokemonIds[0] = r["pokemon1"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon1"]);
                                customPokemonIds[1] = r["pokemon2"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon2"]);
                                customPokemonIds[2] = r["pokemon3"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon3"]);
                                customPokemonIds[3] = r["pokemon4"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon4"]);
                                customPokemonIds[4] = r["pokemon5"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon5"]);
                                customPokemonIds[5] = r["pokemon6"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon6"]);
                            }
                        }
                    }

                    for (int slot = 1; slot <= 6; slot++)
                    {
                        int customPokemonId = customPokemonIds[slot - 1];
                        if (customPokemonId > 0)
                        {
                            await LoadCustomPokemon(slot, customPokemonId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading saved team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCustomPokemon(int slot, int customPokemonId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
                        SELECT pokedexID, nickname, item, ability, nature, 
                               move1, move2, move3, move4,
                               hp, atk, def, spatk, spdef, speed
                        FROM customPokemon 
                        WHERE pokemonID = @pokemonID";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@pokemonID", customPokemonId);

                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (await r.ReadAsync())
                            {
                                int pokedexId = Convert.ToInt32(r["pokedexID"]);
                                string nickname = r["nickname"].ToString();
                                string item = r["item"].ToString();
                                string ability = r["ability"].ToString();
                                string nature = r["nature"].ToString();
                                string move1 = r["move1"].ToString();
                                string move2 = r["move2"].ToString();
                                string move3 = r["move3"].ToString();
                                string move4 = r["move4"].ToString();

                                int hp = Convert.ToInt32(r["hp"]);
                                int atk = Convert.ToInt32(r["atk"]);
                                int def = Convert.ToInt32(r["def"]);
                                int spatk = Convert.ToInt32(r["spatk"]);
                                int spdef = Convert.ToInt32(r["spdef"]);
                                int speed = Convert.ToInt32(r["speed"]);

                                _selectedPokemon[slot - 1] = pokedexId;

                                await LoadPokemonBasicInfo(slot, pokedexId);

                                SetTextBoxValue(slot, "nickname", nickname);
                                SetComboSelectedValue(slot, "item", item);
                                SetComboSelectedValue(slot, "ability", ability);
                                SetComboSelectedValue(slot, "nature", nature);
                                SetComboSelectedValue(slot, "move1", move1);
                                SetComboSelectedValue(slot, "move2", move2);
                                SetComboSelectedValue(slot, "move3", move3);
                                SetComboSelectedValue(slot, "move4", move4);

                                SetTextBoxValue(slot, "hp", hp.ToString());
                                SetTextBoxValue(slot, "atk", atk.ToString());
                                SetTextBoxValue(slot, "def", def.ToString());
                                SetTextBoxValue(slot, "spatk", spatk.ToString());
                                SetTextBoxValue(slot, "spdef", spdef.ToString());
                                SetTextBoxValue(slot, "speed", speed.ToString());

                                System.Diagnostics.Debug.WriteLine($"Slot {slot}: Loaded {nickname} with EVs: HP={hp}, Atk={atk}, Def={def}, SpAtk={spatk}, SpDef={spdef}, Speed={speed}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Pokemon for slot {slot}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPokemonBasicInfo(int slot, int pokemonId)
        {
            try
            {
                string ability1 = "";
                string ability2 = "";
                string hidden = "";
                string pokemonName = "";

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new SqlCommand(
                        "SELECT * FROM pokemons WHERE pokedexID=@id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", pokemonId);

                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (await r.ReadAsync())
                            {
                                ability1 = r["ability1"].ToString();
                                ability2 = r["ability2"].ToString();
                                hidden = r["hiddenAbility"].ToString();
                                pokemonName = r["name"].ToString();
                            }
                        }
                    }
                }

                SetAbilitiesCombo(slot, new List<string> { ability1, ability2, hidden });

                string formattedName = char.ToUpper(pokemonName[0]) + pokemonName.Substring(1);
                int groupBoxIndex = slot - 1;
                if (groupBoxIndex >= 0 && groupBoxIndex < _groupBoxes.Length)
                {
                    var groupBox = _groupBoxes[groupBoxIndex];
                    if (groupBox != null)
                    {
                        groupBox.Text = $"#{pokemonId:D3} {formattedName}";
                    }
                }

                await LoadMoves(slot, pokemonId);
                await LoadSprite(slot, pokemonId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Pokemon info: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetTextBoxValue(int slot, string name, string value)
        {
            try
            {
                var tb = GetTextBoxFromGroupBox(slot, name);
                if (tb != null)
                {
                    tb.Text = value;
                    System.Diagnostics.Debug.WriteLine($"Set {name}{slot} to {value}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Could not find textbox {name}{slot}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting textbox: {ex.Message}");
            }
        }

        private void SetComboSelectedValue(int slot, string name, string value)
        {
            try
            {
                var cb = GetComboFromGroupBox(slot, name);
                if (cb != null && !string.IsNullOrEmpty(value))
                {
                    int index = cb.Items.IndexOf(value);
                    if (index >= 0)
                    {
                        cb.SelectedIndex = index;
                    }
                }
            }
            catch { }
        }

        private async void PictureBox_Click(object sender, EventArgs e)
        {
            if (!(sender is PictureBox pic)) return;

            int slot = (int)pic.Tag;
            int displaySlot = slot + 1;

            using (var picker = new PokemonPicker())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    _selectedPokemon[slot] = picker.SelectedPokemonId;

                    await LoadPokemonBasicInfo(displaySlot, picker.SelectedPokemonId);
                    ResetEVs(displaySlot);
                    SetTextBoxValue(displaySlot, "nickname", "");
                    SetItemsCombo(displaySlot);
                    SetNaturesCombo(displaySlot);
                }
            }
        }

        private void ResetEVs(int slot)
        {
            string[] statNames = { "hp", "atk", "def", "spatk", "spdef", "speed" };
            foreach (string stat in statNames)
            {
                SetTextBoxValue(slot, stat, "0");
            }
        }

        private void SetAbilitiesCombo(int slot, List<string> abilities)
        {
            try
            {
                var cb = GetComboFromGroupBox(slot, "ability");
                if (cb == null) return;

                cb.Items.Clear();
                foreach (var ability in abilities)
                {
                    if (!string.IsNullOrEmpty(ability))
                    {
                        string formatted = char.ToUpper(ability[0]) + ability.Substring(1);
                        cb.Items.Add(formatted);
                    }
                }
                if (cb.Items.Count > 0)
                    cb.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        private async Task LoadSprite(int slot, int pokemonId)
        {
            try
            {
                var poke = await _pokeApi.GetResourceAsync<PokeApiNet.Pokemon>(pokemonId);

                string spriteUrl = null;

                if (poke.Sprites?.Other?.OfficialArtwork?.FrontDefault != null)
                {
                    spriteUrl = poke.Sprites.Other.OfficialArtwork.FrontDefault;
                }
                else if (poke.Sprites?.FrontDefault != null)
                {
                    spriteUrl = poke.Sprites.FrontDefault;
                }

                if (!string.IsNullOrEmpty(spriteUrl))
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(30);
                        var imageBytes = await httpClient.GetByteArrayAsync(spriteUrl);

                        using (var ms = new MemoryStream(imageBytes))
                        {
                            var image = Image.FromStream(ms);
                            var pictureBox = GetPictureBoxFromGroupBox(slot);
                            if (pictureBox != null)
                            {
                                pictureBox.Image?.Dispose();
                                pictureBox.Image = image;
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sprite for Pokemon {pokemonId}: {ex.Message}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task LoadMoves(int slot, int pokemonId)
        {
            try
            {
                var moves = new List<string>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new SqlCommand(
                        @"SELECT m.name 
                          FROM pokemonMoves pm
                          INNER JOIN moves m ON pm.moveID = m.id
                          WHERE pm.pokemonID = @id
                          ORDER BY m.name",
                        connection))
                    {
                        cmd.Parameters.AddWithValue("@id", pokemonId);

                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            while (await r.ReadAsync())
                            {
                                string moveName = r["name"].ToString();
                                if (!string.IsNullOrEmpty(moveName))
                                {
                                    moveName = char.ToUpper(moveName[0]) + moveName.Substring(1);
                                    moves.Add(moveName);
                                }
                            }
                        }
                    }
                }

                if (moves.Count == 0)
                {
                    moves = await LoadMovesFromPokeApi(pokemonId);
                }

                SetMovesCombo(slot, moves);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading moves: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMovesCombo(int slot, List<string> moves)
        {
            try
            {
                for (int i = 1; i <= 4; i++)
                {
                    var cb = GetComboFromGroupBox(slot, $"move{i}");
                    if (cb == null) continue;

                    cb.Items.Clear();
                    foreach (var move in moves)
                    {
                        cb.Items.Add(move);
                    }
                    if (cb.Items.Count > 0)
                        cb.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }

        private async Task<List<string>> LoadMovesFromPokeApi(int pokemonId)
        {
            var moves = new List<string>();

            try
            {
                var poke = await _pokeApi.GetResourceAsync<PokeApiNet.Pokemon>(pokemonId);

                foreach (var moveEntry in poke.Moves)
                {
                    try
                    {
                        var move = await _pokeApi.GetResourceAsync(moveEntry.Move);
                        string moveName = char.ToUpper(move.Name[0]) + move.Name.Substring(1);
                        moves.Add(moveName);
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }

            return moves;
        }

        private string GetSelectedComboValue(int slot, string name)
        {
            try
            {
                var cb = GetComboFromGroupBox(slot, name);
                if (cb != null && cb.SelectedIndex >= 0)
                {
                    return cb.SelectedItem.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        private int GetTextBoxValue(int slot, string name)
        {
            try
            {
                var tb = GetTextBoxFromGroupBox(slot, name);
                if (tb != null)
                {
                    string text = tb.Text.Trim();
                    if (string.IsNullOrEmpty(text))
                    {
                        return 0;
                    }
                    if (int.TryParse(text, out int value))
                    {
                        return value;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Could not find textbox {name}{slot} for reading");
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private string GetTextBoxString(int slot, string name)
        {
            try
            {
                var tb = GetTextBoxFromGroupBox(slot, name);
                if (tb != null)
                {
                    return tb.Text;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        private async void SaveButton_Click_1(object sender, EventArgs e)
        {
            bool hasPokemon = false;
            List<int> filledSlots = new List<int>();
            for (int i = 0; i < _selectedPokemon.Length; i++)
            {
                if (_selectedPokemon[i] > 0)
                {
                    hasPokemon = true;
                    filledSlots.Add(i);
                }
            }

            if (!hasPokemon)
            {
                MessageBox.Show("Please select at least one Pokemon for your team.",
                    "No Pokemon Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (int slotIndex in filledSlots)
            {
                int slot = slotIndex + 1;
                string[] statNames = { "hp", "atk", "def", "spatk", "spdef", "speed" };
                int totalEVs = 0;
                bool hasInvalidEV = false;
                string invalidStats = "";

                foreach (string stat in statNames)
                {
                    int value = GetTextBoxValue(slot, stat);
                    if (value > 252)
                    {
                        hasInvalidEV = true;
                        invalidStats += $"{stat.ToUpper()} has {value} EVs (max 252)\n";
                    }
                    totalEVs += value;
                }

                if (hasInvalidEV)
                {
                    MessageBox.Show($"Invalid EV distribution for Pokemon in slot {slot}:\n\n{invalidStats}\nEach stat can have a maximum of 252 EVs.",
                        "EV Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (totalEVs > 508)
                {
                    MessageBox.Show($"Total EVs for Pokemon in slot {slot} is {totalEVs} (max 508).\n\nPlease reduce your EV spread.",
                        "EV Total Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var transaction = connection.BeginTransaction())
                    {
                        string checkTeamQuery = "SELECT COUNT(*) FROM teams WHERE teamID = @teamID AND userID = @userID";
                        using (var checkCmd = new SqlCommand(checkTeamQuery, connection, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@teamID", _teamNumber);
                            checkCmd.Parameters.AddWithValue("@userID", _userId);
                            int teamExists = (int)await checkCmd.ExecuteScalarAsync();

                            if (teamExists == 0)
                            {
                                string insertTeamQuery = @"
                                    INSERT INTO teams (teamID, userID, pokemon1, pokemon2, pokemon3, pokemon4, pokemon5, pokemon6)
                                    VALUES (@teamID, @userID, NULL, NULL, NULL, NULL, NULL, NULL)";

                                using (var insertCmd = new SqlCommand(insertTeamQuery, connection, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@teamID", _teamNumber);
                                    insertCmd.Parameters.AddWithValue("@userID", _userId);
                                    await insertCmd.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        int[] customPokemonIds = new int[6];

                        string getExistingQuery = @"
                            SELECT pokemon1, pokemon2, pokemon3, pokemon4, pokemon5, pokemon6
                            FROM teams 
                            WHERE teamID = @teamID AND userID = @userID";

                        using (var cmd = new SqlCommand(getExistingQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@teamID", _teamNumber);
                            cmd.Parameters.AddWithValue("@userID", _userId);

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                if (await r.ReadAsync())
                                {
                                    customPokemonIds[0] = r["pokemon1"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon1"]);
                                    customPokemonIds[1] = r["pokemon2"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon2"]);
                                    customPokemonIds[2] = r["pokemon3"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon3"]);
                                    customPokemonIds[3] = r["pokemon4"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon4"]);
                                    customPokemonIds[4] = r["pokemon5"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon5"]);
                                    customPokemonIds[5] = r["pokemon6"] == DBNull.Value ? 0 : Convert.ToInt32(r["pokemon6"]);
                                }
                            }
                        }

                        for (int slot = 1; slot <= 6; slot++)
                        {
                            if (_selectedPokemon[slot - 1] == 0)
                            {
                                if (customPokemonIds[slot - 1] > 0)
                                {
                                    string deleteQuery = "DELETE FROM customPokemon WHERE pokemonID = @pokemonID";
                                    using (var deleteCmd = new SqlCommand(deleteQuery, connection, transaction))
                                    {
                                        deleteCmd.Parameters.AddWithValue("@pokemonID", customPokemonIds[slot - 1]);
                                        await deleteCmd.ExecuteNonQueryAsync();
                                    }
                                    customPokemonIds[slot - 1] = 0;
                                }
                                continue;
                            }

                            string groupBoxName = _groupBoxes[slot - 1].Text;
                            string defaultName = groupBoxName.Contains(" ") ? groupBoxName.Substring(groupBoxName.IndexOf(" ") + 1) : groupBoxName;

                            string nickname = GetTextBoxString(slot, "nickname");
                            if (string.IsNullOrWhiteSpace(nickname))
                            {
                                nickname = defaultName;
                            }

                            string item = GetSelectedComboValue(slot, "item");
                            string ability = GetSelectedComboValue(slot, "ability");
                            string nature = GetSelectedComboValue(slot, "nature");
                            string move1 = GetSelectedComboValue(slot, "move1");
                            string move2 = GetSelectedComboValue(slot, "move2");
                            string move3 = GetSelectedComboValue(slot, "move3");
                            string move4 = GetSelectedComboValue(slot, "move4");

                            int hp = GetTextBoxValue(slot, "hp");
                            int atk = GetTextBoxValue(slot, "atk");
                            int def = GetTextBoxValue(slot, "def");
                            int spatk = GetTextBoxValue(slot, "spatk");
                            int spdef = GetTextBoxValue(slot, "spdef");
                            int speed = GetTextBoxValue(slot, "speed");

                            System.Diagnostics.Debug.WriteLine($"Slot {slot}: Saving {nickname} with EVs: HP={hp}, Atk={atk}, Def={def}, SpAtk={spatk}, SpDef={spdef}, Speed={speed}");

                            if (customPokemonIds[slot - 1] > 0)
                            {
                                string updateQuery = @"
                                    UPDATE customPokemon 
                                    SET 
                                        pokedexID = @pokedexID,
                                        nickname = @nickname,
                                        item = @item,
                                        ability = @ability,
                                        nature = @nature,
                                        move1 = @move1,
                                        move2 = @move2,
                                        move3 = @move3,
                                        move4 = @move4,
                                        hp = @hp,
                                        atk = @atk,
                                        def = @def,
                                        spatk = @spatk,
                                        spdef = @spdef,
                                        speed = @speed
                                    WHERE pokemonID = @pokemonID";

                                using (var updateCmd = new SqlCommand(updateQuery, connection, transaction))
                                {
                                    updateCmd.Parameters.AddWithValue("@pokemonID", customPokemonIds[slot - 1]);
                                    updateCmd.Parameters.AddWithValue("@pokedexID", _selectedPokemon[slot - 1]);
                                    updateCmd.Parameters.AddWithValue("@nickname", nickname);
                                    updateCmd.Parameters.AddWithValue("@item", string.IsNullOrEmpty(item) ? (object)DBNull.Value : item);
                                    updateCmd.Parameters.AddWithValue("@ability", string.IsNullOrEmpty(ability) ? (object)DBNull.Value : ability);
                                    updateCmd.Parameters.AddWithValue("@nature", string.IsNullOrEmpty(nature) ? (object)DBNull.Value : nature);
                                    updateCmd.Parameters.AddWithValue("@move1", string.IsNullOrEmpty(move1) ? (object)DBNull.Value : move1);
                                    updateCmd.Parameters.AddWithValue("@move2", string.IsNullOrEmpty(move2) ? (object)DBNull.Value : move2);
                                    updateCmd.Parameters.AddWithValue("@move3", string.IsNullOrEmpty(move3) ? (object)DBNull.Value : move3);
                                    updateCmd.Parameters.AddWithValue("@move4", string.IsNullOrEmpty(move4) ? (object)DBNull.Value : move4);
                                    updateCmd.Parameters.AddWithValue("@hp", hp);
                                    updateCmd.Parameters.AddWithValue("@atk", atk);
                                    updateCmd.Parameters.AddWithValue("@def", def);
                                    updateCmd.Parameters.AddWithValue("@spatk", spatk);
                                    updateCmd.Parameters.AddWithValue("@spdef", spdef);
                                    updateCmd.Parameters.AddWithValue("@speed", speed);

                                    await updateCmd.ExecuteNonQueryAsync();
                                }
                            }
                            else
                            {
                                string insertQuery = @"
                                    INSERT INTO customPokemon 
                                    (pokedexID, teamID, nickname, item, ability, nature, 
                                     move1, move2, move3, move4, 
                                     hp, atk, def, spatk, spdef, speed)
                                    VALUES 
                                    (@pokedexID, @teamID, @nickname, @item, @ability, @nature,
                                     @move1, @move2, @move3, @move4,
                                     @hp, @atk, @def, @spatk, @spdef, @speed);
                                    SELECT SCOPE_IDENTITY();";

                                using (var insertCmd = new SqlCommand(insertQuery, connection, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@pokedexID", _selectedPokemon[slot - 1]);
                                    insertCmd.Parameters.AddWithValue("@teamID", _teamNumber);
                                    insertCmd.Parameters.AddWithValue("@nickname", nickname);
                                    insertCmd.Parameters.AddWithValue("@item", string.IsNullOrEmpty(item) ? (object)DBNull.Value : item);
                                    insertCmd.Parameters.AddWithValue("@ability", string.IsNullOrEmpty(ability) ? (object)DBNull.Value : ability);
                                    insertCmd.Parameters.AddWithValue("@nature", string.IsNullOrEmpty(nature) ? (object)DBNull.Value : nature);
                                    insertCmd.Parameters.AddWithValue("@move1", string.IsNullOrEmpty(move1) ? (object)DBNull.Value : move1);
                                    insertCmd.Parameters.AddWithValue("@move2", string.IsNullOrEmpty(move2) ? (object)DBNull.Value : move2);
                                    insertCmd.Parameters.AddWithValue("@move3", string.IsNullOrEmpty(move3) ? (object)DBNull.Value : move3);
                                    insertCmd.Parameters.AddWithValue("@move4", string.IsNullOrEmpty(move4) ? (object)DBNull.Value : move4);
                                    insertCmd.Parameters.AddWithValue("@hp", hp);
                                    insertCmd.Parameters.AddWithValue("@atk", atk);
                                    insertCmd.Parameters.AddWithValue("@def", def);
                                    insertCmd.Parameters.AddWithValue("@spatk", spatk);
                                    insertCmd.Parameters.AddWithValue("@spdef", spdef);
                                    insertCmd.Parameters.AddWithValue("@speed", speed);

                                    var result = await insertCmd.ExecuteScalarAsync();
                                    customPokemonIds[slot - 1] = Convert.ToInt32(result);
                                }
                            }
                        }

                        string updateTeamsQuery = @"
                            UPDATE teams 
                            SET 
                                pokemon1 = @pokemon1,
                                pokemon2 = @pokemon2,
                                pokemon3 = @pokemon3,
                                pokemon4 = @pokemon4,
                                pokemon5 = @pokemon5,
                                pokemon6 = @pokemon6
                            WHERE teamID = @teamID AND userID = @userID";

                        using (var cmd = new SqlCommand(updateTeamsQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@teamID", _teamNumber);
                            cmd.Parameters.AddWithValue("@userID", _userId);
                            cmd.Parameters.AddWithValue("@pokemon1", customPokemonIds[0] == 0 ? (object)DBNull.Value : customPokemonIds[0]);
                            cmd.Parameters.AddWithValue("@pokemon2", customPokemonIds[1] == 0 ? (object)DBNull.Value : customPokemonIds[1]);
                            cmd.Parameters.AddWithValue("@pokemon3", customPokemonIds[2] == 0 ? (object)DBNull.Value : customPokemonIds[2]);
                            cmd.Parameters.AddWithValue("@pokemon4", customPokemonIds[3] == 0 ? (object)DBNull.Value : customPokemonIds[3]);
                            cmd.Parameters.AddWithValue("@pokemon5", customPokemonIds[4] == 0 ? (object)DBNull.Value : customPokemonIds[4]);
                            cmd.Parameters.AddWithValue("@pokemon6", customPokemonIds[5] == 0 ? (object)DBNull.Value : customPokemonIds[5]);

                            await cmd.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show($"Team #{_teamNumber} saved successfully!\n\n{filledSlots.Count} Pokemon(s) have been saved.",
                    "Team Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}