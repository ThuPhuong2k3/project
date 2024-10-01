using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //lớp định nghĩa các table trong database của bạn
    public class DTO_HoaDon
    {
        private string _MaHoaDonBan;

        public string MaHoaDonBan
        {
            get { return _MaHoaDonBan; }
            set { _MaHoaDonBan = value; }
        }
        private string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }
   
        private string _NgayBan;

        public string NgayBan
        {
            get { return _NgayBan; }
            set { _NgayBan = value; }
        }
        private string _MaKhach;

        public string MaKhach
        {
            get { return _MaKhach; }
            set { _MaKhach = value; }
        }
        
        private float _TongTien;

        public float TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
        public DTO_HoaDon(string text)
        {

        }


        public DTO_HoaDon(string mhd, string mnv, string nb, string mk, float tt)
        {
            this.MaHoaDonBan = mhd;
            this.MaNhanVien = mnv;
            this.NgayBan = nb;
            this.MaKhach = mk;
            this.TongTien = tt;
            
        }


    }
}
