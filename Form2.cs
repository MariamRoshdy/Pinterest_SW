using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SW
{
    public partial class Form2 : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;password=tiger;";
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;
            c2.CommandText = "select USERNAME, User_passworf from PINTEREST_USER";
            OracleDataReader dr = c2.ExecuteReader();
            if (textBox1.Text.ToString() == "" || textBox2.Text.ToString() == "")
            {
                MessageBox.Show("there is an field empty, fill it first");
            }
            else
            {
                bool isFound = false;
                while (dr.Read())
                {

                    if (dr[0].ToString() == textBox1.Text.ToString() && dr[1].ToString() == textBox2.Text.ToString())
                    { 
                        MessageBox.Show("User Found");
                        isFound = true;
                    }
                }
                if (isFound)
                {
                    this.Hide();
                    Form3 form = new Form3();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("User Not Found.....try again");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }
    }
}
