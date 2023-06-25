using projectlab.Factory;
using projectlab.Model;
using projectlab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Handler
{
    public class TransactionHandler
    {
        public static int insertHeader(int custID, DateTime date)
        {
            TransactionHeader th = TransactionFactory.createHeader(custID, date);
            return TransactionRepository.insertHeader(th);
        }

        public static void insertDetail(int tID, int albumID, int qty)
        {
            TransactionDetail td = TransactionFactory.createDetail(tID, albumID, qty);
            TransactionRepository.insertDetail(td);
        }

        public static List<TransactionHeader> getAllHeader()
        {
            return TransactionRepository.getAllHeader();
        }

        public static List<TransactionHeader> getAllHeaderUser(int id)
        {
            return TransactionRepository.getAllHeaderUser(id);
        }

        public static List<TransactionDetail> getDetail(int id)
        {
            return TransactionRepository.getDetail(id);
        }
    }
}