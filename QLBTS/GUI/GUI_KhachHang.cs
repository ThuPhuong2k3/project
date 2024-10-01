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
    public partial class GUI_KhachHang : Form
    {
        BUS_KhachHang buskh = new BUS_KhachHang();
        public GUI_KhachHang()
        {
            InitializeComponent();
        }

        private void btnQuayVe_Click(object sender, EventArgs e)
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
            DTO_KhachHang kh = new DTO_KhachHang(txtMaKhach.Text, txtTenKhach.Text, txtDiaChi.Text, txtDT.Text);
            txtMaKhach.Enabled = true;
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (buskh.Xoa(kh) == true)
                {
                    MessageBox.Show("Xoá thành công !!");
                    dgvKhachHang.DataSource = buskh.getKhachHang();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công !!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_KhachHang kh = new DTO_KhachHang(txtMaKhach.Text, txtTenKhach.Text, txtDiaChi.Text, txtDT.Text);
            txtMaKhach.Enabled = true;
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (buskh.Sua(kh) == true)
            {

                MessageBox.Show("Bạn đã sửa thông tin thành công!");
                dgvKhachHang.DataSource = buskh.getKhachHang();
            }
            else
            {
                MessageBox.Show("Sửa không thành công !!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_KhachHang kh = new DTO_KhachHang(txtMaKhach.Text, txtTenKhach.Text, txtDiaChi.Text, txtDT.Text);
            txtMaKhach.Enabled = true;
            if (txtMaKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhach.Focus();
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhach.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (buskh.kiemtramatrung(txtMaKhach.Text) == 1)
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                if (buskh.Them(kh) == true)
                {
                    MessageBox.Show("Bạn đã  thêm thành công");
                    dgvKhachHang.DataSource = buskh.getKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !!");
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaKhach.Enabled = true;
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDT.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã tìm kiếm thành công");
            dgvKhachHang.DataSource = buskh.Timkiemsp(txttimkiem.Text);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = buskh.Timkiemsp(txttimkiem.Text);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int HangChon = e.RowIndex;
            txtMaKhach.Text = dgvKhachHang[0, HangChon].Value.ToString();
            txtTenKhach.Text = dgvKhachHang[1, HangChon].Value.ToString();
            txtDiaChi.Text = dgvKhachHang[2, HangChon].Value.ToString();
            txtDT.Text = dgvKhachHang[3, HangChon].Value.ToString();
        }

        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = buskh.getKhachHang();
            dgvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện Thoại";
            //Width độ dài
            dgvKhachHang.Columns[0].Width = 200;
            dgvKhachHang.Columns[1].Width = 220;
            dgvKhachHang.Columns[2].Width = 150;
            dgvKhachHang.Columns[3].Width = 150;

            //Câu lệnh không cho sửa ở bảng dgvKhachHang
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
