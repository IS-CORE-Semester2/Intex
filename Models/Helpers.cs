using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    //For RDS connection
    public class Helpers
    {
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["FagElGamous"];

            //if (string.IsNullOrEmpty(dbname)) return null;

            //I don't think the info below here is actually used, but the connection works with it there so we are just gonna leave it
            string username = appConfig["EpicWerf"];
            string password = appConfig["JacksonRocks"];
            string hostname = appConfig["aa334sqauw5ixt.cww7zl3zl4yd.us-east-1.rds.amazonaws.com"];
            string port = appConfig["1433"];

            return "Data Source=aaw4kdw5iaqlen.cww7zl3zl4yd.us-east-1.rds.amazonaws.com; Initial Catalog=IntexII;User ID=dbuser;Password=intexgroup29;MultipleActiveResultSets=true;";
        }
    }
}
