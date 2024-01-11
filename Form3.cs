using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dairyproject
{
    public partial class addcust : Form
    {

        public addcust()
        {
            InitializeComponent();

        }
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\new dry\dairyproject\Dairyproject\Database1.mdf;Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        
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
                cmd = new SqlCommand(query, connection);
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
           // custview c = new custview();
           // c.ShowDialog();
        }

        private void addcust_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            griddis();
            srchdata();
        }
        public void griddis()
        {
            openconnection();
            String selectquery = "select * from dairy_db.customer";
            cmd = new SqlCommand(selectquery, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            gdcustomer.DataSource = dt;
            closeconnection();
        }

        public void cleartexbox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void btninsert_Click(object sender, EventArgs e)
        {

            if (textBox1.Text=="")
            {
                MessageBox.Show("Please enter Cutomer ID..", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter Name..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Select Cattle..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter Mobile  Number..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string insertquery = "INSERT INTO dairy_db.customer(cust_id,cust_name,cust_mob,cattle)values('" + Convert.ToInt32(this.textBox1.Text) + "','" + this.textBox2.Text + "','" + Convert.ToDouble(this.textBox4.Text) + "','" + textBox3.Text + "' )";

            executeQuery(insertquery);
            MessageBox.Show("customer added succsesfully"," ",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            //  MessageBox.Show("Record Inserted Successfully...");

            griddis();
            cleartexbox();
        }

        private void btnup_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Can't Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            String upquery = "update dairy_db.customer set cust_name='" + textBox2.Text + "',cust_mob='" + textBox4.Text + "' where cust_id='" + textBox1.Text + "'";
            MessageBox.Show("customer deatails updated succsesfully");
            executeQuery(upquery);
            cleartexbox();
            griddis();
        }

        private void btndel_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Cutomer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String deletquery = "delete from dairy_db.customer where cust_id='" + textBox1.Text + "'";
            executeQuery(deletquery);
            MessageBox.Show("customer deatails deleted succsesfully");
            cleartexbox();
            griddis();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox3.Text = "cow";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox3.Text = "Buffalo";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openconnection();
            string selectquery = "select * from dairy_db.customer where cust_id='" + textBox5.Text + "'";
            cmd = new SqlCommand(selectquery, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            gdcustomer.DataSource = dt;
            closeconnection();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public void srchdata()
        {
 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            srchdata();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gdcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
