using hidohieu.Areas.Admin.Models;
using hidohieu.Models;
using hidohieu.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hidohieu.Controllers
{
    public class UserController : Controller
    {
        //Khởi tạo biến dữ liệu : db
        PCDbContext db = new PCDbContext();

        [HttpGet]
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //GET: /User/Register : đăng kí tài khoản thành viên
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //POST: /User/Register : thực hiện lưu dữ liệu đăng ký tài khoản thành viên
        public ActionResult Register(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserProcess();

                var kh = new KhachHang();

                if (user.CheckUsername(model.TaiKhoan, model.MatKhau) == 1)
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else if (user.CheckUsername(model.TaiKhoan, model.MatKhau) == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else
                {
                    kh.TaiKhoan = model.TaiKhoan;
                    kh.MatKhau = model.MatKhau;
                    kh.TenKH = model.TenKH;
                    kh.Email = model.Email;
                    kh.DiaChi = model.DiaChi;
                    kh.DienThoai = model.DienThoai;
                    kh.NgaySinh = model.NgaySinh;
                    kh.NgayTao = DateTime.Now;
                    kh.TrangThai = true;

                    var result = user.InsertUser(kh);

                    if (result > 0)
                    {
                        //Session["User"] = result;
                        ModelState.Clear();
                        //return Redirect("/Home/");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
                            
            }

            return View(model);
        }

        //GET : /User/LoginPage : trang đăng nhập
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }

        //POST : /User/LoginPage : thực hiện đăng nhập
        [HttpPost]
        public ActionResult LoginPage(LoginModel model)
        {
            //kiểm tra hợp lệ dữ liệu
            if (ModelState.IsValid)
            {
                //gọi hàm đăng nhập trong AdminProcess và gán dữ liệu trong biến model
                var result = new UserProcess().Login(model.TaiKhoan, model.MatKhau);
                //Nếu đúng
                if (result == 1)
                {
                    //gán Session["LoginAdmin"] bằng dữ liệu đã đăng nhập
                    Session["User"] = model.TaiKhoan;
                    //trả về trang chủ
                    return RedirectToAction("Index", "Home");
                }
                //nếu tài khoản không tồn tại
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    //return RedirectToAction("LoginPage", "User");
                }
                //nếu nhập sai tài khoản hoặc mật khẩu
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                    //return RedirectToAction("LoginPage", "User");
                }
            }

            return View();
        }

        //GET : /User/Login : đăng nhập tài khoản
        //Parital View : Login
        [HttpGet]
        [ChildActionOnly]
        public PartialViewResult Login()
        {
            return PartialView();
        }

        //POST : /User/Login : thực hiện đăng nhập
        [HttpPost]
        [ChildActionOnly]
        public ActionResult Login(LoginModel model)
        {
            //kiểm tra hợp lệ dữ liệu
            if (ModelState.IsValid)
            {
                //gọi hàm đăng nhập trong AdminProcess và gán dữ liệu trong biến model
                var result = new UserProcess().Login(model.TaiKhoan, model.MatKhau);

                //Nếu đúng
                if (result == 1)
                {
                    //gán Session["LoginAdmin"] bằng dữ liệu đã đăng nhập
                    Session["User"] = model.TaiKhoan;
                    //trả về trang chủ
                    return RedirectToAction("Index", "Home");
                }
                //nếu tài khoản không tồn tại
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    //return RedirectToAction("LoginPage", "User");
                }
                //nếu nhập sai tài khoản hoặc mật khẩu
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                    //return RedirectToAction("LoginPage", "User");
                }
            }

            return PartialView();
        }

        //GET : /User/Logout : đăng xuất tài khoản khách hàng
        [HttpGet]
        public ActionResult Logout()
        {
            Session["User"] = null;

            return RedirectToAction("Index", "Home");
        }

        //GET : /User/EditUser : cập nhật thông tin khách hàng
        [HttpGet]
        public ActionResult EditUser()
        {
            //lấy dữ liệu từ session
            var model = Session["User"];

            if (ModelState.IsValid)
            {
                //tìm tên tài khoản
                var result = db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == model);

                //trả về dữ liệu tương ứng
                return View(result);
            }

            return View();
        }

        //POST : /User/EditUser : thực hiện việc cập nhật thông tin khách hàng
        [HttpPost]
        public ActionResult EditUser(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                //gọi hàm cập nhật thông tin khách hàng
                var result = new UserProcess().UpdateUser(model);

                //thực hiện kiểm tra
                if (result == 1)
                {
                    return RedirectToAction("EditUser");                  
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            }

            return View(model);
        }

    }
}