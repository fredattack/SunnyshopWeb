<%@ Page Title="" Language="C#" MasterPageFile="~/couchePresentation/SunnyMasterPage.Master" AutoEventWireup="true" CodeBehind="pagePanierTemp.aspx.cs" Inherits="sunnyShopWeb.couchePresentation.pagePanierTemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader"  runat="server" Visible="false">
</asp:Content>





<asp:Content ID="Content3" ContentPlaceHolderID="CPHMenu" runat="server">
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="CPHContenu"  runat="server" Visible="false">
            
                 <p id="laTotal" runat="server" ></p><p id="totalVal" runat="server" ></p>

    <script type="text/javascript">
      $("header").hide();
  </script>  
</asp:Content>
