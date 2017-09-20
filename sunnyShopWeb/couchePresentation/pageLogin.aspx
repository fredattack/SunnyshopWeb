<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pageLogin.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.pageLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHMenu" runat="server">
 
        
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">
  
    <form id="fLogin" runat="server">
        <asp:HiddenField ID="HiddenFieldSessionControl" runat="server" />
        <div class="test">
        <table class ="tableInscription">
            <tr>
                <td class ="LaTab">Login :</td>
                <td><asp:TextBox ID="TBLogin" MaxLength="20" runat="server"
                CssClass="tbLogin"  required="required" >
                </asp:TextBox></td>
              </tr>
              <tr>
                <td colspan="2"><asp:Label ID="LaLoginFalse" runat="server" Text="Login inconnu" forecolor="red"></asp:Label></td>
              </tr>
              <tr>
                <td class ="LaTab">Password : </td>
                <td><asp:TextBox ID="TBPass" TextMode="Password" MaxLength="20" runat="server"
                CssClass="tbLogin"  required="required">
                </asp:TextBox></td>
              </tr>
              <tr>
                <td colspan="2"><asp:Label ID="LaPassFalse" runat="server" Text="le mot de passe ne correspond pas" forecolor="red"></asp:Label></td>
              </tr>
        </table>  
        
            <div >        
                <asp:Button ID="BContinuer" runat="server" Text="Valider"
                OnClientClick="test();"  onclick="BContinuer_Click" CssClass="myButton" />
            </div>  
        </div>     
    </form>
  
</asp:Content>
