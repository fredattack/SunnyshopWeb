<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pageProduit.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.pageProduit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">
    <form id="form1" runat="server">
          <asp:hiddenfield ID="HiddenFieldSessionControl" runat="server"></asp:hiddenfield>
    <div class="UserInfo" onclick="#" runat="server" id="theDiv"> 
        <div class="cadre">              
        </div>
        <div class="label">        
                <asp:Label ID="LaUserName" runat="server" Text="LaText" title="Profil" CssClass="LaUserName"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Se déconnecter" OnClick="Button1_Click" onmousemove='overElement(this);' onmouseout='outElement(this);' />
           </div>  
            <a href="/couchePresentation/pageUserProfil.aspx"><img class="sign" src="/images/imgDivers/sign.png" runat="server"  />&nbsp;</a>
            <a href="#"><img class="cart" src="/images/imgDivers/cart.png" runat="server" />&nbsp;</a>
        </div> 
    
       
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHMenu" runat="server">
    <ul id="menu-bar">
             <li><a href="/couchePresentation/mainPage.aspx">Home</a></li>
             <li class="active"><a href="/couchePresentation/pageVin.aspx">Produits</a></li>
               <li id="liMonCompte"><a href="/couchePresentation/pageUserProfil.aspx">Mon Compte</a></li>
    </ul>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CPHContenu" runat="server">
    <aside>   
    <ul id="menuSide" >
        <li class="active"  ><a href="/couchePresentation/pageVin.aspx">Les vins</a></li>
             
            <li><a href="/couchePresentation/pageAlcool.aspx">Les Alcools </a></li> 
            <li><a href="/couchePresentation/pageChemise.aspx">Les Chemises</a></li>
    </ul>
    </aside>

</asp:Content>
