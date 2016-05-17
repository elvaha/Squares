$('.h').click(function () {

    $('.main-navigation').removeClass('rotate').addClass('rotate-reverse');
    $('.main-navigation__item').removeClass('rotate1').addClass('rotate1-reverse');
    $('.main-navigation__logo').removeClass('rotate1').addClass('rotate1-reverse');

});

$('.v').click(function () {

    $('.main-navigation').addClass('rotate').removeClass('rotate-reverse');
    $('.main-navigation__item').addClass('rotate1').removeClass('rotate1-reverse');
    $('.main-navigation__logo').addClass('rotate1').removeClass('rotate1-reverse');

});

$('.f').click(function () {
    $('.fold').toggleClass('fold--collapse').one('webkitTransitionEnd mozTransitionEnd MSTransitionEnd otransitionend transitionend', function () {

        console.log('transitionend');

        $('.gallery').children().addClass('animated').addClass('zoomOut').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {

            $(this).removeClass('zoomOut').detach();
            $('.gallery').append($(this));

        });

    });

});

$('.gallery__item')
    .height($('.gallery__item').width());

$(window).resize(function () {

    $('.gallery__item')
        .height($('.gallery__item').width());

});

$('#search-widget').hover(function () {

    //$(this).css('width', '100%').css('max-width', '700px');

    //$(this).find('.search__type').css('display', 'inline-block');

    //$(this).find('.search__searchbar-wrapper').css('display', 'block');

}, function () {

    //$(this).removeAttr('style');

    //$(this).find('.search__type').removeAttr('style');

    //$(this).find('.search__searchbar-wrapper').removeAttr('style');

});


$('.main-navigation__item').hover(function () {

    console.log('in');

    $(this).find('a').first().css('color', '#ff6a00');

}, function () {

    console.log('out');

    $(this).find('a').first().removeAttr('style');

});

var flag = false;
var flag1 = false;
var distance = $('#search-widget').offset().top,
    $window = $(window);

/*

$window.scroll(function () {

    if ($window.scrollTop() >= distance - 10) {
        console.log('SCROLLED PAST');
        
        flag = true;

        if (flag1) {
            console.log('DOWN');

            var size = $window.width() - ($('.main-navigation').width() + 20) + 'px';
            console.log(size);

            $('#search-widget').css('width', size);

            $('#search-widget').addClass('search--pin');
            $('.main-navigation').removeClass('rotate').addClass('rotate-reverse');
            $('.main-navigation__item').removeClass('rotate1').addClass('rotate1-reverse');
            $('.main-navigation__logo').removeClass('rotate1').addClass('rotate1-reverse');
            flag1 = !flag1;

        }

    } else {
        console.log('SCROLLED BEFORE');

        flag1 = true;

        if (flag) {
            console.log('UP');

            $('#search-widget').removeAttr('style');

            $('#search-widget').removeClass('search--pin');
            $('.main-navigation').addClass('rotate').removeClass('rotate-reverse');
            $('.main-navigation__item').addClass('rotate1').removeClass('rotate1-reverse');
            $('.main-navigation__logo').addClass('rotate1').removeClass('rotate1-reverse');
            flag = !flag;

        }

    }

});

 */

function stuffAboveOnce() {

    if ($window.scrollTop() >= distance - 10) {

            console.log('DOWN');

            var size = $window.width() - ($('.main-navigation').width() + 20) + 'px';
            console.log(size);

            $('#search-widget').css('width', size);

            $('#search-widget').addClass('search--pin');
            $('.main-navigation').removeClass('rotate').addClass('rotate-reverse');
            $('.main-navigation__item').removeClass('rotate1').addClass('rotate1-reverse');
            $('.main-navigation__logo').removeClass('rotate1').addClass('rotate1-reverse');
            flag1 = !flag1;

    }

}