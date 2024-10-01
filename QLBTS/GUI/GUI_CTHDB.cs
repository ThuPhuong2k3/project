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
using System.IO;
using app = Microsoft.Office.Interop.Excel.Application;

namespace GUI
{
    public partial class GUI_CTHDB : Form
    {
        BUS_CTHDB busct = new BUS_CTHDB();
        public GUI_CTHDB()
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
            DTO_CTHDB ct = new DTO_CTHDB(txtMaHDB.Text, txtMaHang.Text, float.Parse(txtSoLuong.Text), float.Parse(txtDonGia.Text), float.Parse(txtGiamGia.Text), float.Parse(txtThanhTien.Text));
            txtMaHDB.Enabled = true;

            if (txtMaHDB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busct.Xoa(ct) == true)
                {
                    MessageBox.Show("Xoá thành công !!");
                    dgvCTHDB.DataSource = busct.getCTHDB();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công !!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_CTHDB ct = new DTO_CTHDB(txtMaHDB.Text, txtMaHang.Text, float.Parse(txtSoLuong.Text), float.Parse(txtDonGia.Text), float.Parse(txtGiamGia.Text), float.Parse(txtThanhTien.Text));
            txtMaHDB.Enabled = true;

            if (txtMaHDB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busct.Sua(ct) == true)
                {

                    MessageBox.Show("Bạn đã sửa thông tin thành công!");
                    dgvCTHDB.DataSource = busct.getCTHDB();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công !!");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_CTHDB ct = new DTO_CTHDB(txtMaHDB.Text, txtMaHang.Text, float.Parse(txtSoLuong.Text), float.Parse(txtDonGia.Text), float.Parse(txtGiamGia.Text), float.Parse(txtThanhTien.Text));
            txtMaHDB.Enabled = true;
            if (txtMaHDB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hoá đơn bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDB.Focus();
                return;
            }
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }
            if (txtSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }
            if (txtDonGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamGia.Focus();
                return;
            }
            if (txtThanhTien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thành tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThanhTien.Focus();
                return;
            }
            if (busct.kiemtramatrung(txtMaHDB.Text) == 1)
            {
                MessageBox.Show("Mã hoá đơn  này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                if (busct.Them(ct) == true)
                {
                    MessageBox.Show("Bạn đã  thêm thành công");
                    dgvCTHDB.DataSource = busct.getCTHDB();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !!");
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaHDB.Enabled = true;
            txtMaHDB.Text = "";
            txtMaHang.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã tìm kiếm thành công");
            dgvCTHDB.DataSource = busct.Timkiemsp(txttimkiem.Text);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            dgvCTHDB.DataSource = busct.Timkiemsp(txttimkiem.Text);
        }

        private void dgvCTHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int HangChon = e.RowIndex;
            txtMaHDB.Text = dgvCTHDB[0, HangChon].Value.ToString();
            txtMaHang.Text = dgvCTHDB[1, HangChon].Value.ToString();
            txtSoLuong.Text = dgvCTHDB[2, HangChon].Value.ToString();
            txtDonGia.Text = dgvCTHDB[3, HangChon].Value.ToString();
            txtGiamGia.Text = dgvCTHDB[4, HangChon].Value.ToString();
            txtThanhTien.Text = dgvCTHDB[5, HangChon].Value.ToString();
        }

        private void GUI_CTHDB_Load(object sender, EventArgs e)
        {
            dgvCTHDB.DataSource = busct.getCTHDB();
            dgvCTHDB.Columns[0].HeaderText = "Mã HDB";
            dgvCTHDB.Columns[1].HeaderText = "Mã Hàng";
            dgvCTHDB.Columns[2].HeaderText = "Số Lượng";
            dgvCTHDB.Columns[3].HeaderText = "Đơn Giá";
            dgvCTHDB.Columns[4].HeaderText = "Giảm Giá";
            dgvCTHDB.Columns[5].HeaderText = "Thành Tiền";
            dgvCTHDB.Columns[0].Width = 150;
            dgvCTHDB.Columns[1].Width = 150;
            dgvCTHDB.Columns[2].Width = 120;
            dgvCTHDB.Columns[3].Width = 120;
            dgvCTHDB.Columns[4].Width = 120;
            dgvCTHDB.Columns[5].Width = 120;

            //Câu lệnh không cho sửa ở bảng dgvChatLieu
            dgvCTHDB.AllowUserToAddRows = false;
            dgvCTHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportFile(busct.getCTHDB(), "danh sach hoa don", "Danh sách chi tiết hóa đơn bán ");
        }
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã Lớp";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã Sinh Viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tên Sinh Viên";
            cl3.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Ngày Sinh";

            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Địa Chỉ";

            cl5.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Quê Quán";

            cl6.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "G3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    if (dataTable.Columns[col].DataType == typeof(DateTime))
                    {
                        DateTime dateValue = (DateTime)dataRow[col];
                        arr[row, col] = dateValue.ToShortDateString();

                    }

                    else
                    {
                        arr[row, col] = dataRow[col];
                    }
                }
            }
            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã 

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
    }
}
