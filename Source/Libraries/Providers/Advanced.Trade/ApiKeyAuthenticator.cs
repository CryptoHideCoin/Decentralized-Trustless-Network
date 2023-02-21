using System;
using System.Security.Cryptography;
using System.Text;

namespace AdvancedTrade
{
   public static class ApiKeyAuthenticator
   {
        internal static string Sign(string base64key, string data)
        {
           var hmacKey = Convert.FromBase64String(base64key);
           var dataBytes = Encoding.UTF8.GetBytes(data);

           using (var hmac = new HMACSHA256(hmacKey))
           {
               var sig = hmac.ComputeHash(dataBytes);
               return Convert.ToBase64String(sig);
           }
        }

        internal static string generateSignature(string content, string appSecret)
        {
            string ToHexString(byte[] array)
            {
                StringBuilder hex = new StringBuilder(array.Length * 2);
                foreach (byte b in array)
                {
                    hex.AppendFormat("{0:x2}", b);
                }
                return hex.ToString();
            }

            string key = appSecret;
            string hash;
            ASCIIEncoding encoder = new ASCIIEncoding();
            Byte[] code = encoder.GetBytes(key);
            using (HMACSHA256 hmac = new HMACSHA256(code))
            {
                Byte[] hmBytes = hmac.ComputeHash(encoder.GetBytes(content));
                hash = ToHexString(hmBytes);
            }
            return hash;
        }

      public static string GenerateSignature(string timestamp, string method, string requestPath, string body, string appSecret)
      {
            return generateSignature(timestamp + method + requestPath + body, appSecret);
        }

      public static string GenerateSignature(string channel, string timestamp, string body, string appSecret)
      {
            return generateSignature(timestamp + channel + body, appSecret);
      }
   }
}
