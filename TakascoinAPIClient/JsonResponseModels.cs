

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls.Expressions;

namespace TakascoinAPI
{

#region Invoice Info
    public class InvoiceJson
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
    }
#endregion

#region Status Result
    public class StatusJson
    {
        public bool success { get; set; }
        public string status { get; set; }
        public string left { get; set; }
        public string paid { get; set; }
    }
#endregion

#region Create Invoice Result
    public class InvoiceResultJson
    {
        public bool success { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string key { get; set; }
        public string html { get; set; }
        public string payAmount { get; set; }
        public string address { get; set; }
    }
#endregion

#region Create Button Result
    public class ButtonResultJson
    {
        public bool success { get; set; }
        public string hash { get; set; }
        public string html { get; set; }
    }
#endregion

#region Free Escrow result
    public class EscrowResultJson
    {
        public bool success { get; set; }
    }
#endregion

}
