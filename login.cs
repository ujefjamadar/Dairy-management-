using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Dairyproject
{
    public partial class login : Form
    {
        //[DllImport("Gdi32.dll",EntryPoint ="CreatRoundRectRgn")]
        //(
        //    int nleft
            
            
        //);
        public login()
        {
            InitializeComponent();
            this.ActiveControl = txtid;
            txtid.Focus();
        }

        private void login_Load(object sender, EventArgs e)
        {
            btnlogin.Enabled = false;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            
            
            if(txtid.Text=="")
            {
                btnlogin.Enabled = false;
            }
            else
            {
                btnlogin.Enabled = true;

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Please Enter ID","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (txtnm.Text == "")
            {
                MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtpass.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             



            if (txtid.Text=="1" && txtnm.Text=="admin" && txtpass.Text=="1234")
            {
                MessageBox.Show("Login Succesfull,","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Visible = false;
                home obj1 = new home();
                obj1.ShowDialog();
                // textBox1.Text = "";
                // textBox2.Text = "";
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid ID,Username or Password","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtnm_TextChanged(object sender, EventArgs e)
        {
            if(txtnm.Text=="")
            {
                btnlogin.Enabled = false;

            }
            else
            {
                btnlogin.Enabled = true;

            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                btnlogin.Enabled = false;

            }
            else
            {
                btnlogin.Enabled = true;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpass.Checked)
            {
                txtpass.UseSystemPasswordChar = true;
            }
            else
            {
                txtpass.UseSystemPasswordChar = false;

            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtnm.Focus();
            }
        }

        private void txtnm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtpass.Focus();
            //}
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnlogin.Focus();
            //}
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtid.Text))
                {
                    txtnm.Focus();
                }

            }
        }

        private void txtnm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtnm.Text))
                {
                    txtpass.Focus();
                }

            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtid.Text))
                {
                    btnlogin.Focus();
                }

            }
        }
    }
}
