using System;
using System.Collections.Generic;
using be;
using DAL;

namespace BLL
{
    public class blproduct
    {
        public void create(product product)
        {
            daproduct p = new daproduct();
            p.create(product);
        }

        public List<product> read()
        {
            daproduct p = new daproduct();

            return p.read();
        }
        public List<product> search(List<string> tags)
        {
            daproduct p = new daproduct();

            return p.search(tags);
        }

        public void update(product product)
        {
            daproduct p = new daproduct();
            p.update(product);
        }
        public product searchById(int id)
        {
            daproduct p = new daproduct();
            return p.searchById(id);
        }
        public List<product> listById (int id)
        {
            daproduct p = new daproduct();
            return p.listById(id);
        }
        public List<product> searchById(List<int> ids)
        {
            daproduct p = new daproduct();
            return p.searchById(ids);
        }
        public int gettotal()
        {
            daproduct p = new daproduct();
            return p.gettotal();
        }
        public List<product> getskip(int c)
        {
            daproduct p = new daproduct();
            return p.getskip(c);
        }
    }
}
