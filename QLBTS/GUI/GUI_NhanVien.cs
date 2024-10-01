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
    public partial class GUI_NhanVien : Form
    {
        BUS_NhanVien busnv = new BUS_NhanVien();
        public GUI_NhanVien()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI_Menu fmain = new GUI_Menu();
            fmain.Show();
            this.Hide();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien(txtMaNV.Text, txtTenNV.Text, comboBox1.Text, txtDiaChi.Text, mskNgaySinh.Text);
            txtMaNV.Enabled = true;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busnv.Xoa(nv) == true)
                {
                    MessageBox.Show("Xoá thành công !!");
                    dgvNhanVien.DataSource = busnv.getNhanVien();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công !!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien(txtMaNV.Text, txtTenNV.Text, comboBox1.Text, txtDiaChi.Text, mskNgaySinh.Text);
            txtMaNV.Enabled = true;
            if (busnv.Sua(nv) == true)
            {

                MessageBox.Show("Bạn đã sửa thông tin thành công!");
                dgvNhanVien.DataSource = busnv.getNhanVien();
            }
            else
            {
                MessageBox.Show("Sửa không thành công !!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_NhanVien cl = new DTO_NhanVien(txtMaNV.Text, txtTenNV.Text, comboBox1.Text, txtDiaChi.Text, mskNgaySinh.Text);
            txtMaNV.Enabled = true;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (busnv.kiemtramatrung(txtMaNV.Text) == 1)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                if (busnv.Them(cl) == true)
                {
                    MessageBox.Show("Bạn đã  thêm thành công");
                    dgvNhanVien.DataSource = busnv.getNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !!");
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            comboBox1.Text = "";
            txtDiaChi.Text = "";
            mskNgaySinh.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã tìm kiếm thành công");
            dgvNhanVien.DataSource = busnv.Timkiemsp(txttimkiem.Text);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = busnv.Timkiemsp(txttimkiem.Text);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien[1, i].Value.ToString();
            comboBox1.Text = dgvNhanVien[2, i].Value.ToString();
            txtDiaChi.Text = dgvNhanVien[3, i].Value.ToString();
            mskNgaySinh.Text = dgvNhanVien[4, i].Value.ToString();
            txtMaNV.Enabled = true;
        }

        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = busnv.getNhanVien();
            dgvNhanVien.Columns[0].HeaderText = "Mã  Nhân  Viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới  Tính";
            dgvNhanVien.Columns[3].HeaderText = "Địa  Chỉ";
            dgvNhanVien.Columns[4].HeaderText = "Ngày Sinh";

            dgvNhanVien.Columns[0].Width = 150;
            dgvNhanVien.Columns[1].Width = 160;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 120;
            dgvNhanVien.Columns[4].Width = 110;


            //Câu lệnh không cho sửa ở bảng dgvNguyenLieu
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskNgaySinh_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
