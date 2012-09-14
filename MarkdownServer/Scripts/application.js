$(function () {

    //  Unobtrusive JavaScript for elements with data-outline='xxx'
    //  where 'xxx' is the target element to be outlined
    $('[data-outline]').each(function () {
        var menu = $(this);
        var target = $(menu.data('outline'));
        var outline = HTML5Outline(target[0]).asHTML(true);
        menu.append(outline);
    });

});