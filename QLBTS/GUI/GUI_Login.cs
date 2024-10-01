using DTO;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI
{
    public partial class GUI_Login : Form
    {
        BUS_Login buscl = new BUS_Login();
        public GUI_Login()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DTO_Login cl = new DTO_Login(txtdn.Text, txtmk.Text);
            if (buscl.DangNhap(cl) != "")
            {
                GUI_Menu fmain = new GUI_Menu();
                fmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }
        }

       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtdn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtmk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtdn_TextChanged(object sender, EventArgs e)
        {

        }

        private void GUI_Login_Load(object sender, EventArgs e)
        {
          
        }
    }
}
