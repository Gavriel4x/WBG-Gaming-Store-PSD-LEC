using projectlab.Handler;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Controller
{
    public class AlbumController
    {
        public static bool isValid { get; set; }
        public static List<Album> getAll(int id)
        {
            return AlbumHandler.getAll(id);
        }

        public static string[] validate(string name, string desc, string price, string stock, String filename, String fileExtension, bool isFile, int fileLength)
        {
            isValid = true;
            String[] errList = new String[5];

            if (name.Trim().Equals("") || desc.Trim().Equals("") || price.Trim().Equals("") || stock.Trim().Equals("") || !isFile)
            {
                if (name.Trim().Equals(""))
                {
                    errList[0] = "Album name must be filled";
                }
                if (desc.Trim().Equals(""))
                {
                    errList[1] = "Album desc must be filled";
                }
                if (price.Trim().Equals(""))
                {
                    errList[2] = "Album price must be filled";
                }
                if (stock.Trim().Equals(""))
                {
                    errList[3] = "Album stock must be filled";
                }
                if (!isFile)
                {
                    errList[4] = "Image Field must be choosed, file extension must be .png, .jpg, .jpeg, or .jfif, and file size must be lower than 2MB";
                }

                isValid = false;
            }
            if(errList[0] == null)
            {
                if (name.Length >= 50 || name.Length <= 0)
                {
                    errList[0] = "Album name length must be smaller than 50 and more than 0";
                    isValid = false;
                }
            }

            
            if(errList[1] == null)
            {
                if (desc.Length >= 225 || name.Length <= 0)
                {
                    errList[1] = "Album description length must be smaller than 225 and more than 0";
                    isValid = false;
                }
            }
            
            if(errList[2] == null)
            {
                int prc = int.Parse(price);
                if(prc < 100000 || prc > 1000000)
                {
                    errList[2] = "Album price must be between 100000 and 1000000";
                    isValid = false;
                }
            }

            if(errList[3] == null)
            {
                int stk = int.Parse(stock);
                if (stk <= 0)
                {
                    errList[3] = "Album stock must be more than 0";
                    isValid = false;
                }
            }

            if(errList[4] == null)
            {
                if (!(fileExtension.ToLower().Equals(".png") || fileExtension.ToLower().Equals(".jpg") || fileExtension.ToLower().Equals(".jpeg") || fileExtension.ToLower().Equals(".jfif")))
                {
                    errList[4] = "File extension must be .png, .jpg, .jpeg, or.jfif";
                    isValid = false;

                }else if(fileLength >= 2 * 1024 * 1024)
                {
                    errList[4] = "File size must be lower than 2MB";
                    isValid = false;
                }

            }

            if (isValid)
            {
                for (int i = 0; i < errList.Length; i++)
                {
                    errList[i] = "";
                }
            }

            return errList;
        }

        public static void updateAlbum(string id, string name, string desc, string price, string stock, string filepath)
        {
            AlbumHandler.updateAlbum(id, name, desc, price, stock, filepath);
        }

        public static Album getAlbum(int id)
        {
            return AlbumHandler.getAlbum(id);
        }

        public static void insertAlbum(string aid, string name, string desc, string price, string stock, string filepath)
        {
            AlbumHandler.insertAlbum(aid, name, desc, price, stock, filepath);
        }

        public static void removeAlbum(string id)
        {
            AlbumHandler.removeAlbum(id);
        }
    }
}