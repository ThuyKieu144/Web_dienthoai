using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web_dienthoai.Areas.Admin.Data
{
    public class SPDisplayVM
    {
        [Display(Name = "Mã sản phẩm")]
        public int MaSP { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        public string TenSP { get; set; }

        [DisplayName("Giá bán"), DataType(DataType.Currency)]
        public decimal? Gia { get; set; }
        [Display(Name = "Số Lượng Còn")]
        public int? SoLuongTon { get; set; }
        [Display(Name = "Tên Nhà Cung Cấp")]

        public string TenNCC { get; set; }
        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
    }
}