using projectlab.Factory;
using projectlab.Model;
using projectlab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Handler
{
    public class AlbumHandler
    {
        public static List<Album> getAll(int id)
        {
            return AlbumRepository.getAll(id);
        }

        public static void insertAlbum(string aid, string name, string desc, string price, string stock, string filepath)
        {
            Album a = AlbumFactory.create(AlbumHandler.getNextID() ,aid, name, desc, price, stock, filepath);
            AlbumRepository.insert(a);
        }

        public static void removeAlbum(string id)
        {
            AlbumRepository.remove(id);
        }

        public static Album getAlbum(int id)
        {
            return AlbumRepository.getAlbum(id);
        }

        public static void updateAlbum(string id, string name, string desc, string price, string stock, string filepath)
        {
            AlbumRepository.update(id, name, desc, price, stock, filepath);
        }

        public static int getNextID()
        {
            return AlbumRepository.totalAlbum().Count();
        }
    }
}