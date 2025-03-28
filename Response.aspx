<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Response.aspx.cs" Inherits="Response" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table>
            <tr>
               <td>
                   <asp:Label ID="lblbankTxnId" Text="BankTxnId" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtbankTxnId" runat="server"></asp:TextBox>
               </td>
                </tr>
                  
           <tr>
               <td>
                   <asp:Label ID="lblatomTxnId" Text="AtomTxnId" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtatomTxnId" runat="server"></asp:TextBox>
               </td>
                </tr>
            <tr>
               <td>
                   <asp:Label ID="lblamount"  Text="Amount" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtamount"   runat="server"></asp:TextBox>
               </td>
                </tr>
           <tr>
               <td>
                   <asp:Label ID="lblstatusCode" Text="Status" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtstatusCode"  ReadOnly="true" runat="server"></asp:TextBox>
               </td>
                </tr>
           <tr>
               <td>
                   <asp:Label ID="lblmessage" Text="Message" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtmessage"  ReadOnly="true" runat="server"></asp:TextBox>
               </td>
                </tr>
          <tr>
               <td>
                   <asp:Label ID="lbltxnCompleteDate" Text="TxnDate" runat ="server"></asp:Label>

               </td>
               <td>
                 <asp:TextBox ID="txtdate" ReadOnly="true" runat="server"></asp:TextBox>
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
