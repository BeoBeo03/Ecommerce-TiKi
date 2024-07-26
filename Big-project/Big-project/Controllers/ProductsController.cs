using Big_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace Big_project.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private TikiShopEntities db = new TikiShopEntities();
        public ActionResult ProductList(string SearchString)
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

            /*int pageSize = 12;
            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            // Nếu page = null thì đặt lại page là 1.
            if (page == null) page = 1;
            // Trả về các product được phân trang theo kích thước và số trang.
            return View(products.ToPagedList(pageNumber, pageSize));*/


        }

    }
}