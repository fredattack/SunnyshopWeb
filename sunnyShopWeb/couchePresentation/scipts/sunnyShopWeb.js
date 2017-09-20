
//#region init pages
function initApp() {
    window.console.log("initApp() -start");
     window.console.log("input[id$=HiddenFieldSessionControl] --> val = "+ $("input[id$=HiddenFieldSessionControl]").val())
     if ($("input[id$=HiddenFieldSessionControl]").val() == "null")
     {
         $("#liMonCompte").hide();
         $(".ColQuant").hide();
     }
     else
     {
         $("#liMonCompte").show();
         $(".ColQuant").show();
     }
    
}
function initVin() {
        window.console.log("initVin()  page load");
  
    }
//#endregion init pages 

//#region ManageDom
    function overElement(e) {
        e.style.cursor = "pointer";
    }

    function outElement(e) {
        e.style.cursor = "default";
    }
//#endregion ManageDom

//#region Product
    function addQuant(e) {
        var index = e.substring(3, e.length);
        var tbVal = parseInt($('#TbQ' + index).val());
        var stock = parseInt($('#laStock' + index).text());
        if (stock != 0) {
            if (tbVal < stock)
                tbVal += 1;
        }
        else alert("L'article est actuellement indisponible.");
        $('#TbQ' + index).val(tbVal.toString());
        
        window.console.log("addQuant responsee= " + index + ", valeur de tb = " + tbVal.toString());
    }
    function removeQuant(e) {
        var index = e.substring(3, e.length);
        var tbVal = parseInt($('#TbQ' + index).val());
        if (tbVal != 0) {
            tbVal -= 1;
        }
        $('#TbQ' + index).val(tbVal.toString());
        window.console.log("removeQuant responsee= " + index + ", valeur de tb = " + tbVal.toString());
    }

    function addToCartAjax(e) {
        var idProduit = e.substring(3, e.length);
               
        window.console.log(idProduit + " requete ajax start");
        if (parseInt($('#TbQ' + idProduit).val()) != 0) {
            if ($("#laIdVin" + idProduit).text().substring(1, 2) == 0) {
                if (parseInt($('#TbQ' + idProduit).val()) < 3)
                {
                    alert("la quantité minimum de vin commandée doit être de 3.")
                }

                else {
                    //creaction de l'objet ligneCommande
                    var ligneCommande = {
                        IdProduit: $("#laIdVin" + idProduit).text(),
                        Quantity: parseInt($('#TbQ' + idProduit).val())
                    }

                    //envoie de l'objet vers le serveur
                    $.ajax({
                        type: "POST",
                        url: "/couchePresentation/panierData.aspx/getData",
                        data: JSON.stringify(ligneCommande),
                        datatype: "json",
                        //async: false,

                    });

                    //gestion des Affichage et de la DialogBox
                    window.console.log(ligneCommande.IdProduit + " requete ajax end");
                    refreshIframe();
                    window.console.log(ligneCommande.IdProduit + " dialog refreshed start");
                    openDialog();
                    window.console.log(ligneCommande.IdProduit + " openDialog ");
                }

            }
            else
            {
                //creaction de l'objet ligneCommande
                var ligneCommande = {
                    IdProduit: $("#laIdVin" + idProduit).text(),
                    Quantity: parseInt($('#TbQ' + idProduit).val())
                }

                //envoie de l'objet vers le serveur
                $.ajax({
                    type: "POST",
                    url: "/couchePresentation/panierData.aspx/getData",
                    data: JSON.stringify(ligneCommande),
                    datatype: "json",
                    //async: false,

                });

                //gestion des Affichage et de la DialogBox
                window.console.log(ligneCommande.IdProduit + " requete ajax end");
                refreshIframe();
                window.console.log(ligneCommande.IdProduit + " dialog refreshed start");
                openDialog();
                window.console.log(ligneCommande.IdProduit + " openDialog ");
            }
        }
        else alert("Veuillez indiquer la quantité souhaitée");
    }

    function addQuantChemise(e) {
        var index = e.substring(3, e.length);
        var tbVal = parseInt($('#TbQ' + index).val());
        var stock = parseInt($('#laStock' + index).text());
        tbVal += 1;
        $('#TbQ' + index).val(tbVal.toString());

        window.console.log("addQuant responsee= " + index + ", valeur de tb = " + tbVal.toString());
    }

    function addChemiseToCartAjax(e) {
        var idMotif = e.substring(3, e.length);
        if($('#Selecteur' + idMotif).prop('selectedIndex')!=0)
        {
            if (parseInt($('#TbQ' + idMotif).val()) != 0) {

                //creaction de l'objet ligneCommande
                var ligneCommande =
                    {
                        IdProduit: createIdTaile(e),
                        Quantity: parseInt($('#TbQ' + idMotif).val())
                    }

                //envoie de l'objet vers le serveur
                $.ajax(
                    {
                    type: "POST",
                    url: "/couchePresentation/panierData.aspx/getData",
                    data: JSON.stringify(ligneCommande),
                    datatype: "json",
                    async: false
                  
                });

                //gestion des Affichage et de la DialogBox
                window.console.log(ligneCommande.IdProduit + " requete ajax end");
                refreshIframe();
                window.console.log(ligneCommande.IdProduit + " dialog refreshed start");
                openDialog();
                window.console.log(ligneCommande.IdProduit + " openDialog ");
            }
            else alert("Veuillez indiquer la quantité souhaitée");
        }
        else alert("Veuillez d'abord choisr une taille disponible.");
    }

    function createIdTaile(e) {
        var idMotif = e.substring(3, e.length);
            
        var idProdGen = $("#laIdChemise" + idMotif).text();
        var idSansTaille = idProdGen.substring(0, idProdGen.length - 1);
        var idtaille=$('#Selecteur' + idMotif).prop('selectedIndex')-1
        var idProduit = idSansTaille+ idtaille ;
        window.console.log("idProduit avec la bonne taille:" + idProduit);
        return idProduit;
       
    }

