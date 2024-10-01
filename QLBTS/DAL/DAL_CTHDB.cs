using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTHDB : DBConnect
    {

        public DataTable getCTHDB()
        {
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblCTHDB", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public int kiemtramatrung(string ma)
        {
            int i;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from tblCTHDB where MaHDB='" + ma.Trim() + "'", cnn);
            i = (int)cmd.ExecuteScalar();
            cnn.Close();
            return i;
        }
        public bool Them(DTO_CTHDB ct)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Insert into tblCTHDB values('{0}','{1}','{2}','{3}','{4}','{5}')", ct.MaHoaDonBan, ct.MaHang, ct.SoLuong, ct.DonGia, ct.GiamGia, ct.ThanhTien);
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
        public bool Sua(DTO_CTHDB ct)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Update tblCTHDB set MaHang='{1}',SoLuong='{2}',DonGia='{3}',GiamGia='{4}',ThanhTien='{5}' where MaHDB='{0}'", ct.MaHoaDonBan, ct.MaHang, ct.SoLuong, ct.DonGia, ct.GiamGia, ct.ThanhTien);
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
        public bool Xoa(DTO_CTHDB ct)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Delete from tblCTHDB where MaHDB='{0}'", ct.MaHoaDonBan);
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
            SqlDataAdapter datk = new SqlDataAdapter("Select * from  tblCTHDB where MaHang LIKE N'%" + masp + "%'", cnn);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            cnn.Close();
            return dttk;
        }
    }
}
