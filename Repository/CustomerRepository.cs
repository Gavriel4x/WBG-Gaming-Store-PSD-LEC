using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Repository
{
    public class CustomerRepository
    {
        public static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static Customer login(string email, string pass)
        {
            
            Customer u = (from data in db.Customers
                      where data.CustomerEmail.Equals(email) && data.CustomerPassword.Equals(pass)
                      select data).FirstOrDefault();
            return u;
        }

        public static Customer getCust(int id)
        {
            return (from data in db.Customers where data.CustomerID == id select data).FirstOrDefault();
        }
        public static String searchEmail(String email)
        {
            Customer c = (from data in db.Customers
                          where data.CustomerEmail.Equals(email)
                          select data).FirstOrDefault();

            if(c != null)
            {
                return c.CustomerEmail;
            }
            return null;
        }

        public static String searchPassword(String email, String password)
        {
            Customer c = (from data in db.Customers
                          where data.CustomerPassword.Equals(password) &&
                          data.CustomerEmail.Equals(email)
                          select data).FirstOrDefault();

            if (c != null)
            {
                return c.CustomerPassword;
            }
            return null;
        }

        public static void updateCustomer(int id, string name, string email, string password, string gender, string address)
        {
            Customer c = db.Customers.Find(id);
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerPassword = password;
            c.CustomerGender = gender;
            c.CustomerAddress = address;

            db.SaveChanges();
        }

        public static void addCustomer(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
        }

        public static List<Customer> totalCustomer()
        {
           return (from data in db.Customers select data).ToList();
        }
    }
}