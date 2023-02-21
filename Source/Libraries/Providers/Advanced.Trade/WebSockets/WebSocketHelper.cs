using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AdvancedTrade.Models;
using System.Security.Cryptography;

namespace AdvancedTrade.WebSockets
{
   public static class WebSocketHelper
   {
       public static async Task<string> MakeAuthenticatedSubscriptionAsync(Subscription subscription, WebSocketConfig config)
       {

        string UTCtime()
        {
            DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
            
            string unixTime = dto.ToUnixTimeSeconds().ToString();
            return unixTime;
        }

        subscription.ApiKey = config.ApiKey;
        subscription.Timestamp = UTCtime();

        string body = string.Join(",", subscription.ProductIds);

        subscription.Signature = ApiKeyAuthenticator.GenerateSignature(subscription.Channel, subscription.Timestamp, body, config.ApiPrivate);

        return JsonConvert.SerializeObject(subscription);
      }

      public static bool TryParse(string json, out object parsed)
      {
         var obj = JObject.Parse(json);

         if (!obj.ContainsKey("channel"))
         {
            parsed = null;
            return false;
         }

         var channel = obj["channel"].Value<string>();

         switch(channel)
         {
            case "heartbeat":
               parsed = obj.ToObject<HeartbeatEvent>();
               break;

            case "subscriptions":
               parsed = obj.ToObject<SubscriptionsEvent>();
               break;

            case "ticker":
               parsed = obj.ToObject<EventTickers>();
               break;

            case "snapshot":
               parsed = obj.ToObject<SnapshotEvent>();
               break;

            case "l2update":
               parsed = obj.ToObject<L2UpdateEvent>();
               break;

            case "received":
               parsed = obj.ToObject<ReceivedEvent>();
               break;

            case "open":
               parsed = obj.ToObject<OpenEvent>();
               break;

            case "done":
               parsed = obj.ToObject<DoneEvent>();
               break;

            case "match":
               parsed = obj.ToObject<MatchEvent>();
               break;

            case "change":
               parsed = obj.ToObject<ChangeEvent>();
               break;

            case "activate":
               parsed = obj.ToObject<ActivateEvent>();
               break;

            case "error":
                parsed = obj.ToObject<ErrorEvent>();
                break;

            default:
               parsed = null;
               return false;
         }
         
         return true;
      }
   }
}
