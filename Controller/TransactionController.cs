using projectlab.Handler;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Controller
{
    public class TransactionController
    {
        public static int insertHeader(int custID, DateTime date)
        {
            return TransactionHandler.insertHeader(custID, date);
        }

        public static void insertDetail(int tID, int albumID, int qty, int userID)
        {
            TransactionHandler.insertDetail(tID, albumID, qty);
            Album a = AlbumController.getAlbum(albumID);
            int stock = a.AlbumStock - qty;
            AlbumController.updateAlbum(a.AlbumID.ToString(), a.AlbumName, a.AlbumDescription, a.AlbumPrice.ToString(), stock.ToString(), a.AlbumImage);

            CartController.removeCart(albumID, userID);
        }

        public static List<TransactionHeader> getAllHeader()
        {
            return TransactionHandler.getAllHeader();
        }

        public static List<TransactionHeader> getAllHeaderUser(int id)
        {
            return TransactionHandler.getAllHeaderUser(id);
        }

        public static List<TransactionDetail> getDetail(int id)
        {
            return TransactionHandler.getDetail(id);
        }
    }
}