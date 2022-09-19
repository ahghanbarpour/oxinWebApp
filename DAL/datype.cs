using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be;

namespace DAL
{
    public class datype
    {
        public void create(type t)
        {
            db db = new db();
            db.types.Add(t);
            db.SaveChanges();
        }
        public List<type> read()
        {
            db db = new db();

            return db.types.ToList();
        }
        public int gettotal()
        {
            db db = new db();
            return db.types.Count();
        }
        public List<type> search(List<string> tags)
        {
            List<type> ty = new List<type>();
            foreach (var item in tags)
            {
                db db = new db();
                var q = from i in db.types
                        where i.title.Contains(item.ToString())
                        select i;
                ty = ty.Concat(q.ToList()).ToList();
            }
            return ty;
        }
        public void update(type t)
        {
            db db = new db();
            var q = from i in db.types where i.typeId == t.typeId select i;
            type tt = new type();
            tt = q.Single();
            //pp.type = p.type;
            tt.title = t.title;
            db.SaveChanges();
            //return "ویرایش اطلاعات با موفقیت انجام شد";
        }
        public List<type> getskip(int c)
        {
            int t = c * 10;
            db db = new db();
            var q = db.types.Skip(t).Take(10);
            return q.ToList();
        }

    }
}
