using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetDemoApplication.DataClasses
{
    public class DatabaseHelper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DataSetDemoDb"].ConnectionString;
            }
        }
    }
}
