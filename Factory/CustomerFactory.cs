using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Factory
{
    public class CustomerFactory
    {
        public static Customer create(int id, string name, string email, string pass, string gender, string address, string role)
        {
            Customer c = new Customer();
            c.CustomerID = id;
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerGender = gender;
            c.CustomerPassword = pass;
            c.CustomerAddress = address;
            c.CustomerRole = role;

            return c;
        }
    }
}