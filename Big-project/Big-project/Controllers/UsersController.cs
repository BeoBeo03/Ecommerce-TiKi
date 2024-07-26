
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Big_project.Models;
using System.Net;

namespace Big_project.Controllers
{
    public class UsersController : Controller
    {
        private TikiShopEntities db = new TikiShopEntities();
        // GET: Users
      
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.EmailCus))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Họ và tên không được để trống");
                if (string.IsNullOrEmpty(cust.AdressCus))
                    ModelState.AddModelError(string.Empty, "Địa chỉ không được để trống");
                if (string.IsNullOrEmpty(cust.PhoneCus))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");

                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhậpnày hay chưa
                var khachhang = db.Customer.FirstOrDefault(k => k.EmailCus == cust.EmailCus);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng ký" );
               

                if (ModelState.IsValid)
                {
                    //cust.phanquyen=2;
                    db.Customer.Add(cust);
                    db.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.EmailCus))
                    ModelState.AddModelError(string.Empty, "Email  không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    
                  
                    if(cust.EmailCus=="admin@gmail.com"&& cust.PassCus=="123")
                    {
                        ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                        Session["TaiKhoanAdmin"] = "Admin";
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        var khachhang = db.Customer.FirstOrDefault(k => k.EmailCus == cust.EmailCus && k.PassCus == cust.PassCus);
                        if (khachhang != null)
                        {
                            ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                            Session["TaiKhoan"] = khachhang;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        }
                    }
                  
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["Taikhoan"] = null;
            return Redirect("/");
        }
    }

   
}
