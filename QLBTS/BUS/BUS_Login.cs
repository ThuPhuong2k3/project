using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Login
    {
        DAL_Login dalcl = new DAL_Login();
        public DataTable getLogin()
        {
            return dalcl.getLogin();
        }
        public string DangNhap(DTO_Login cl)
        {
            return dalcl.DangNhap(cl);
        }

    }
}

