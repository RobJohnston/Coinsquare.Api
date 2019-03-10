# Coinsquare.Api
A .Net Standard client for the Coinsquare cryptocurrency API. 


[![nuget](https://img.shields.io/nuget/v/Coinsquare.Api.svg)](https://www.nuget.org/packages/Coinsquare.Api/)
![Downloads](https://img.shields.io/nuget/dt/Coinsquare.Api.svg)

**This is an alpha version, meaning the API is not feature complete and may contain bugs.**

An account is not required to access the public API methods. 
However, if you do create an account, please use my referral code (9A96B01B4) when you [register](https://coinsquare.io/register?r=9A96B01B4). 
It's an easy way to give back to this project at no cost to you.

## Installation via NuGet
```
Install-Package Coinsquare.Api
```

## Example usage

```csharp

## Example usage

```csharp
using System;
using System.Threading.Tasks;
using Coinsquare.Api;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Coinsquare!\n");

            using (var client = new CoinsquareClient())
            {
                try
                {
                    // Get ticker info.
                    var t = Task.Run(() => client.GetQuotesAsync());
                    var quoteResponse = t.Result;

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
                    Console.WriteLine("\n BIDS \n");
                    Console.WriteLine($"{"ΣBTC",-15}|{"BTC",-15}|{"CAD",-10}|{"Bid Price (BTC)",-15}");
                    Console.WriteLine(new string('-', 58));
                    foreach (var entry in bookResponse.Books)
                    {
                        if (entry.Type == Coinsquare.Api.Models.OrderType.B)
                        {
                            Console.WriteLine($"{entry.Sum / 100000000,15}|" +
                                $"{entry.Base / 100000000,15}|" +
                                $"{entry.Amount / 100,10}|" +
                                $"{entry.Price / 100000000,15}");
                        }
                    }

                    // Show asks.
                    Console.WriteLine("\n ASKS \n");
                    Console.WriteLine($"{"Ask Price (BTC)",-15}|{"CAD",-10}|{"BTC",-15}|{"ΣBTC",-15}");
                    Console.WriteLine(new string('-', 58));

                    foreach (var entry in bookResponse.Books)
                    {
                        if (entry.Type == Coinsquare.Api.Models.OrderType.S)
                        {
                            Console.WriteLine($"{entry.Price / 100000000,15}|" +
                                $"{entry.Amount / 100,10}|" +
                                $"{entry.Base / 100000000,15}|" +
                                $"{entry.Sum / 100000000,15}");
                        }
                    }

                    // Show completed trades.
                    Console.WriteLine("\n COMPLETED TRADES \n");
                    Console.WriteLine($"{"Action",-8}|{"Price",-10}|{"Amount",-10}|{"Base",-15}|{"Date",-17}");
                    Console.WriteLine(new string('-', 64));

                    foreach (var sale in bookResponse.Sales)
                    {
                        Console.WriteLine($"{sale.Type,-8}|" +
                            $"{sale.Price / 100000000,10}|" +
                            $"{sale.Amount / 100,10}|" +
                            $"{sale.Base / 100000000,15}|" +
                            $"{sale.Date,17}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
```

### Output
```
Hello Coinsquare!

BTC last traded at 8445.23 CAD.

 BIDS

ΣBTC           |BTC            |CAD       |Bid Price (BTC)
----------------------------------------------------------
     0.34506924|     0.34506924|   2914.19|     0.00011841
     0.92639378|     0.58132454|   4911.08|     0.00011837
     1.75850268|      0.8321089|   7031.51|     0.00011834
     2.60709585|     0.84859317|   7175.05|     0.00011827
     3.22114939|     0.61405354|   5193.72|     0.00011823
      3.5403284|     0.31917901|   2700.33|      0.0001182
      3.6583884|        0.11806|      1000|     0.00011806
     4.11861429|     0.46022589|   3900.55|     0.00011799
     4.12680202|     0.00818773|     69.47|     0.00011786
     4.66301662|      0.5362146|      4555|     0.00011772
     4.78066662|        0.11765|      1000|     0.00011765
     4.80471312|      0.0240465|       205|      0.0001173
     5.37539997|     0.57068685|    4873.5|      0.0001171
     5.90526673|     0.52986676|   4529.55|     0.00011698
     6.36188958|     0.45662285|   3903.76|     0.00011697
               |               |          |

 ASKS

Ask Price (BTC)|CAD       |BTC            |ΣBTC
----------------------------------------------------------
     0.00011862|      3000|        0.35586|        0.35586
     0.00011868|    419.59|     0.04979694|     0.40565694
     0.00011869|   4052.83|     0.48103039|     0.88668733
     0.00011876|   6079.09|     0.72195274|     1.60864007
     0.00011882|       500|        0.05941|     1.66805007
     0.00011884|    456.58|     0.05425997|     1.72231004
     0.00011888|   1436.41|     0.17076043|     1.89307047
     0.00011889|    149.91|      0.0178228|     1.91089327
     0.00011891|    633.75|     0.07535921|     1.98625248
     0.00011893|      1000|        0.11893|     2.10518248
     0.00011898|    417.27|     0.04964679|     2.15482927
     0.00011903|      2000|        0.23806|     2.39288927
     0.00011922|    155.82|     0.01857686|     2.41146613
     0.00011923|       3.5|     0.00041731|     2.41188344
     0.00011939|      2000|        0.23878|     2.65066344
               |          |               |

 COMPLETED TRADES

Action  |Price     |Amount    |Base           |Date
----------------------------------------------------------------
S       |0.00011842|    189.79|     0.02247494| 2018-10-02 01:48
S       |0.00011841|    297.71|     0.03525184| 2018-10-02 01:48
B       |0.00011849|  11346.07|     1.34439583| 2018-10-02 01:48
S       |0.00011848|   1880.34|     0.22278268| 2018-10-02 01:45
B       |0.00011876|      4.76|     0.00056529| 2018-10-02 01:45
S       |0.00011848|     40.45|     0.00479252| 2018-10-02 01:45
S       |0.00011846|      2100|       0.248766| 2018-10-02 01:45
S       |0.00011842|    230.21|     0.02726146| 2018-10-02 01:45
B       |0.00011857|    9349.8|     1.10860579| 2018-10-02 01:44
S       |0.00011848|    266.07|     0.03152397| 2018-10-02 01:41
B       |0.00011876|   9066.83|     1.07677673| 2018-10-02 01:41
S       |0.00011849|    221.43|     0.02623724| 2018-10-02 01:41
B       |0.00011877|  15120.24|      1.7958309| 2018-10-02 01:39
B       |0.00011879|     86.44|      0.0102682| 2018-10-02 01:37
S       |0.00011849|     85.58|     0.01014037| 2018-10-02 01:37
B       |0.00011866|  13637.99|     1.61828389| 2018-10-02 01:36

Press any key to exit.
```

## My related projects

* [QuadrigaCX.Api](https://github.com/RobJohnston/QuadrigaCX.Api)
* [CoinField.Api](https://github.com/RobJohnston/CoinField.Api)
* [Ndax.Api](https://github.com/RobJohnston/Ndax.Api)
* [EzBtc.Api](https://github.com/RobJohnston/EzBtc.Api)
* [AnxPro.Api](https://github.com/RobJohnston/AnxPro.Api)

## Donation addresses

* Bitcoin (BTC): 3EA6e7CdW3ePEpTLuLPZBFC7JiSM8Hy4iW 
* Bitcoin Cash SV (BSV):  bitcoincash:qp2a7ynlkk0u52mdc8rkdhjgc0xcag4jjywxsvervc
* Bitcoin Cash ABC (BAB): bitcoincash:qp2a7ynlkk0u52mdc8rkdhjgc0xcag4jjywxsvervc
* Ethereum (ETH): 0x42471B305b6E54369E378178301DC0406CF9196a
* Ripple (XRP): rDM9x1ehphbwXX8UhvF2j8tyuJY2VVnm5; XRP Tag: 295362556
* Litecoin (LTC):  MW7jWtqu5oGAPzvx3tDJWqdJpaV6p3Vi9V
* Dash (DASH):  Xh4MwCv7Hd4ufpHbn1u5heiirU6s8cuV3B
* Dogecoin (DOGE):  D9aR1y8jyBxYWKDs5AebWqoGcg8CNmp7gm
* Ethereum Classic (ETH): 0x42471B305b6E54369E378178301DC0406CF9196a
