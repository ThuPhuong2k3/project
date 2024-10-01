using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NhanVien : DBConnect
    {
        public DataTable getNhanVien()
        {
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblNhanVien", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public int kiemtramatrung(string ma)
        {
            int i;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from tblNhanVien where MaNhanVien='" + ma.Trim() + "'", cnn);
            i = (int)cmd.ExecuteScalar();
            cnn.Close();
            return i;
        }
        public bool Them(DTO_NhanVien nv)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Insert into tblNhanVien values('{0}',N'{1}',N'{2}',N'{3}','{4}',)", nv.MaNhanVien, nv.TenNhanVien, nv.GioiTinh, nv.DiaChi, nv.NgaySinh);
                SqlCommand cmd = new SqlCommand(sql, cnn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return false;
        }
        public bool Sua(DTO_NhanVien nv)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Update tblNhanVien set TenNhanVien=N'{1}',GioiTinh=N'{2}',DiaChi=N'{3}',NgaySinh='{4}' where MaNhanVien='{0}'", nv.MaNhanVien, nv.TenNhanVien, nv.GioiTinh, nv.DiaChi, nv.NgaySinh);
                SqlCommand cmd = new SqlCommand(sql, cnn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return false;
        }
        public bool Xoa(DTO_NhanVien nv)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Delete from tblNhanVien where MaNhanVien='{0}'", nv.MaNhanVien);
                SqlCommand cmd = new SqlCommand(sql, cnn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return false;
        }
        public DataTable Timkiemsp(string masp)
        {
            cnn.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from  tblNhanVien where MaNhanVien LIKE N'%" + masp + "%'", cnn);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            cnn.Close();
            return dttk;
        }
    }
}
