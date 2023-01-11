using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvancedTrade.Models;
using Flurl;
using Flurl.Http;

namespace AdvancedTrade
{
   public interface ICoinbaseAccountsEndpoint
   {
      /// <summary>
      /// Get a list of your payment methods.
      /// </summary>
      /// <param name="cancellationToken"></param>
      Task<List<CoinbaseAccount>> GetAllAccountsAsync(CancellationToken cancellationToken = default);
   }

   public partial class AdvancedTradeClient : ICoinbaseAccountsEndpoint
   {
      public ICoinbaseAccountsEndpoint CoinbaseAccounts => this;

      protected internal Url CoinbaseAccountsEndpoint => this.Config.ApiUrl.AppendPathSegment("coinbase-accounts");

      Task<List<CoinbaseAccount>> ICoinbaseAccountsEndpoint.GetAllAccountsAsync(CancellationToken cancellationToken)
      {
         return this.CoinbaseAccountsEndpoint
            .WithClient(this)
            .GetJsonAsync<List<CoinbaseAccount>>(cancellationToken);
      }
   }
}
