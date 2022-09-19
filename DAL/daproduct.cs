using System;
using be;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class daproduct
    {
        public void create(product p)
        {
            db db = new db();
            db.products.Add(p);
            db.SaveChanges();
        }
        //این متد ایندکس رو پر میکنه
        public List<product> read()
        {
            db db = new db();

            return db.products.Include(t => t.type).ToList();
        }
        public List<product> search(List<string> tags)
        {
            List<product> pr = new List<product>();
            foreach (var item in tags)
            {
                db db = new db();
                var q = from i in db.products
                        where i.brand.Contains(item.ToString()) || i.model.Contains(item.ToString()) || i.vol.Contains(item.ToString()) || i.price == Convert.ToInt32(item)
                        select i;
                pr = pr.Concat(q.ToList()).ToList();
            }
            return pr;
        }
        public void update(product p)
        {
            db db = new db();
            var q = from i in db.products where i.productId == p.productId select i;
            product pp = new product();
            pp = q.Single();
            //pp.type = p.type;
            pp.type = p.type;
            pp.brand = p.brand;
            pp.model = p.model;
            pp.vol = p.vol;
            pp.price = p.price;
            pp.pic = p.pic;
            pp.descript = p.descript;
            db.SaveChanges();
            //return "ویرایش اطلاعات با موفقیت انجام شد";
        }
        public product searchById(int id)
        {
            db db = new db();

            var q = from i in db.products.Include(s => s.type).ThenInclude(s => s.products) where i.productId == id select i;

            return q.SingleOrDefault();
        }
        public List<product> listById(int id)
        {
            db db = new db();

            var q = from i in db.products.Include(s => s.type).ThenInclude(s => s.products) where i.typeId == id select i;

            return q.ToList();
        }
        public List<product> searchById(List<int> ids)
        {
            db db = new db();
            var q = from i in db.products.Include(s => s.type).ThenInclude(s => s.products).ThenInclude(s => s.orderId) where ids.Contains(i.productId) select i;

            return q.ToList();
        }
        public int gettotal()
        {
            db db = new db();
            return db.products.Count();
        }
        public List<product> getskip(int c)
        {
            int t = c * 10;
            db db = new db();
            var q = db.products.Include(t => t.type).Skip(t).Take(10);
            return q.ToList();
        }
    }
}
