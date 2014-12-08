using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakascoinAPI
{
    public class InvoiceInfo
    {
        public bool success { get; set; }
        public string id { get; set; }
        public string orderID { get; set; }
        public string item { get; set; }
        public string description { get; set; }
        //public string invoiceID { get; set; }
        public string address { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string payAmount { get; set; }
        public bool escrow { get; set; }
        public string company { get; set; }
        public string motto { get; set; }
        public string companyLogo { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string status { get; set; }

        public InvoiceInfo(dynamic obj)
        {
            this.success = (bool)obj.success;
            this.id = (string)obj.id;
            this.orderID = (string)obj.orderID;
            this.item = (string)obj.item;
            this.description = (string)obj.description;
            //this.invoiceID = (string)obj.invoiceID;
            this.address = (string)obj.address;
            this.amount = (string)obj.amount;
            this.currency = (string)obj.currency;
            this.amount = (string)obj.amount;
            this.payAmount = (string)obj.payAmount;
            this.escrow = (bool)obj.escrow;
            this.company = (string)obj.company;
            this.motto = (string)obj.motto;
            this.companyLogo = (string)obj.companyLogo;
            this.addressLine1 = (string)obj.addressLine1;
            this.addressLine2 = (string)obj.addressLine2;
            this.status = (string)obj.status;
	    }
    }

    public class StatusInfo
    {
        public bool success { get; set; }
        public string status { get; set; }
        public string left { get; set; }
        public string paid { get; set; }

        public StatusInfo(dynamic obj)
        {
            this.success = (bool)obj.success;
            this.status = (string)obj.status;
            this.left = (string)obj.left;
            this.paid = (string)obj.paid;
        }
    }

    public class InvoiceResult
    {
        public bool success { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string url { get; set; }
        public string html { get; set; }
        public string payAmount { get; set; }
        public string address { get; set; }

        public InvoiceResult(dynamic obj)
        {
            this.success = (bool)obj.success;
            this.id = (string)obj.id;
            this.key = (string)obj.key;
            this.url = (string)obj.url;
            this.html = (string)obj.html;
            this.payAmount = (string)obj.payAmount;
            this.address = (string)obj.address;
        }
    }

    public class ButtonResult
    {
        public bool success { get; set; }
        public string hash { get; set; }
        public string html { get; set; }

        public ButtonResult(dynamic obj)
        {
            this.success = (bool)obj.success;
            this.hash = (string)obj.hash;
            this.html = (string)obj.html;
        }
    }

    public class EscrowResult
    {
        public bool success { get; set; }

        public EscrowResult(dynamic obj)
        {
            this.success = (bool)obj.success;
        }
    }
}
