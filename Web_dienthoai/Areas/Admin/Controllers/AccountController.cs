using System.Linq;
using System.Web.Mvc;
using Web_dienthoai.Models;

namespace Web_dienthoai.Areas.Admin.Controllers
{
     
    public class AccountController : Controller
    {
        // GET: Admin/Account
        private QLDienThoai _context = new QLDienThoai();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            // Kiểm tra thông tin đăng nhập từ database
            var account = _context.Account.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (account != null)
            {
                // Lưu thông tin vào session
                Session["Username"] = account.Username;
                Session["Role"] = account.Role;
                Session["Email"] = account.Email;

                // Kiểm tra vai trò của tài khoản và chuyển hướng
                if (account.Role == "Admin")
                {
                    return RedirectToAction("Index", "DefaultAdmin", new { area = "Admin" });
                }
                else if (account.Role == "User")
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ViewBag.ErrorMessage = "Vai trò không hợp lệ.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}