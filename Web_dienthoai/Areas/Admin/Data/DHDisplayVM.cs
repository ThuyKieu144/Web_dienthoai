using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_dienthoai.Areas.Admin.Data
{
    public class DHDisplayVM
    {
        [Display(Name = "Mã đơn hàng")]

        public int DonHangID { get; set; }

        [Display(Name = "Ngày đặt"), DataType(DataType.Date)]
        public DateTime? NgayDat { get; set; }

        [Display(Name = "Tên khách hàng")]
        public string TenKhachHang { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }
        [Display(Name = "Trạng thái")]
        public string Ten { get; set; }
        [Display(Name ="Tổng tiền")]
        public decimal? TongTien { get; set; }
    }
}