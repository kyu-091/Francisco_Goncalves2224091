using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokeApiNet;

namespace kyusAPTB
{
    public partial class TeamBuilder : Form
    {
        private readonly string _connectionString = @"Server=kyu-laptop\;Database=kyusAPTB;Trusted_Connection=True";
        private readonly PokeApiClient _pokeApi = new PokeApiClient();
        private readonly int _userId;

        private readonly PictureBox[][] _teamPictureBoxes;

        public TeamBuilder()
        {
            InitializeComponent();

            _userId = Session.CurrentUser?.UserID ?? 1;

            _teamPictureBoxes = new PictureBox[][]
            {
                new PictureBox[] { pokemon11, pokemon12, pokemon13, pokemon14, pokemon15, pokemon16 },
                new PictureBox[] { pokemon21, pokemon22, pokemon23, pokemon24, pokemon25, pokemon26 },
                new PictureBox[] { pokemon31, pokemon32, pokemon33, pokemon34, pokemon35, pokemon36 }
            };

            LoadAllTeams();
        }

        private async void LoadAllTeams()
        {
            for (int teamId = 1; teamId <= 3; teamId++)
            {
                await LoadTeam(teamId);
            }
        }

        private async Task LoadTeam(int teamNumber)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string checkTeamQuery = "SELECT COUNT(*) FROM teams WHERE teamID = @teamID AND userID = @userID";
                    using (var checkCmd = new SqlCommand(checkTeamQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@teamID", teamNumber);
                        checkCmd.Parameters.AddWithValue("@userID", _userId);
                        int teamExists = (int)await checkCmd.ExecuteScalarAsync();

                        int idx = teamNumber - 1;
                        if (teamExists == 0)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                _teamPictureBoxes[idx][i].Image = null;
                            }
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
                        cmd.Parameters.AddWithValue("@teamID", teamNumber);
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

                    int teamIdx = teamNumber - 1;
                    for (int slot = 0; slot < 6; slot++)
                    {
                        int customPokemonId = customPokemonIds[slot];
                        if (customPokemonId > 0)
                        {
                            await LoadPokemonSprite(teamIdx, slot, customPokemonId);
                        }
                        else
                        {
                            _teamPictureBoxes[teamIdx][slot].Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading team {teamNumber}: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPokemonSprite(int teamIndex, int slotIndex, int customPokemonId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT pokedexID FROM customPokemon WHERE pokemonID = @pokemonID";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@pokemonID", customPokemonId);
                        var result = await cmd.ExecuteScalarAsync();

                        if (result != null)
                        {
                            int pokedexId = Convert.ToInt32(result);
                            await LoadSprite(_teamPictureBoxes[teamIndex][slotIndex], pokedexId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading Pokemon sprite: {ex.Message}");
            }
        }

        private async Task LoadSprite(PictureBox pictureBox, int pokemonId)
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

                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            var image = Image.FromStream(ms);

                            if (pictureBox.InvokeRequired)
                            {
                                pictureBox.Invoke(new Action(() =>
                                {
                                    pictureBox.Image?.Dispose();
                                    pictureBox.Image = image;
                                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                }));
                            }
                            else
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
                System.Diagnostics.Debug.WriteLine($"Error loading sprite for Pokemon {pokemonId}: {ex.Message}");
            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int teamNumber = 0;

            if (btn == editButton1)
                teamNumber = 1;
            else if (btn == editButton2)
                teamNumber = 2;
            else if (btn == editButton3)
                teamNumber = 3;

            if (teamNumber > 0)
            {
                using (NewTeam newTeam = new NewTeam(teamNumber))
                {
                    newTeam.Region = this.Region;
                    var result = newTeam.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        await LoadTeam(teamNumber);
                    }
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int teamNumber = 0;

            if (btn == deleteButton1)
                teamNumber = 1;
            else if (btn == deleteButton2)
                teamNumber = 2;
            else if (btn == deleteButton3)
                teamNumber = 3;

            if (teamNumber > 0)
            {
                var result = MessageBox.Show($"Are you sure you want to delete Team {teamNumber}?\n\nAll Pokemon in this team will be permanently removed.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    await DeleteTeam(teamNumber);
                }
            }
        }

        private async Task DeleteTeam(int teamNumber)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var transaction = connection.BeginTransaction())
                    {
                        string getIdsQuery = @"
                            SELECT pokemon1, pokemon2, pokemon3, pokemon4, pokemon5, pokemon6
                            FROM teams 
                            WHERE teamID = @teamID AND userID = @userID";

                        int[] customPokemonIds = new int[6];
                        using (var cmd = new SqlCommand(getIdsQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@teamID", teamNumber);
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

                        string updateTeamQuery = @"
                            UPDATE teams 
                            SET 
                                pokemon1 = NULL,
                                pokemon2 = NULL,
                                pokemon3 = NULL,
                                pokemon4 = NULL,
                                pokemon5 = NULL,
                                pokemon6 = NULL
                            WHERE teamID = @teamID AND userID = @userID";

                        using (var updateCmd = new SqlCommand(updateTeamQuery, connection, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@teamID", teamNumber);
                            updateCmd.Parameters.AddWithValue("@userID", _userId);
                            await updateCmd.ExecuteNonQueryAsync();
                        }

                        foreach (int id in customPokemonIds)
                        {
                            if (id > 0)
                            {
                                string deletePokemonQuery = "DELETE FROM customPokemon WHERE pokemonID = @pokemonID";
                                using (var deleteCmd = new SqlCommand(deletePokemonQuery, connection, transaction))
                                {
                                    deleteCmd.Parameters.AddWithValue("@pokemonID", id);
                                    await deleteCmd.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        string deleteTeamQuery = "DELETE FROM teams WHERE teamID = @teamID AND userID = @userID";
                        using (var deleteCmd = new SqlCommand(deleteTeamQuery, connection, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@teamID", teamNumber);
                            deleteCmd.Parameters.AddWithValue("@userID", _userId);
                            await deleteCmd.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                    }
                }

                int teamIdx = teamNumber - 1;
                for (int i = 0; i < 6; i++)
                {
                    if (_teamPictureBoxes[teamIdx][i].Image != null)
                    {
                        _teamPictureBoxes[teamIdx][i].Image.Dispose();
                        _teamPictureBoxes[teamIdx][i].Image = null;
                    }
                }

                MessageBox.Show($"Team {teamNumber} deleted successfully.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PokedexButton_Click(object sender, EventArgs e)
        {
            Pokedex temp = new Pokedex();
            temp.Region = this.Region;
            temp.Show();
            this.Hide();
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

        private void TeamBuilder_Load(object sender, EventArgs e)
        {
        }
    }
}