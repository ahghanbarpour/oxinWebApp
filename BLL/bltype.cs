using System;
using System.Collections.Generic;
using System.Text;
using be;
using DAL;

namespace BLL
{
    public class bltype
    {
        public void create(type type)
        {
            datype t = new datype();
            t.create(type);
        }

        public List<type> read()
        {
            datype t = new datype();

            return t.read();
        }
        public List<type> search(List<string> tags)
        {
            datype t = new datype();

            return t.search(tags);
        }

        public void update(type type)
        {
            datype t = new datype();
            t.update(type);
        }
        public int gettotal()
        {
            datype t = new datype();
            return t.gettotal();
        }
        public List<type> getskip(int c)
        {
            datype t = new datype();
            return t.getskip(c);
        }
    }
}
