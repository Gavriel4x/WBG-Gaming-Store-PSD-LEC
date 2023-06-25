using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Repository
{
    public class TransactionRepository
    {
        public static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
        public static int insertHeader(TransactionHeader th)
        {
            db.TransactionHeaders.Add(th);
            db.SaveChanges();

            db.Entry(th).GetDatabaseValues();
            int lastInsertedId = th.TransactionID;
            System.Diagnostics.Debug.WriteLine(lastInsertedId);
            return lastInsertedId;
        }

        public static void insertDetail(TransactionDetail td)
        {
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public static List<TransactionHeader> getAllHeader()
        {
            return (from data in db.TransactionHeaders select data).ToList();
        }

        public static List<TransactionHeader> getAllHeaderUser(int id)
        {
            return (from data in db.TransactionHeaders where data.CustomerID == id select data).ToList();
        }

        public static List<TransactionDetail> getDetail(int id)
        {
            return (from data in db.TransactionDetails where data.TransactionID == id select data).ToList();
        }
    }
}