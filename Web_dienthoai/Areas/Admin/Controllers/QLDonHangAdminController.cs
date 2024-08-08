using System;
using System.Linq;
using System.Web.Mvc;
using Web_dienthoai.Areas.Admin.Data;
using Web_dienthoai.Areas.Admin.Filters;
using Web_dienthoai.Models;

namespace Web_dienthoai.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class QLDonHangAdminController : Controller
    {
        // GET: Admin/QLDonHang
        private QLDienThoai _context = new QLDienThoai();

        public ActionResult Index(string search, string sort)
        {
            var lstDH = (from d in _context.DonHang
                         join tt in _context.TrangThaiDH on d.TrangThaiID equals tt.TrangThaiID into tttemp
                         join kh in _context.KhachHang on d.KhachHangID equals kh.KhachHangID into khtemp
                         from tt in tttemp.DefaultIfEmpty()
                         from kh in khtemp.DefaultIfEmpty()
                         orderby d.DonHangID descending
                         select new DHDisplayVM()
                         {
                             DonHangID = d.DonHangID,
                             TenKhachHang = kh != null ? kh.TenKhachHang : "",
                             DiaChi = kh != null ? kh.DiaChi : "",
                             SoDienThoai = kh != null ? kh.SoDienThoai : "",
                             Ten = tt != null ? tt.Ten : "",
                             NgayDat = d.NgayDat,
                             TongTien = _context.CTDonHang
                                       .Where(ct => ct.DonHangID == d.DonHangID)
                                       .Sum(ct => (decimal?)(ct.SoLuong * ct.Gia)) ?? 0
                         }).ToList();
            /*search*/
            #region search, sort
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower(); // Chuyển đổi từ khóa tìm kiếm thành chữ thường
                lstDH = lstDH.Where(d => (d.DonHangID.ToString().Contains(search)) ||
                                         (d.TenKhachHang != null && d.TenKhachHang.ToLower().Contains(search))  ||
                                         (d.DiaChi != null && d.DiaChi.ToLower().Contains(search)) ||
                                         (d.SoDienThoai != null && d.SoDienThoai.Contains(search)) ||
                                         (d.Ten!=null&& d.Ten.ToLower().Contains(search))  ||
                                         (d.TongTien.ToString().Contains(search)) ||
                                          d.NgayDat!=null&& d.NgayDat.ToString().Contains(search)).ToList();
            }
            ViewBag.Search = search;
            /*sort*/
            ViewBag.MaDHSort = sort == "MaDH"? "MaDH_desc" : "MaDH";
            ViewBag.NgayDatSort = sort == "NgayDat" ? "NgayDat_desc" : "NgayDat";
            ViewBag.TenKHSort = sort == "TenKH" ? "TenKH_desc" : "TenKH";
            ViewBag.DiaChiSort = sort == "DiaChi" ? "DiaChi_desc" : "DiaChi";
            ViewBag.SDTSort = sort == "SDT" ? "SDT_desc" : "SDT";
            ViewBag.TinhTrangSort = sort == "TinhTrang" ? "TinhTrang_desc" : "TinhTrang";
            ViewBag.TongTienSort = sort == "TongTien" ? "TongTien_desc" : "TongTien";
            switch (sort)
            {
                case "MaDH":
                    lstDH = lstDH.OrderBy(d => d.DonHangID).ToList();
                    break;
                case "MaSP_desc":
                    lstDH = lstDH.OrderByDescending(d => d.DonHangID).ToList();
                    break;
                case "NgayDat":
                    lstDH = lstDH.OrderBy(d => d.NgayDat).ToList();
                    break;
                case "NgayDat_desc":
                    lstDH = lstDH.OrderByDescending(d => d.NgayDat).ToList();
                    break;
                case "TenKH":
                    lstDH = lstDH.OrderBy(d => d.TenKhachHang).ToList();
                    break;
                case "TenKH_desc":
                    lstDH = lstDH.OrderByDescending(d => d.TenKhachHang).ToList();
                    break;
                case "SDT":
                    lstDH = lstDH.OrderBy(d => d.SoDienThoai).ToList();
                    break;
                case "SDT_desc":
                    lstDH = lstDH.OrderByDescending(d => d.SoDienThoai).ToList();
                    break;
                case "DiaChi":
                    lstDH = lstDH.OrderBy(d => d.DiaChi).ToList();
                    break;
                case "DiaChi_desc":
                    lstDH = lstDH.OrderByDescending(d => d.DiaChi).ToList();
                    break;
                case "TinhTrang":
                    lstDH = lstDH.OrderBy(d => d.Ten).ToList();
                    break;
                case "TinhTrang_desc":
                    lstDH = lstDH.OrderByDescending(d => d.Ten).ToList();
                    break;
                case "TongTien":
                    lstDH = lstDH.OrderBy(d => d.TongTien).ToList();
                    break;
                case "TongTien_desc":
                    lstDH = lstDH.OrderByDescending(d => d.TongTien).ToList();
                    break;
            }
            #endregion

            ViewBag.message = lstDH.Count();
            return View(lstDH);
        }

        public ActionResult DetailDH(int id)
        {
            var lstCTDH = (from c in _context.CTDonHang
                           join s in _context.SanPham on c.SanPhamID equals s.SanPhamID into stemp
                           from s in stemp.DefaultIfEmpty()
                           join dh in _context.DonHang on c.DonHangID equals dh.DonHangID
                           join tt in _context.TrangThaiDH on dh.TrangThaiID equals tt.TrangThaiID
                           where dh.DonHangID == id
                           orderby c.CTDonHangID ascending
                           select new CTDonHangVM()
                           {
                               MaCTDH = c.CTDonHangID,
                               DonHangID = c.DonHangID,
                               TenSP = s != null ? s.TenSanPham : "",
                               SoLuong = c.SoLuong,
                               Gia = c.Gia,
                               HinhAnh = s.HinhAnh,
                               TongTien = (decimal)c.Gia * c.SoLuong,
                               TrangThaiID = dh.TrangThaiID,
                               TrangThaiName = tt.Ten,
                               ThanhTien = _context.CTDonHang
                                       .Where(ct => ct.DonHangID == dh.DonHangID)
                                       .Sum(ct => (decimal?)(ct.SoLuong * ct.Gia)) ?? 0
                           }).ToList();

            // Debug information
            foreach (var item in lstCTDH)
            {
                Console.WriteLine($"DonHangID: {item.MaCTDH}, TrangThaiID: {item.TrangThaiID}");
            }

            ViewBag.message = lstCTDH.Count();
            ViewBag.TrangThaiID = lstCTDH.FirstOrDefault()?.TrangThaiID ?? 0;

            return View(lstCTDH);
        }


        public ActionResult CheckDH (int id)
        {
            var dh = _context.DonHang.Where(x => x.DonHangID == id).FirstOrDefault();

            dh.TrangThaiID = 2;

            _context.SaveChanges();
            return RedirectToAction("Index", "QLDonHangAdmin");
        }

        public ActionResult CancelDH(int id)
        {
            var dh = _context.DonHang.FirstOrDefault(x => x.DonHangID == id);

            if (dh == null)
            {
                // Handle the case where the order was not found, e.g., return an error view or message
                return HttpNotFound(); // Hoặc sử dụng một cách xử lý khác như trả về một trang thông báo lỗi
            }

            // Tiếp tục xử lý khi đơn hàng được tìm thấy
            dh.TrangThaiID = 3;
            _context.SaveChanges();

            return RedirectToAction("Index", "QLDonHangAdmin");
        }
    }
}