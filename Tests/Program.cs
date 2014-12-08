using System;
using System.Collections.Generic;
using TakascoinAPI;


namespace Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			var takas = new Takascoin();
            string apiKey = "takascoin emailiniz";

			Console.WriteLine("Testing Coinvoy c# client");

            //NEW INVOICE
            Console.WriteLine("Odeme olusturuluyor");
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("item", "Urun Adi");
            options.Add("description", "Urun aciklamasi");

            var invoiceResultObj = takas.payment("5", apiKey, options); //5 TL

            Console.WriteLine("Invoice ID is: "+invoiceResultObj.id+" and invoice url is: "+invoiceResultObj.url+" and payment amount is: " + invoiceResultObj.payAmount);
            if (invoiceResultObj.success)
            {
                Console.WriteLine("Create invoice: OK");
            }


            //INVOICE INFORMATION
            Console.WriteLine("Getting invoice information: " + invoiceResultObj.id);
            var invoiceObj = takas.getInvoice(invoiceResultObj.id);
            Console.WriteLine("Invoice payment address is: " + invoiceObj.address);
            if (invoiceObj.success)
            {
                Console.WriteLine("Get invoice: OK");
            }

            //INVOICE STATUS
            Console.WriteLine("Getting invoice status: "+invoiceResultObj.id);
            var statusObj = takas.getStatus(invoiceResultObj.id);

            Console.WriteLine("Status: " + statusObj.status);
            if (statusObj.success)
            {
                Console.WriteLine("Get status: OK");
            }

            //CREATE BUTTON
            Console.WriteLine("Creating a new BUTTON.");
            options = new Dictionary<string, string>();
            options.Add("email", "your notification email");
            options.Add("company", "Your company");
            options.Add("item", "Urun");
            options.Add("description", "Urun tanimi");

            var buttonResultObj = takas.button("2", apiKey, options);

            Console.WriteLine("Invoice hash is: " + buttonResultObj.hash);
            if (buttonResultObj.success)
            {
                Console.WriteLine("Create button: OK");
            }

			Console.ReadLine();
		}
	}
}
