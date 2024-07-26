using Big_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Big_project.Controllers
{
    public class AdminController : Controller
    {
        private TikiShopEntities db = new TikiShopEntities();
        public ActionResult Index1()
        {
            ViewBag.CountUser = db.Customer.Count();
            ViewBag.CountProduct = db.Products.Count();
            ViewBag.CountOrder = db.OrderPro.Count();
            
            ViewBag.OrderList = db.OrderPro.ToList();
            
            return View();
        }
        // GET: Admin
        
        public ActionResult Index()
        {
            if (Session["TaiKhoanAdmin"] != null)
            {
                var customer = db.Customer;
                return View(customer.ToList());
            }
             return RedirectToAction("Login", "Users");

        }
        

    }
}