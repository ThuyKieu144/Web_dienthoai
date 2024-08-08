using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Web_dienthoai.Models;

namespace Web_dienthoai.Controllers
{
    public class HTSanPhamController : Controller
    {
        // GET: HTSanPham
        public QLDienThoai _db = new QLDienThoai();

        // GET: HTSanPham
        public ActionResult Index()
        {
            //var sanPhams = _db.SanPhams.ToList();
            return View();
        }

        public ActionResult Sidebar()
        {
            List<SanPham> lis = _db.SanPham.Take(5).ToList();
            List<NhaCungCap> NCC = _db.NhaCungCap.Take(5).ToList();
            ViewBag.ThuongHieu = NCC;
            return View(lis);
        }

        public ActionResult Sale()
        {
            List<SanPham> lis = _db.SanPham.Take(5).ToList();
            List<NhaCungCap> NCC = _db.NhaCungCap.Take(5).ToList();
            ViewBag.ThuongHieu = NCC;
            return View(lis);
        }

        public ActionResult Hot()
        {
            List<SanPham> lis = _db.SanPham.Take(5).ToList();
            List<NhaCungCap> NCC = _db.NhaCungCap.Take(5).ToList();
            ViewBag.ThuongHieu = NCC;
            return View(lis);
        }

        public ActionResult ChinhHang()
        {
            List<SanPham> lis = _db.SanPham.Take(5).ToList();
            List<NhaCungCap> NCC = _db.NhaCungCap.Take(5).ToList();
            ViewBag.ThuongHieu = NCC;
            return View(lis);
        }

        public ActionResult Goiy()
        {
            List<SanPham> lis = _db.SanPham.Take(5).ToList();
            List<NhaCungCap> NCC = _db.NhaCungCap.Take(5).ToList();
            ViewBag.ThuongHieu = NCC;
            return View(lis);
        }


        public ActionResult Details(int id)
        {
            var sanPham = _db.SanPham.Find(id);
            return View(sanPham);
        }

        public ActionResult ProductsByBrand(int brandId)
        {
            var productsByBrand = _db.SanPham.Where(sp => sp.NhaCungCapID == brandId).ToList();
            var brand = _db.NhaCungCap.Find(brandId);
            ViewBag.BrandName = brand?.TenNhaCungCap ?? "Thương hiệu không xác định";

            return View("ProductsByBrand", productsByBrand);
        }

        public ActionResult ProductsByPrice(string[] priceRange)
        {
            var products = _db.SanPham.AsQueryable();

            if (priceRange != null && priceRange.Length > 0)
            {
                var productList = new List<SanPham>();
                foreach (var range in priceRange)
                {
                    var rangeParts = range.Split('-');
                    decimal minPrice = decimal.Parse(rangeParts[0]);
                    decimal maxPrice;
                    if (rangeParts.Length > 1 && !string.IsNullOrEmpty(rangeParts[1]))
                    {
                        maxPrice = decimal.Parse(rangeParts[1]);
                    }
                    else
                    {
                        maxPrice = decimal.MaxValue;
                    }

                    var filteredProducts = products.Where(p => p.Gia >= minPrice && p.Gia <= maxPrice).ToList();
                    productList.AddRange(filteredProducts);
                }

                // Loại bỏ các sản phẩm trùng lặp nếu có
                products = productList.Distinct().AsQueryable();
            }

            // Lưu các giá trị lọc vào ViewBag
            ViewBag.SelectedPriceRange = string.Join(", ", priceRange);

            return View(products.ToList());
        }


    }
}