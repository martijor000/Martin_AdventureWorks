using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_AdventureWorks.Data
{
    public static class db
    {
        public static string GetConnectionString()
        {
            return dbConnectionString();
        }

        private static string dbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
    }
}