//#endregion Product

//#region PanierTemp

    function addQuantPan(e) {
        var index = e.substring(6, e.length);
        //creaction de l'objet ligneCommande
        var ligneCommande = {
            IdProduit: $("#laId" + index).text(),
            Quantity: 1
        }
        var tbVal = parseInt($('#TbQPan' + index).val());
        var stock = parseInt($('#laStock' + index).text()); 
        if (tbVal < stock) {
            tbVal += 1;
            $('#TbQPan' + index).val(tbVal.toString());
            $.ajax({
                type: "POST",
                url: "/couchePresentation/panierData.aspx/getData",
                data: JSON.stringify(ligneCommande),
                datatype: "json",
                async: false,

            });

        }
        else alert("Désolé, le stock disponible est atteint");
        
        //envoie de l'objet vers le serveur
       
        var prix = parseFloat($('#prix' + index).text().replace(',', '.'));
        var quant = parseFloat($('#TbQPan' + index).val());
        var total = prix*quant;
        $('#ssT' + index).text(total);
        location.reload();
    }

    function removeQuantPan(e) {
        var index = e.substring(6, e.length);
        var tbVal = parseInt($('#TbQPan' + index).val());
       
        tbVal -= 1;
        $('#TbQPan' + index).val(tbVal.toString());
        //creaction de l'objet ligneCommande
        var ligneCommande = {
            IdProduit: $("#laId" + index).text(),
            Quantity: -1
        }

        //envoie de l'objet vers le serveur
        $.ajax({
            type: "POST",
            url: "/couchePresentation/panierData.aspx/getData",
            data: JSON.stringify(ligneCommande),
            datatype: "json",
            //async: false,

        });
        var prix = parseFloat($('#prix' + index).text().replace(',', '.'));
        var quant = parseFloat($('#TbQPan' + index).val());
        var total = prix * quant;
        $('#ssT' + index).text(total);
        location.reload();
    }

    function deleteItem(e) {
        var index = e.substring(3, e.length);
       // alert(index);
        //creaction de l'objet ligneCommande
        var ligneCommande = {
            IdProduit: $("#laId" + index).text(),
            Quantity: 0
        }
        //envoie de l'objet vers le serveur
        $.ajax({
            type: "POST",
            url: "/couchePresentation/panierData.aspx/getData",
            async:false,
            data: JSON.stringify(ligneCommande),
            datatype: "json",
            //async: false,
        });
       // location.reload(false);
        window.top.location = window.top.location
        
    }

        //#endregion 

        //#region Confirmation
        
   

    function confirmData() {

        confirm("Voulez-vous enregistrer ces données?");
    }

     

        //#endregion Confirmation

   

        //#region dialog

        function updateTotal() {
            //var cptr = $('.listPanierTab').length;

            //for (var i = 0; i < cptr; i++) {
            //var total=total+ $('#ssT'+i).val();
            //}
            total=$('#ssT0').text();
            alert(typeof total);
           

        }
        


        function openDialog() {

            $("#dialog").css("display", "block");
            $("#backgroundDialogue").css("display", "none");// modifier background
            $(".listVinMotif").css("opacity", "0.1");//masquer les produits

            $("#dialog").dialog({
                autoOpen: false,
                position: 'center',
                title: 'EDIT',
                draggable: false,
                width: 700,
                height: auto,
                resizable: true,
                modal: true,

            });
            $("#dialog").dialog("open");

            $(".CPHMenu]").css("display", "none");

        }

        function refreshIframe() {
            var iframe = document.getElementById("dialogIframe");
            iframe.src = iframe.src;
        }


        function dialogClose() {
            
         //   window.location = '/couchepresentation/pagepanier.aspx';
            $(".listvinmotif").css("display", "block");
            $("#dialog").css("display", "none");
            $(".listvinmotif").css("opacity", "1");
            window.location.reload();
        }

        function checkOut() {
            window.location = '/couchePresentation/pagePanier.aspx';
        }
