namespace Web_dienthoai.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDonHang")]
    public partial class CTDonHang
    {
        public int CTDonHangID { get; set; }

        public int? DonHangID { get; set; }

        public int? SanPhamID { get; set; }

        public int? SoLuong { get; set; }

        public decimal? Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
