using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //lớp định nghĩa các table trong database của bạ
    public class DTO_KhachHang
    {
        private string _MaKhach;

        public string MaKhach
        {
            get { return _MaKhach; }
            set { _MaKhach = value; }
        }
        private string _TenKhach;

        public string TenKhach
        {
            get { return _TenKhach; }
            set { _TenKhach = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _DienThoai;
        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }

        public DTO_KhachHang()
        {

        }

        public DTO_KhachHang(string mk, string tk, string dc, string dt)
        {
            this.MaKhach = mk;
            this.TenKhach = tk;
            this.DiaChi = dc;
            this.DienThoai = dt;
        }
    }
}
