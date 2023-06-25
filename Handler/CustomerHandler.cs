using projectlab.Factory;
using projectlab.Model;
using projectlab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Handler
{
    public class CustomerHandler
    {
        public static Customer login(string email, string password)
        {
            return CustomerRepository.login(email, password);
        }

        public static Customer getCust(int id)
        {
            return CustomerRepository.getCust(id);
        }

        public static String getEmailAndPassword(bool isReturnEmail,String email, String password)
        {
            if (isReturnEmail == true) return CustomerRepository.searchEmail(email);
            else if(isReturnEmail == false) return CustomerRepository.searchPassword(email,password);

            return null;
        }

        public static void addCustomer(int id, string name, string email, string password, string gender, string address, string role)
        {
            Customer c = CustomerFactory.create(id, name, email, password, gender, address, role);
            CustomerRepository.addCustomer(c);
        }

        public static int countCustomer()
        {
            return CustomerRepository.totalCustomer().Count();
        }

        public static void updateCustomer(int id, string name, string email, string password, string gender, string address)
        {
            CustomerRepository.updateCustomer(id, name, email, password, gender, address);
        }
    }
}