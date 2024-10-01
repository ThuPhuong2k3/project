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
    public class DAL_HangHoa : DBConnect
    {

        public DataTable getHangHoa()
        {
            cnn.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * from tblHang", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public DataTable gettable(string sql)
        {
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cnn.Close();
            return tb;

        }
        public int kiemtramatrung(string ma)
        {
            int i;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from tblHang where MaHang='" + ma.Trim() + "'", cnn);
            i = (int)cmd.ExecuteScalar();
            cnn.Close();
            return i;
        }
        public bool Them(DTO_HangHoa hh)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Insert into tblHang values('{0}',N'{1}',N'{2}','{3}','{4}','{5}',N'{6}')", hh.MaHang, hh.TenHang, hh.ChatLieu, hh.SoLuong, hh.DonGiaNhap, hh.DonGiaBan, hh.GhiChu);
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
        public bool Sua(DTO_HangHoa hh)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Update tblHang set TenHang=N'{1}',ChatLieu=N'{2}',SoLuong='{3}',DonGiaNhap='{4}',DonGiaBan='{5}',GhiChu='{6}' Where MaHang='{0}'", hh.MaHang, hh.TenHang, hh.ChatLieu, hh.SoLuong, hh.DonGiaNhap, hh.DonGiaBan, hh.GhiChu);
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
        public bool Xoa(DTO_HangHoa hh)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Delete from tblHang where MaHang='{0}'", hh.MaHang);
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
            SqlDataAdapter datk = new SqlDataAdapter("Select * from tblHang where MaHang LIKE N'%" + masp + "%'", cnn);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            cnn.Close();
            return dttk;
        }
    }
}
