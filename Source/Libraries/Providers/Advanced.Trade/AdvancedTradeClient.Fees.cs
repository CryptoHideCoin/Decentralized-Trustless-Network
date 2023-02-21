using System.Threading;
using System.Threading.Tasks;
using AdvancedTrade.Models;
using Flurl.Http;

namespace AdvancedTrade
{
    public interface IFeesEndpoint
    {
        /// <summary>
        /// This request will return your current maker and taker fee rates,
        /// as well as your 30-day trailing volume. Quoted rates are subject
        /// to change.
        /// </summary>
        /// <param name="cancellationToken"></param>
        Task<MakerTakerFees> GetCurrentFeesAsync(CancellationToken cancellationToken = default);
    }

    public partial class AdvancedTradeClient : IFeesEndpoint
    {
        public IFeesEndpoint Fees => this;

        Task<MakerTakerFees> IFeesEndpoint.GetCurrentFeesAsync(CancellationToken cancellationToken)
        {
            return this.Config.ApiUrl
               .WithClient(this)
               .AppendPathSegment("fees")
               .GetJsonAsync<MakerTakerFees>(cancellationToken);
        }
    }
}
