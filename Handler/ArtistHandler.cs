using projectlab.Factory;
using projectlab.Model;
using projectlab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Handler
{
    public class ArtistHandler
    {
        public static List<Artist> getAll()
        {
            return ArtistRepository.getAll();
        }
        public static void removeArtist(String ID)
        {
            ArtistRepository.remove(ID);
        }

        public static int getArtistID(String artistName)
        {
            return ArtistRepository.getId(artistName);
        }

        public static Artist getArtist(int id)
        {
            return ArtistRepository.searchArtist(id);
        }

        public static String getArtistName(String artistName)
        {
            return ArtistRepository.searcArtist(artistName);
        }

        public static void updateArtist(int id, String artistName, String url)
        {
           ArtistRepository.update(id, artistName, url);
        }

        public static void insertArtist(int id, string text, string filepath)
        {
            Artist a = ArtistFactory.create(id, text, filepath);
            ArtistRepository.insert(a);
        }

        public static int countArtist()
        {
            return ArtistRepository.totalArtist().Count();
        }
    }
}