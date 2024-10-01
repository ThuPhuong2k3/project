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
    public class DAL_KhachHang : DBConnect
    {
        public DataTable getKhachHang()
        {
            cnn.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * from tblKhach", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public int kiemtramatrung(string ma)
        {
            int i;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from tblKhach where MaKhach='" + ma.Trim() + "'", cnn);
            i = (int)cmd.ExecuteScalar();
            cnn.Close();
            return i;
        }
        public bool Them(DTO_KhachHang kh)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Insert into tblKhach values('{0}',N'{1}',N'{2}',N'{3}')", kh.MaKhach, kh.TenKhach, kh.DiaChi, kh.DienThoai);
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
        public bool Sua(DTO_KhachHang kh)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Update tblKhach set TenKhach=N'{1}',DiaChi=N'{2}',DienThoai='{3}' where MaKhach='{0}'", kh.MaKhach, kh.TenKhach, kh.DiaChi, kh.DienThoai);
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
        public bool Xoa(DTO_KhachHang kh)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Delete from tblKhach where MaKhach='{0}'", kh.MaKhach);
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
            SqlDataAdapter datk = new SqlDataAdapter("Select * from  tblKhach where MaKhach LIKE N'%" + masp + "%'", cnn);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            cnn.Close();
            return dttk;
        }
    }
}
