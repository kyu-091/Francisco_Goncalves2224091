using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kyusAPTB
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server = kyu-laptop\\; Database = kyusAPTB; Trusted_Connection = True");
                conn.Open();

                SqlCommand logIn = new SqlCommand(
                "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password", conn);

                logIn.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = user.Text;
                logIn.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = pass.Text;

                int count = (int)logIn.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Login successful! Welcome, " + user.Text + "!");

                    SqlCommand getInfo = new SqlCommand("SELECT userID, username, password FROM users WHERE username = @username", conn);
                    getInfo.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = user.Text;

                    SqlDataReader reader = getInfo.ExecuteReader();

                    if (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string password = reader.GetString(2);

                        Session.CurrentUser = new UserInfo(userID, username, password);

                        Home temp = new Home();
                        temp.Region = this.Region;
                        temp.Show();
                        this.Hide();
                    }

                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your username and password.");
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Database error: " + sqlex.Message);
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server = kyu-laptop\\; Database = kyusAPTB; Trusted_Connection = True");
                conn.Open();

                SqlCommand signUp = new SqlCommand(
                "INSERT INTO users (username, password) VALUES (@username, @password)", conn);

                if (string.IsNullOrWhiteSpace(user.Text) || string.IsNullOrWhiteSpace(pass.Text))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }

                signUp.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = user.Text;
                signUp.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = pass.Text;

                int rowsAffected = signUp.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sign-up successful! Welcome, " + user.Text + "!");
                }

                conn.Close();
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2627 || sqlex.Number == 2601)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                }
                else
                {
                    MessageBox.Show("Database error: " + sqlex.Message);
                }
            }
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}