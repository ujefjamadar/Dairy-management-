using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Dairyproject
{
    public partial class bill : Form
    {
        public bill()
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
        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                    txtrd.Text = dr[1].ToString();
                }
                else
                {

                }
                dr.Close();
                if (txtrd.Text == "cow")
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
            if (txtid.Text == "")
            {
                txtnm.Text = "";
            }
        }

        Double ttl = 0;
        private void bill_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           txtrd.Text = "Cow";
        }
        public void griddis()
        {
            openconnection();
            if (radioButton3.Checked == true)
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                String selectquery = "select cattle,c_date,section,liter,fat,rate,total from dairy_db.collection where c_date between '" + dateTimePicker1.Value.ToString() + "' And '" + dateTimePicker2.Value.ToString() + "' && cust_id='" + Convert.ToInt32(txtid.Text) + "'";
                cmd = new SqlCommand(selectquery, connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                ad.Dispose();
               // return;

            }
            else if(radioButton4.Checked==true)
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                String selectquery = "select cattle,s_date,section,liter,rate,total from dairy_db.selling where s_date between '" + dateTimePicker1.Value.ToString() + "' And '" + dateTimePicker2.Value.ToString() + "' && cust_id='" + Convert.ToInt32(txtid.Text) + "'";
                cmd = new SqlCommand(selectquery, connection);
                SqlDataAdapter ad1 = new SqlDataAdapter(cmd);
                DataTable ddt = new DataTable();
                ad1.Fill(ddt);
                dataGridView2.DataSource = ddt;
                ad1.Dispose();

            }
            else
            {

            }
            closeconnection();
            
        }

        private void btngnrate_Click(object sender, EventArgs e)
        {
            if (txtid.Text=="")
            {
                MessageBox.Show("Customer ID is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (dateTimePicker1.Value.Date==false)
            //{
            //    MessageBox.Show("Start Date is not Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //if (dateTimePicker2.Checked == false)
            //{
            //    MessageBox.Show("Start Date is not Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



           
            if (txtnm.Text == "")
            {
                MessageBox.Show("Please Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            griddis();
            if (radioButton3.Checked == true)
            {
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                }
                lblttl.Text = sum.ToString();
                double s = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    s += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                }
                lblamt.Text = s.ToString();
            }
            if (radioButton4.Checked == true)
            {
                double sm = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    sm += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                }
                lblttl.Text = sm.ToString();
                double smm = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    smm += Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                }
                lblamt.Text = smm.ToString();
            }
            //else
            //{

            //}
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtrd.Text = "Buffalo";
        }

        private void txttotal_ltr_TextChanged(object sender, EventArgs e)
        {
            //txttotal_ltr.Text = "0";
            //for(int i=0; i < dataGri;dView1.Rows.Count; i++)
            //{
            //    txttotal_ltr.Text = Convert.ToString(double.Parse(txttotal_ltr.Text) + double.Parse(dataGridView1.Rows[i].Cells[3
            //        ].Value.ToString()));
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //txttotal_ltr.Text = "0";
            // lblttl.Text = "0";
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //   // txttotal_ltr.Text = Convert.ToString(double.Parse(txttotal_ltr.Text) + double.Parse(dataGridView1.Rows[i].Cells["liter"].Value.ToString()));
            //    ttl += double.Parse(dataGridView1.Rows[i].Cells["liter"].Value.ToString());
            //}
            //dataGridView1.Rows.Add(null, null, null, ttl, null, null, null);
            //Double sum = 0;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    sum = Convert.ToDouble(dataGridView1.Rows[i].Cells["Liter"].Value);
            //    lblttl.Text = sum.ToString();
            //}
           //double sum = 0;
           // for(int i = 0; i < dataGridView1.Rows.Count; i++)
           // {
           //     sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
           // }
           // lblttl.Text = sum.ToString();


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Double sum = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = Convert.ToDouble(dataGridView1.Rows[i].Cells["liter"].Value);
                lblttl.Text = sum.ToString();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
