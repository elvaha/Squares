var rotateShit = function () {

    var menuContainer = $('.main-navigation');
    var menuItems = $('.main-navigation__item');

    function rotateVertical() {

        $(menuContainer).addClass('rotate').removeClass('rotate--reverse');
        $(menuItems).addClass('rotate-child').removeClass('rotate-child--reverse');

    }

    function rotateHorizontal() {

        $(menuContainer).addClass('rotate--reverse').removeClass('rotate');
        $(menuItems).addClass('rotate-child--reverse').removeClass('rotate-child');

    }

    return {
        rotateVertical: rotateVertical,
        rotateHorizontal: rotateHorizontal
    }

}

var searchbarShit = function () {

    var searchbar = $('#search-widget');
    var searchbarChildren = searchbar.children();

    function createExpandButton() {

        var arrowImg = $('<img />');
        arrowImg.attr('src', '/Content/images/left-arrow.png');
        arrowImg.addClass('search__arrow');

        $(arrowImg).click(function () {

            expandSearchbar();

        });

        return arrowImg;

    }

    function expandSearchbar() {

        searchbar.removeAttr('style');

        searchbar
            .find('.search__arrow')
            .remove();

        searchbarChildren.show();

    }

    function collapseSearchbar() {

        searchbar.css('width', '50px');
        searchbar.append(createExpandButton());
        searchbarChildren.hide();

    }

    return {
        expandSearchbar: expandSearchbar,
        collapseSearchbar: collapseSearchbar
    }

}

function menuTransform(transitionPoint) {

    if ($(transitionPoint).offset() === undefined || $(window).width() <= 1366) return;

    var shitRotator = new rotateShit();
    var shitSearchbar = new searchbarShit();

    var flagBottom = false;
    var flagTop = false;

    var distance = $(transitionPoint).offset().top;
    var $window = $(window);

    if ($window.width() > 1366) {

        $window.scroll(function () {

            if ($window.scrollTop() >= distance) {

                flagBottom = true;

                if (flagTop) {

                    shitRotator.rotateVertical();
                    shitSearchbar.collapseSearchbar();
                    flagTop = !flagTop;

                }

            } else {

                flagTop = true;

                if (flagBottom) {

                    shitRotator.rotateHorizontal();
                    shitSearchbar.expandSearchbar();
                    flagBottom = !flagBottom;

                }

            }

        });

    }

}

menuTransform('#transify');