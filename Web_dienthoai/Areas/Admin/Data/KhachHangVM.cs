using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_dienthoai.Areas.Admin.Data
{
    public class KhachHangVM
    {
        public int KhachHangID { get; set; }

        public string TenKhachHang { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public string HinhAnh { get; set; }
    }
}