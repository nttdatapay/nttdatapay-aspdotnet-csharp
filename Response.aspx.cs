using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Net;
using Payrequest;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Payresponse;
using Newtonsoft.Json;
using PayInstrument1;



public partial class Response : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection nvc = Request.Form;
        byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        int iterations = 65536;
        int keysize = 256;
        // string plaintext = "{\"payInstrument\":{\"headDetails\":{\"version\":\"OTSv1.1\",\"payMode\":\"SL\",\"channel\":\"ECOMM\",\"api\":\"SALE\",\"stage\":1,\"platform\":\"WEB\"},\"merchDetails\":{\"merchId\":8952,\"userId\":\"\",\"password\":\"Test@123\",\"merchTxnId\":\"1234567890\",\"merchType\":\"R\",\"mccCode\":562,\"merchTxnDate\":\"2019-12-24 20:46:00\"},\"payDetails\":{\"prodDetails\":[{\"prodName\": \"NSE\",\"prodAmount\": 10.00}],\"amount\":10.00,\"surchargeAmount\":0.00,\"totalAmount\":10.00,\"custAccNo\":null,\"custAccIfsc\":null,\"clientCode\":\"12345\",\"txnCurrency\":\"INR\",\"remarks\":null,\"signature\":\"7c643bbd9418c23e972f5468377821d9f0486601e1749930816c409fddbc7beb5d2943d832b6382d3d4a8bd7755e914922fb85aa8c234210bf2993566686a46a\"},\"responseUrls\":{\"returnUrl\":\"http://172.21.21.136:9001/payment/ots/v1/merchresp\",\"cancelUrl\":null,\"notificationUrl\":null},\"payModeSpecificData\":{\"subChannel\":[\"BQ\"],\"bankDetails\":null,\"emiDetails\":null,\"multiProdDetails\":null,\"cardDetails\":null},\"extras\":{\"udf1\":null,\"udf2\":null,\"udf3\":null,\"udf4\":null,\"udf5\":null},\"custDetails\":{\"custFirstName\":null,\"custLastName\":null,\"custEmail\":\"test@gm.com\",\"custMobile\":null,\"billingInfo\":null}}} ";
        string hashAlgorithm = "SHA1";
        string encdata = nvc["encdata"];
        string passphrase1 = "75AEF0FA1B94B3C10D4F5B268F757F11";
        string salt1 = "75AEF0FA1B94B3C10D4F5B268F757F11";
        string Decryptval = decrypt(encdata, passphrase1, salt1, iv, iterations);

        //   Decryptval = "{\"merchDetails\":{\"merchId\":8952,\"merchTxnId\":\"test000123\",\"merchTxnDate\":\"2021-12-03T15:24:35\"},\"payDetails\":{\"atomTxnId\":11000000174314,\"prodDetails\":[{\"prodName\":\"NSE\",\"prodAmount\":100.0}],\"amount\":100.00,\"surchargeAmount\":1.18,\"totalAmount\":101.18,\"custAccNo\":\"213232323\",\"clientCode\":\"1234\",\"txnCurrency\":\"INR\",\"signature\":\"2b12c8bfc0e3a8268eddb6f406bf4187d4d0a0064d0355446986511453922c27e38367a97fff85863d48c147a8218e9e2d5003ab121f6f61ce3914030c60caac\",\"txnInitDate\":\"2021-12-03 15:24:36\",\"txnCompleteDate\":\"2021-12-03 15:24:40\"},\"payModeSpecificData\":{\"subChannel\":[\"NB\"],\"bankDetails\":{\"otsBankId\":2001,\"bankTxnId\":\"qjUiPQ2bMQhjPXmzE1on\",\"otsBankName\":\"Atom Bank\"}},\"extras\":{\"udf1\":\"\",\"udf2\":\"\",\"udf3\":\"\",\"udf4\":\"\",\"udf5\":\"\"},\"custDetails\":{\"custEmail\":\"sagar.gopale@atomtech.in\",\"custMobile\":\"8976286911\",\"billingInfo\":{}},\"responseDetails\":{\"statusCode\":\"OTS0000\",\"message\":\"SUCCESS\",\"description\":\"TRANSACTION IS SUCCESSFUL.\"}}";
        Payresponse.Rootobject root = new Payresponse.Rootobject();
        Payresponse.Parent objectres = new Payresponse.Parent();
        objectres = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Payresponse.Parent>(Decryptval);




        string message = objectres.payInstrument.responseDetails.message;
        string statusCode = objectres.payInstrument.responseDetails.statusCode;
        string bankTxnId = objectres.payInstrument.payModeSpecificData.bankDetails.bankTxnId;
        string atomTxnId = objectres.payInstrument.payDetails.atomTxnId; 
        string txnCompleteDate = objectres.payInstrument.payDetails.txnCompleteDate;
        string amount = objectres.payInstrument.payDetails.amount;
        txtatomTxnId.Text = atomTxnId;
        txtbankTxnId.Text = bankTxnId;
        txtamount.Text = amount;
        txtdate.Text = txnCompleteDate;
        txtstatusCode.Text = statusCode;
        txtmessage.Text = message;

    }

    public String Encrypt(String plainText, String passphrase, String salt, Byte[] iv, int iterations)
    {
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        string data = ByteArrayToHexString(Encrypt(plainBytes, GetSymmetricAlgorithm(passphrase, salt, iv, iterations))).ToUpper();


        return data;
    }
    public String decrypt(String plainText, String passphrase, String salt, Byte[] iv, int iterations)
    {
        byte[] str = HexStringToByte(plainText);

        string data1 = Encoding.UTF8.GetString(decrypt(str, GetSymmetricAlgorithm(passphrase, salt, iv, iterations)));
        return data1;
    }
    public byte[] Encrypt(byte[] plainBytes, SymmetricAlgorithm sa)
    {
        return sa.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);

    }
    public byte[] decrypt(byte[] plainBytes, SymmetricAlgorithm sa)
    {
        return sa.CreateDecryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
    }
    public SymmetricAlgorithm GetSymmetricAlgorithm(String passphrase, String salt, Byte[] iv, int iterations)
    {
        var saltBytes = new byte[16];
        var ivBytes = new byte[16];
        Rfc2898DeriveBytes rfcdb = new System.Security.Cryptography.Rfc2898DeriveBytes(passphrase, Encoding.UTF8.GetBytes(salt), iterations, HashAlgorithmName.SHA512);
        saltBytes = rfcdb.GetBytes(32);
        var tempBytes = iv;
        Array.Copy(tempBytes, ivBytes, Math.Min(ivBytes.Length, tempBytes.Length));
        var rij = new RijndaelManaged(); //SymmetricAlgorithm.Create();
        rij.Mode = CipherMode.CBC;
        rij.Padding = PaddingMode.PKCS7;
        rij.FeedbackSize = 128;
        rij.KeySize = 128;

        rij.BlockSize = 128;
        rij.Key = saltBytes;
        rij.IV = ivBytes;
        return rij;
    }
    protected static byte[] HexStringToByte(string hexString)
    {
        try
        {
            int bytesCount = (hexString.Length) / 2;
            byte[] bytes = new byte[bytesCount];
            for (int x = 0; x < bytesCount; ++x)
            {
                bytes[x] = Convert.ToByte(hexString.Substring(x * 2, 2), 16);
            }
            return bytes;
        }
        catch
        {
            throw;
        }
    }
    public static string ByteArrayToHexString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }
}
