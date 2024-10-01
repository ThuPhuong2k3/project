using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NguyenLieu
    {
        DAL_NguyenLieu dalcl = new DAL_NguyenLieu();
        public DataTable getNguyenLieu()
        {
            return dalcl.getNguyenLieu();
        }
        public int kiemtramatrung(string ma)
        {
            return dalcl.kiemtramatrung(ma);
        }
        public bool Them(DTO_NguyenLieu cl)
        {
            return dalcl.Them(cl);
        }
        public bool Sua(DTO_NguyenLieu cl)
        {
            return dalcl.Sua(cl);
        }
        public bool Xoa(DTO_NguyenLieu cl)
        {
            return dalcl.Xoa(cl);
        }

    }
}
