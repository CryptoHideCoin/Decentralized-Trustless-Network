using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Security.Cryptography;
using RestSharp;

namespace Api_CB
{
    public class Program
    {
        public partial class OrderCancel
        {
            public List<string> order_ids { get; set; }

            public OrderCancel()
            {
                order_ids = new List<string>();
            }
        }

        public static void Main(string[] args)
        {
            string UTCtime()
            {
                DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
                
                string unixTime = dto.ToUnixTimeSeconds().ToString();

                return unixTime;
            }

            long timeStampValue()
            {
                DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);

                return dto.ToUnixTimeSeconds();
            }

            string ToHexString(byte[] array)
            {
                StringBuilder hex = new StringBuilder(array.Length * 2);
                foreach (byte b in array)
                {
                    hex.AppendFormat("{0:x2}", b);
                }
                return hex.ToString();
            }

            string CreateToken(string data)
            {
                string key = "Q75nC8RWJRV0k9HRrniQx4iXUdxSHJip";
                string hash;
                ASCIIEncoding encoder = new ASCIIEncoding();
                Byte[] code = encoder.GetBytes(key);
                using (HMACSHA256 hmac1 = new HMACSHA256(code))
                {
                    Byte[] hmBytes = hmac1.ComputeHash(encoder.GetBytes(data));
                    hash = ToHexString(hmBytes);
                }
                return hash;
            }

            /*string apiKey = "s56G5OI9uA6rnQvA";*/
            /*string apiSecret = "Q75nC8RWJRV0k9HRrniQx4iXUdxSHJip";*/
            string apiKey = "sTNFcV0Pk4PYhUBi";
            string apiSecret = "sz3crtq36GEXwYoXVb4cQ0TjYWe3cXKz";

            /*var client = new RestClient("https://api.coinbase.com/api/v3/brokerage/accounts");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var prehash = timestampStr + httpMethodStr + requestUri + contentBody;
            var signedSignature = CreateToken(prehash);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("CB-ACCESS-KEY", apiKey);
            request.AddHeader("CB-ACCESS-SIGN", signedSignature);
            request.AddHeader("CB-ACCESS-TIMESTAMP", timeStamp);

            
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return;*/

            var baseUri = "https://api.coinbase.com";
            var test_url = "/orders/batch_cancel";
            var requestUri = "/api/v3/brokerage" + test_url;
            var fullUri = baseUri + requestUri /*+ "?limit=100"*/;

            string contentBody = "";
            var timeStamp = UTCtime();
            var httpMethod = System.Net.Http.HttpMethod.Post;

            var convertedString = Convert.FromBase64String(apiSecret);
            var hmaccsha = new HMACSHA256(convertedString);

            string timestampStr = timeStampValue().ToString("F0", System.Globalization.CultureInfo.InvariantCulture);
            string httpMethodStr = httpMethod.ToString().ToUpper();
            var prehash = timestampStr + httpMethodStr + requestUri + contentBody;

            byte[] prehashBytes = Encoding.UTF8.GetBytes(prehash);
            byte[] keyBytes = Encoding.UTF8.GetBytes(apiSecret);

            HMACSHA256 hmac = new HMACSHA256(keyBytes);
            byte[] hash2 = hmac.ComputeHash(prehashBytes);

            string signedSignature = BitConverter.ToString(hash2).Replace("-", "").ToLower();

            /*var signedSignature = Convert.ToBase64String(hmaccsha.ComputeHash(bytes));*/
            /*var signedSignature = CreateToken(prehash);*/

            var request = new RestRequest();

            OrderCancel values = new OrderCancel();

            values.order_ids.Add("c7158b0f-d654-43ee-87a0-7c6b52b7dbbe");


            /*request.AddHeader("Content-Type", "application/json");*/
            request.AddHeader("CB-ACCESS-KEY", apiKey);
            request.AddHeader("CB-ACCESS-SIGN", signedSignature);
            request.AddHeader("CB-ACCESS-TIMESTAMP", timestampStr);

            request.AddJsonBody(values);

            var client = new RestClient(fullUri);
            /*var response = client.Execute(request);*/
            var response = client.Post(request);

            return;

            using (var ws = new WebSocket("wss://advanced-trade-ws.coinbase.com"))
            {
                var TimeStamp = UTCtime();
                var Hstring = TimeStamp + "tickerBTC-USDT"; //string to sign
                ws.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;
                //ws.OnMessage += (sender, e) => Console.WriteLine(e.Data);
                ws.OnMessage += Ws_OnMSGReceived;
                /*subscribe_msg subscribe = new subscribe_msg("subscribe", "ticker", "", "", UTCtime(), CreateToken(Hstring));*/
                /*var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(subscribe);*/
                ws.Connect();

                /*ws.Send(jsonString);*/
                Console.ReadKey(true);
            }
        }
        // event handler on msg recived
        private static void Ws_OnMSGReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            //throw new NotImplementedException();
        }

        public class subscribe_msg
        {
            public string type { get; set; }
            public List<string> product_ids { get; set; }
            public string channel { get; set; }
            public string api_key { get; set; }
            public string timestamp { get; set; }
            public string signature { get; set; }

            public subscribe_msg(string Type, string Channel, string Product_ids, string API_key, string Timestamp, string Signature)
            {
                this.type = Type;
                this.channel = Channel;
                this.product_ids = new List<string>() { "SHIB-USD" };
                this.api_key = "s56G5OI9uA6rnQvA"; 
                this.timestamp = Timestamp;
                this.signature = Signature;
            }
        }
    }
}
