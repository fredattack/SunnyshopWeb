<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pagePanier.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.pagePanier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenFieldSessionControl" runat="server" />    
    <div class="UserInfo" runat="server" onclick="#" id ="theDiv"> 
        <div class="cadre">              
        </div>
        <div class="label">        
                <asp:Label ID="LaUserName" runat="server" Text="LaText" title="Profil" CssClass="LaUserName"></asp:Label>
                 <asp:Button ID="Button1" runat="server" Text="Se déconnecter" OnClick="Button1_Click" onmousemove='overElement(this);' onmouseout='outElement(this);'/>
                <asp:Label ID="LabCart" CssClass="LabCart" runat="server" Text=""></asp:Label>
        </div>  
            <a href="/couchePresentation/pageUserProfil.aspx"><img class="sign" src="/images/imgDivers/sign.png" runat="server"  />&nbsp;</a>
            <a href="#"><img class="cart" src="/images/imgDivers/cart.png" runat="server" onclick='addToCartAjax(this.id);' />&nbsp;</a>
        </div> 
     <div class="btPanier">

         <asp:Button ID="BtClearCart" CssClass="myButton"  runat="server" Text="vider le Panier" onclientClick="return confirm('Voulez vous effacer votre panier?'); " OnClick="BtClearCart_Click"
          TabIndex="1" />
         <asp:Button ID="BtCheckOut" CssClass="myButton"  TabIndex="0" runat="server" Text="Valider la commande" OnClick="BtCheckOut_Click" />

    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHMenu" runat="server">
    <ul id="menu-bar">
             <li><a href="/couchePresentation/index.aspx">Home</a></li>
             <li ><a href="/couchePresentation/pageVin.aspx">Produits</a>
              
             </li>
               <li class="active"><a href="/couchePresentation/pageUserProfil.aspx">Mon Compte</a></li>
           
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
   <%--// <form>--%>
    
                 <p id="laTotal" runat="server" ></p><p id="totalVal" runat="server" ></p>
        <p id="laAlert" runat="server"></p>

    </<%--form--%>>
</asp:Content>