//#endregion dialog

//#region Dialog DetailOrder

    function search(e){

    var index = e.substring(6, e.length);
    
    var idOrder = $("#idOrderTab" + index).html();
    window.console.log(idOrder + " requete ajax start");
            

    //envoie de l'objet vers le serveur
    $.ajax({
        type: 'POST',
        url: "/couchePresentation/orderData.aspx/getIdOrder",
     //   data: JSON.stringify(idOrder),
        data:idOrder,
        datatype: 'html',
        //async: false,

    });

    //gestion des Affichage et de la DialogBox
    window.console.log(idOrder + " requete ajax end");
    var iframe = document.getElementById("dialogIframeDetail");
    iframe.src = iframe.src;
    window.console.log(" dialog refreshed start");
    openDialogDetail();
    window.console.log( " openDialog ");
           
           
}
 
function openDialogDetail() {
    $(".motifOrderClient").css("display","none");
    $("#dialogDetail").css("display", "block");
    $("#backgroundDialogue").css("display", "none");// modifier background
  //  $(".listVinMotif").css("opacity", "0.1");//masquer les produits

    $("#dialogDetail").dialog({
        autoOpen: false,
        position: 'center',
        title: 'EDIT',
        draggable: false,
        width: 700,
        height: auto,
        resizable: true,
        modal: true,

    });
    $("#dialogDetail").dialog("open");

    $(".motifOrderClient").css("display", "none");

}
function closeIframe() {
    $(".motifOrderClient").css("display", "block");
    $("#dialogDetail").css("display", "none");
    $(".motifOrderClient").css("opacity", "1");
    window.location.reload();
}

//#endregion


    
