using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //lớp định nghĩa các table trong database của bạn
    public class DTO_HangHoa
    {
        private string _MaHang;

        public string MaHang
        {
            get { return _MaHang; }
            set { _MaHang = value; }
        }
        private string _TenHang;

        public string TenHang
        {
            get { return _TenHang; }
            set { _TenHang = value; }
        }
        private string _MaChatLieu;

        public string ChatLieu
        {
            get { return _MaChatLieu; }
            set { _MaChatLieu = value; }
        }
        private float _SoLuong;

        public float SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private float _DonGiaNhap;

        public float DonGiaNhap
        {
            get { return _DonGiaNhap; }
            set { _DonGiaNhap = value; }
        }
        private float _DonGiaBan;

        public float DonGiaBan
        {
            get { return _DonGiaBan; }
            set { _DonGiaBan = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    
        public DTO_HangHoa()
        {

        }
        public DTO_HangHoa(string mahang, string tenhang, string chatlieu, float soluong, float dongianhap, float dongiaban, string ghichu)
        {
            this.MaHang = mahang;
            this.TenHang = tenhang;
            this.ChatLieu = chatlieu;
            this.SoLuong = soluong;
            this.DonGiaNhap = dongianhap;
            this.DonGiaBan = dongiaban;
            this.GhiChu = ghichu;

        }
    }
}
