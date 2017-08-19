let hovered: boolean = false;
function hover(selector: JQuery) {
    hovered = !hovered;
    if (hovered) {
        selector.attr('src', '/images/icons/arrow_up.png');
        $('#sortItem').removeAttr('hidden');
    } else {
        selector.attr('src', '/images/icons/arrow_down.png');
        $('#sortItem').attr('hidden','hidden');
    }
}
