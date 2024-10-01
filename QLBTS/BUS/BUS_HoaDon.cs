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
    public class BUS_HoaDon
    {
        DAL_HoaDon dalhd = new DAL_HoaDon();
        public DataTable getHoaDon()
        {
            return dalhd.getHoaDon();
        }
        public int kiemtramatrung(string ma)
        {
            return dalhd.kiemtramatrung(ma);
        }
        public bool Them(DTO_HoaDon hd)
        {
            return dalhd.Them(hd);
        }
        public bool Sua(DTO_HoaDon hd)
        {

            return dalhd.Sua(hd);
        }
        public bool Xoa(DTO_HoaDon hd)
        {

            return dalhd.Xoa(hd);
        }
        public DataTable Timkiemsp(string masp)
        {
            return dalhd.Timkiemsp(masp);
        }
    }
}
