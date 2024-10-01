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
    public class BUS_NhanVien
    {
        DAL_NhanVien dalnv = new DAL_NhanVien();
        public DataTable getNhanVien()
        {
            return dalnv.getNhanVien();
        }
        public int kiemtramatrung(string ma)
        {
            return dalnv.kiemtramatrung(ma);
        }
        public bool Them(DTO_NhanVien nv)
        {
            return dalnv.Them(nv);
        }
        public bool Sua(DTO_NhanVien nv)
        {
            return dalnv.Sua(nv);
        }
        public bool Xoa(DTO_NhanVien nv)
        {
            return dalnv.Xoa(nv);
        }
        public DataTable Timkiemsp(string masp)
        {
            return dalnv.Timkiemsp(masp);
        }
    }
}
