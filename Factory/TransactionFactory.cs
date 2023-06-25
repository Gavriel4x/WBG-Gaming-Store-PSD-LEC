using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader createHeader(int customerID, DateTime date)
        {
            TransactionHeader t = new TransactionHeader();
            t.CustomerID = customerID;
            t.TransactionDate = date;

            return t; 
        }

        public static TransactionDetail createDetail(int tID, int albumID, int qty)
        {
            TransactionDetail t = new TransactionDetail();
            t.TransactionID = tID;
            t.AlbumID = albumID;
            t.Qty = qty;

            return t;
        }
    }
}