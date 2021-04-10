using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class Helpers
    {
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["FagElGamous"];

            //if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["EpicWerf"];
            string password = appConfig["JacksonRocks"];
            string hostname = appConfig["aa334sqauw5ixt.cww7zl3zl4yd.us-east-1.rds.amazonaws.com"];
            string port = appConfig["1433"];

            //return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
            return "Data Source=aa4olymoet4lpi.cww7zl3zl4yd.us-east-1.rds.amazonaws.com;Initial Catalog=IntexII;User ID=dbuser;Password=intexgroup29;MultipleActiveResultSets=true;";
            //"DefaultConnection": "Host=aa334sqauw5ixt.cww7zl3zl4yd.us-east-1.rds.amazonaws.com;Port=1433;Username=EpicWerf;Password=JacksonRocks;Database=aa334sqauw5ixt"

            //return "Data Source=aa15qhx9s42mgmt.chgpbo5ixplt.us-east-1.rds.amazonaws.com;Initial Catalog=ebdb;User ID=dbuser;Password=group211;";
        }
    }
}
