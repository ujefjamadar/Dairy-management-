using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dairyproject
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        public void loadform(object form)
        {
            
            
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

            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //login l = new login();
            //l.ShowDialog();
           DialogResult exit=exit= MessageBox.Show("Are you Sure to Exit","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(exit==DialogResult.No)
            {
             //  button8 ="true" ;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            addcust a = new addcust();
            a.Show();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            // loadform(new collctioncs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnseller_Click(object sender, EventArgs e)
        {
           // subppnnlcust.Visible = false;
        
        }

        private void btnbuyer_Click(object sender, EventArgs e)
        {
            //subppnnlcust.Visible = false;
           // addcust c = new addcust();
            //c.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }
        private void frmshw(object frm)
        {
            try
            {
                if (this.panel3.Controls.Count > 0)
                    this.panel3.Controls.RemoveAt(0);
                home f = frm as home;
                f.TopLevel = true;
                f.Dock = DockStyle.Fill;
                this.panel3.Controls.Add(f);
                this.panel3.Tag = f;
                f.Show();
            }
            catch
            {

            }
           
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = exit = MessageBox.Show("Are you Sure to Exit", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                e.Cancel = false;

                //login l = new login();
                //l.ShowDialog();


            }
            else
            {
                e.Cancel = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            button8.Visible = true;

        }

        private void button11_Click(object sender, EventArgs e)
        {
          
           // button11.Visible = false;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            selling s = new selling();
            s.Show();
            //frmshw(new selling());

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            collection g = new collection();
            g.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            setrate t = new setrate();
            t.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            addcust ad = new addcust();
            ad.Show();

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bill b = new bill();
            b.Show();
        }

        private void home_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control==true&& e.KeyCode==Keys.H)
            {
                button1.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                button2.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                button3.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.B)
            {
                button4.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.T)
            {
                button5.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                button6.PerformClick();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible =false;
        }

     

        private void button2_MouseEnter_1(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button3_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void button3_MouseEnter_1(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void button3_MouseLeave_1(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button4_MouseEnter_1(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            label7.Visible = true;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //button13.Visible = false;
            //button11.Visible = true;

        }
    }
}
