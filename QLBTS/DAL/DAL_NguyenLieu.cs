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
    public class DAL_NguyenLieu : DBConnect
    {


        public DataTable getNguyenLieu()
        {
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblNguyenLieu", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public int kiemtramatrung(string ma)
        {
            int i;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from tblNguyenLieu where MaNguyenLieu='" + ma.Trim() + "'", cnn);
            i = (int)cmd.ExecuteScalar();
            cnn.Close();
            return i;
        }
        public bool Them(DTO_NguyenLieu cl)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Insert into tblNguyenLieu values('{0}',N'{1}')", cl.MaNguyenLieu, cl.TenNguyenLieu);
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
        public bool Sua(DTO_NguyenLieu cl)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Update tblNguyenLieu set TenNguyenLieu=N'{1}' where MaNguyenLieu='{0}'", cl.MaNguyenLieu, cl.TenNguyenLieu);
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
        public bool Xoa(DTO_NguyenLieu cl)
        {
            try
            {
                cnn.Open();
                string sql = string.Format("Delete from tblNguyenLieu where MaNguyenLieu='{0}'", cl.MaNguyenLieu);
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
    }
}
