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
    public partial class GUI_HangHoa : Form
    {
        BUS_HangHoa bushh = new BUS_HangHoa();
        public GUI_HangHoa()
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
            this.Hide(); DTO_HangHoa hh = new DTO_HangHoa(txtMaHang.Text, txtTenHang.Text, txtNguyenLieu.Text, int.Parse(txtSoLuong.Text), int.Parse(txtDonGiaNhap.Text), int.Parse(txtDonGiaBan.Text), ghichu.Text);
            txtMaHang.Enabled = true;
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bushh.Xoa(hh) == true)
                {
                    MessageBox.Show("Xoá thành công !!");
                    dgvHangHoa.DataSource = bushh.getHangHoa();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công !!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_HangHoa hh = new DTO_HangHoa(txtMaHang.Text, txtTenHang.Text, txtNguyenLieu.Text, int.Parse(txtSoLuong.Text), int.Parse(txtDonGiaNhap.Text), int.Parse(txtDonGiaBan.Text), ghichu.Text);
            txtMaHang.Enabled = true;

            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bushh.Sua(hh) == true)
                {

                    MessageBox.Show("Bạn đã sửa thông tin thành công!");
                    dgvHangHoa.DataSource = bushh.getHangHoa();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công !!");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            DTO_HangHoa hh = new DTO_HangHoa(txtMaHang.Text, txtTenHang.Text, txtNguyenLieu.Text, int.Parse(txtSoLuong.Text), int.Parse(txtDonGiaNhap.Text), int.Parse(txtDonGiaBan.Text), ghichu.Text);
            txtMaHang.Enabled = true;
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }
            if (txtNguyenLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập  nguyên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguyenLieu.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }
            if (txtDonGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }
            if (bushh.kiemtramatrung(txtMaHang.Text) == 1)
            {
                MessageBox.Show("Mã chất liệu này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                if (bushh.Them(hh) == true)
                {
                    MessageBox.Show("Bạn đã  thêm thành công");
                    dgvHangHoa.DataSource = bushh.getHangHoa();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !!");
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaHang.Enabled = true;
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtNguyenLieu.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            ghichu.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Bạn đã tìm kiếm thành công");
            dgvHangHoa.DataSource = bushh.Timkiemsp(txttimkiem.Text);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = bushh.Timkiemsp(txttimkiem.Text);
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int HangChon = e.RowIndex;
            txtMaHang.Text = dgvHangHoa[0, HangChon].Value.ToString();
            txtTenHang.Text = dgvHangHoa[1, HangChon].Value.ToString();
            txtNguyenLieu.Text = dgvHangHoa[2, HangChon].Value.ToString();
            txtSoLuong.Text = dgvHangHoa[3, HangChon].Value.ToString();
            txtDonGiaNhap.Text = dgvHangHoa[4, HangChon].Value.ToString();
            txtDonGiaBan.Text = dgvHangHoa[5, HangChon].Value.ToString();
            ghichu.Text = dgvHangHoa[6, HangChon].Value.ToString();
        }

        private void GUI_HangHoa_Load(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = bushh.getHangHoa();
            dgvHangHoa.Columns[0].HeaderText = "Mã Hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên Hàng";
            dgvHangHoa.Columns[2].HeaderText = "Nguyên Liêu";
            dgvHangHoa.Columns[3].HeaderText = "Số Lượng";
            dgvHangHoa.Columns[4].HeaderText = "Đơn Giá Nhập";
            dgvHangHoa.Columns[5].HeaderText = "Đơn Giá Bán";
            dgvHangHoa.Columns[6].HeaderText = "Ghi Chú";
            dgvHangHoa.Columns[0].Width = 150;
            dgvHangHoa.Columns[1].Width = 200;
            dgvHangHoa.Columns[2].Width = 120;
            dgvHangHoa.Columns[3].Width = 120;
            dgvHangHoa.Columns[4].Width = 140;
            dgvHangHoa.Columns[5].Width = 140;
            dgvHangHoa.Columns[6].Width = 100;
 
            //Câu lệnh không cho sửa ở bảng dgvHangHoa
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void ghichu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
