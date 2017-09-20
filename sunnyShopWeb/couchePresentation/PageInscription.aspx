<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="PageInscription.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.PageInsciption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHMenu" runat="server">
      
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContenu" runat="server">
    <form id="fLogin" runat="server">
          <table class ="tableInscription">
              <tr>
                <td class ="LaTab"><asp:Label ID="LaLogin" runat="server" CssClass="LaInscription" Text="Login : "></asp:Label></td>
                <td><asp:TextBox ID="TbLogin" runat="server"  CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>
              <tr>
                <td class ="LaTab"><asp:Label ID="LaPassword" runat="server"  CssClass="LaInscription" Text="Mot De Passe : "></asp:Label></td>
                <td><asp:TextBox ID="TbPassword" runat="server"  CssClass="tbLogin" TextMode="Password" required="required"></asp:TextBox></td>
              </tr>
              <tr>
                <td class ="LaTab"><asp:Label ID="LaPassword2" runat="server"  CssClass="LaInscription" Text="Confirmation : "></asp:Label></td>
                <td><asp:TextBox ID="TbPassword2" runat="server"  CssClass="tbLogin" TextMode="Password" required="required"></asp:TextBox></td>
              </tr>
              <tr>
                <td class ="LaTab"> <asp:Label ID="LaPrenom" runat="server" CssClass="LaInscription" Text="Prénom : "></asp:Label></td>
                <td> <asp:TextBox ID="TbPrenom" runat="server"  CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>
              <tr>
                <td class ="LaTab"><asp:Label ID="LaNom" runat="server" CssClass="LaInscription" Text="Nom : "></asp:Label></td>
                <td><asp:TextBox ID="TbNom" runat="server"  CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>
              <tr>
                <td class ="LaTab"><asp:Label ID="LaAdress" runat="server" CssClass="LaInscription" Text="Adresse : "></asp:Label></td>
                <td><asp:TextBox ID="TbAdresse" runat="server"  CssClass="tbLogin" required="required" TextMode="MultiLine"></asp:TextBox></td>
              </tr> 
            <tr>
                <td class ="LaTab"><asp:Label ID="LaBirthDate" runat="server" CssClass="LaInscription" Text="Date De Naissance (jj/mm/aaaa) : "></asp:Label></td>
                <td><asp:TextBox ID="TbBirthDate" runat="server"  CssClass="tbLogin" required="required" TextMode="Date"></asp:TextBox></td>
              </tr>
            </table>
        <div >        
                <asp:Button ID="BValiderInscription" runat="server" Text="Valider"
                OnClientClick="confirmData();" OnClick="BContinuer_Click" CssClass="myButton" />
        </div> 
    </form>
</asp:Content>
