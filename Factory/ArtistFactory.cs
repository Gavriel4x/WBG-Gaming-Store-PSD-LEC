using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Factory
{
    public class ArtistFactory
    {
        public static Artist create(int id, string name, string image)
        {
            Artist a = new Artist();
            a.ArtistID = id;
            a.ArtistName = name;
            a.ArtistImage = image;

            return a;
        }
    }
}