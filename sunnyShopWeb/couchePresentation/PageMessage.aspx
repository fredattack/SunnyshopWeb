<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="PageMessage.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.PageMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHMenu" runat="server">
     <ul id="menu-bar">
             <li><a href="/couchePresentation/index.aspx">Home</a></li>
             <li ><a href="/couchePresentation/pageVin.aspx">Produits</a>
              
             </li>
               <li><a href="/couchePresentation/pageUserProfil.aspx">Mon Compte</a></li>
            
        </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContenu" runat="server">
    <h1>Information</h1>
    <p>
        <b><asp:label ID="LMsg" runat="server" text="Label"  CssClass="msg"></asp:label>
    </p>

</asp:Content>
