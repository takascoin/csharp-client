using System;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace TakascoinAPI
{
	// Documentation is at https://coinvoy.net/developers
    // Methods:
    //
    // getInvoice           - Get invoice information
    // getStatus            - Get invoice status
    // invoice              - Create new invoice
    // button               - Create new button for client-side use
    // donation             - Create new donation button without any defined amount
    // freeEscrow           - Release a confirmed escrow payment and forward it to seller
    // validateNotification - Securely validate an incoming IPN (payment notification)

	
	public class Takascoin
    {
        private string URL_BASE = "https://coinvoy.net/api/takas/";
        private string URL_COMMON_BASE = "https://coinvoy.net/api/";

        public Takascoin()
        {

        }

		// Invoice Information
		public InvoiceInfo getInvoice(string invoiceID)
		{
            Dictionary<string, string> requestObj = new Dictionary<string, string>();
            requestObj.Add("invoiceID", invoiceID);

            string json = JsonConvert.SerializeObject(requestObj);

            string result = String.Empty;
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json; charset=utf-8;");
                client.Encoding = Encoding.UTF8; ;
                result = client.UploadString(URL_COMMON_BASE + "invoice", "POST", json);
            }

            dynamic obj = JsonConvert.DeserializeObject<InvoiceJson>(result);

            return new InvoiceInfo(obj);
		}

		// INVOICE STATUS
		public StatusInfo getStatus(string invoiceID)
		{
            Dictionary<string, string> requestObj = new Dictionary<string, string>();
            requestObj.Add("invoiceID", invoiceID);
            string json = JsonConvert.SerializeObject(requestObj);

            string result = String.Empty;
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                result = client.UploadString(URL_COMMON_BASE + "status", "POST", json);
            }

            dynamic obj = JsonConvert.DeserializeObject<StatusJson>(result);

            return new StatusInfo(obj);
		}

        // CREATE NEW INVOICE
        public InvoiceResult payment(string amount, string apiKey, Dictionary<string, string> parameters)
        {
            parameters.Add("amount", amount);
            parameters.Add("apiKey", apiKey);
            parameters.Add("currency", "TL");
            string json = JsonConvert.SerializeObject(parameters);

            string result = String.Empty;
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json; charset=utf-8;");
                client.Encoding = Encoding.UTF8; ;
                result = client.UploadString(URL_BASE + "payment", "POST", json);
            }

            dynamic obj = JsonConvert.DeserializeObject<InvoiceResultJson>(result);

            return new InvoiceResult(obj);
        }

        public ButtonResult button(string amount, string apiKey, Dictionary<string, string> parameters)
        {
            parameters.Add("amount", amount);
            parameters.Add("apiKey", apiKey);
            parameters.Add("currency", "TL");
            string json = JsonConvert.SerializeObject(parameters);

            string result = String.Empty;
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json; charset=utf-8;");
                client.Encoding = Encoding.UTF8; ;
                result = client.UploadString(URL_BASE + "button", "POST", json);
            }

            dynamic obj = JsonConvert.DeserializeObject<ButtonResultJson>(result);

            return new ButtonResult(obj);
        }


        public bool validateNotification(string hash, string orderID , string invoiceID, string secret)
        {
            var encoding = new ASCIIEncoding();
            var text = encoding.GetBytes(orderID + ":" + invoiceID);
            var key = encoding.GetBytes(secret);
            var sha256 = new HMACSHA256(key);
            var signature = BitConverter.ToString(sha256.ComputeHash(text)).Replace("-", string.Empty).ToLower();

            if(hash.ToLower() == signature)
            {
                return true;
            }
            return false;
        }

	}

}
