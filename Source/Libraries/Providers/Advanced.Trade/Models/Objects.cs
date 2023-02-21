using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace AdvancedTrade.Models
{
    public partial class Product : Json
    {
        [JsonProperty("product_id")]
        public string ProductID { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("price_percentage_change_24h")]
        public string PricePercentageChange24h { get; set; }

        [JsonProperty("volume_24h")]
        public string Volume24h { get; set; }

        [JsonProperty("volume_percentage_change_24h")]
        public string VolumePercentageChange24h { get; set; }

        [JsonProperty("base_increment")]
        public string BaseIncrement { get; set; }

        [JsonProperty("quote_increment")]
        public string QuoteIncrement { get; set; }

        [JsonProperty("quote_min_size")]
        public string QuoteMinSize { get; set; }

        [JsonProperty("quote_max_size")]
        public string QuoteMaxSize { get; set; }

        [JsonProperty("base_min_size")]
        public decimal BaseMinSize { get; set; }

        [JsonProperty("base_max_size")]
        public decimal BaseMaxSize { get; set; }

        [JsonProperty("base_name")]
        public string BaseName { get; set; }

        [JsonProperty("quote_name")]
        public string QuoteName { get; set; }

        [JsonProperty("watched")]
        public bool Whatched { get; set; }

        [JsonProperty("is_disabled")]
        public bool IsDisabled { get; set; }

        [JsonProperty("new")]
        public bool New { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("cancel_only")]
        public bool CancelOnly { get; set; }

        [JsonProperty("limit_only")]
        public bool LimitOnly { get; set; }

        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }

        [JsonProperty("trading_disabled")]
        public bool TradingDisabled { get; set; }

        [JsonProperty("auction_mode")]
        public bool AuctionMode { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("quote_currency_id")]
        public string QuoteCurrencyId { get; set; }

        [JsonProperty("base_currency_id")]
        public string BaseCurrencyId { get; set; }

        [JsonProperty("mid_market_price")]
        public string MidMarketPrice { get; set; }
    }

    public partial class OrderBook : Json
    {
        [JsonProperty("asks", ItemConverterType = typeof(OrderBookItemConverter))]
        public OrderBookEntry[] Asks { get; set; }

        [JsonProperty("bids", ItemConverterType = typeof(OrderBookItemConverter))]
        public OrderBookEntry[] Bids { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }
    }

    public abstract class JsonConverter2<T> : JsonConverter<T>
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    public class OrderBookItemConverter : JsonConverter2<OrderBookEntry>
    {
        public override OrderBookEntry ReadJson(JsonReader reader, Type objectType, OrderBookEntry existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var price = reader.ReadAsDecimal();
            var size = reader.ReadAsDecimal();

            var obe = new OrderBookEntry
            {
                Price = price.Value,
                Size = size.Value,
            };

            reader.Read();

            if (reader.Value is long l)
            {
                obe.OrderCount = l;
            }
            else if (reader.Value is string strGuid)
            {
                obe.OrderId = strGuid;
            }

            reader.Read();

            return obe;
        }
    }

    public partial class OrderBookEntry
    {
        [JsonProperty(Order = 1)]
        public decimal Price { get; set; }
        [JsonProperty(Order = 2)]
        public decimal Size { get; set; }
        [JsonProperty(Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderCount { get; set; }
        [JsonProperty(Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }
    }

    public partial class Ticker
    {
        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("trade_id")]
        public long TradeId { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }
    }

    public partial class Trade
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("side")]
        public OrderSide Side { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("trade_id")]
        public long TradeId { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderSide
    {
        [EnumMember(Value = "buy")]
        Buy,

        [EnumMember(Value = "sell")]
        Sell
    }

    [JsonConverter(typeof(CandleConverter))]
    public class Candle
    {
        [JsonProperty(Order = 1)]
        public DateTimeOffset Time { get; set; }

        [JsonProperty(Order = 2)]
        public decimal? Low { get; set; }

        [JsonProperty(Order = 3)]
        public decimal? High { get; set; }

        [JsonProperty(Order = 4)]
        public decimal? Open { get; set; }

        [JsonProperty(Order = 5)]
        public decimal? Close { get; set; }

        [JsonProperty(Order = 6)]
        public decimal? Volume { get; set; }
    }

    public class CandleConverter : JsonConverter<Candle>
    {
        public override void WriteJson(JsonWriter writer, Candle value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("time");
            writer.WriteValue(value.Time);
            writer.WritePropertyName("low");
            writer.WriteValue(value.Low);
            writer.WritePropertyName("high");
            writer.WriteValue(value.High);
            writer.WritePropertyName("open");
            writer.WriteValue(value.Open);
            writer.WritePropertyName("close");
            writer.WriteValue(value.Close);
            writer.WritePropertyName("volume");
            writer.WriteValue(value.Volume);
            writer.WriteEndObject();
        }

        public override Candle ReadJson(JsonReader reader, Type objectType, Candle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var j = JArray.Load(reader);

            var time = j[0].Value<int>();
            var low = j.ElementAtOrDefault(1)?.Value<decimal?>();
            var high = j.ElementAtOrDefault(2)?.Value<decimal?>();
            var open = j.ElementAtOrDefault(3)?.Value<decimal?>();
            var close = j.ElementAtOrDefault(4)?.Value<decimal?>();
            var vol = j.ElementAtOrDefault(5)?.Value<decimal?>();

            var c = new Candle
            {
                Time = TimeHelper.FromUnixTimestampSeconds(time),
                Low = low,
                High = high,
                Open = open,
                Close = close,
                Volume = vol
            };

            return c;
        }
    }

    public partial class Stats : Json
    {
        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("volume_30day")]
        public decimal Volume30Day { get; set; }
    }

    public partial class Currency : Json
    {
        [JsonProperty("details")]
        public JObject Details { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("min_size")]
        public decimal MinSize { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("convertible_to", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ConvertibleTo { get; set; }
    }

    public partial class Time : Json
    {
        [JsonProperty("iso")]
        public DateTimeOffset Iso { get; set; }

        [JsonProperty("epoch")]
        public long Epoch { get; set; }
    }

    public partial class Balance
    {
        [JsonProperty("value")]
        public string value { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }
    }

    public partial class DataAccount : Json
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("available_balance")]
        public Balance Available { get; set; }

        [JsonProperty("hold")]
        public Balance Hold { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created_at")]
        public string Created_At { get; set; }

        [JsonProperty("updated_at")]
        public string Updated_At { get; set; }

        [JsonProperty("deleted_at")]
        public string Deleted_At { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }
    }

    public partial class Accounts : Json
    {
        [JsonProperty("accounts")]
        public DataAccount[] Data { get; set; }

        [JsonProperty("has_next")]
        public bool Has_Next { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
    }

    public partial class Account : Json
   {
      /// <summary>
      /// Account Id
      /// </summary>
      [JsonProperty("id")]
      public string Id { get; set; }

      /// <summary>
      /// the currency of the account
      /// </summary>
      [JsonProperty("currency")]
      public string Currency { get; set; }

      /// <summary>
      /// total funds in the account
      /// </summary>
      [JsonProperty("balance")]
      public decimal Balance { get; set; }

      /// <summary>
      /// funds available to withdraw or trade
      /// </summary>
      [JsonProperty("available")]
      public decimal Available { get; set; }

      /// <summary>
      /// funds on hold (not available for use).
      /// When you place an order, the funds for the order are placed on hold. They cannot be used for other orders or withdrawn. Funds will remain on hold until the order is filled or canceled
      /// </summary>
      [JsonProperty("hold")]
      public decimal Hold { get; set; }

      [JsonProperty("profile_id")]
      public string ProfileId { get; set; }
   }

   public class AccountHistory : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("created_at")]
      public DateTimeOffset CreatedAt { get; set; }

      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("balance")]
      public decimal Balance { get; set; }

      [JsonProperty("type")]
      public string Type { get; set; }

      [JsonProperty("details")]
      public AccountDetails Details { get; set; }
   }

   public partial class AccountDetails : Json
   {
      [JsonProperty("transfer_id")]
      public string TransferId { get; set; }

      [JsonProperty("transfer_type")]
      public string TransferType { get; set; }

      [JsonProperty("order_id")]
      public string OrderId { get; set; }

      [JsonProperty("trade_id")]
      public string TradeId { get; set; }

      public string ProductId { get; set; }
   }

   public partial class AccountHold : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("account_id")]
      public string AccountId { get; set; }

      [JsonProperty("created_at")]
      public DateTimeOffset CreatedAt { get; set; }

      [JsonProperty("updated_at")]
      public DateTimeOffset UpdatedAt { get; set; }

      [JsonProperty("amount")]
      public string Amount { get; set; }

      [JsonProperty("type")]
      public string Type { get; set; }

      [JsonProperty("ref")]
      public string Ref { get; set; }
   }

   public partial class OrderRequest : Json
   {
      [JsonProperty("size")]
      public string Size { get; set; }

      [JsonProperty("price")]
      public string Price { get; set; }

      [JsonProperty("side")]
      public OrderSide Side { get; set; }

      [JsonProperty("product_id")]
      public string ProductId { get; set; }
   }

   public class OrderConfigurationMaker
    {
        [JsonProperty("quote_size")]
        public string QuoteSize { get; set; }

        [JsonProperty("base_size")]
        public string BaseSize { get; set; }
    }

   public class OrderConfigurationLimitGtc
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public decimal LimitPrice { get; set; }

        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }
    }

    public class NewOrderConfigurationLimitGtc
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public string LimitPrice { get; set; }

        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }
    }

    public class OrderConfigurationLimitGtd
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public decimal LimitPrice { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }
    }

    public class NewOrderConfigurationLimitGtd
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public string LimitPrice { get; set; }

        [JsonProperty("end_time")]
        public DateTimeOffset EndTime { get; set; }

        [JsonProperty("post_only")]
        public bool PostOnly { get; set; }
    }

    public class OrderConfigurationStopLimitGtc
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public decimal LimitPrice { get; set; }

        [JsonProperty("stop_price")]
        public decimal StopPrice { get; set; }

        [JsonProperty("stop_direction")]
        public StopDirectionType StopDirection { get; set; }
    }

    public class NewOrderConfigurationStopLimitGtc
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public string LimitPrice { get; set; }

        [JsonProperty("stop_price")]
        public string StopPrice { get; set; }

        [JsonProperty("stop_direction")]
        public string StopDirection { get; set; }
    }

    public class OrderConfigurationStopLimitGtd
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public decimal LimitPrice { get; set; }

        [JsonProperty("stop_price")]
        public decimal StopPrice { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("stop_direction")]
        public StopDirectionType StopDirection { get; set; }
    }

    public class NewOrderConfigurationStopLimitGtd
    {
        [JsonProperty("base_size")]
        public string BaseSize { get; set; }

        [JsonProperty("limit_price")]
        public string LimitPrice { get; set; }

        [JsonProperty("stop_price")]
        public string StopPrice { get; set; }

        [JsonProperty("end_time")]
        public DateTimeOffset EndTime { get; set; }

        [JsonProperty("stop_direction")]
        public string StopDirection { get; set; }
    }

    public class OrderConfiguration
    {
        [JsonProperty("market_market_ioc")]
        public OrderConfigurationMaker MarketIoc { get; set; }

        [JsonProperty("limit_limit_gtc")]
        public OrderConfigurationLimitGtc LimitGtc { get; set; }

        [JsonProperty("limit_limit_gtd")]
        public OrderConfigurationLimitGtd LimitGtd { get; set; }

        [JsonProperty("stop_limit_gtc")]
        public OrderConfigurationStopLimitGtc StopLimitGtc { get; set; }

        [JsonProperty("stop_limit_gtd")]
        public OrderConfigurationStopLimitGtd StopLimitGtd { get; set; }
    }

    public class NewOrderConfiguration
    {
        [JsonProperty("market_market_ioc")]
        public OrderConfigurationMaker MarketIoc { get; set; }

        [JsonProperty("limit_limit_gtc")]
        public NewOrderConfigurationLimitGtc LimitGtc { get; set; }

        [JsonProperty("limit_limit_gtd")]
        public NewOrderConfigurationLimitGtd LimitGtd { get; set; }

        [JsonProperty("stop_limit_stop_limit_gtc")]
        public NewOrderConfigurationStopLimitGtc StopLimitGtc { get; set; }

        [JsonProperty("stop_limit_stop_limit_gtd")]
        public NewOrderConfigurationStopLimitGtd StopLimitGtd { get; set; }
    }

    public partial class OrderDetails : Json
   {
      [JsonProperty("order_id")]
      public string Order_Id { get; set; }

      [JsonProperty("product_id")]
      public string ProductId { get; set; }

      [JsonProperty("user_id")]
      public string UserId { get; set; }

      [JsonProperty("order_configuration")]
      public OrderConfiguration OrderConfigurationData { get; set; }

      [JsonProperty("side")]
      public SideType Side { get; set; }

      [JsonProperty("client_order_id")]
      public string ClientOrderId { get; set; }

      [JsonProperty("status")]
      public StatusType Status { get; set; }

      [JsonProperty("time_in_force")]
      public TimeInForceType TimeInForce { get; set; }

      [JsonProperty("created_time")]
      public DateTimeOffset CreatedTime { get; set; }

      [JsonProperty("completion_percentage")]
      public decimal CompletionPercentage { get; set; }

      [JsonProperty("filled_size")]
      public decimal FilledSize { get; set; }

      [JsonProperty("average_filled_price")]
      public decimal AverageFilledPrice { get; set; }

      [JsonProperty("fee")]
      public string Fee { get; set; }

      [JsonProperty("number_of_fills")]
      public decimal NumberOfFills { get; set; }

      [JsonProperty("filled_value")]
      public decimal FilledValue { get; set; }

      [JsonProperty("pending_cancel")]
      public bool PendingCancel { get; set; }

      [JsonProperty("size_in_quote")]
      public bool SizeInQuote { get; set; }

      [JsonProperty("total_fees")]
      public decimal TotalFees { get; set; }

      [JsonProperty("size_inclusive_of_fees")]
      public bool SizeInclusiveOfFees { get; set; }

      [JsonProperty("total_value_after_fees")]
      public decimal TotalValueAfterFees { get; set; }

      [JsonProperty("trigger_status")]
      public TriggerStatusType TriggerStatus { get; set; }

      [JsonProperty("order_type")]
      public OrderType OrderType { get; set; }

      [JsonProperty("reject_reason")]
      public RejectReasonType RejectReason { get; set; }

      [JsonProperty("settled")]
      public bool Settled { get; set; }

      [JsonProperty("product_type")]
      public ProductType ProductType { get; set; }

      [JsonProperty("reject_message")]
      public string RejectMessage { get; set; }

      [JsonProperty("cancel_message")]
      public string CancelMessage { get; set; }

      [JsonProperty("order_placement_source")]
      public OrderPlacementSourceType OrderPlacementSource { get; set; }
    }

    public partial class Order
    {
        [JsonProperty("order")]
        public OrderDetails OrderData { get; set; }
    }

    public partial class OrderList
    {
        [JsonProperty("orders")]
        public List<OrderDetails> Orders { get; set; }

        [JsonProperty("sequence")]
        public Int64 Sequence { get; set; }

        [JsonProperty("has_next")]
        public bool HasNext { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }

    public partial class OrderCancel
   {
        [JsonProperty("order_ids")]
        public List<string> Order_Ids { get; set; }

        public OrderCancel()
        {
            Order_Ids = new List<string>();
        }
   }

   /// <summary>
   /// Time in force policies provide guarantees about the lifetime of
   /// an order. There are four policies: good till canceled GTC, good
   /// till time GTT, immediate or cancel IOC, and fill or kill FOK
   /// </summary>
   [JsonConverter(typeof(StringEnumConverter))]
   public enum TimeInForce
   {
      /// <summary>
      /// Good till canceled orders remain open on the book until
      /// canceled. This is the default behavior if no policy is specified.
      /// </summary>
      [EnumMember(Value = "GTC")]
      GoodTillCanceled,

      /// <summary>
      /// Good till time orders remain open on the book until
      /// canceled or the allotted cancel_after is depleted on the
      /// matching engine. GTT orders are guaranteed to cancel before
      /// any other order is processed after the cancel_after timestamp
      /// which is returned by the API. A day is considered 24 hours.
      /// </summary>
      [EnumMember(Value = "GTT")]
      GoodTillTime,

      /// <summary>
      /// Immediate or cancel orders instantly cancel the remaining
      /// size of the limit order instead of opening it on the book.
      /// </summary>
      [EnumMember(Value = "IOC")]
      ImmediateOrCancel,

      /// <summary>
      /// Fill or kill orders are rejected if the entire size
      /// cannot be matched.
      /// </summary>
      [EnumMember(Value = "FOK")]
      FillOrKill
   }

   public partial class Fill : Json
   {
      [JsonProperty("entry_id")]
      public string EntryId { get; set; }

      [JsonProperty("trade_id")]
      public string TradeId { get; set; }

      [JsonProperty("order_id")]
      public string OrderId { get; set; }

      [JsonProperty("trade_time")]
      public DateTimeOffset TradeTime { get; set; }

      [JsonProperty("trade_type")]
      public TradeType TradeType { get; set; }

      [JsonProperty("price")]
      public decimal Price { get; set; }

      [JsonProperty("size")]
      public decimal Size { get; set; }

      [JsonProperty("commission")]
      public string Commission { get; set; }

      [JsonProperty("product_id")]
      public string ProductId { get; set; }

      [JsonProperty("sequence_timestamp")]
      public DateTimeOffset SequenceTimeStamp { get; set; }

      [JsonProperty("liquidity_indicator")]
      public LiquidityIndicatorType LiquidityIndicator { get; set; }

      [JsonProperty("size_in_quote")]
      public bool SizeInQuote { get; set; }

      [JsonProperty("user_id")]
      public string UserId { get; set; }

      [JsonProperty("side")]
      public SideType Side { get; set; }
   }

   public partial class FillList
   {
        [JsonProperty("fills")]
        public List<Fill> Fills { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }
    }

   public partial class NewOrderParameter
   {
        [JsonProperty("client_order_id")]
        public string ClientOrderId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("order_configuration")]
        public NewOrderConfiguration OrderConfiguration { get; set; }

        public NewOrderParameter()
        {
            OrderConfiguration = new NewOrderConfiguration();

            /*OrderConfiguration.LimitGtc = new NewOrderConfigurationLimitGtc();
            OrderConfiguration.LimitGtd = new NewOrderConfigurationLimitGtd();
            OrderConfiguration.MarketIoc = new OrderConfigurationMaker();
            OrderConfiguration.StopLimitGtc = new NewOrderConfigurationStopLimitGtc();
            OrderConfiguration.StopLimitGtd = new NewOrderConfigurationStopLimitGtd();*/
        }
    }

    public partial class SuccessResponseInformations
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("client_order_id")]
        public string ClientOrderId { get; set; }
    }

    public partial class ErrorResponseInformations
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error_details")]
        public string ErrorDetails { get; set; }

        [JsonProperty("preview_failure_reason")]
        public string PreviewFailureReason { get; set; }

        [JsonProperty("new_order_failure_reason")]
        public string NewOrderFailureReason { get; set; }
    }

    public partial class ResponsePlaceOrder
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("failure_reason")]
        public string FailureReason { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("success_response")]
        public SuccessResponseInformations SuccessResponse { get; set; }

        [JsonProperty("error_response")]
        public ErrorResponseInformations ErrorResponse { get; set; }

        [JsonProperty("order_configuration")]
        public NewOrderConfiguration OrderConfiguration { get; set; }
    }

    public partial class PaymentMethodDeposit : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }

      [JsonProperty("payout_at")]
      public DateTimeOffset PayoutAt { get; set; }
   }

   public partial class CoinbaseDeposit : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }
   }

   public class PaymentMethodWithdraw : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }

      [JsonProperty("payout_at")]
      public DateTimeOffset PayoutAt { get; set; }
   }

   public class CoinbaseWithdraw : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }
   }

   public class CryptoWithdraw : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }

      [JsonProperty("fee")]
      public decimal Fee { get; set; }

      [JsonProperty("subtotal")]
      public decimal Subtotal { get; set; }
    }

    public class FeeEstimate : Json
    {
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
    }

    public partial class Withdrawal : Json
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        [JsonProperty("completed_at")]
        public DateTimeOffset? CompletedAt { get; set; }
        [JsonProperty("canceled_at")]
        public DateTimeOffset? CanceledAt { get; set; }
        [JsonProperty("processed_at")]
        public DateTimeOffset? ProcessedAt { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_nonce")]
        public string UserNonce { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("details")]
        public WithdrawalDetails Details { get; set; }
    }

    public partial class WithdrawalDetails : Json
    {
        [JsonProperty("destination_tag")]
        public string DestinationTag { get; set; }
        [JsonProperty("sent_to_address")]
        public string SentToAddress { get; set; }
        [JsonProperty("coinbase_account_id")]
        public string CoinbaseAccountId { get; set; }
        [JsonProperty("destination_tag_name")]
        public string DestinationTagName { get; set; }
        [JsonProperty("coinbase_withdrawal_id")]
        public string CoinbaseWithdrawalId { get; set; }
        [JsonProperty("coinbase_transaction_id")]
        public string CoinbaseTransactionId { get; set; }
        [JsonProperty("crypto_transaction_hash")]
        public string CryptoTransactionHash { get; set; }
        [JsonProperty("coinbase_payment_method_id")]
        public string CoinbasePaymentMethodId { get; set; }
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }
    }

    public partial class Deposit : Json
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        [JsonProperty("completed_at")]
        public DateTimeOffset? CompletedAt { get; set; }
        [JsonProperty("canceled_at")]
        public DateTimeOffset? CanceledAt { get; set; }
        [JsonProperty("processed_at")]
        public DateTimeOffset? ProcessedAt { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_nonce")]
        public string UserNonce { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("details")]
        public DepositDetails Details { get; set; }
    }

    public partial class DepositDetails : Json
    {
        [JsonProperty("crypto_address")]
        public string CryptoAddress { get; set; }
        [JsonProperty("destination_tag")]
        public string DestinationTag { get; set; }
        [JsonProperty("coinbase_account_id")]
        public string CoinbaseAccountId { get; set; }
        [JsonProperty("destination_tag_name")]
        public string DestinationTagName { get; set; }
        [JsonProperty("crypto_transaction_id")]
        public string CryptoTransactionId { get; set; }
        [JsonProperty("coinbase_transaction_id")]
        public string CoinbaseTransactionId { get; set; }
        [JsonProperty("crypto_transaction_hash")]
        public string CryptoTransactionHash { get; set; }
    }

    public partial class GeneratedDepositCryptoAddress : Json
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("destination_tag")]
        public string DestinationTag { get; set; }
        [JsonProperty("address_info")]
        public GeneratedDepositCryptoAddressAddressInfo AddressInfo { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
        [JsonProperty("network")]
        public string Network { get; set; }
        [JsonProperty("resource")]
        public string Resource { get; set; }
        [JsonProperty("deposit_uri")]
        public string DepositUri { get; set; }
        [JsonProperty("exchange_deposit_address")]
        public bool ExchangeDepositAddress { get; set; }
    }

    public partial class GeneratedDepositCryptoAddressAddressInfo : Json
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("destination_tag")]
        public string DestinationTag { get; set; }
    }

    public partial class Conversion : Json
    {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("from_account_id")]
      public string FromAccountId { get; set; }

      [JsonProperty("to_account_id")]
      public string ToAccountId { get; set; }

      [JsonProperty("from")]
      public string From { get; set; }

      [JsonProperty("to")]
      public string To { get; set; }
   }

   public partial class PaymentMethod : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("type")]
      public string Type { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }

      [JsonProperty("primary_buy")]
      public bool PrimaryBuy { get; set; }

      [JsonProperty("primary_sell")]
      public bool PrimarySell { get; set; }

      [JsonProperty("allow_buy")]
      public bool AllowBuy { get; set; }

      [JsonProperty("allow_sell")]
      public bool AllowSell { get; set; }

      [JsonProperty("allow_deposit")]
      public bool AllowDeposit { get; set; }

      [JsonProperty("allow_withdraw")]
      public bool AllowWithdraw { get; set; }

      [JsonProperty("limits")]
      public Limits Limits { get; set; }
   }

   public partial class Limits : Json
   {
      [JsonProperty("buy")]
      public Limit[] Buy { get; set; }

      [JsonProperty("instant_buy")]
      public Limit[] InstantBuy { get; set; }

      [JsonProperty("sell")]
      public Limit[] Sell { get; set; }

      [JsonProperty("deposit")]
      public Limit[] Deposit { get; set; }
   }

   public partial class Limit : Json
   {
      [JsonProperty("period_in_days")]
      public long PeriodInDays { get; set; }

      [JsonProperty("total")]
      public Money Total { get; set; }

      [JsonProperty("remaining")]
      public Money Remaining { get; set; }
   }

   public partial class Money : Json
   {
      [JsonProperty("amount")]
      public decimal Amount { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }
   }

   public partial class CoinbaseAccount : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("balance")]
      public decimal Balance { get; set; }

      [JsonProperty("currency")]
      public string Currency { get; set; }

      [JsonProperty("type")]
      public string Type { get; set; }

      [JsonProperty("primary")]
      public bool Primary { get; set; }

      [JsonProperty("active")]
      public bool Active { get; set; }

      [JsonProperty("wire_deposit_information", NullValueHandling = NullValueHandling.Ignore)]
      public WireDepositInformation WireDepositInformation { get; set; }

      [JsonProperty("sepa_deposit_information", NullValueHandling = NullValueHandling.Ignore)]
      public SepaDepositInformation SepaDepositInformation { get; set; }
   }

   public static class ExtensionsForCoinbaseAccount
   {
      public static bool IsWallet(this CoinbaseAccount ca)
      {
         return ca.Type == "wallet";
      }

      public static bool IsFiat(this CoinbaseAccount ca)
      {
         return ca.Type == "fiat";
      }

      public static bool IsMultisig(this CoinbaseAccount ca)
      {
         return ca.Type == "multisig";
      }

      public static bool IsVault(this CoinbaseAccount ca)
      {
         return ca.Type == "vault";
      }

      public static bool IsMultiSigVault(this CoinbaseAccount ca)
      {
         return ca.Type == "multisig_vault";
      }
   }

   public partial class WireDepositInformation : Json
   {
      [JsonProperty("account_number")]
      public string AccountNumber { get; set; }

      [JsonProperty("routing_number")]
      public string RoutingNumber { get; set; }

      [JsonProperty("bank_name")]
      public string BankName { get; set; }

      [JsonProperty("bank_address")]
      public string BankAddress { get; set; }

      [JsonProperty("bank_country")]
      public BankCountry BankCountry { get; set; }

      [JsonProperty("account_name")]
      public string AccountName { get; set; }

      [JsonProperty("account_address")]
      public string AccountAddress { get; set; }

      [JsonProperty("reference")]
      public string Reference { get; set; }
   }

   public partial class SepaDepositInformation : Json
   {
      [JsonProperty("iban")]
      public string Iban { get; set; }

      [JsonProperty("swift")]
      public string Swift { get; set; }

      [JsonProperty("bank_name")]
      public string BankName { get; set; }

      [JsonProperty("bank_address")]
      public string BankAddress { get; set; }

      [JsonProperty("bank_country_name")]
      public string BankCountryName { get; set; }

      [JsonProperty("account_name")]
      public string AccountName { get; set; }

      [JsonProperty("account_address")]
      public string AccountAddress { get; set; }

      [JsonProperty("reference")]
      public string Reference { get; set; }
   }

   public partial class BankCountry : Json
   {
      [JsonProperty("code")]
      public string Code { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }
   }

   public partial class Report : Json
   {
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("type")]
      public ReportType Type { get; set; }

      [JsonProperty("status")]
      public string Status { get; set; }

      [JsonProperty("created_at")]
      public DateTimeOffset CreatedAt { get; set; }

      [JsonProperty("completed_at")]
      public DateTimeOffset? CompletedAt { get; set; }

      [JsonProperty("expires_at")]
      public DateTimeOffset ExpiresAt { get; set; }

      [JsonProperty("file_url")]
      public string FileUrl { get; set; }

      [JsonProperty("params")]
      public ReportParams Params { get; set; }
   }

   public partial class ReportParams : Json
   {
      [JsonProperty("start_date")]
      public DateTimeOffset StartDate { get; set; }

      [JsonProperty("end_date")]
      public DateTimeOffset EndDate { get; set; }
   }

   [JsonConverter(typeof(StringEnumConverter))]
   public enum ReportType
   {
      [EnumMember(Value = "fills")]
      Fills,
      [EnumMember(Value = "account")]
      Account
   }

   public partial class TrailingVolume : Json
    {
      [JsonProperty("product_id")]
      public string ProductId { get; set; }

      [JsonProperty("exchange_volume")]
      public decimal ExchangeVolume { get; set; }

      [JsonProperty("volume")]
      public decimal Volume { get; set; }

      [JsonProperty("recorded_at")]
      public DateTimeOffset RecordedAt { get; set; }
   }

   public partial class MakerTakerFees : Json
   {
        [JsonProperty("maker_fee_rate")]
        public decimal MakerFeeRate { get; set; }
        [JsonProperty("taker_fee_rate")]
        public decimal TakerFeeRate { get; set; }
        [JsonProperty("usd_volume")]
        public decimal? UsdVolume { get; set; }
    }
}
