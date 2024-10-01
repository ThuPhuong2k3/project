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
    public class DAL_HoaDon : DBConnect
    {
        public DataTable getHoaDon()
        {
            cnn.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * from tblHDB", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            int i;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from tblHDB where MaHDB='" + ma.Trim() + "'", cnn);
            i = (int)cmd.ExecuteScalar();
            cnn.Close();
            return i;
        }
        public bool Them(DTO_HoaDon hd)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Insert into tblHDB values('{0}','{1}','{2}',N'{3}',N'{4}')", hd.MaHoaDonBan, hd.MaNhanVien, hd.MaKhach, hd.NgayBan, hd.TongTien);
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
        public bool Sua(DTO_HoaDon hd)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Update tblHDB set MaNhanVien='{1}',MaKhach='{2}',NgayBan='{3}',TongTien='{4}' Where MaHDB='{0}'", hd.MaHoaDonBan, hd.MaNhanVien, hd.MaKhach, hd.NgayBan, hd.TongTien);
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
        public bool Xoa(DTO_HoaDon hd)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Delete from tblHDB where MaHDB='{0}'", hd.MaHoaDonBan);
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
            SqlDataAdapter datk = new SqlDataAdapter("Select * from tblHDB where MaNhanVien LIKE N'%" + masp + "%'", cnn);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            cnn.Close();
            return dttk;
        }
    }
}
