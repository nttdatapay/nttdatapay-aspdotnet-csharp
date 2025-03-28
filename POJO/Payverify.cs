using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Payverify
{

    /// <summary>
    /// Summary description for Payverify
    /// </summary>
    public class Payverify
    {
        public string atomTokenId { get; set; }
  
        public ResponseDetails responseDetails { get; set; }
        public Payverify()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
    //public class TokenId
    //{
    //    public string atomTokenId { get; set; }

    //}
    public class ResponseDetails
        {
            public string txnStatusCode { get; set; }
            public string txnMessage { get; set; }
            public string txnDescription { get; set; }


        }

     



    }
