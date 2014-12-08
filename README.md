
TAKASCOIN PAYMENT API - C# Client Library
================================

C# client library for Takascoin API


##About Takascoin

Takascoin is an online Bitcoin exchange platform. Takascoin is also a payment services provider for merchants.

##Get started

Just include TakascoinAPIClient project to your solution and manage invoice pretty easily

```

using TakascoinAPI;

var takas = new Takascoin();

string apiKey = "takas@email"

Dictionary<string, string> options = new Dictionary<string, string>();
    options.Add("item", "Item description");
    options.Add("description", "Payment Description");
    options.Add("callback", "http://yourcallback/ipn");

var invoiceResultObj = takas.payment("10", apiKey, options);

if (invoiceResultObj.success)
{
    Console.WriteLine("Create invoice: OK");
}

Console.WriteLine("Invoice ID : " + invoiceResultObj.id);
Console.WriteLine("Invoice payment address is : " + invoiceResultObj.address);
Console.WriteLine("Invoice payment url is : " + invoiceResultObj.url);
Console.WriteLine("Invoice default html : " + invoiceResultObj.html);


Console.WriteLine("Getting invoice information: " + invoiceResultObj.id);
var invoiceObj = takas.getInvoice(invoiceResultObj.id);
Console.WriteLine("Invoice payment address is: " + invoiceObj.address);
if (invoiceObj.success)
{
    Console.WriteLine("Get invoice: OK");
}

```
Your feedback and suggestions are very much welcome. Please contact info@takascoin.com for any input. 

Enjoy!

Takascoin
