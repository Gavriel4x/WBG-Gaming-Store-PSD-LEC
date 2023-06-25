using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Factory
{
    public class AlbumFactory
    {
        public static Album create(int id, string aid, string name, string desc, string price, string stock, string img)
        {
            return new Album
            {
                ArtistID = int.Parse(aid),
                AlbumName = name,
                AlbumDescription = desc,
                AlbumPrice = int.Parse(price),
                AlbumStock = int.Parse(stock),
                AlbumImage = img
            };
        }
  
        

}
}