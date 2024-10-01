using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Menu : Form
    {
        public GUI_Menu()
        {
            InitializeComponent();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult dgl = MessageBox.Show("Thoát Chương Trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgl == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuNguyenLieu_Click(object sender, EventArgs e)
        {
            GUI_NguyenLieu fmain = new GUI_NguyenLieu();
            fmain.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI_NhanVien fmain = new GUI_NhanVien();
            fmain.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GUI_KhachHang fmain = new GUI_KhachHang();
            fmain.Show();
            this.Hide();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GUI_HangHoa fmain = new GUI_HangHoa();
            fmain.Show();
            this.Hide();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            GUI_HoaDon fmain = new GUI_HoaDon();
            fmain.Show();
            this.Hide();
        }

        private void chiTiếtHoáĐơnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GUI_CTHDB fmain = new GUI_CTHDB();
            fmain.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI_TimKiem fmain = new GUI_TimKiem();
            fmain.Show();
            this.Hide();
        }

        private void mnuFindHang_Click(object sender, EventArgs e)
        {
            GUI_TimKiem fmain = new GUI_TimKiem();
            fmain.Show();
            this.Hide();
        }

        private void mnuFindKhachHang_Click(object sender, EventArgs e)
        {
            GUI_TimKiem fmain = new GUI_TimKiem();
            fmain.Show();
            this.Hide();
        }

        private void chiTiếtHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem fmain = new GUI_TimKiem();
            fmain.Show();
            this.Hide();
        }
    }
}
