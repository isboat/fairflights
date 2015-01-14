using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.Configuration
{
    public class AppSettings
    {
        public static string SkyScannerUri {
            get
            {
                return ConfigurationManager.AppSettings["skyScannerUri"];

            }
        }

        public static string WegoUri
        {
            get
            {
                return ConfigurationManager.AppSettings["wegoUri"];

            }
        }
    }
}
