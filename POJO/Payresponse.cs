using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Payresponse
{
    /// <summary>
    /// Summary description for Payresponse
    /// </summary>

    public class Parent
    {
        public PayInstrument payInstrument { get; set; }
    }

    public class PayInstrument
    {
      
        // public MsgBdy msgBdy { get; set; }
        public MerchDetails merchDetails { get; set; }
        public PayDetails payDetails { get; set; }
        public CustDetails custDetails { get; set; }
        public Extras extras { get; set; }
        public ResponseDetails responseDetails { get; set; }
        public PayModeSpecificData payModeSpecificData { get; set; }
        public PayInstrument()
        {
            //
            // TODO: Add constructor logic here
            //
        }
       


    }
  
        public class MerchDetails
        {

            public string merchId { get; set; }
            public string userId { get; set; }
            public string password { get; set; }
            public string merchTxnDate { get; set; }
            public string merchTxnId { get; set; }


        }
        public class PayDetails
        {
            public string amount { get; set; }
            public string product { get; set; }
            public string custAccNo { get; set; }
            public string txnCurrency { get; set; }
            public string atomTxnId { get; set; }
            public string signature { get; set; }
            public string txnCompleteDate { get; set; }



        }
        public class CustDetails
        {
            public string custEmail { get; set; }
            public string custMobile { get; set; }


        }
        public class Extras
        {
            public string udf1 { get; set; }
            public string udf2 { get; set; }
            public string udf3 { get; set; }
            public string udf4 { get; set; }
            public string udf5 { get; set; }

        }
        public class ResponseDetails
        {


            public string statusCode { get; set; }
            public string message { get; set; }
            public string description { get; set; }


        } 
        public class PayModeSpecificData
        {
            public List<string> subChannel { get; set; }
            public BankDetails bankDetails { get; set; }
        }

    
    //public class BankDetails
        //{
        //    public BankDetails bankDetails { get; set; }
        //    public string subChannel { get; set; }



        //}
    public class BankDetails
    {
        public int otsBankId { get; set; }
        public string bankTxnId { get; set; }
        public string otsBankName { get; set; }
    }
    public class Rootobject
        {
            public PayInstrument payInstrument { get; set; }
        }

    }

