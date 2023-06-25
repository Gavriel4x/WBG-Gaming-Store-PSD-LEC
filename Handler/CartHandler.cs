using projectlab.Factory;
using projectlab.Model;
using projectlab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Handler
{
    public class CartHandler
    {
        public static void insertCart(string aid, int cid, int qty)
        {
            Cart c = CartFactory.create(int.Parse(aid), cid, qty);
            CartRepository.insertCart(c);
        }

        public static List<Cart> getAll()
        {
            return CartRepository.getAll();
        }

        public static List<Cart> getAllCart(int id)
        {
            return CartRepository.getAllCart(id);
        }

        public static void removeCart(int albumID, int userID)
        {
            CartRepository.remove(albumID, userID);
        }
    }
}