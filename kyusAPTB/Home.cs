using System;
using System.Windows.Forms;

namespace kyusAPTB
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void PokedexButton_Click(object sender, EventArgs e)
        {
            Pokedex temp = new Pokedex();
            temp.Region = this.Region;
            temp.Show();
            this.Hide();
        }

        private void TeamBuilderButton_Click(object sender, EventArgs e)
        {
            TeamBuilder temp = new TeamBuilder();
            temp.Region = this.Region;
            temp.Show();
            this.Hide();
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
        }
    }
}