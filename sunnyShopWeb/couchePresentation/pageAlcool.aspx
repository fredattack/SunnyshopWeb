<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pageAlcool.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.pageAlcool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">

     <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenFieldSessionControl" runat="server" />

    <div class="UserInfo" runat="server"  id="theDiv"> 
        <div class="cadre">              
        </div>
        <div class="label">        
                <asp:Label ID="LaUserName" runat="server" Text="LaText" title="Profil" CssClass="LaUserName"></asp:Label>
                <asp:Button ID="Button1" runat="server" Text="Se déconnecter" OnClick="Button1_Click" onmousemove='overElement(this);' onmouseout='outElement(this);' />
                <asp:Label ID="LabCart" CssClass="LabCart" runat="server" Text=""></asp:Label>
        </div> 
            <a href="/couchePresentation/pageUserProfil.aspx"><img class="sign" src="/images/imgDivers/sign.png" runat="server"  />&nbsp;</a>
            <a href="#"><img class="cart" src="/images/imgDivers/cart.png" runat="server" onclick='addToCartAjax(this.id);'/>&nbsp;</a>
                
    </div> 

</form>
    
        <%--<asp:HiddenField ID="HiddenField1" runat="server" />--%>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHMenu" ClassCss="CPHMenu" runat="server">
         <%--Boite de dialogue pour afficher panier temporaire--%>
        <div id="dialog"  title="Dialog Title">
            <iframe id="dialogIframe" frameborder="0" scrolling="yes" width="700" height="700" src="/couchePresentation/pagePanierTemp.aspx">
            </iframe>
              <div id="buttonDialog">
                <button  class="myButton" id="buttonContinue" type="button" onclick="dialogClose();" >Continue shopping</button>
                <button class="myButton" id="buttonCheckOut"  type="button" onclick="checkOut();">Valider commande</button>
            </div>
        </div> 
   
     <ul id="menu-bar">
             <li><a href="/couchePresentation/index.aspx">Home</a></li>
             <li class="active" ><a href="/couchePresentation/pageVin.aspx">Produits</a>
              
             </li>
               <li id="liMonCompte"><a href="/couchePresentation/pageUserProfil.aspx">Mon Compte</a></li>
        </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContenu"  runat="server">
<aside>
    <ul id="menuSide" >
             
        <li   ><a href="/couchePresentation/pageVin.aspx">Les vins</a></li>
             
            <li class="active"><a href="/couchePresentation/pageAlcool.aspx">Les Alcools </a></li> 
            <li><a href="/couchePresentation/pageChemise.aspx">Les Chemises</a></li>
    </ul>
    </aside>


 

      
    
</asp:Content>
