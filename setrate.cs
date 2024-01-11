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
namespace Dairyproject
{
    public partial class setrate : Form
    {
        public setrate()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
        MySqlCommand cmd = new MySqlCommand();

        public void openconnection()
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();

            }
        }
        public void closeconnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();

            }
        }
        public void executeQuery(String query)
        {
            try
            {
                openconnection();
                cmd = new MySqlCommand(query, connection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //  MessageBox.Show("Query Executed");
                }
                else
                {
                    // MessageBox.Show("Query Not Executed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeconnection();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void setrate_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox3.Text=="")
            {
                MessageBox.Show("Please Select Cattle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text=="")
            {
                MessageBox.Show("Please Enter Fat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            string insertquery = "INSERT INTO dairy_db.set_fat_rate(fat,rate,cattle)values('" + Convert.ToDouble(this.textBox1.Text) + "','" +Convert.ToDouble(this.textBox2.Text )+ "','"+textBox3.Text+"' )";

            executeQuery(insertquery);
            MessageBox.Show("record added");
            cleartextbox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Can't Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String upquery = "update dairy_db.set_fat_rate set rate='" + Convert.ToInt32(textBox2.Text) + "' where fat=" + textBox1.Text;
            MessageBox.Show("Rate Updated","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            executeQuery(upquery);
            cleartextbox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "cow";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "buffalo";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String deletquery = "delete from dairy_db.set_fat_rate where fat='" + textBox1.Text + "'";
            executeQuery(deletquery);
            MessageBox.Show("record deleted");
            cleartextbox();


        }
        public void cleartextbox()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox2.Focus();
                }

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    button1.Focus();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
