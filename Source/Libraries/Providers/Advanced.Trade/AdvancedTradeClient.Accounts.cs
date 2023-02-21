using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvancedTrade.Models;
using Flurl;
using Flurl.Http;

namespace AdvancedTrade
{
   public interface IAccountsEndpoint
   {
      /// <summary>
      /// Get a list of trading accounts.
      /// </summary>
      Task<Accounts> GetPagedAccountsAsync(CancellationToken cancellationToken = default, string limit = "250", string cursor = "");

      /// <summary>
      /// Get a list of trading accounts.
      /// </summary>
      List<DataAccount> GetAccountsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Information for a single account. Use this endpoint when you know the account_id.
        /// </summary>
        Task<Account> GetAccountAsync(string accountId, CancellationToken cancellationToken = default);

      /// <summary>
      /// Get account activity. Account activity either increases or decreases your account balance. Items are paginated and sorted latest first.
      /// </summary>
      Task<PagedResponse<AccountHistory>> GetAccountHistoryAsync(
         string accountId,
         int? limit = null, string before = null, string after = null,
         CancellationToken cancellationToken = default);

      /// <summary>
      /// Holds are placed on an account for any active orders or pending withdraw requests. As an order is filled, the hold amount is updated. If an order is canceled, any remaining hold is removed. For a withdraw, once it is completed, the hold is removed.
      /// </summary>
      Task<PagedResponse<AccountHold>> GetAccountHoldAsync(
         string accountId,
         int? limit = null, string before = null, string after = null,
         CancellationToken cancellationToken = default);
   }

   public partial class AdvancedTradeClient : IAccountsEndpoint
   {
      public IAccountsEndpoint Accounts => this;

      protected internal Url AccountsEndpoint => this.Config.ApiUrl.AppendPathSegment("accounts");

      Task<Accounts> IAccountsEndpoint.GetPagedAccountsAsync(CancellationToken cancellationToken, string limit = "250", string cursor = "")
      {            
            if (limit.Length > 0)
            {
                if (cursor.Length > 0)
                    return this.AccountsEndpoint.WithClient(this).SetQueryParam("limit", limit).SetQueryParam("cursor", cursor).GetJsonAsync<Accounts>();
                else
                    return this.AccountsEndpoint.WithClient(this).SetQueryParam("limit", limit).GetJsonAsync<Accounts>();
            }
            else
                return this.AccountsEndpoint.WithClient(this).GetJsonAsync<Accounts>(cancellationToken);
        }

      List<DataAccount> IAccountsEndpoint.GetAccountsAsync(CancellationToken cancellationToken) 
        {
            bool proceed = true;
            List<DataAccount> result = new List<DataAccount>();
            Task<Accounts> accounts;

            accounts = Accounts.GetPagedAccountsAsync(cancellationToken);

            while (proceed)
            {
                foreach (DataAccount item in accounts.Result.Data)
                {
                    decimal numAvailable = 1;
                    decimal numHold = 1;

                    decimal.TryParse(item.Available.value.Replace(".", ","), out numAvailable);
                    decimal.TryParse(item.Available.value.Replace(".", ","), out numHold);

                    if ((numAvailable != 0) | (numHold != 0)) result.Add(item);
                }

                proceed = accounts.Result.Has_Next;

                if (proceed) accounts = Accounts.GetPagedAccountsAsync(cancellationToken, "250", accounts.Result.Cursor);
            }

            return result;
        }

        Task<Account> IAccountsEndpoint.GetAccountAsync(string accountId, CancellationToken cancellationToken)
      {
         return this.AccountsEndpoint
            .WithClient(this)
            .AppendPathSegment(accountId)
            .GetJsonAsync<Account>(cancellationToken);
      }

      Task<PagedResponse<AccountHistory>> IAccountsEndpoint.GetAccountHistoryAsync(
         string accountId,
         int? limit, string before, string after,
         CancellationToken cancellationToken)
      {
         return this.AccountsEndpoint
            .WithClient(this)
            .AppendPathSegments(accountId, "ledger")
            .AsPagedRequest(limit, before, after)
            .GetPagedJsonAsync<AccountHistory>(cancellationToken);
      }

      Task<PagedResponse<AccountHold>> IAccountsEndpoint.GetAccountHoldAsync(
         string accountId,
         int? limit, string before, string after,
         CancellationToken cancellationToken)
      {
         return this.AccountsEndpoint
            .WithClient(this)
            .AppendPathSegments(accountId, "holds")
            .AsPagedRequest(limit, before, after)
            .GetPagedJsonAsync<AccountHold>(cancellationToken);
      }
   }
}
