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
    public class BUS_HangHoa
    {
        DAL_HangHoa dalhh = new DAL_HangHoa();
        public DataTable getHangHoa()
        {
            return dalhh.getHangHoa();
        }
        public int kiemtramatrung(string ma)
        {
            return dalhh.kiemtramatrung(ma);
        }
        public bool Them(DTO_HangHoa hh)
        {
            return dalhh.Them(hh);
        }
        public bool Sua(DTO_HangHoa hh)
        {

            return dalhh.Sua(hh);
        }
        public bool Xoa(DTO_HangHoa hh)
        {

            return dalhh.Xoa(hh);
        }
        public DataTable Timkiemsp(string masp)
        {
            return dalhh.Timkiemsp(masp);
        }

    }
}
