//Sets the valiadation border color and symbol on form load
$(function validateForm() {
    $(document)
        .ready(function() {
            var textbox = document.getElementById("nameTextBox");
            if (textbox !== undefined) {
                validation(textbox);
            }
            var taxidTextBox = document.getElementById("taxIdTextBox");
            if (taxidTextBox !== undefined && taxidTextBox != null) {
                validation(taxidTextBox);
            }
        });

    $("body").show();
});

//Checks document validation on Save.
function documentSubmitClick() {
    var textbox = document.getElementById("nameTextBox");
    return validation(textbox);
}

//Checks company validation  on Save
function companySubmitClick() {
    var textbox = document.getElementById("nameTextBox");
    var taxidTextBox = document.getElementById("taxIdTextBox");
    var isValid = validation(textbox);
    if (isValid) {
        isValid = taxIdValidation(taxidTextBox.value);
        return isValid;
    } else {
        return false;
    }
}

//Performs the validation needed for user input
function validation(validationfield) {
    if (validationfield != undefined && validationfield.parentElement != undefined) {
        var validationErrorElement = validationfield.parentElement
            .getElementsByClassName("propertiesValidationError")[0];
        var flag;
        if (validationfield.value === "") {

            flag = false;
            ApplyBorderStyle(validationfield, flag);

            return false;

        } else {
            flag = true;
            ApplyBorderStyle(validationfield, flag);

            return true;
        }
    }
}

function ApplyBorderStyle(textbox,flag)
{
    var validationErrorElement = textbox.parentElement.getElementsByClassName("propertiesValidationError")[0];
    if (flag) {
        textbox.style.boxShadow = "0px 0px 2px 2px green";
        textbox.title = "";
        if (validationErrorElement !== undefined) {
            validationErrorElement.hidden = true;
        }
    } else {
        textbox.style.boxShadow = "0px 0px 2px 2px red";
        textbox.title = "Add a valid field";
        textbox.value = "";
        if (validationErrorElement === undefined) {
            var reg = /(value=")(\s?(.+)?)?(?=".*)/igm;
            var oldHtml = textbox.outerHTML;
            var sub = '$1';
            textbox.parentElement.innerHTML =  oldHtml.replace(reg, sub) + "<div class='propertiesValidationError'>X</div>";
        } else {
            validationErrorElement.hidden = false;
        }
    }
}

//Method to calculate if a given TaxId is valid
function taxIdValidation(taxid) {
    var textbox = document.getElementById("taxIdTextBox");
    var flag;
    if (taxid.length !== 9) {
        flag = false;
        ApplyBorderStyle(textbox, flag);
        return false;
    }

    var temp = Number(taxid) / 10;
    temp = Math.floor(temp);
    var sum = 0;
    for (var i = 2; i < 257; i = i * 2)
    {
        sum += (temp % 10) * i;
        temp = temp / 10;
        temp = Math.floor(temp);
    }

    var temp2 = (sum % 11) % 10;
    var isValid = (temp2 === Number(taxid) % 10);
    if (!isValid) {
        //taxid = document.getElementById("taxIdTextBox");
        flag = false;
        ApplyBorderStyle(textbox, flag);
    } else {
        flag = true;
        //taxid = document.getElementById("taxIdTextBox");
        ApplyBorderStyle(textbox, flag);
        //validation(taxid);
    }
    
    return temp2 === Number(taxid) % 10;
    
}