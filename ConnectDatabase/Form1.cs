using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConnectDatabase
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String source = "server=localhost;user id=root;database=hellodata";
            MySqlConnection con = new MySqlConnection(source);
            con.Open();
            MessageBox.Show("DB Connected");
            string selectQuery = "SELECT * FROM persons WHERE Personid=" + int.Parse(textBox4.Text);
            MySqlCommand command = new MySqlCommand(selectQuery, con);
            MySqlDataReader mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox3.Text = mdr.GetString("FirstName");
                textBox2.Text = mdr.GetString("LastName");
                textBox1.Text = mdr.GetInt32("Age").ToString();
            }
            else
            {
                MessageBox.Show("No Data For The Id" + int.Parse(textBox4.Text));
                textBox4.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
              
            }
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
