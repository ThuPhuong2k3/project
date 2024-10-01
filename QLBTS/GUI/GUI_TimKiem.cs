using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class GUI_TimKiem : Form
    {
        //Tạo kết nối với cơ sở dữ liệu
        public SqlConnection cn = new SqlConnection();
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                    cn.ConnectionString = "Data Source=DESKTOP-H7QDFO7\\SQLEXPRESS;Initial Catalog=QLBTS;Integrated Security=True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Ngatketnoi()
        {
            if (cn.State != 0)
            {
                cn.Close();
            }
        }

        //Phương thức truy vấn để xem dữ liệu
        public DataTable XemDL(string sql)
        {
            Ketnoi();

            SqlDataAdapter adap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            return dt;

            Ngatketnoi();
        }

        //Phương thức truy vấn dữ liệu: Insert, Update, Delete
        public SqlCommand ThucThiDl(string sql)
        {
            Ketnoi();

            SqlCommand cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();

            return cm;

            Ngatketnoi();
        }
        BUS_HangHoa hh = new BUS_HangHoa();
        public GUI_TimKiem()
        {
            InitializeComponent();
        }

        private void cbbcachtim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI_Menu fmain = new GUI_Menu();
            fmain.Show();
            this.Hide();
        }

        private void txtTukhoa_TextChanged(object sender, EventArgs e)
        {
            if (cbbcachtim.Text == "Mã Nhân Viên")
            {
                dgvTK.DataSource = XemDL("Select * from tblNhanVien Where MaNhanVien like '%" + txtTukhoa.Text.Trim() + "%'");


            }
            if (cbbcachtim.Text == "Tên Nhân Viên")
            {
                dgvTK.DataSource = XemDL("Select * from tblNhanVien Where TenNhanVien like N'%" + txtTukhoa.Text.Trim() + "%'");


            }
            if (cbbcachtim.Text == "Mã Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblHang Where MaHang like '%" + txtTukhoa.Text.Trim() + "%'");


            }
            if (cbbcachtim.Text == "Tên Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblHang Where TenHang like N'%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Mã Khách Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblKhach Where MaKhach like '%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Tên Khách Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblKhach Where TenKhach like N'%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Mã Nguyên Liệu")
            {
                dgvTK.DataSource = XemDL("Select * from tblNguyenLieu Where MaNguyenLieu like '%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Tên Nguyên Liệu")
            {
                dgvTK.DataSource = XemDL("Select * from tblNguyenLieu Where TenNguyenLieu like N'%" + txtTukhoa.Text.Trim() + "%'");
            }

            if (cbbcachtim.Text == "Mã Hoá Đơn Bán")
            {
                dgvTK.DataSource = XemDL("Select * from  tblHoaDBH Where MaHDB like '%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Chi Tiết Hoá Đơn Bán")
            {
                dgvTK.DataSource = XemDL("Select * from  tblCTHDB Where MaHDB like '%" + txtTukhoa.Text.Trim() + "%'");
            }
        }

        private void GUI_TimKiem_Load(object sender, EventArgs e)
        {
            if (cbbcachtim.Text == "Mã Nhân Viên")
            {
                dgvTK.DataSource = XemDL("Select * from tblNhanVien Where MaNhanVien like '%" + txtTukhoa.Text.Trim() + "%'");


            }
            if (cbbcachtim.Text == "Tên Nhân Viên")
            {
                dgvTK.DataSource = XemDL("Select * from tblNhanVien Where TenNhanVien like N'%" + txtTukhoa.Text.Trim() + "%'");


            }
            if (cbbcachtim.Text == "Mã Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblHang Where MaHang like '%" + txtTukhoa.Text.Trim() + "%'");


            }
            if (cbbcachtim.Text == "Tên Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblHang Where TenHang like N'%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Mã Khách Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblKhach Where MaKhach like '%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Tên Khách Hàng")
            {
                dgvTK.DataSource = XemDL("Select * from tblKhach Where TenKhach like N'%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Mã Nguyên Liệu")
            {
                dgvTK.DataSource = XemDL("Select * from tblNguyenLieu Where MaNguyenLieu like '%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Tên Nguyên Liệu")
            {
                dgvTK.DataSource = XemDL("Select * from tblNguyenLieu Where TenNguyenLieu like N'%" + txtTukhoa.Text.Trim() + "%'");
            }

            if (cbbcachtim.Text == "Mã Hoá Đơn Bán")
            {
                dgvTK.DataSource = XemDL("Select * from  tblHoaDBH Where MaHDB like '%" + txtTukhoa.Text.Trim() + "%'");
            }
            if (cbbcachtim.Text == "Chi Tiết Hoá Đơn Bán")
            {
                dgvTK.DataSource = XemDL("Select * from  tblCTHDB Where MaHDB like '%" + txtTukhoa.Text.Trim() + "%'");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void dgvTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
