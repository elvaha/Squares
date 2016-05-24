function rotateVertical(rotationElement, rotationElementChild) {

    $(rotationElement).addClass('rotate').removeClass('rotate--reverse');
    $(rotationElementChild).addClass('rotate-child').removeClass('rotate-child--reverse');

}

function rotateHorizontal(rotationElement, rotationElementChild) {

    $(rotationElement).addClass('rotate--reverse').removeClass('rotate');
    $(rotationElementChild).addClass('rotate-child--reverse').removeClass('rotate-child');

}

function expandSearchbar() {

    $('#search-widget').removeAttr('style');
    $('#search-widget .search__type').show();
    $('#search-widget .search__searchbar-wrapper').show();
    $('#search-widget .search__sort').show();
    $('#search-widget .search__submit').show();
    $('#search-widget .search__form').find('.search__arrow').remove();

}

function collapseSearchbar() {

    console.log('collapse');

    $('#search-widget').css('width', '100px');
    $('#search-widget .search__type').hide();
    $('#search-widget .search__searchbar-wrapper').hide();
    $('#search-widget .search__sort').hide();
    $('#search-widget .search__submit').hide();

    var arrowImg = $('<img />');
    arrowImg.attr('src', 'https://cdn0.iconfinder.com/data/icons/solid-line-essential-ui-icon-set/512/essential_set_left-512.png');
    arrowImg.addClass('search__arrow');

    $('#search-widget .search__form').append(arrowImg);

    $(arrowImg).click(function () {

        expandSearchbar();

    });

}

function displace(breakpoint, rotationElement, rotationElementChild) {

    if ($(breakpoint).offset() === undefined || $(window).width() <= 1366) return;

    var flagBottom = false;
    var flagTop = false;
    var distance = $(breakpoint).offset().top,
        $window = $(window);

    if ($window.scrollTop() >= distance + 20) {
    
        console.log('INIT');

        collapseSearchbar();
        rotateVertical(rotationElement, rotationElementChild);
    }

    if ($window.width() > 1366) {

        $window.scroll(function () {

            if ($window.scrollTop() >= distance + 20) {

                flagBottom = true;

                if (flagTop) {

                    collapseSearchbar();
                    rotateVertical(rotationElement, rotationElementChild);
                    flagTop = !flagTop;

                }

            } else {

                flagTop = true;

                if (flagBottom) {
                    console.log('UP');

                    expandSearchbar();
                    rotateHorizontal(rotationElement, rotationElementChild);
                    flagBottom = !flagBottom;

                }

            }

        });

    }

}

displace('#index-hook', '.main-navigation', '.main-navigation__item');
displace('#about-hook', '.main-navigation', '.main-navigation__item');
displace('.gallery #search-widget', '.main-navigation', '.main-navigation__item');
displace('body.designer', '.main-navigation', '.main-navigation__item');

$('.squares-modal__close').click(function () {

    $(this).parent()
        .hide();

    $(this).parent()
        .find('form')
        .find("input, textarea")
        .val("");

});

$('.drop-zone').height($('.drop-zone').width());