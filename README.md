# Coinsquare.Api
A .Net Standard client for the Coinsquare cryptocurrency API. 

**This is an alpha version, meaning the API is not feature complete and may contain bugs.**

Contribute to this project by sending some XɃT my way: 1NTr61Gv6PEgVFDvXxNi2WuPWfucKTS54F 

Or show your support by using my referral link to create your account: 
https://coinsquare.io/register?r=9A96B01B4


## Example usage

```csharp
using System;
using Coinsquare.Api;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Coinsquare!");

            using (var client = new CoinsquareClient())
            {
                try
                {
                    // Get ticker info.
                    var quoteResponse = client.GetQuotesAsync().GetAwaiter().GetResult();

                    // Show the tickers based on Canadian dollars.
                    foreach (var quote in quoteResponse.Quotes)
                    {
                        if (quote.Base == "CAD")
                        {
                            Console.WriteLine(string.Format("{0} last traded at {1} CAD.", quote.Ticker, quote.Last / 100));
                        }
                    }

                    // Get order book and transaction info for the CAD/BTC pair.
                    var bookResponse = client.GetOrderBookAndSalesAsync("CAD", "BTC").GetAwaiter().GetResult();

                    // Show bids.
                    foreach (var entry in bookResponse.Books)
                    {
                        if (entry.Type == Coinsquare.Api.Models.OrderType.B)
                        {
                            Console.WriteLine("ΣBTC {0} BTC {1} CAD {2} Bid Price (BTC) {3}", 
                                entry.Sum / 100000000, entry.Base / 100000000, entry.Amount / 100, entry.Price / 100000000);
                        }
                    }

                    // Show asks.
                    foreach (var entry in bookResponse.Books)
                    {
                        if (entry.Type == Coinsquare.Api.Models.OrderType.S)
                        {
                            Console.WriteLine("Ask Price (BTC) {0} CAD {1} BTC {2} ΣBTC {3}",
                                entry.Price / 100000000, entry.Amount / 100, entry.Base / 100000000, entry.Sum / 100000000);
                        }
                    }

                    // Show completed trades.
                    foreach (var sale in bookResponse.Sales)
                    {
                        Console.WriteLine("Action {0} Ticker {1} Bid Price (BTC) {2} CAD {3} BTC {4} Date {5}",
                            sale.Type, "CAD", sale.Price / 100000000, sale.Amount / 100, sale.Base / 100000000, sale.Date);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }
    }
}

```