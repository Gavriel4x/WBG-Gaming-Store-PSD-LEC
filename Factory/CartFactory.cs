using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Factory
{
    public class CartFactory
    {
        public static Cart create(int aid, int cid, int qty)
        {
            Cart c = new Cart();
            c.AlbumID = aid;
            c.CustomerID = cid;
            c.Qty = qty;

            return c;
        }
    }
}