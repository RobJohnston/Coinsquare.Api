using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Coinsquare.Api.Models;

namespace Coinsquare.Api
{
    public partial class CoinsquareClient
    {
        public async Task<QuoteData> GetQuotesAsync()
        {
            // NOTE: Original location https://coinsquare.io/?method=quotes
            return await QueryPublicAsync<QuoteData>(
                "data/quotes",
                null
            );
        }

        public async Task<BookData> GetOrderBookAndSalesAsync(string ticker, string @base)
        {
            // NOTE: Original location https://coinsquare.io/?method=book&ticker=CAD&base=BTC
            return await QueryPublicAsync<BookData>(
                string.Format("data/bookandsales/{0}/{1}/16", ticker, @base),
                null
            );
        }
    }
}
