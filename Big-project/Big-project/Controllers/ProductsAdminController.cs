using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Big_project.Models;

namespace Big_project.Controllers
{
    public class ProductsAdminController : Controller
    {
        private TikiShopEntities db = new TikiShopEntities();

        // GET: ProductsAdmin
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category1);
            return View(products.ToList());
        }

        // GET: ProductsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: ProductsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.IDSP = new SelectList(db.Category, "IDSP", "IDCate");
            return View();
        }

        // POST: ProductsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenIP,Donvitinh,Dongiabd,HinhSP,star,Cauhinh,Dongia,Hinhminhhoa1,Hinhminhhoa2,Hinhminhhoa3,Hinhminhhoa4,Screen,HDH,CameraAfter,CameraBefore,Chip,Ram,Rom,Sim,Pin,sale,Feedback,Imgdescription,Soluongban,DanhMuc")] Products products)
        {
            if (ModelState.IsValid)
            {
               
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSP = new SelectList(db.Category, "IDSP", "IDCate", products);
            return View(products);
        }

        // GET: ProductsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSP = new SelectList(db.Category, "IDSP", "IDCate", products.IDSP);
            return View(products);
        }

        // POST: ProductsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSP,TenIP,Donvitinh,Dongiabd,HinhSP,star,Cauhinh,Dongia,Hinhminhhoa1,Hinhminhhoa2,Hinhminhhoa3,Hinhminhhoa4,Screen,HDH,CameraAfter,CameraBefore,Chip,Ram,Rom,Sim,Pin,sale,Feedback,Imgdescription,Soluongban,DanhMuc")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSP = new SelectList(db.Category, "IDSP", "IDCate", products.IDSP);
            return View(products);
        }

        // GET: ProductsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: ProductsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
