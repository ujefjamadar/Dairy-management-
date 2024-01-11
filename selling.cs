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
    public partial class selling : Form
    {
        public selling()
        {
            InitializeComponent();
            this.ActiveControl = txtid;
            txtid.Focus();
        }
        SqlConnection connection = new SqlConnection("datasource=localhost;port=3306;username=root;password=root");
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


        private void selling_Load(object sender, EventArgs e)
        {
            textBox4.Visible = false;
            textBox5.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtnm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
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

            connection.Close();
            clr();
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")

            {

                MessageBox.Show("Section is not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (txtid.Text == "")

            {

                MessageBox.Show("Please enter Customer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (textBox4.Text == "")

            {

                MessageBox.Show("Cattel is not Slected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (txtltr.Text == "")

            {

                MessageBox.Show("Please Enter Liter ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (txtrate.Text == "")

            {

                MessageBox.Show("Please Enter Rate ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            connection.Open(); 
            String insetquery = "INSERT INTO dairy_db.selling(cust_id,cust_name,cattle,liter,rate,total,s_date,section)Values('" + Convert.ToInt32(this.txtid.Text) + "','" + this.txtnm.Text + "','" + textBox4.Text + "','" + Convert.ToDouble(this.txtltr.Text) + "','" + Convert.ToDouble(this.txtrate.Text) + "','" + Convert.ToDouble(txttotl.Text) + "','" + dateTimePicker1.Value.ToString() + "','" + this.textBox5.Text + "')";

            executeQuery(insetquery);
            MessageBox.Show("Information Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // cleartextbox();
            connection.Close();
           griddis();
            cleartexbox();
        }
        public void cleartexbox()
        {
            txtid.Text = "";
            txtnm.Text = "";
            textBox4.Text = "";
            txtltr.Text = "";
            txtrate.Text = "";
            txttotl.Text = "";
        }
        public void clr()
        {
            if (txtid.Text == "")
            {
                txtnm.Text = "";
                textBox4.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                
            }

           
        }
        public void clear()
        {
            if (txtltr.Text == "")
            {
                txtrate.Text = "";
                txttotl.Text = "";
    

            }
        }
        public void griddis()
        {
            openconnection();
            String selectquery = "select cust_id,cust_name,cattle,liter,rate,total from dairy_db.selling where s_date= '" + dateTimePicker1.Value.ToString() + "' && section='" + textBox5.Text + "'";
            cmd = new SqlCommand(selectquery, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            gdsellview.DataSource = dt;
            closeconnection();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            griddis();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            griddis();
        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttotl.Text = (float.Parse(txtltr.Text) * float.Parse(txtrate.Text)).ToString();
            }
            catch
            {

            }
            clr2();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox5.Text = "Morning";

        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox5.Text = "Evening";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "Cow";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "Buffalo";
        }

        private void txtltr_TextChanged(object sender, EventArgs e)
        {
            clear();
        }

        private void txtid_KeyDown(object sender, KeyEventArgs e)
        {
            
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

        private void txtltr_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtltr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtltr.Text))
                {
                    txtrate.Focus();
                }

            }
        }
        public void clr2()
        {
            if(txtrate.Text=="")
            {
                txttotl.Text = "";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")

            {

                MessageBox.Show("Please Enter Customer ID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            String deletquery = "delete from dairy_db.selling where cust_id='" + txtid.Text + "'";
            executeQuery(deletquery);
            MessageBox.Show("customer deatails deleted succsesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cleartexbox();
            griddis();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")

            {

                MessageBox.Show("Can't Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }



            String upquery = "update dairy_db.collection set liter='" + txtltr.Text + "',rate='" + txtrate.Text + "',total='" + txttotl.Text + "' where cust_id='" + txtid.Text + "'";
            MessageBox.Show("customer deatails updated succsesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            executeQuery(upquery);
            cleartexbox();
            griddis();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openconnection();
            string selectquery = "select * from dairy_db.selling where cust_id=" + textBox2.Text;
            cmd = new SqlCommand(selectquery, connection);
           SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            gdsellview.DataSource = dt;
            closeconnection();
        }
    }
}
