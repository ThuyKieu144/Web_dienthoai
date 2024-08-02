using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopOnline.Areas.Admin.Data
{
    public class SachDisplayVM
    {
        [DisplayName("Mã sách")]
        public int MaSach { get; set; }
        [DisplayName("Tên sách")]
        public string TenSach { get; set; }
        [DisplayName("Giá bán"), DataType(DataType.Currency)]
        public decimal? GiaBan { get; set; }
        [DisplayName("Ngày cập nhật"), DataType(DataType.Date)]
        public DateTime? NgayCapNhat { get; set; }
        [DisplayName("Ảnh bìa")]
        public string AnhBia { get; set; }
        [DisplayName("Số lượng còn")]
        public int? SoLuongTon { get; set; }
        [DisplayName("Chủ đề")]
        public string TenChuDe { get; set; }
        [DisplayName("Nhà xuất bản")]
        public string TenNhaXuatBan { get; set; }
    }
}