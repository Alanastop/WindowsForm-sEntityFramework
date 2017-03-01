var popUpObj;

function showModalReportViewer(link) {
    popUpObj = window.open(link,
        "ModalPopUp",
        "toolbar=no," +
        "scrollbars=yes," +
        "location=no," +
        "statusbar=no," +
        "menubar=no," +
        "resizable=yes," +
        "width=470px," +
        "height=450"
    );

    LoadModalDiv();
    popUpObj.focus();


    return false;
}

function showModalPopUp(button, link) {
   
      var rowId = 0;
    popUpObj = window.open(link + rowId,
        "ModalPopUp",
        "toolbar=no," +
        "scrollbars=yes," +
        "location=no," +
        "statusbar=no," +
        "menubar=no," +
        "resizable=yes," +
        "width=470px," +
        "height=450"
    );

    LoadModalDiv();
    popUpObj.focus();


    return false;
}


function LoadModalDiv() {
    var bcgDiv = document.getElementById("divBackground");
    bcgDiv.style.display = "block";
}

function HideModalDiv() {
  
        var bcgDiv = document.getElementById("divBackground");
        bcgDiv.style.display = "none";
}

function checkBalancePostBack() {
    localStorage.setItem('isBalancePostback', true);
}

function checkSendMailPostBack() {
    localStorage.setItem('isSendEmailPostback', true);
}

function PropertiesFormCloseFunction() {
    window.onbeforeunload = (function() {
        var element = document.activeElement;
        var isBalancePostback = localStorage.getItem("isBalancePostback");
        if (isBalancePostback != undefined && isBalancePostback === "true") {
            localStorage.setItem('isBalancePostback', false);
            return;
        }

        var isSendEmailPostback = localStorage.getItem("isSendEmailPostback");
        if (isSendEmailPostback != undefined && isSendEmailPostback === "true") {
            localStorage.setItem('isSendEmailPostback', false);
            return;
        }

        

        if (window.opener !== null && !window.opener.closed) {          
            if (element != undefined &&
                element.classList != undefined &&
                (element.classList.contains("propertiesOKButton")
                || element.classList.contains("editButtonClass"))) {

                if (element.classList.contains("propertiesOKButton")) {
                    window.opener.HideModalDiv();
                }
                return;
            }

            var retrievedObject = localStorage.getItem("preventExit");
            if (retrievedObject === "true") {
                localStorage.setItem('preventExit', false);
                return;
            }

            window.opener.location.href = window.opener.location.href;
            window.opener.HideModalDiv();
            localStorage.removeItem("isBalancePostback");
            localStorage.removeItem("isSendEmailPostback");
            localStorage.removeItem("temp");
            window.close();
        }
    });
}

function PropertiesFormSubmitFunction() {
    if (window.opener !== null && !window.opener.closed) {
        window.opener.location.href = window.opener.location.href;
        
        window.close();
    }
}

function FilterGrid(textbox) {
    var val = textbox.value;
    var objectList = $("#GridView1 > tbody > tr > td");
    for (var i = 0; i < objectList.length; i++) {
        var currentTd = objectList[i];
        if (currentTd.classList.contains("filterByTaxId")) {
            if (currentTd.innerText.indexOf(val) < 0)
                currentTd.parentElement.hidden = true;
            else
                currentTd.parentElement.hidden = false;
        }
    }
}


function closeForm() {

    if (window.opener !== null && !window.opener.closed) {
        window.opener.location.href = window.opener.location.href;
        window.close();
    }
}

//function reportFormClose() {
//    window.onbeforeunload = function () {
//            if (window.opener !== null && !window.opener.closed) {
//                var element = document.activeElement;
//                if (element != undefined && element.classList.contains("editButtonClass")) {
//                    return;
//                }

//                var bcgDiv = document.getElementById("divBackground");
//                bcgDiv.style.display = "none";
//                window.opener.location.href = window.opener.location.href;
//                window.close();
//            }
//        }
//}


$(function() {
    $("#filterId")
        .keydown(function(event) {
            if (event.keyCode === 13) {
                event.preventDefault();
                FilterGrid(event.currentTarget);

            }
            return true;
        });
});