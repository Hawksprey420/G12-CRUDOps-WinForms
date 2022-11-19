using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LogInForm
{
    public partial class LogInPage : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public LogInPage()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Hawkspreyy\Desktop\Database.mdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Users where Username='" + textBoxUsername.Text + "'and Password='" + textBoxPassword.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }

            if (count == 1)
            {
                this.Hide();
                Dashboard dash = new
                    Dashboard();
                dash.ShowDialog();  
            }

            else
            {
                MessageBox.Show("all incorrect");
            }

            connection.Close();
        }
    }
}
