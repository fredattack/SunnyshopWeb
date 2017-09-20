<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHMenu" runat="server">
    
    <form action="/" method="post" runat="server">
        <asp:HiddenField ID="HiddenFieldSessionControl" runat="server" />
    </form>
    
    
    <ul id="menu-bar" >
             <li ><a href="/couchePresentation/index.aspx">Home</a></li>
             <li><a href="/couchePresentation/pageVin.aspx">Produits</a>
              
             </li>
               <li id="liMonCompte"><a href="/couchePresentation/pageUserProfil.aspx">Mon Compte</a></li>
        </ul>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">

    <img  src="/images/imgDivers/CoverImage.jpg" runat="server" />
   
    <div class="loginButon">
        <a href="/couchePresentation/pageLogin.aspx" class="myButton">Se connecter</a>  
        <a href="/couchePresentation/PageInscription.aspx" class="myButton">S'inscrire</a> 
    </div>

</asp:Content>
