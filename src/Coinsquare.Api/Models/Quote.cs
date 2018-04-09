using Newtonsoft.Json;

namespace Coinsquare.Api.Models
{
    public partial class QuoteData
    {
        /// <summary>
        /// A list of quotes.
        /// </summary>
        [JsonProperty("quotes")]
        public Quote[] Quotes { get; set; }

        /// <summary>
        /// The sum off all <c>VolBase</c> for each <c>Quote</c>.
        /// </summary>
        [JsonProperty("volbasesum")]
        public ulong VolBaseSum { get; set; }
    }

    /// <summary>
    /// Represents trading information.
    /// </summary>
    public partial class Quote
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        /// <summary>
        /// Either "open" or "index".  An index does not have a <c>Bid</c> or <c>Ask</c>.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Last price.
        /// </summary>
        [JsonProperty("last")]
        public decimal Last { get; set; }

        /// <summary>
        /// Last 24 hour volume.
        /// </summary>
        [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Volume { get; set; }

        [JsonProperty("volbase")]
        public decimal? VolBase { get; set; }

        /// <summary>
        /// Highest buy order.
        /// </summary>
        [JsonProperty("bid")]
        public decimal? Bid { get; set; }

        /// <summary>
        /// Lowest sell order.
        /// </summary>
        [JsonProperty("ask")]
        public decimal? Ask { get; set; }

        /// <summary>
        /// Last 24 hours price low.
        /// </summary>
        [JsonProperty("low24")]
        public decimal Low24 { get; set; }

        /// <summary>
        /// Last 24 hours price high.
        /// </summary>
        [JsonProperty("high24")]
        public decimal High24 { get; set; }

        [JsonProperty("ret24")]
        public float Ret24 { get; set; }
    }
}
