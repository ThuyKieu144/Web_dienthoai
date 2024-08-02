using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopOnline.Areas.Admin.Data
{
    public class SachVM
    {
        [Display(Name = "Mã sách")]
        public int MaSach { get; set; }
        [Display(Name ="Tên sách")]
        public string TenSach { get; set; }
        [Display(Name = "Giá bán") ]
        public decimal? GiaBan { get; set; }
        [Display(Name = "Mô tả"),DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
        [Display(Name = "Ngày cập nhật"),DataType(DataType.Date)]
        public DateTime? NgayCapNhat { get; set; }
        [Display(Name = "Ảnh bìa")]

        public string AnhBia { get; set; }
        [Display(Name = "Số lượng còn")]

        public int? SoLuongTon { get; set; }
        [Display(Name = "Tên chủ đề")]
        public int? MaChuDe { get; set; }
        [Display(Name = "Tên xuất bản")]

        public int? MaNXB { get; set; }

        [Display(Name = "Mới")]
        public int? Moi { get; set; }
    }
}