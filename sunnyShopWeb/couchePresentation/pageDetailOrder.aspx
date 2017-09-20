<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pageDetailOrder.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.pageDetailOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHMenu" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContenu" runat="server">
<div class="laTable">  
     <table class="odTable">

        <tr>
            <th class="idProd" id="idProd{6}">Ref.</th>
            <th class="nomProd" id="nomProd{6}">Description</th>
            <th class="prixUnit" id="prixUnit{6}">Prix/U</th>
            <th class="quantity" id="quantity{6}">Quantité</th>
            <th class="ssTotal" id="ssTotal{6}">Sous-Total</th>
        </tr>
    </table>
    </div> 
    <script type="text/javascript">
      $("header").hide();
  </script>  
</asp:Content>
