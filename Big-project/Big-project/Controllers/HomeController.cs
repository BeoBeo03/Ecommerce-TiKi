using Big_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Big_project.Controllers
{
    public class HomeController : Controller
    {
        private TikiShopEntities db = new TikiShopEntities();
        private List<Products> Index (int soluong)
        {
            return db.Products.Take(soluong).ToList();
        }
        public ActionResult Index(string category, int? page, string SearchString)
        {

            var products = db.Products;
            //Tìm kiếm chuỗi truy vấn theo NamePro, nếu chuỗi truy vấn SearchString khác rỗng, null
            if (!String.IsNullOrEmpty(SearchString))
            {

                SearchString = SearchString.ToLower();
                var kq = products.Where(s => s.TenIP.ToLower().Contains(SearchString));
                return View(kq.ToList());
               
            }
            return View(products.ToList());

            /*if (category == null)
            {
                int pageSize = 12;
                int pageNum = (page ?? 1);
                var product = db.Products.OrderByDescending(x => x.TenIP);
                return View(product.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var product = db.Products.OrderByDescending(x => x.TenIP).Where(p => p.DanhMuc == category);
                return View(product);
            }*/
            
        }
       
        public ActionResult Description()
        {
            return View();
        }
        public ActionResult GioiThieuTiki()
        {
            return View();
        }
        public ActionResult HuongDanDatHang()
        {
            return View();
        }
       
        public ActionResult BanHangCungTiki()
        {
            return View();
        }
        public ActionResult GTTikiXu()
        {
            return View();
        }
        public ActionResult New()
        {
            return View();
        }


    }
}