$(document).ready(function () {
    var $side = $("#side");
    var $sideName = $("#sideName");

    if (isElementExist("#changeSidePage")) {
        if ($side.val()) {
            $sideName.text("Light");
            removeClass("body", "light-side-background-color");
            setClass("body", "light-side-background-color");
            removeClass(".navbar", "navbar-inverse");
            setClass(".navbar", "navbar-default");
        } else {
            removeClass("body", "dark-side-background-color");
            setClass("body", "dark-side-background-color");
            removeClass(".navbar", "navbar-default");
            setClass(".navbar", "navbar-inverse");
            $sideName.text("Dark");
        }
    }

    function changeSideClick() {
        if (!($side.val())) {
            alert("LOL. There is no way out! P.S. Your HR department has been contacted");
        } else {
            $sideName.text("Dark");
        }
    }

    function setClass(element, cssClass) {
        var $element = $(element);

        if (!($element.hasClass(cssClass))) {
            $element.addClass(cssClass);
        }
    }

    function removeClass(element, cssClass) {
        var $element = $(element);

        if (($element.hasClass(cssClass))) {
            $element.removeClass(cssClass);
        }
    }

    function isElementExist(id) {
        return $("div").is(id);
    }

    $("#btnYes").bind("click", changeSideClick);
});