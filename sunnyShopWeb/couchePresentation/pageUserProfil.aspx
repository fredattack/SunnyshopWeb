<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pageUserProfil.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">

      <div class="UserInfo" onclick="#"> 
        <div class="cadre">
        </div>
        <div class="label">        
                <asp:Label ID="LaUserName" runat="server" Text="LaText" title="Profil" CssClass="LaUserName"></asp:Label>
               <a href="/couchePresentation/index.aspx">
                   <asp:Label ID="LaDisconnect" runat="server" Text="Se déconnecter" titled="Votre Panier"  
                       CssClass="LaDisconnect" onclick="javascript: alert('Vous êtes déconnecté');">
                <asp:Label ID="LabCart" CssClass="LabCart" runat="server" Text=""></asp:Label>

                   </asp:Label>
               </a> 
           </div>  
            <a href="/couchePresentation/pageUserProfil.aspx"><img class="sign" src="/images/imgDivers/sign.png" runat="server"  />&nbsp;</a>
            <a href="#"><img class="cart" src="/images/imgDivers/cart.png" runat="server" />&nbsp;</a>
        </div> 

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
             <li class="active"  ><a href="/couchePresentation/pageUserProfil.aspx">Modifier le profil</a></li>
             
            <li><a href="/couchePresentation/pageCommande.aspx">Commandes</a></li> 
            <li><a href="/couchePresentation/pagePanier.aspx">Panier</a></li>
    </ul>
    </aside>
    
    <div id="profilZone" >
        <form id="fLogin" runat="server">
            <h1>Modifier votre profil</h1>
          <table class ="tableInscription">
              
              <%--<tr>
                <td class ="LaTab"><asp:Label ID="LaLogin" runat="server" CssClass="LaInscription" Text="Login : "></asp:Label></td>
                <td class ="TbTab"><asp:TextBox ID="TbLogin" runat="server"  CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>--%>
              <%--******* Ajouter:****************Fonction modifier password--%>
               
              <%--<tr>
                <td class ="LaTab"><asp:Label ID="LaPassword"  runat="server" CssClass="LaInscription" Text="Mot De Passe : "></asp:Label></td>
                <td><asp:TextBox ID="TbPassword" runat="server" TextMode="Password" CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>--%>
              <tr>
                <td class ="LaTab"> <asp:Label ID="LaPrenom" runat="server" CssClass="LaInscription" Text="Prénom : "></asp:Label></td>
                <td class ="TbTab"> <asp:TextBox ID="TbPrenom" runat="server"  CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>
              <tr>
                <td class ="LaTab"><asp:Label ID="LaNom" runat="server" CssClass="LaInscription" Text="Nom : "></asp:Label></td>
                <td class ="TbTab"><asp:TextBox ID="TbNom" runat="server"  CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>
              <tr>
                <td class ="LaTab"><asp:Label ID="LaAdress" runat="server" CssClass="LaInscription" Text="Adresse : "></asp:Label></td>
                <td class ="TbTab"><asp:TextBox ID="TbAdresse" runat="server"  CssClass="tbLogin" required="required" TextMode="MultiLine" ></asp:TextBox></td>
              </tr> 
            <tr>
                <td class ="LaTab"><asp:Label ID="LaBirthDate" runat="server" CssClass="LaInscription" Text="Date De Naissance (jj/mm/aaaa) : "></asp:Label></td>
                <td class ="TbTab"><asp:TextBox ID="TbBirthDate" runat="server"  CssClass="tbLogin" required="required"></asp:TextBox></td>
              </tr>
            </table>
        <div >        
                <asp:Button ID="BValiderInscription" runat="server" Text="Valider"
                OnClientClick="return confirm('Voulez vous Enregistrer ces modifications?');" OnClick="BContinuer_Click" CssClass="myButton" />
        </div> 
    </form>
    </div>
</asp:Content>
