using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;
using Web_dienthoai.Areas.Admin.Filters;
using Web_dienthoai.Models;

namespace Web_dienthoai.Areas.Admin.Controllers
{
    [AdminAuthorization]

    public class QLThongKeAdminController : Controller
    {
        // GET: Admin/QLThongKeAdmin
        private QLDienThoai db = new QLDienThoai();

        // GET: Admin/QLThongKeAdmin
        public ActionResult Index()
        {
            #region chart doanh thu theo tháng
            var revenueData = db.DonHang
                .Where(dh => dh.TrangThaiID == 2 && dh.NgayDat.HasValue)
                .GroupBy(dh => new { dh.NgayDat.Value.Year, dh.NgayDat.Value.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Revenue = g.Sum(dh => dh.CTDonHang.Sum(ct => (decimal?)ct.SoLuong * ct.Gia) ?? 0)
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            var labels = revenueData.Select(rd => $"{rd.Month}/{rd.Year}").ToArray();
            var values = revenueData.Select(rd => rd.Revenue).ToArray();

            ViewBag.Labels = labels;
            ViewBag.Values = values;
            #endregion

            #region chart top 5 sản phẩm bán chạy trong tháng
            var thangHienTai = DateTime.Now.Month;
            var namHienTai = DateTime.Now.Year;

            var sanPhamBanChay = (from ct in db.CTDonHang
                                  join sp in db.SanPham on ct.SanPhamID equals sp.SanPhamID
                                  join dh in db.DonHang on ct.DonHangID equals dh.DonHangID
                                  where dh.NgayDat.HasValue &&
                                      dh.NgayDat.Value.Month == thangHienTai &&
                                      dh.NgayDat.Value.Year == namHienTai &&
                                      dh.TrangThaiID ==2
                                  group ct by new { ct.SanPhamID, sp.TenSanPham } into spGroup
                                  select new
                                  {
                                      TenSP = spGroup.Key.TenSanPham,
                                      SoLuongBan = spGroup.Sum(ct => ct.SoLuong)
                                  })
                                  .OrderByDescending(sp => sp.SoLuongBan)
                                  .Take(5) // Lấy top 5 sản phẩm bán chạy nhất
                                  .ToList();
                        
            ViewBag.TopSellingProductsLabels = JsonConvert.SerializeObject(sanPhamBanChay.Select(sp => sp.TenSP).ToArray());
            ViewBag.TopSellingProductsValues = JsonConvert.SerializeObject(sanPhamBanChay.Select(sp => sp.SoLuongBan).ToArray());
            #endregion

            return View();
        }
    }

}

