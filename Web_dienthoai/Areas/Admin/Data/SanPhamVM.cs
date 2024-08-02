using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_dienthoai.Areas.Admin.Data
{
    public class SanPhamVM
    {
        [Display(Name = "Mã sản phẩm")]
        public int SanPhamID { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Tên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự.")]

        public string TenSanPham { get; set; }

        [DisplayName("Giá bán"), DataType(DataType.Currency)]
        [Required(ErrorMessage = "Giá là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải là số và lớn hơn 0.")]
        public decimal? Gia { get; set; }
        [Display(Name = "Số Lượng Còn")]
        [Required(ErrorMessage = "Số lượng còn là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải là số và lớn hơn 0.")]
        public int? SoLuongTon { get; set; }
        [Display(Name = "Tên Nhà Cung Cấp")]

        public int? NhaCungCapID { get; set; }
        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Mô tả"), DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Mô tả là bắt buộc.")]
        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string MoTa { get; set; }
    }
}