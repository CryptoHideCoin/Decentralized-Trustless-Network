using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvancedTrade.Models;
using Flurl;
using Flurl.Http;

namespace AdvancedTrade
{
   public interface IOrdersEndpoint
   {
      /// <summary>
      /// List your current open orders. Only open or un-settled orders are returned.
      /// As soon as an order is no longer open and settled, it will no longer
      /// appear in the default request.
      /// </summary>
      /// <param name="status">Status: ['open', 'pending', 'active', 'all']. Limit list of orders to these
      /// statuses. Passing 'all' returns orders of all statuses. To specify multiple statuses,
      /// supply a comma delimited list of statuses. IE: 'open, pending'.</param>
      /// <param name="productId">The coinbase specific product id. IE: 'BTC-USD', 'ETH-USD', etc.</param>
      /// <param name="limit">Number of results per request. Maximum 100. (default 100)</param>
      /// <param name="before">Request page before (newer) this pagination id.</param>
      /// <param name="after">Request page after (older) this pagination id.</param>
      Task<PagedResponse<Order>> GetAllOrdersAsync(
         string status = "all",
         string productId = null,
         int? limit = null, string before = null, string after = null,
         CancellationToken cancellationToken = default);

      /// <summary>
      /// Get a single order by order id.
      /// </summary>
      Task<Order> GetOrderAsync(string orderId, CancellationToken cancellationToken = default);

      Task<OrderList> GetProductOrdersAsync(string productId, CancellationToken cancellationToken = default);

      Task<FillList> GetProductFillOrdersAsync(string productId, string orderId, CancellationToken cancellationToken = default);

      Task<ResponsePlaceOrder> PlaceOrderAsync(string productId, bool sideBuy, decimal quantity, decimal limitPrice, CancellationToken cancellationToken = default);

      /// <summary>
      /// Cancel a previously placed order.
      /// If the order had no matches during its lifetime its record may be purged.
      /// </summary>
      Task<JsonResults> CancelOrderByIdAsync(string orderId, CancellationToken cancellationToken = default);

      /// <summary>
      /// Cancel a previously placed order.
      /// If the order had no matches during its lifetime its record may be purged.
      /// </summary>
      Task<JsonResults> CancelOrdersByIdAsync(OrderCancel ids, CancellationToken cancellationToken = default);
   }

    public partial class AdvancedTradeClient : IOrdersEndpoint
    {
        public IOrdersEndpoint Orders => this;

        protected internal Url OrdersEndpoint => this.Config.ApiUrl.AppendPathSegment("orders");

        Task<PagedResponse<Order>> IOrdersEndpoint.GetAllOrdersAsync(
           string status, string productId,
           int? limit, string before, string after,
           CancellationToken cancellationToken)
        {
            var statuses = status.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return this.OrdersEndpoint
               .WithClient(this)
               .SetQueryParam("status", statuses)
               .SetQueryParam("product_id", productId)
               .AsPagedRequest(limit, before, after)
               .GetPagedJsonAsync<Order>(cancellationToken);
        }

        Task<Order> IOrdersEndpoint.GetOrderAsync(
           string orderId, CancellationToken cancellationToken)
        {
            return this.OrdersEndpoint
               .WithClient(this)
               .AppendPathSegment("historical")
               .AppendPathSegment(orderId)
               .GetJsonAsync<Order>(cancellationToken);
        }

        Task<OrderList> IOrdersEndpoint.GetProductOrdersAsync(
            string productId, CancellationToken cancellationToken = default)
        {
            return this.OrdersEndpoint
                .WithClient(this)
                .AppendPathSegment("historical")
                .AppendPathSegment("batch")
                .SetQueryParam("limit", "5")
                .SetQueryParam("product_id", productId)
                .GetJsonAsync<OrderList>(cancellationToken);
        }

        Task<FillList> IOrdersEndpoint.GetProductFillOrdersAsync(
            string productId, string orderId, CancellationToken cancellationToken = default)
        {
            var baseObject = this.OrdersEndpoint
                .WithClient(this)
                .AppendPathSegment("historical")
                .AppendPathSegment("fills")
                .SetQueryParam("limit", "5");

            if (productId.Length > 0)
                baseObject.SetQueryParam("product_id", productId);

            if (orderId.Length > 0)
                baseObject.SetQueryParam("order_id", orderId);

            return baseObject
                .GetJsonAsync<FillList>(cancellationToken);
        }

        Task<ResponsePlaceOrder> IOrdersEndpoint.PlaceOrderAsync(string productId, bool sideBuy, decimal quantity, decimal limitPrice, CancellationToken cancellationToken = default)
        {
            NewOrderParameter data = new NewOrderParameter();

            data.ClientOrderId = Guid.NewGuid().ToString();
            data.ProductId = productId;

            if (sideBuy == true)
                data.Side = "BUY";
            else
                data.Side = "SELL";

            data.OrderConfiguration.LimitGtc = new NewOrderConfigurationLimitGtc();

            data.OrderConfiguration.LimitGtc.BaseSize = quantity.ToString("0.00").Replace(",", ".");
            data.OrderConfiguration.LimitGtc.LimitPrice = limitPrice.ToString("0.00").Replace(",", ".");
            data.OrderConfiguration.LimitGtc.PostOnly = true;

            var request = this.OrdersEndpoint
                        .WithClient(this)
                        .PostJsonAsync(data, cancellationToken)
                        .ReceiveJson<ResponsePlaceOrder>();

            request.Wait();

            return request;
        }

        Task<JsonResults> IOrdersEndpoint.CancelOrderByIdAsync(
           string orderId,
           CancellationToken cancellationToken)
        {
            OrderCancel values = new OrderCancel();

            values.Order_Ids.Add(orderId);

            return Orders.CancelOrdersByIdAsync(values, cancellationToken);
        }

        Task<JsonResults> IOrdersEndpoint.CancelOrdersByIdAsync(
         OrderCancel ids,
         CancellationToken cancellationToken)
        {
            var request = this.OrdersEndpoint
                        .WithClient(this)
                        .AppendPathSegment("batch_cancel")
                        .PostJsonAsync(ids, cancellationToken)
                        .ReceiveJson<JsonResults>();

            return request;
        }

        
   }
}
