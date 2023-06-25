using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Repository
{
    public class CartRepository
    {
        public static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Cart> getAll()
        {
            return (from data in db.Carts select data).ToList();
        }

        public static List<Cart> getAllCart(int id)
        {
            return (from data in db.Carts where data.CustomerID == id select data).ToList();
        }

        public static void remove(int albumID, int userID)
        {
            Cart cart = db.Carts.FirstOrDefault(x => x.AlbumID == albumID && x.CustomerID == userID);
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void insertCart(Cart c)
        {
            db.Carts.Add(c);
            db.SaveChanges();
        }

    }
}