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
    public class BUS_KhachHang
    {
        DAL_KhachHang dalkh = new DAL_KhachHang();
        public DataTable getKhachHang()
        {
            return dalkh.getKhachHang();
        }
        public int kiemtramatrung(string ma)
        {
            return dalkh.kiemtramatrung(ma);
        }
        public bool Them(DTO_KhachHang kh)
        {
            return dalkh.Them(kh);
        }
        public bool Sua(DTO_KhachHang hh)
        {

            return dalkh.Sua(hh);
        }
        public bool Xoa(DTO_KhachHang kh)
        {

            return dalkh.Xoa(kh);
        }
        public DataTable Timkiemsp(string masp)
        {
            return dalkh.Timkiemsp(masp);
        }
    }
}
