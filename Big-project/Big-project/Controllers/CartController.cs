using Big_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Big_project.Controllers
{
    public class CartController : Controller
    {
        private TikiShopEntities db = new TikiShopEntities();
        // GET: Cart
        public List<CartItem> GetCart()
        {
            List<CartItem> myCart = Session["GioHang"] as
            List<CartItem>;
            //Nếu giỏ hàng chưa tồn tại thì tạo mới và đưa vào Session
            if (myCart == null)
            {
                myCart = new List<CartItem>();
                Session["GioHang"] = myCart;
            }
            return myCart;
        }
        public ActionResult AddToCart(int id)
        {
            //Lấy giỏ hàng hiện tại
            List<CartItem> myCart = GetCart();
            CartItem currentProduct = myCart.FirstOrDefault(p =>p.IDSP == id);
            if (currentProduct == null)
            {
                currentProduct = new CartItem(id);
                myCart.Add(currentProduct);
            }
            else
            {
                currentProduct.Number++; //Sản phẩm đã có trong giỏ thì
                //tăng số lượng lên 1
            }
            return RedirectToAction("Index", "Home", new{
                id = id
            });
        }
        private int GetTotalNumber()
        {
            int totalNumber = 0;
            List<CartItem> myCart = GetCart();
            if (myCart != null)
                totalNumber = myCart.Sum(sp => sp.Number);
            return totalNumber;
        }
        
        private decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            List<CartItem> myCart = GetCart();
            if (myCart != null)
                totalPrice = myCart.Sum(sp => sp.FinalPrice());
            return totalPrice;
        }
        public ActionResult GetCartInfo()
        {
            List<CartItem> myCart = GetCart();
            //Nếu giỏ hàng trống thì trả về trang ban đầu
            if (myCart == null || myCart.Count == 0)
            {
                return RedirectToAction("EmpryCart", "Cart");
            }
            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return View(myCart); //Trả về View hiển thị thông tin giỏ
        }
        public ActionResult EmpryCart()
        {
            ViewBag.EmptyNotification = "Chưa có sản phẩm nào trong giỏ hàng";
            return View();
        }
        public ActionResult CartPartial()
        {
            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return PartialView();
        }
        public ActionResult XoaMatHang(int MaSP)
        {
            
            List<CartItem> gioHang = GetCart();
            //Lấy sản phẩm trong giỏ hàng
            var sanpham = gioHang.FirstOrDefault(s => s.IDSP == MaSP);
            if (sanpham != null)
            {
                gioHang.RemoveAll(s => s.IDSP == MaSP);
                return RedirectToAction("GetCartInfo"); //Quay về trang giỏ hàng
            }
            if (gioHang.Count == 0) //Quay về trang chủ nếu giỏ hàng không có gì
                return RedirectToAction("Index", "Home");
            return RedirectToAction("GetCartInfo");
        }

        
        
        public ActionResult CapNhatMatHang(int MaSP, int SoLuong)
        {
            List<CartItem> gioHang = GetCart();
            //Lấy sản phẩm trong giỏ hàng
            var sanpham = gioHang.FirstOrDefault(s => s.IDSP == MaSP);
            if (sanpham != null)
            {
                //Cập nhật lại số lượng tương ứng
                //Lưu ý số lượng phải lớn hơn hoặc bằng 1
                sanpham.Number = SoLuong;
            }
            return RedirectToAction("GetCartInfo"); //Quay về trang giỏ hàng
        }
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null) //Chưa đăng nhập
                return RedirectToAction("Login", "Users");
            List<CartItem> gioHang = GetCart();
            if (gioHang == null || gioHang.Count == 0) //Chưa có giỏ hàng hoặc chưa có sp
                return RedirectToAction("Index", "Home");
            ViewBag.TongSL = GetTotalNumber();
            ViewBag.TongTien = GetTotalPrice();
            return View(gioHang); //Trả về View hiển thị thông tin giỏ hàng
        }


        
        public ActionResult DongYDatHang(string addressOrder)
        {
            List<CartItem> myCart = GetCart();
            Customer khach = Session["TaiKhoan"] as Customer; //Khách
            OrderPro DonHang = new OrderPro(); //Tạo mới đơn đặt hàng
            DonHang.IDCus = khach.IDCus;
            DonHang.DateOrder = DateTime.Now;
            DonHang.AddressDeliverry = addressOrder;
            DonHang.Dienthoainhan = khach.PhoneCus;
            db.OrderPro.Add(DonHang);
            db.SaveChanges();
            //Lần lượt thêm từng chi tiết cho đơn hàng trên
            foreach (var product in myCart)
            {
                OrderDetail chitiet = new OrderDetail();
                chitiet.IDOrder = DonHang.ID;
                chitiet.IDProduct = product.IDSP;
                chitiet.Quantity = product.Number;
                chitiet.UnitPrice = (double)product.Dongia;
                chitiet.Thanhtien =(double)product.FinalPrice();
                db.OrderDetail.Add(chitiet);
            }
            db.SaveChanges();
            myCart.Clear();
           //Xóa giỏ hàng
           Session["MyCart"] = null;
            return RedirectToAction("CheckOut", "Cart");
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        
    }
}