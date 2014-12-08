Coinvoy API - C# Client Library
================================

C# client library for Coinvoy API


##About Coinvoy

Coinvoy is an online payment processor for Bitcoin. It's objective is to provide an easiest yet the most secure way to accept Bitcoin.

##Get started

Just include CoinvoyAPIClient project to your solution and manage invoice pretty easily

```

using CoinvoyAPI;

var cv = new Coinvoy();

Dictionary<string, string> options = new Dictionary<string, string>();
    options.Add("email", "your@email");
    options.Add("provider", "Your Service/Company");
    options.Add("item", "Item description");
    options.Add("description", "Payment Description");
    options.Add("escrow", "true");

var invoiceResultObj = cv.invoice("0.001", "1JZbrknYYEEySTJSrsrECg4vpmitZ1s8wb", "BTC", options);

if (invoiceResultObj.success)
{
    Console.WriteLine("Create invoice: OK");
}

Console.WriteLine("Invoice ID : " + invoiceResultObj.id);
Console.WriteLine("Invoice payment address is : " + invoiceResultObj.address);
Console.WriteLine("Invoice payment url is : " + invoiceResultObj.url);
Console.WriteLine("Invoice escrow key is : " + invoiceResultObj.key);
Console.WriteLine("Invoice default html : " + invoiceResultObj.html);

var escrowResultObj = cv.freeEscrow("3DXVLSJMOFAXF2ZJIGIFN27WHPZDXSDQY6ZCYL2VYN4HYHNE4OXA73YLKNYSY6B46CQDLDCM63QVG===");
Console.WriteLine("Free escrow result is: " + escrowResultObj.success);
if (escrowResultObj.success)
{
    Console.WriteLine("Free Escrow: OK");
}

Console.WriteLine("Getting invoice information: " + invoiceResultObj.id);
var invoiceObj = cv.getInvoice(invoiceResultObj.id);
Console.WriteLine("Invoice payment address is: " + invoiceObj.address);
if (invoiceObj.success)
{
    Console.WriteLine("Get invoice: OK");
}

```
