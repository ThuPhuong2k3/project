using BUS;
using DTO;
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
    public partial class GUI_HoaDon : Form
    {
        BUS_HoaDon bushd = new BUS_HoaDon();
        public GUI_HoaDon()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI_Menu fmain = new GUI_Menu();
            fmain.Show();
            this.Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            GUI_Menu fmain = new GUI_Menu();
            fmain.Show();
            this.Hide();
            DTO_HoaDon hd = new DTO_HoaDon(txtMaHD.Text, txtMaNV.Text, txtMaKH.Text, mskNgayBan.Text, float.Parse(txtTong.Text));
            txtMaHD.Enabled = true;
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bushd.Xoa(hd) == true)
                    MessageBox.Show("Xoá thành công !!");
                dgvHoaDon.DataSource = bushd.getHoaDon();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_HoaDon hd = new DTO_HoaDon(txtMaHD.Text, txtMaNV.Text, txtMaKH.Text, mskNgayBan.Text, float.Parse(txtTong.Text));
            txtMaHD.Enabled = true;

            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bushd.Sua(hd) == true)
                {

                    MessageBox.Show("Bạn đã sửa thông tin thành công!");
                    dgvHoaDon.DataSource = bushd.getHoaDon();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công !!");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_HoaDon hd = new DTO_HoaDon(txtMaHD.Text, txtMaNV.Text, txtMaKH.Text, mskNgayBan.Text, float.Parse(txtTong.Text));
            txtMaHD.Enabled = true;
            if (txtMaHD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hoá đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHD.Focus();
                return;
            }
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (txtTong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTong.Focus();
                return;
            }
            if (bushd.kiemtramatrung(txtMaHD.Text) == 1)
            {
                MessageBox.Show("Mã hoá đơn này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                if (bushd.Them(hd) == true)
                {
                    MessageBox.Show("Bạn đã  thêm thành công");
                    dgvHoaDon.DataSource = bushd.getHoaDon();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !!");
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Enabled = true;
            txtMaHD.Text = "";
            txtMaNV.Text = "";
            txtMaKH.Text = "";
            txtTong.Text = "";
            mskNgayBan.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã tìm kiếm thành công");
            dgvHoaDon.DataSource = bushd.Timkiemsp(txttimkiem.Text);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = bushd.Timkiemsp(txttimkiem.Text);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int HangChon = e.RowIndex;
            txtMaHD.Text = dgvHoaDon[0, HangChon].Value.ToString();
            txtMaNV.Text = dgvHoaDon[1, HangChon].Value.ToString();
            txtMaKH.Text = dgvHoaDon[2, HangChon].Value.ToString();
            mskNgayBan.Text = dgvHoaDon[3, HangChon].Value.ToString();
            txtTong.Text = dgvHoaDon[4, HangChon].Value.ToString();
        }

        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = bushd.getHoaDon();
            dgvHoaDon.Columns[0].HeaderText = "Mã Hoá Đơn Bán";
            dgvHoaDon.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvHoaDon.Columns[2].HeaderText = "Mã Khách";
            dgvHoaDon.Columns[3].HeaderText = "Ngày Bán";
            dgvHoaDon.Columns[4].HeaderText = "Tổng Tiền";
            dgvHoaDon.Columns[0].Width = 180;
            dgvHoaDon.Columns[1].Width = 150;
            dgvHoaDon.Columns[2].Width = 150;
            dgvHoaDon.Columns[3].Width = 150;
            dgvHoaDon.Columns[4].Width = 150;

            //Câu lệnh không cho sửa ở bảng dgvHoaDon
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
