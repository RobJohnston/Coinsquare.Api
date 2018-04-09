using Newtonsoft.Json;

namespace Coinsquare.Api.Models
{
    /// <summary>
    /// Represents a collection of order book entries and recent market transactions.
    /// </summary>
    public partial class BookData
    {
        /// <summary>
        /// A list of order book entries.
        /// </summary>
        [JsonProperty("book")]
        public Book[] Books { get; set; }

        /// <summary>
        /// A list of recent market transactions.
        /// </summary>
        [JsonProperty("sales")]
        public Sale[] Sales { get; set; }
    }

    /// <summary>
    /// Represents an order book entry.
    /// </summary>
    public partial class Book
    {
        /// <summary>
        /// An integer used to order the entries.
        /// </summary>
        [JsonProperty("i")]
        public int Index { get; set; }

        /// <summary>
        /// Either "buy" or "sell", indicating the type of the order.
        /// </summary>
        [JsonProperty("t")]
        public OrderType Type { get; set; }

        /// <summary>
        /// Price of the order.
        /// </summary>
        [JsonProperty("prc")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Amount of the order, in Satoshis.
        /// </summary>
        [JsonProperty("amt")]
        public decimal? Amount { get; set; }

        [JsonProperty("base")]
        public decimal? Base { get; set; }

        /// <summary>
        /// A running sum of all <c>Base</c> values in order of <c>Index</c>.
        /// </summary>
        [JsonProperty("sum")]
        public decimal? Sum { get; set; }
    }

    /// <summary>
    /// Represents a market transaction.
    /// </summary>
    public partial class Sale
    {
        /// <summary>
        /// An integer used to order the transactions.
        /// </summary>
        [JsonProperty("i")]
        public int Index { get; set; }

        /// <summary>
        /// A unique identifier for the trade.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The date and time of the trade, in YYYY-MM-DD HH-mm format.
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// Either "buy" or "sell", indicating the type of the order.
        /// </summary>
        [JsonProperty("t")]
        public OrderType Type { get; set; }

        /// <summary>
        /// The amount executed.
        /// </summary>
        [JsonProperty("amt")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Price of trade.
        /// </summary>
        [JsonProperty("prc")]
        public decimal Price { get; set; }

        [JsonProperty("base")]
        public decimal Base { get; set; }
    }
}
