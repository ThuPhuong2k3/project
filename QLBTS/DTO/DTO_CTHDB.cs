using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTHDB
    {
        private string _MaHoaDonBan;

        public string MaHoaDonBan
        {
            get { return _MaHoaDonBan; }
            set { _MaHoaDonBan = value; }
        }
        private string _MaHang;

        public string MaHang
        {
            get { return _MaHang; }
            set { _MaHang = value; }
        }
        private float _SoLuong;

        public float SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private float _DonGia;

        public float DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        private float _GiamGia;

        public float GiamGia
        {
            get { return _GiamGia; }
            set { _GiamGia = value; }
        }
        private float _ThanhTien;

        public float ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
        public DTO_CTHDB()
        {

        }
        public DTO_CTHDB(string mahoadonban, string mahang, float soluong, float dongia, float giamgia, float thanhtien)
        {
            this.MaHoaDonBan = mahoadonban;
            this.MaHang = mahang;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.GiamGia = giamgia;
            this.ThanhTien = thanhtien;
        }
    }
}
