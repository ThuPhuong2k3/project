using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class GUI_NguyenLieu : Form
    {
        BUS_NguyenLieu buscl = new BUS_NguyenLieu();
        public GUI_NguyenLieu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); GUI_Menu fmain = new GUI_Menu();
            fmain.Show();
            this.Hide();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DTO_NguyenLieu cl = new DTO_NguyenLieu(txtMaNguyenLieu.Text, txtTenNguyenLieu.Text);
            txtMaNguyenLieu.Enabled = true;
            if (txtMaNguyenLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (buscl.Xoa(cl) == true)
                {
                    MessageBox.Show("Xoá thành công !!");
                    dgvNguyenLieu.DataSource = buscl.getNguyenLieu();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công !!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_NguyenLieu cl = new DTO_NguyenLieu(txtMaNguyenLieu.Text, txtTenNguyenLieu.Text);
            txtMaNguyenLieu.Enabled = true;

            if (txtMaNguyenLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (buscl.Sua(cl) == true)
                {

                    MessageBox.Show("Bạn đã sửa thông tin thành công!");
                    dgvNguyenLieu.DataSource = buscl.getNguyenLieu();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công !!");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_NguyenLieu cl = new DTO_NguyenLieu(txtMaNguyenLieu.Text, txtTenNguyenLieu.Text);
            txtMaNguyenLieu.Enabled = true;
            if (txtMaNguyenLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNguyenLieu.Focus();
                return;
            }
            if (txtTenNguyenLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguyenLieu.Focus();
                return;
            }
            if (buscl.kiemtramatrung(txtMaNguyenLieu.Text) == 1)
            {
                MessageBox.Show("Mã chất liệu này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                if (buscl.Them(cl) == true)
                {
                    MessageBox.Show("Bạn đã  thêm thành công");
                    dgvNguyenLieu.DataSource = buscl.getNguyenLieu();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !!");
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaNguyenLieu.Enabled = true;
            txtMaNguyenLieu.Text = "";
            txtTenNguyenLieu.Text = "";
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int HangChon = e.RowIndex;
            txtMaNguyenLieu.Text = dgvNguyenLieu[0, HangChon].Value.ToString();
            txtTenNguyenLieu.Text = dgvNguyenLieu[1, HangChon].Value.ToString();
        }

        private void GUI_NguyenLieu_Load(object sender, EventArgs e)
        {
            dgvNguyenLieu.DataSource = buscl.getNguyenLieu();
            dgvNguyenLieu.Columns[0].HeaderText = "Mã Nguyên Liệu";
            dgvNguyenLieu.Columns[1].HeaderText = "Tên Nguyên Liệu";
            dgvNguyenLieu.Columns[0].Width = 320;


            dgvNguyenLieu.Columns[1].Width = 400;
            //Câu lệnh không cho sửa ở bảng dgvNguyenLieu
            dgvNguyenLieu.AllowUserToAddRows = false;
            dgvNguyenLieu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaNguyenLieu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
