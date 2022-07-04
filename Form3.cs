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
    public partial class Form3 : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;password=tiger;";
        OracleConnection conn;
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select PIN_DATA, PIN_DESCRIPTION, USERID from PINS where PIN_ID=:id";
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
            }
            dr.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select PIN_ID from PINS";

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();

            

        }

        private void Form3_Closing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //el goz2 bta3 el procedure ely na2s
            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;
            string  name;
            c2.CommandText = "GETBOARDID";
            c2.CommandType = CommandType.StoredProcedure;
            c2.Parameters.Add("BID", textBox7.Text);
            c2.Parameters.Add("BN", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
            c2.ExecuteNonQuery();
            name = Convert.ToString(c2.Parameters["BN"].Value);

            if (name != "null")
            {
                textBox8.Text = name.ToString();
                MessageBox.Show("Found");
            }
            else
            {
                textBox8.Text = ""; 
                MessageBox.Show("Not Found!!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "GETBOARDROWS";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("bid", textBox4.Text);
            c.Parameters.Add("CID", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = c.ExecuteReader();
            bool isFound = false;
            comboBox2.Items.Clear();
            while (dr.Read())
            {
                isFound = true;
                comboBox2.Items.Add(dr[0]);
            }
            if (isFound)
                 MessageBox.Show("Pins Added");
            else
               MessageBox.Show("This ID doesn't Exist or user doesn't have pins ;(");
                                
                dr.Close();           
        }
    }
}
