<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="mainPage.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.PageAcceuil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CPHHeader" runat="server">
   
    
     <form action="/" method="post" runat="server">
        
         <asp:hiddenfield ID="HiddenFieldSessionControl" runat="server"></asp:hiddenfield>
     
     

    <div class="UserInfo" runat="server" onclick="#" id="theDiv"> 
        <div class="cadre">              
        </div>
        <div class="label">        
                <asp:Label ID="LaUserName" runat="server" Text="LaText" title="Profil" CssClass="LaUserName"></asp:Label>
               <%--//  <asp:Button ID="Button1" runat="server" Text="Se déconnecter" OnClick="Button1_Click"/>--%>

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
           </div>  
            <a href="/couchePresentation/pageUserProfil.aspx"><img class="sign" src="/images/imgDivers/sign.png" runat="server"  />&nbsp;</a>
            <a href="#"><img class="cart" src="/images/imgDivers/cart.png" runat="server" />&nbsp;</a>
        </div> 
   </form>
   
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHMenu" runat="server">

    <ul id="menu-bar">
             <li class="active"><a href="/couchePresentation/mainPage.aspx">Home</a></li>
             <li><a href="/couchePresentation/pageProduit.aspx">Produits</a>
              
             </li>
               <li id="liMonCompte"><a href="/couchePresentation/pageUserProfil.aspx">Mon Compte</a></li>
             
        </ul>
    <div id="dialog"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPHContenu" runat="server">



</asp:Content>
