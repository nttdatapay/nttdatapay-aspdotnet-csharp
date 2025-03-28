<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
 <script src="https://pgtest.atomtech.in/staticdata/ots/js/atomcheckout.js" type="text/javascript"></script>


<html xmlns="http://www.w3.org/1999/xhtml">
   


<head runat="server">
    <title></title>

    
 <script type="text/javascript">
     function openPay() {
       
       // alert('openPay called');
        var rb = document.getElementById('txttok').value;
        //alert("mesage:"+rb);
const options = {
    "atomTokenId": rb,
"merchId": "8952",
"custEmail": "sagar.gopale@atomtech.in",
"custMobile": "8976286911",
"returnUrl": "http://localhost:50903/Response.aspx"
}
let atom = new AtomPaynetz(options,'uat');
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table>
            <tr>
               <td>
                   <asp:Label ID="lblmer" Text="Merchant_id" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtmer" runat="server"></asp:TextBox>
               </td>
                </tr>
                  
           <tr>
               <td>
                   <asp:Label ID="lbltok" Text="Token." runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txttok" runat="server"></asp:TextBox>
               </td>
                </tr>
           <tr>
               <td>
                   <asp:Label ID="lblmob" Text="Mobile No." runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtmob"  runat="server"></asp:TextBox>
               </td>
                </tr>
           <tr>
               <td>
                   <asp:Label ID="lblmail" Text="E-Mail" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
               </td>
                </tr>
           
    <asp:Button ID="btmpay" Text="Pay" runat="server" OnClientClick="openPay(); return false"  />
      
       <%-- <asp:Label ID="lbldata" runat="server"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>--%>
           </table>
    </div>
    </form>
</body>
</html>
