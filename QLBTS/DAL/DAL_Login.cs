using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Login : DBConnect
    {
        public DataTable getLogin()
        {
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblTaiKhoan ", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public string DangNhap(DTO_Login cl)
        {
            string id = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblTaiKhoan WHERE TaiKhoan = N'" + cl.TaiKhoan + "' AND MatKhau = N'" + cl.MatKhau + "'", cnn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["TaiKhoan"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return id;
        }

    }

}
