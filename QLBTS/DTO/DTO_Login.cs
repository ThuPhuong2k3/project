using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //lớp định nghĩa các table trong database của bạn
    public class DTO_Login
    {
        private string _TaiKhoan;

        public string TaiKhoan
        {
            get { return _TaiKhoan; }
            set { _TaiKhoan = value; }
        }
        private string _MatKhau;

        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }

        public DTO_Login()
        {

        }
        public DTO_Login(string taikhoan, string matkhau)
        {
            this.TaiKhoan = taikhoan;
            this.MatKhau = matkhau;
        }

    }
}
