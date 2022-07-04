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
    public partial class Form1 : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;password=tiger;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;
            c2.CommandText = "select Max(USER_ID) from PINTEREST_USER";
            OracleDataReader dr = c2.ExecuteReader();
           // MessageBox.Show("Bell");

            int id = 0;
            if (dr.Read())
               id = Convert.ToInt32(dr[0].ToString()) + 1;

           // MessageBox.Show("Bell");
            MessageBox.Show("Your id: "+ id.ToString());
            c.Connection = conn;
            c.CommandText = "insert into PINTEREST_USER values(:id,:uname, :email, :fname, :utype, :age, :pass)";
            c.Parameters.Add("id", id);
            c.Parameters.Add("uname", textBox5.Text);
            c.Parameters.Add("email", textBox6.Text);
            c.Parameters.Add("fname", textBox7.Text);
            c.Parameters.Add("utype", textBox8.Text);
            c.Parameters.Add("age", textBox9.Text);
            c.Parameters.Add("pass", textBox1.Text);

            if (
                textBox5.Text.ToString() == "" ||
                textBox6.Text.ToString() == "" ||
                textBox7.Text.ToString() == "" ||
                textBox8.Text.ToString() == "" ||
                textBox9.Text.ToString() == "" ||
                textBox1.Text.ToString() == "" 
                )
            {
                MessageBox.Show("there is an empty field, fill it first");
            }
            else
            {
                
                bool flag = true;
                if (flag)
                {
                    int r = c.ExecuteNonQuery();
                    if (r != -1)   
                        MessageBox.Show("user id added");
                }
            }
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox1.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
