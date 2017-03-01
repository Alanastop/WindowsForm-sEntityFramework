$(function() {
    //$('#name').bind('paste', function () {
    //    var self = this;
    //    setTimeout(function () {
    //        if (!/^[a-zA-Z]+$/.test($(self).val())) $(self).val('');
    //    }, 0);
    //});

    $("#balanceTextBox")
        .bind("paste",
            function() {
                var self = this;

                setTimeout(function() {
                       if (!/^\d*(\.\d{1,2})+$/.test($(self).val())) {
                           $(self).val("");
                       }
                   },
                   0);
            });

    $(".decimal")
        .keypress(function(e) {
            var character = String.fromCharCode(e.keyCode);
            var newValue = this.value + character;
            if (isNaN(newValue) || hasDecimalPlace(newValue, 3)) {
                e.preventDefault();
                return false;
            }
        });

    function hasDecimalPlace(value, x) {
        var pointIndex = value.indexOf(".");
        return pointIndex >= 0 && pointIndex < value.length - x;
    }
});