using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //lớp định nghĩa các table trong database của bạn
    public class DTO_NhanVien
    {
        private string _MaNhanVien;

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }
        private string _TenNhanVien;

        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; }
        }
        private string _GioiTinh;

        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        private string _NgaySinh;

        public string NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        public DTO_NhanVien()
        {

        }
        public DTO_NhanVien(string manhanvien, string tennhanvien, string gioitinh, string diachi, string ngaysinh)
        {
            this.MaNhanVien = manhanvien;
            this.TenNhanVien = tennhanvien;
            this.GioiTinh = gioitinh;
            this.DiaChi = diachi;
            this.NgaySinh = ngaysinh;
        }
    }
}
