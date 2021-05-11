using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortner.Utility
{
    public class Util
    {

        private const string DEFAULT_CHARACTERS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static int BASE62 = 62;
        private static int limit = 7;
        public static string GetBase62(long longUrlId)
        {

            long hashcode = longUrlId;
            // insert to dbm & retur the Id
            // long hashcode = 100054651616;
            StringBuilder hashStr = new StringBuilder();


            while (hashcode > 0)                // while (hashcode / BASE62 > 0)
            {
                hashStr.Append(DEFAULT_CHARACTERS[(int)hashcode % BASE62]);
                hashcode /= BASE62;
                if (hashStr.Length >= limit)
                    break;
            }
            hashStr.Append(DEFAULT_CHARACTERS[(int)hashcode]);

            while (hashStr.Length < limit)
            {
                hashStr.Append(DEFAULT_CHARACTERS[0]);
            }
            return Reverses(hashStr.ToString()).ToString();


        }

        public static string Reverses(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        /*

        public static string GetConfiguration(string configKey, IConfiguration configuration)
        {
            try
            {
                string retVal = configuration.GetValue<string>(configKey);
                return retVal;
            }
            catch (Exception e)
            {
               // logger.LogError(Utils.GetErrorinfo(e));
               // logger.LogError(" Appsettings.json file do not have a value for " + configKey + "....");
                return "";
            }

        }
        */



    }
}
