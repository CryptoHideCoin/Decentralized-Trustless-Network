using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvancedTrade.Models;
using Flurl.Http;

namespace AdvancedTrade
{
   public static class ExtensionsForAdvancedTradeClient
   {
      public static IFlurlRequest AsPagedRequest(this IFlurlRequest r, int? limit = 100, long? before = null, long? after = null)
      {
         return r.SetQueryParam("limit", limit)
            .SetQueryParam("before", before)
            .SetQueryParam("after", after);
      }

      public static async Task<PagedResponse<T>> GetPagedJsonAsync<T>(this IFlurlRequest request, CancellationToken cancellationToken = default(CancellationToken))
      {
         var task = request.GetAsync(cancellationToken);
         var r = await task.ConfigureAwait(false);

         var data = await task.ReceiveJson<List<T>>().ConfigureAwait(false);

         var p = new PagedResponse<T>
            {
               Data = data
            };

         if( long.TryParse(r.GetHeaderValue(HeaderNames.Before), out var before) )
         {
            p.Before = before;
         }

         if( long.TryParse(r.GetHeaderValue(HeaderNames.After), out var after) )
         {
            p.After = after;
         }

         return p;
      }
   }
}
