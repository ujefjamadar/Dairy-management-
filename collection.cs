
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
    public partial class collection : Form
    {
        public collection()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("");
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


        private void txtid_TextChanged(object sender, EventArgs e)
        {
              openconnection();
            try
            {
                string selectquery = "select cust_name,cattle from dairy_db.customer where cust_id=" + txtid.Text;
                cmd = new SqlCommand(selectquery, connection);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtnm.Text = dr[0].ToString();
                    textBox4.Text = dr[1].ToString();
                }
                else
                {

                }
                dr.Close();
                if (textBox4.Text == "cow")
                {
                    radioButton1.Checked = true;

                }
                else
                {
                    radioButton2.Checked = true;
                }
                dr.Close();
            }
            catch (Exception ex)
            {

            }
            closeconnection();
            clear();
        }
        public void griddis()
        {
            openconnection();
            String selectquery = "Select cust_id,cust_name,cattle,liter,fat,rate,total from collection where c_date= '" + dateTimePicker1.Value.ToString() + "' && section='" + textBox5.Text + "'";
            cmd = new SqlCommand(selectquery, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            gdviewofcollection.DataSource = dt;
            closeconnection();
            ad.Dispose();
        }
        public void clear()
        {
            if (txtid.Text == "")
            {
                txtnm.Text = "";
                textBox4.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;

            }
        }

        private void collection_Load(object sender, EventArgs e)
        {
            textBox4.Visible = false;

            textBox5.Visible = false;
            griddis();

        }
         
        private void btnsave_Click(object sender, EventArgs e)
        {
            

            if (textBox5.Text == "")
            {
                MessageBox.Show("Please Select Section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtid.Text == "")
                {
                    MessageBox.Show("Please enter Customer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (txtnm.Text == "")
            {
                MessageBox.Show("Please enter Name..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Select Cattel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtltr.Text == "")
            {
                MessageBox.Show("Please Enter Liter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            if (txtfat.Text == "")
            {
                MessageBox.Show("Please enter Fat..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtrate.Text == "")
            {
                MessageBox.Show("Please enter rate..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter Total..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }





            connection.Open();
            String insertquery = "INSERT INTO collection(cust_id,cust_name,cattle,liter,fat,rate,total,c_date,section)Values('" + Convert.ToInt32(this.txtid.Text) + "','" + this.txtnm.Text + "','" + this.textBox4.Text + "','" + Convert.ToDouble(this.txtltr.Text) + "','" + Convert.ToDouble(this.txtfat.Text) + "','" + Convert.ToDouble(this.txtrate.Text) + "','" + Convert.ToDouble(textBox2.Text) + "','" + dateTimePicker1.Value.ToString() + "','" + this.textBox5.Text + "')";

            executeQuery(insertquery);
            MessageBox.Show("Information Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //string instqry = "INSERT INTO dairy_db.total_collection(cow,buffalo,tc_date,section) values('" + Convert.ToDouble(textBox1.Text) + "','"+Convert.ToDouble(txtbuflo.Text)+ "', '"+dateTimePicker1.Value.ToString() +"','"+textBox5.Text+"' )";
            //executeQuery(instqry);
            connection.Close();
            griddis();
            cleartexbox();
        }

        private void txtfat_TextChanged(object sender, EventArgs e)
        {
            openconnection();
            try
            {


                string selctqry = "select rate from dairy_db.set_fat_rate where fat= " + Convert.ToDouble(txtfat.Text);
                cmd = new SqlCommand(selctqry, connection);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    txtrate.Text = dr[0].ToString();

                }
                dr.Close();
            }
            catch (Exception w)
            {

            }
            closeconnection();
            if (txtfat.Text == "")
            {
                txtrate.Text = "";
                textBox2.Text = "";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            griddis();
            //griddis();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            griddis();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtid.Text=="")

            {
                
                    MessageBox.Show("Can't Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                
            }
            
        
                        
            String upquery = "update dairy_db.collection set liter='" + txtltr.Text + "',fat='" + txtfat.Text + "',rate='" + txtrate.Text + "',total='" +textBox2.Text + "' where cust_id='" + txtid.Text + "'";
            MessageBox.Show("customer deatails updated succsesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            executeQuery(upquery);
            cleartexbox();
            griddis();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")

            {

                MessageBox.Show("Please Enter Customer ID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            String deletquery = "delete from dairy_db.collection where cust_id='" + txtid.Text + "'";
            executeQuery(deletquery);
            MessageBox.Show("customer deatails deleted succsesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cleartexbox();
            griddis();
        }
        public void cleartexbox()
        {
            txtid.Text = "";
            txtnm.Text = "";
            textBox4.Text = "";
            txtltr.Text = "";
            txtfat.Text = "";
            txtrate.Text = "";
            textBox2.Text = "";



        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {

            try
            {
                textBox2.Text = (Convert.ToDouble(txtltr.Text) * Convert.ToDouble(txtrate.Text)).ToString();
            }
            catch
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Morning";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "Evening";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            griddis();
        }

        private void txtltr_TextChanged(object sender, EventArgs e)
        {
            clr();

        }
        public void clr()
        {
            if(txtltr.Text=="")
            {
                textBox2.Text = "";
                txtfat.Text = "";
                txtrate.Text = "";
            }
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtid.Text))
                {
                    txtltr.Focus();
                }

            }
        }

        private void txtltr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtid.Text))
                {
                    txtfat.Focus();
                }

            }
        }

        private void txtfat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtid.Text))
                {
                    btnsave.Focus();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        openconnection();
        string selectquery = "select cust_name,cattle,liter,fat,rate,total from dairy_db.collection where cust_id=" + txtsrch.Text;
        cmd = new SqlCommand(selectquery, connection);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        gdviewofcollection.DataSource = dt;
        closeconnection();
        }
    }

}
