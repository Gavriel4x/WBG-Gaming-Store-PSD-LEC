using projectlab.Handler;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Controller
{
    public class CartController
    {
        public static string insertValidation(string quantity, Album album)
        {
            string error = "";
            if (quantity == "")
            {
                error = "Quantity must be filled";
            }
            else if(int.Parse(quantity) <= 0)
            {
                error = "Quantity must more than 0";
            }
            else if (int.Parse(quantity) > album.AlbumStock)
            {
                error = "Quantity must not exceed stock";
            }

            return error;
        }

        public static void insertCart( string aid, int cid, int qty)
        {
            CartHandler.insertCart(aid, cid, qty);
        }

        public static List<Cart> getAll()
        {
            return CartHandler.getAll();
        }

        public static List<Cart> getAllCart(int id)
        {
            return CartHandler.getAllCart(id);
        }

        public static void removeCart(int albumID, int userID)
        {
            CartHandler.removeCart(albumID, userID);
        }
    }
}