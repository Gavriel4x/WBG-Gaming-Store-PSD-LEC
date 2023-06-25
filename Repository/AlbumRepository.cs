using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace projectlab.Repository
{
    public class AlbumRepository
    {
        public static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Album> getAll(int id)
        {
            return (from data in db.Albums where data.ArtistID == id select data).ToList();
        }

        public static void remove(String ID)
        {
            int aID = int.Parse(ID);
            Album album = db.Albums.FirstOrDefault(x => x.AlbumID == aID);
            db.Albums.Remove(album);
            db.SaveChanges();
        }

        public static void insert(Album a)
        {
            db.Albums.Add(a);
            db.SaveChanges();


        }

        public static Album getAlbum(int id)
        {
            Album album = db.Albums.FirstOrDefault(x => x.AlbumID == id);
            return album;
        }

        public static void update(string id, string name, string desc, string price, string stock, string filepath)
        {
            Album a = db.Albums.Find(int.Parse(id));

            a.AlbumName = name;
            a.AlbumDescription = desc;
            a.AlbumPrice = int.Parse(price);
            a.AlbumStock = int.Parse(stock);
            a.AlbumImage = filepath;
            db.SaveChanges();
        }
        public static List<Album> totalAlbum()
        {
            return (from data in db.Albums select data).ToList();
        }

    }
}