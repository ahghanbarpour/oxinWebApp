using System;
using System.Collections.Generic;
using System.Text;
using be;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class daorder
    {
        public void create(Order p)
        {
            db db = new db();
            db.Orders.Add(p);
            db.SaveChanges();
        }
        public List<Order> read()
        {
            db db = new db();

            return db.Orders.Include(t => t.Order_Products).ThenInclude(t => t.product).ToList();
        }
        //public List<Order> search(List<string> tags)
        //{
        //    List<Order> pr = new List<Order>();
        //    foreach (var item in tags)
        //    {
        //        db db = new db();
        //        var q = from i in db.Orders.Include(s => s.Order_Products).ThenInclude(s => s.product)
        //                where i.Order_Products.Contains(item.ToString()) || i.model.Contains(item.ToString()) || i.vol.Contains(item.ToString()) || i.price == Convert.ToInt32(item)
        //                select i;
        //        pr = pr.Concat(q.ToList()).ToList();
        //    }
        //    return pr;
        //}
        //public void update(Order p)
        //{
        //    db db = new db();
        //    var q = from i in db.Orders where i.id == p.id select i;
        //    Order oo = new Order();
        //    oo = q.Single();
        //    oo.totalPrice = p.totalPrice;
        //    db.SaveChanges();
        //}
        public Order searchById(int id)
        {
            db db = new db();

            var q = from i in db.Orders where i.id == id select i;

            return q.SingleOrDefault();
        }
        public List<product> searchById(List<orderId> ids)
        {
            db db = new db();
            
            var q = from i in db.products.Include(s => s.Order_Products).ThenInclude(s => s.product) where ids.Contains(i.orderId) select i;

            return q.ToList();
        }
        public int gettotal()
        {
            db db = new db();
            return db.Orders.Count();
        }
        public List<Order> getskip(int c)
        {
            int t = c * 10;
            db db = new db();
            var q = db.Orders.Include(t => t.Order_Products).ThenInclude(t => t.product).Skip(t).Take(10);
            return q.ToList();
        }
    }
}
