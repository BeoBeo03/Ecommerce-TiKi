using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Big_project.Models
{
    public class CartItem
    {
        private TikiShopEntities db = new TikiShopEntities();
        public int IDSP { get; set; }
        public string TenIP { get; set; }
        public string HinhSP { get; set; }
        public decimal Dongia { get; set; }
        public int Number { get; set; }
         
        public Products products { get; set; }
        public int _quantity { get; set; }
        public decimal FinalPrice()
        {
            return Number * Dongia;
        }
        public CartItem(int ProductID)
        {
            this.IDSP = ProductID;
            var productDB = db.Products.Single(s => s.IDSP ==this.IDSP);
            this.TenIP = productDB.TenIP;
            this.HinhSP = productDB.HinhSP;
            this.Dongia = (decimal)productDB.Dongia;
            this.Number = 1;
        }
        public class Cart
        {
            List<CartItem> items = new List<CartItem>();
            public IEnumerable<CartItem> Items
            {
                get { return items; }
            }
            public void ClearCart()
            {
                items.Clear();
            }
            
        }
        

    }
}