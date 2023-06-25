using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectlab.Repository
{
    public class DatabaseSingleton
    {
        private static LocalDatabaseEntities db = null;
        private DatabaseSingleton()
        {

        }

        public static LocalDatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new LocalDatabaseEntities();
            }
            return db;
        }
    }
}