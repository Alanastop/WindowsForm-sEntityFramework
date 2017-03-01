

function valueChange(input) {

    if (input.value !== input.defaultValue) {
        input.style.backgroundColor = "lightgreen";
        greenTextBox = input.id;
        textbox = document.getElementById('greenTextBox');
        textbox.value += greenTextBox + ",";
        localStorage.setItem('temp', textbox.value);
        return false;
        //} else {
        //    input.style.backgroundColor = "white";
        //}}
    }
    return false;

}

$(function () {
    $(document)
        .ready(function () {

            var textbox = document.getElementById("greenTextBox");
            if (textbox != undefined) {
                textbox.value = localStorage.getItem("temp");
                var res = textbox.value.split(",");
                res.forEach(function (word) {
                    var temptextbox = document.getElementById(word);
                    if (temptextbox != undefined) {
                        temptextbox.style.backgroundColor = "lightgreen";
                    }
                    
                });
            }


        });

});