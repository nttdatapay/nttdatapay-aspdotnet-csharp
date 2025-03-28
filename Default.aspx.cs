using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Net;

using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
using Payverify;

public partial class _Default : System.Web.UI.Page
{
    string Tok_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string payInstrument = "";
      

        try
        {

            Payrequest.RootObject rt = new Payrequest.RootObject();
            Payrequest.MsgBdy mb = new Payrequest.MsgBdy();
            Payrequest.HeadDetails hd = new Payrequest.HeadDetails();
            // Payrequest.HeadDetails hd = new Payrequest.HeadDetails();
            Payrequest.MerchDetails md = new Payrequest.MerchDetails();
            Payrequest.PayDetails pd = new Payrequest.PayDetails();
            Payrequest.CustDetails cd = new Payrequest.CustDetails();
            Payrequest.Extras ex = new Payrequest.Extras();

            Payrequest.Payrequest pr = new Payrequest.Payrequest();


            hd.version = "OTSv1.1";
            hd.api = "AUTH";
            hd.platform = "FLASH";

            md.merchId = "8952";
            md.userId = "";
            md.password = "Test@123";
            md.merchTxnDate = "2021-09-04 20:46:00";
            md.merchTxnId = "test000123";


            pd.amount = "100";
            pd.product = "NSE";
            pd.custAccNo = "213232323";
            pd.txnCurrency = "INR";

            cd.custEmail = "sagar.gopale@atomtech.in";
            cd.custMobile = "8976286911";

            ex.udf1 = "";
            ex.udf2 = "";
            ex.udf3 = "";
            ex.udf4 = "";
            ex.udf5 = "";


            pr.headDetails = hd;
            pr.merchDetails = md;
            pr.payDetails = pd;
            pr.custDetails = cd;
            pr.extras = ex;

            rt.payInstrument = pr;
            var json = new JavaScriptSerializer().Serialize(rt);



            string passphrase = "A4476C2062FFA58980DC8F79EB6A799E";
            string salt = "A4476C2062FFA58980DC8F79EB6A799E";
            byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int iterations = 65536;
            int keysize = 256;
            // string plaintext = "{\"payInstrument\":{\"headDetails\":{\"version\":\"OTSv1.1\",\"payMode\":\"SL\",\"channel\":\"ECOMM\",\"api\":\"SALE\",\"stage\":1,\"platform\":\"WEB\"},\"merchDetails\":{\"merchId\":8952,\"userId\":\"\",\"password\":\"Test@123\",\"merchTxnId\":\"1234567890\",\"merchType\":\"R\",\"mccCode\":562,\"merchTxnDate\":\"2019-12-24 20:46:00\"},\"payDetails\":{\"prodDetails\":[{\"prodName\": \"NSE\",\"prodAmount\": 10.00}],\"amount\":10.00,\"surchargeAmount\":0.00,\"totalAmount\":10.00,\"custAccNo\":null,\"custAccIfsc\":null,\"clientCode\":\"12345\",\"txnCurrency\":\"INR\",\"remarks\":null,\"signature\":\"7c643bbd9418c23e972f5468377821d9f0486601e1749930816c409fddbc7beb5d2943d832b6382d3d4a8bd7755e914922fb85aa8c234210bf2993566686a46a\"},\"responseUrls\":{\"returnUrl\":\"http://172.21.21.136:9001/payment/ots/v1/merchresp\",\"cancelUrl\":null,\"notificationUrl\":null},\"payModeSpecificData\":{\"subChannel\":[\"BQ\"],\"bankDetails\":null,\"emiDetails\":null,\"multiProdDetails\":null,\"cardDetails\":null},\"extras\":{\"udf1\":null,\"udf2\":null,\"udf3\":null,\"udf4\":null,\"udf5\":null},\"custDetails\":{\"custFirstName\":null,\"custLastName\":null,\"custEmail\":\"test@gm.com\",\"custMobile\":null,\"billingInfo\":null}}} ";
            string hashAlgorithm = "SHA1";
            string Encryptval = Encrypt(json, passphrase, salt, iv, iterations);



            //Response.Redirect("https://caller.atomtech.in/ots/payment/txn?merchId=8952&encData=" + Encryptval);



            //  string Decryptval = decrypt(Encryptval, passphrase, salt, iv, iterations);

            //   Response.Redirect("https://caller.atomtech.in/ots/payment/txn?merchId=8952&encData=" + Encryptval);


            // string data="{\"payrequest\":{\"merchanyDetails\":{\"merchId\":\"8952\",\"userId\":\"\",\"password\":\"NCA@1234\",\"merchTxnDate\":\"2021-09-04 20:46:00\",\"merchTxnId\":\"test000123\"},\"payDetails\":{\"amount\":\"100\",\"product\":\"NSE\",\"custAccNo\":\"213232323\",\"txnCurrency\":\"INR\"},\"custDetails\":{\"custEmail\":\"sagar.gopale @atomtech.in\",\"custMobile\":\"8976286911\"},\"extras\":{\"udf1\":\"\",\"udf2\":\"\",\"udf3\":\"\",\"udf4\":\"\",\"udf5\":\"\"},\"headDetails\":{\"version\":\"OTSv1.1\",\"api\":\"AUTH\",\"platform\":\"FLASH\"}}}";




            string testurleq = "https://caller.atomtech.in/ots/aipay/auth?merchId=8952&encData=" + Encryptval;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(testurleq);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            //request.Timeout = 600000;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            //Console.WriteLine(stream);
            // Console.WriteLine(json);
            stream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonresponse = response.ToString();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            ////  string jsonresponse = post;
            string temp = null;
            string status = "";
            while ((temp = reader.ReadLine()) != null)
            {
                jsonresponse += temp;
            }
            //InitiateOrderResEq.RootObject objectres = new InitiateOrderResEq.RootObject();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var result = jsonresponse.Replace("System.Net.HttpWebResponse", "");
            //// var result = "{\"initiateDigiOrderResponse\":{ \"msgHdr\":{ \"rslt\":\"OK\"},\"msgBdy\":{ \"sts\":\"ACPT\",\"txnId\":\"DIG2019039816365405440004\"}}}";
            //  var  objectres = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Payverify.Payverify>(result);

            var uri = new Uri("http://atom.in?" + result);


            var query = HttpUtility.ParseQueryString(uri.Query);

            string encData = query.Get("encData");
            // string  encData="5500FEA2F09DA7EF128CFE7D2D01F2533B8D8211ACDCEEE850A7943CF46D4A18FF153971B83983A1EBF8B48F36315222E33FED142A05BE8FD890492ED759983B173801C801A79B390C17E01354CA0752087CF1E71316E5F442FADA985C46B06DB8462928DB18BC8E7714EC6128340CB8690A185F590E47658C293FA2E73ADC77899D6E7B119E17005E625CF2258A6A74363EAA59A43FF785505A77D163DA232B1D2250C4A1A1C755E10D5991A2DB5B3C";
            string passphrase1 = "75AEF0FA1B94B3C10D4F5B268F757F11";
            string salt1 = "75AEF0FA1B94B3C10D4F5B268F757F11";
            string Decryptval = decrypt(encData, passphrase1, salt1, iv, iterations);
            //{ "atomTokenId":15000000085830,"responseDetails":{ "txnStatusCode":"OTS0000","txnMessage":"SUCCESS","txnDescription":"ATOM TOKEN ID HAS BEEN GENERATED SUCCESSFULLY"} }
            Payverify.Payverify objectres = new Payverify.Payverify();
             objectres = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Payverify.Payverify>(Decryptval);
            string txnMessage = objectres.responseDetails.txnMessage;
              Tok_id = objectres.atomTokenId;

            //lbldata.Text = Decryptval;
            //Label2.Text = Convert.ToString(Tok_id);
            txtmer.Text = "8952";
            txttok.Text = Tok_id;
            txtmob.Text = "8976286911";
            txtmail.Text = "suresh.kore@atomtech.in";
        }

        catch (Exception ex)
        {
          

        }
    }

    protected void btmpay_Click(object sender, EventArgs e)
    {
      


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


