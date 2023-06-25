using projectlab.Handler;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Controller
{
    public class ArtistController
    {
        private static bool isValid;

        public static String[] updateValidation(string artistName, String filename, String fileExtension, bool isFile, int fileLength)
        {

            bool isValidEmail = true;
            isValid = true;
            String[] errList = new String[2];

            if (artistName.Trim().Equals(""))
            {
                if (artistName.Trim().Equals(""))
                    errList[0] = "Artist name Field must be filled";
                
                isValid = false;
            }

            if (!isFile)
            {
                errList[1] = "Image Field must be choosed, file extension must be .png, .jpg, .jpeg, or .jfif, and file size must be lower than 2MB";

                isValid = false; isValidEmail = false;
            }

            String retrievedArtistName = ArtistHandler.getArtistName(artistName);

            if (retrievedArtistName.Equals(artistName))
            {
                if (errList[0] == null)
                {
                    errList[0] = "Artist name already exist, must be unique";

                    isValid = false;
                }

            }
            else
            {
                errList[0] = "";
            }

            if ( !(fileExtension.ToLower().Equals(".png") || fileExtension.ToLower().Equals(".jpg") || fileExtension.ToLower().Equals(".jpeg") || fileExtension.ToLower().Equals(".jfif")))
            {
                if(errList[1] == null)
                {
                    errList[1] = "File extension must be .png, .jpg, .jpeg, or.jfif";
                    isValid = false; isValidEmail = false;
                }

            }else if(isValidEmail)
            {
                errList[1] = "";
            }

            // Validate file size
            if (fileLength >= 2 * 1024 * 1024)
            {// 2MB
                if (errList[1] == null)
                {
                    errList[1] = "File size must be lower than 2MB.";
                    isValid = false; isValidEmail = false;
                }
            } else if(isValidEmail)
            {
                errList[1] = "";
            }

            return errList;
        }

        public static int getNextID()
        {
            return ArtistHandler.countArtist();
        }

        public static void insertArtist(string text, string filepath)
        {
            ArtistHandler.insertArtist(getNextID(), text, filepath);
        }

        public static bool isValidatedUpdate()
        {
            return isValid;
        }

        public static Artist getArtist(int id)
        {
            return ArtistHandler.getArtist(id);
        }

        public static void updateArtist(int id, String artistName, String url)
        {
            ArtistHandler.updateArtist(id, artistName, url);
        }

        public static List<Artist> getAll()
        {
            return ArtistHandler.getAll();
        }

        public static void removeArtist(String ID)
        {
            ArtistHandler.removeArtist(ID);
        }
    }
}