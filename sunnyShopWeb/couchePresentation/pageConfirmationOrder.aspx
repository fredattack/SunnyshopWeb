<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pageConfirmationOrder.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.pageConfirmationOrder" %>
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
    <aside>
    <ul id="menuSide" >
              <li  ><a href="/couchePresentation/pageUserProfil.aspx">Modifier le profil</a></li>
            <li ><a href="/couchePresentation/pageCommande.aspx">Commandes</a></li> 
            <li class="active"><a href="/couchePresentation/pagePanier.aspx">Panier</a></li>
    </ul>
    </aside>
    <h1>Merci pour votre Commande</h1>
    <br />
    <p id="ConfirmationText" runat="server">Vous Pouvez suivre le status de votre commande sur la page "Mon Compte" dans l'onglet "Commande"</p>
    
</asp:Content>
