using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kyusAPTB
{
    public partial class PokemonPicker : Form
    {
        private PokeApiClient _pokeClient;
        private List<NamedApiResource<Pokemon>> _fullPokemonList;
        private List<NamedApiResource<Pokemon>> _currentDisplayList;
        public int SelectedPokemonId { get; private set; }

        public PokemonPicker()
        {
            InitializeComponent();
            _pokeClient = new PokeApiClient();
            LoadPokemonList();
        }

        private async void LoadPokemonList()
        {
            try
            {
                var pokemonPage = await _pokeClient.GetNamedResourcePageAsync<Pokemon>(151, 0);
                _fullPokemonList = pokemonPage.Results.Take(151).ToList();
                _currentDisplayList = _fullPokemonList;

                listBox1.Items.Clear();

                for (int i = 0; i < _fullPokemonList.Count; i++)
                {
                    int id = i + 1;
                    string name = _fullPokemonList[i].Name;
                    name = char.ToUpper(name[0]) + name.Substring(1);
                    listBox1.Items.Add($"#{id:D3} {name}");
                }

                if (listBox1.Items.Count > 0)
                    listBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Pokemon: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && _currentDisplayList != null)
            {
                var selectedPokemon = _currentDisplayList[listBox1.SelectedIndex];
                SelectedPokemonId = _fullPokemonList.FindIndex(p => p.Name == selectedPokemon.Name) + 1;
            }
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && _currentDisplayList != null)
            {
                var selectedPokemon = _currentDisplayList[listBox1.SelectedIndex];
                SelectedPokemonId = _fullPokemonList.FindIndex(p => p.Name == selectedPokemon.Name) + 1;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a Pokemon from the list.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click_1(sender, e);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                _currentDisplayList = _fullPokemonList;
            }
            else
            {
                _currentDisplayList = _fullPokemonList
                    .Where(p => p.Name.Contains(searchTerm))
                    .ToList();
            }

            listBox1.Items.Clear();
            foreach (var pokemon in _currentDisplayList)
            {
                int id = _fullPokemonList.FindIndex(p => p.Name == pokemon.Name) + 1;
                string name = char.ToUpper(pokemon.Name[0]) + pokemon.Name.Substring(1);
                listBox1.Items.Add($"#{id:D3} {name}");
            }

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void PokemonPicker_Load(object sender, EventArgs e)
        {
        }
    }
}