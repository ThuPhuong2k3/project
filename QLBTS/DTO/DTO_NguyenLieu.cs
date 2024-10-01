using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    // lớp định nghĩa các table trong database của bạn
    public class DTO_NguyenLieu
    {
        private string _MaNguyenLieu;

        public string MaNguyenLieu
        {
            get { return _MaNguyenLieu; }
            set { _MaNguyenLieu = value; }
        }
        private string _TenNguyenLieu;

        public string TenNguyenLieu
        {
            get { return _TenNguyenLieu; }
            set { _TenNguyenLieu = value; }
        }
        public DTO_NguyenLieu()
        {

        }
        public DTO_NguyenLieu(string manguyenlieu, string tennguyenlieu)
        {
            this.MaNguyenLieu = manguyenlieu;
            this._TenNguyenLieu = tennguyenlieu;
        }


    }
}
