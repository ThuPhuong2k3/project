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
    public class BUS_CTHDB
    {
        DAL_CTHDB dalcthdb = new DAL_CTHDB();
        public DataTable getCTHDB()
        {
            return dalcthdb.getCTHDB();
        }
        public int kiemtramatrung(string ma)
        {
            return dalcthdb.kiemtramatrung(ma);
        }
        public bool Them(DTO_CTHDB ct)
        {
            return dalcthdb.Them(ct);
        }
        public bool Sua(DTO_CTHDB ct)
        {
            return dalcthdb.Sua(ct);
        }
        public bool Xoa(DTO_CTHDB ct)
        {
            return dalcthdb.Xoa(ct);
        }
        public DataTable Timkiemsp(string masp)
        {
            return dalcthdb.Timkiemsp(masp);
        }
    }
}
