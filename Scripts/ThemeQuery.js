//On every page load checks if there was previously an applied theme else it applies by default the light theme
$(function () {
    $(document).ready(function () {
        var id = getStoredValue("currentthemeid");
        var userChoice = $("#" + id).html();
        if (!isBlank(userChoice)) {
            $("#dropdownMenu1").html(userChoice + ' <span class="caret"></span>');
        } else {
            var fistChoice = $("#themeDropDown li:first-child").text();
            $("#dropdownMenu1").html(fistChoice + ' <span class="caret"></span>');

        }

        if (id === "dark") {
            applyDarkTheme();

        } else {
            applyLightTheme();
        }

        $('body').show();
    });

//Calls the light or dark theme function to apply depending on the user selection from the dropdown
    $("#themeDropDown li")
        .click(function (event) {
            $("#dropdownMenu1").html($(this).text() + ' <span class="caret"></span>');
            var id = $(event.target).attr("id");
            storeValue("currentthemeid", id);
            if (id === "dark") {
                applyDarkTheme();
            } else {
                applyLightTheme();
            }
        });
});

//Apply dark theme function
function applyDarkTheme() {
    $("#themeId").removeClass("lightThemeClass");
    $("#themeId").addClass("darkThemeClass");
}

//Apply light theme function
function applyLightTheme() {
    $("#themeId").removeClass("darkThemeClass");
    $("#themeId").addClass("lightThemeClass");
}

//Checks if user had applied a theme
function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

//Stores the selected theme so it keeps it on changing between windows
function storeValue(key, value) {
    if (localStorage) {
        localStorage.setItem(key, value);
    } else {
        $.cookies.set(key, value);
    }
}

//Gets the selected theme.
function getStoredValue(key) {
    if (localStorage) {
        return localStorage.getItem(key);
    } else {
        return $.cookies.get(key);
    }
}