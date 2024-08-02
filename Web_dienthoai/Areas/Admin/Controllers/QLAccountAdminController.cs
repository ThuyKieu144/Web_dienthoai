using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web_dienthoai.Areas.Admin.Data;
using Web_dienthoai.Areas.Admin.Filters;
using Web_dienthoai.Models;

namespace Web_dienthoai.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class QLAccountAdminController : Controller
    {
        private QLDienThoai _context = new QLDienThoai();

        public ActionResult Index(string search, string sort)
        {
            var lstAccounts = (from a in _context.Account
                               orderby a.AccountID descending
                               select new AccountVM()
                               {
                                   AccountID = a.AccountID,
                                   Username = a.Username,
                                   Email = a.Email,
                                   Role = a.Role
                               }).ToList();

            /* search */
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                lstAccounts = lstAccounts.Where(a =>
                    (a.Username != null && a.Username.ToLower().Contains(search)) ||
                    (a.Email != null && a.Email.ToLower().Contains(search)) ||
                    (a.Role != null && a.Role.ToLower().Contains(search))).ToList();
            }
            ViewBag.Search = search;

            /* sort */
            ViewBag.MaAccSort = sort == "MaAcc" ? "MaAcc_desc" : "MaAcc";
            ViewBag.UsernameSort = sort == "Username" ? "Username_desc" : "Username";
            ViewBag.EmailSort = sort == "Email" ? "Email_desc" : "Email";
            ViewBag.RoleSort = sort == "Role" ? "Role_desc" : "Role";

            switch (sort)
            {
                case "MaAcc":
                    lstAccounts = lstAccounts.OrderBy(a => a.AccountID).ToList();
                    break;
                case "MaAcc_desc":
                    lstAccounts = lstAccounts.OrderByDescending(a => a.AccountID).ToList();
                    break;
                case "Username":
                    lstAccounts = lstAccounts.OrderBy(a => a.Username).ToList();
                    break;
                case "Username_desc":
                    lstAccounts = lstAccounts.OrderByDescending(a => a.Username).ToList();
                    break;
                case "Email":
                    lstAccounts = lstAccounts.OrderBy(a => a.Email).ToList();
                    break;
                case "Email_desc":
                    lstAccounts = lstAccounts.OrderByDescending(a => a.Email).ToList();
                    break;
                case "Role":
                    lstAccounts = lstAccounts.OrderBy(a => a.Role).ToList();
                    break;
                case "Role_desc":
                    lstAccounts = lstAccounts.OrderByDescending(a => a.Role).ToList();
                    break;
            }
            ViewBag.Message = lstAccounts.Count();
            return View(lstAccounts);
        }

        public ActionResult IndexKH(string search, string sort)
        {
            var lstKhachHang = (from a in _context.KhachHang
                               orderby a.KhachHangID descending
                               select new KhachHangVM()
                               {
                                   KhachHangID = a.KhachHangID,
                                   TenKhachHang = a.TenKhachHang,
                                   Email = a.Email,
                                   DiaChi = a.DiaChi,
                                   SoDienThoai = a.SoDienThoai
                               }).ToList();

            /* search */
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                lstKhachHang = lstKhachHang.Where(a =>
                    (a.TenKhachHang != null && a.TenKhachHang.ToLower().Contains(search)) ||
                    (a.Email != null && a.Email.ToLower().Contains(search)) ||
                    (a.DiaChi != null && a.DiaChi.ToLower().Contains(search)) ||
                    (a.SoDienThoai != null && a.SoDienThoai.ToLower().Contains(search))).ToList();
            }
            ViewBag.Search = search;

            /* sort */
            ViewBag.MaKhachHangSort = sort == "MaKH" ? "MaKH_desc" : "MaKH";
            ViewBag.TenKhachHangSort = sort == "TenKH" ? "TenKH_desc" : "TenKH";
            ViewBag.EmailKHSort = sort == "EmailKH" ? "EmailKH_desc" : "EmailKH";
            ViewBag.DiaChiKHSort = sort == "DiaChiKH" ? "DiaChi_desc" : "DiaChiKH";
            ViewBag.SdtSort = sort == "SDT" ? "SDT_desc" : "SDT";

            switch (sort)
            {
                case "MaKH":
                    lstKhachHang = lstKhachHang.OrderBy(a => a.KhachHangID).ToList();
                    break;
                case "MaKH_desc":
                    lstKhachHang = lstKhachHang.OrderByDescending(a => a.KhachHangID).ToList();
                    break;
                case "TenKH":
                    lstKhachHang = lstKhachHang.OrderBy(a => a.TenKhachHang).ToList();
                    break;
                case "TenKH_desc":
                    lstKhachHang = lstKhachHang.OrderByDescending(a => a.TenKhachHang).ToList();
                    break;
                case "EmailKH":
                    lstKhachHang = lstKhachHang.OrderBy(a => a.Email).ToList();
                    break;
                case "EmailKH_desc":
                    lstKhachHang = lstKhachHang.OrderByDescending(a => a.Email).ToList();
                    break;
                case "DiaChiKH":
                    lstKhachHang = lstKhachHang.OrderBy(a => a.DiaChi).ToList();
                    break;
                case "DiaChiKH_desc":
                    lstKhachHang = lstKhachHang.OrderByDescending(a => a.DiaChi).ToList();
                    break;
                case "SDT":
                    lstKhachHang = lstKhachHang.OrderBy(a => a.SoDienThoai).ToList();
                    break;
                case "SDT_desc":
                    lstKhachHang = lstKhachHang.OrderByDescending(a => a.SoDienThoai).ToList();
                    break;
            }
            ViewBag.Message = lstKhachHang.Count();
            return View(lstKhachHang);
        }
        public ActionResult DetailAccount(int id)
        {
            var account = _context.Account.Where(a => a.AccountID == id).Select(a => new AccountVM()
            {
                AccountID = a.AccountID,
                Username = a.Username,
                Email = a.Email,
                Role = a.Role
            }).FirstOrDefault();

            return View(account);
        }
                
        [HttpGet]
        public ActionResult AddAccount()
        {
            var roles = new List<SelectListItem>
            {
                new SelectListItem { Text = "Admin", Value = "Admin" },
                new SelectListItem { Text = "User", Value = "User" }
            };

            ViewBag.RoleList = roles;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAccount(AccountVM formData)
        {
            if (ModelState.IsValid)
            {
                var account = new Account()
                {
                    Username = formData.Username,
                    Password = formData.Password, // Ensure to hash passwords in a real application
                    Email = formData.Email,
                    Role = formData.Role
                };

                _context.Account.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index", "QLAccountAdmin");
            }
            return View(formData);
        }

        [HttpGet]
        public ActionResult DeleteAccount(int id)
        {
            var account = _context.Account.Where(a => a.AccountID == id).Select(a => new AccountVM()
            {
                AccountID = a.AccountID,
                Username = a.Username,
                Email = a.Email,
                Role = a.Role
            }).FirstOrDefault();
            return View(account);
        }

        [HttpPost, ActionName("DeleteAccount")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteAccount(int id)
        {
            var account = _context.Account.Find(id);
            if (account == null)
            {
                return RedirectToAction("Index", "QLAccountAdmin");
            }
            _context.Account.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index", "QLAccountAdmin");
        }

        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            var roles = new List<SelectListItem>
            {
                new SelectListItem { Text = "Admin", Value = "Admin" },
                new SelectListItem { Text = "User", Value = "User" }
            };

            ViewBag.RoleList = roles;

            var account = (from item in _context.Account
                           where item.AccountID == id
                           select new EditAccountVM()
                           {
                               AccountID = item.AccountID,
                               Username = item.Username,
                               Email = item.Email,
                               Role = item.Role
                           }).FirstOrDefault();

            if (account == null)
            {
                return RedirectToAction("Index", "QLAccountAdmin");
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount(EditAccountVM formData)
        {
            if (ModelState.IsValid)
            {
                var account = _context.Account.Where(x => x.AccountID == formData.AccountID).FirstOrDefault();
                if (account == null)
                {
                    return RedirectToAction("Index", "QLAccountAdmin");
                }

                if (!string.IsNullOrWhiteSpace(formData.EditPassword) && !string.IsNullOrWhiteSpace(formData.NewPassword))
                {
                    // Kiểm tra mật khẩu hiện tại
                    if ( account.Password != formData.EditPassword)
                    {
                        ModelState.AddModelError("EditPassword", "Mật khẩu hiện tại không chính xác.");
                    }
                    else
                    {
                        account.Password = formData.NewPassword;                    
                    }
                }
                if (ModelState.IsValid)
                {
                    account.Username = formData.Username;
                    account.Email = formData.Email;
                    account.Role = formData.Role;

                    _context.SaveChanges();
                    return RedirectToAction("Index", "QLAccountAdmin");
                }
            }

            // Logging or debugging to understand why ModelState is not valid
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
            }

            var roles = new List<SelectListItem>
            {
                new SelectListItem { Text = "Admin", Value = "Admin" },
                new SelectListItem { Text = "User", Value = "User" }
            };
            ViewBag.RoleList = roles;

            return View(formData);
        }

    }
}
