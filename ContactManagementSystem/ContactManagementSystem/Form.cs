using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ContactManagementSystem
{
    public partial class Form1 : Form
    {
        string connStr = "Server=localhost;Database=ContactDB;Uid=root;Pwd=;";
        int selectedId = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void LoadContacts()
        {
            listContacts.Items.Clear();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT Id, Name, Email, Phone FROM Contacts;";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listContacts.Items.Add(
                            dr["Id"] + " | " +
                            dr["Name"] + " — " +
                            dr["Email"] + " — " +
                            dr["Phone"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "")
            {
                lblStatus.Text = "Please fill in all fields.";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                return;
            }
            try
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "INSERT INTO Contacts (Name, Email, Phone) VALUES (@Name, @Email, @Phone);";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.ExecuteNonQuery();
                }
                lblStatus.Text = "Contact added!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                ClearFields();
                LoadContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding: " + ex.Message);
            }
        }

        private void listContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listContacts.SelectedItem == null) return;
            string selected = listContacts.SelectedItem.ToString();
            string[] parts = selected.Split('|');
            selectedId = int.Parse(parts[0].Trim());
            try
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT * FROM Contacts WHERE Id=@Id;";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Id", selectedId);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtName.Text = dr["Name"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtPhone.Text = dr["Phone"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                lblStatus.Text = "Please select a contact to update.";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                return;
            }
            try
            {
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string sql = "UPDATE Contacts SET Name=@Name, Email=@Email, Phone=@Phone WHERE Id=@Id;";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Id", selectedId);
                    cmd.ExecuteNonQuery();
                }
                lblStatus.Text = "Contact updated!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                ClearFields();
                LoadContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                lblStatus.Text = "Please select a contact to delete.";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                return;
            }
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this contact?",
                "Confirm Delete",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connStr))
                    {
                        con.Open();
                        string sql = "DELETE FROM Contacts WHERE Id=@Id;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@Id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                    lblStatus.Text = "Contact deleted!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    ClearFields();
                    LoadContacts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            selectedId = -1;
            lblStatus.Text = "";
        }
    }
}