using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Repository
{
    public class ArtistRepository
    {

        public static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Artist> getAll()
        {
            return (from data in db.Artists select data).ToList();
        }

        public static void remove(String ID)
        {
            int aID = int.Parse(ID);
            Artist artist = db.Artists.FirstOrDefault(x => x.ArtistID == aID);
            db.Artists.Remove(artist);
            db.SaveChanges();

        }

        public static int getId(String artistName)
        {
            return db.Artists.Where(x => x.ArtistName.Equals(artistName)).FirstOrDefault().ArtistID;
        }

        public static Artist searchArtist(int id)
        {
            return db.Artists.Find(id);
        }

        public static String searcArtist(String artistName)
        {
            Artist a = (from data in db.Artists
                          where data.ArtistName.Equals(artistName)
                          select data).FirstOrDefault();

            if (a != null)
            {
                return a.ArtistName;
            }
            return "";
        }

        public static void insert(Artist a)
        {
            db.Artists.Add(a);
            db.SaveChanges();
        }

        public static void update(int id, String artistName, String url)
        {
            db.Artists.Find(id).ArtistName = artistName;
            db.Artists.Find(id).ArtistImage = url;

            db.SaveChanges();
        }

        public static List<Artist> totalArtist()
        {
            return (from data in db.Artists select data).ToList();
        }
    }
}