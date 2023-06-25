using projectlab.Handler;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace projectlab.Controller
{
    public class CustomerController
    {
        private static bool isValid, isValidRegister;
        private static HttpCookie cookie;

        private static bool isAlphanumeric(string input)
        {
            bool digit = false;
            bool letter = false;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    digit = true;
                }

                if (char.IsLetter(c))
                {
                    letter = true;
                }

                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }

            if (digit && letter) return true;
            else return false;
        }

        public static Customer getCust(int id)
        {
            return CustomerHandler.getCust(id);
        }

        public static String[] loginValidation(string email, string pass)
        {
            isValid = true;
            String[] errList = new String[2];

            if (email.Trim().Equals("") || pass.Trim().Equals(""))
            {
                if(email.Trim().Equals(""))
                    errList[0] = "Email Field must be filled";
                if(pass.Trim().Equals(""))
                    errList[1] = "Pass Field must be filled";

                isValid = false;
            }

            String retrievedEmail = CustomerHandler.getEmailAndPassword(true, email, pass);
            String retrievedPassword = CustomerHandler.getEmailAndPassword(false, email, pass);

            if (retrievedEmail == null)
            {
                if(errList[0] == null)
                {
                    errList[0] = "Email doesn't match";

                    isValid = false;
                }

            } else if (retrievedEmail.Equals(email))
            {
                errList[0] = "";
            }


            if(retrievedPassword == null)
            {
                if (errList[1] == null)
                {
                    errList[1] = "Password doesn't match";
                    isValid = false;
                }
            } else if (retrievedEmail.Equals(email) && retrievedPassword.Equals(pass))
            {
                errList[1] = "";
            }

            return errList;
        }

        public static void updateCustomer(int id, string name, string email, string password, string gender, string address)
        {
            CustomerHandler.updateCustomer(id, name, email, password, gender, address);
        }

        public static string[] registerValidation(string name, string email,RadioButton rbMale, RadioButton rbFemale, string address, string password)
        {
            isValidRegister = true;
            String[] errList = new String[5];

            if(name.Trim().Equals("") || email.Trim().Equals("") || address.Trim().Equals("") || password.Trim().Equals("") || (rbMale.Checked == false && rbFemale.Checked == false))
            {
                if (name.Trim().Equals(""))
                    errList[0] = "Name Field must be filled";
                if (email.Trim().Equals(""))
                    errList[1] = "Email Field must be filled";
                if (rbMale.Checked == false && rbFemale.Checked == false)
                    errList[2] = "Gender Field must be selected";
                if (address.Trim().Equals(""))
                    errList[3] = "Address Field must be filled";
                if (password.Trim().Equals(""))
                    errList[4] = "Password Field must be filled";

                isValidRegister = false;
            }

            if (errList[0] == null)
            {
                if(name.Length < 5 || name.Length > 50)
                {
                    errList[0] = "Name must be between 5 - 50 characters";
                    isValid = false;
                } 

            }

            String retrievedEmail = CustomerHandler.getEmailAndPassword(true, email, password);
            if (retrievedEmail != null)
            {
                if (errList[1] == null)
                {
                    errList[1] = "Email must be unique";

                    isValidRegister = false;
                }

            }
            

            if(errList[3] == null)
            {
                if(address.EndsWith("Street") == false)
                {
                    errList[3] = "Address must ends with 'Street'";

                    isValidRegister = false;
                }

            }

            if(errList[4] == null)
            {
                if(isAlphanumeric(password) == false)
                {
                    errList[4] = "Password must be alphanumeric";

                    isValidRegister = false;
                }
            }


            return errList;
        }
        public static bool isValidatedLogin()
        {
            return isValid;
        }

        public static bool isValidatedRegister()
        {
            return isValidRegister;
        }

        public static Customer login(string email, string pass)
        {
            if (email.Equals("") || pass.Equals(""))
            {
                return null;
            }
            return CustomerHandler.login(email, pass);
        }

        public static void addCustomer(string name, string email, string password, string gender,  string address, string role)
        {
            CustomerHandler.addCustomer(getNextID(),name, email, password, gender, address, role);
        }

        public static HttpCookie setCookie(CheckBox cb, TextBox email, TextBox pass)
        {
            cookie = new HttpCookie("Login");
            cookie.Values["Email"] = email.Text;
            cookie.Values["Password"] = pass.Text;
            cookie.Expires = DateTime.Now.AddDays(1);

            return cookie;
        }

        public static int getNextID()
        {
            return CustomerHandler.countCustomer();
        }
    }
}