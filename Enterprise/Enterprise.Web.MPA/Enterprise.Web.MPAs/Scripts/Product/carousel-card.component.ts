let marginLeft: number = 0;
function prevbtnclicked(selector: JQuery) {
    marginLeft = Number(selector.css('margin-left').substring(0, selector.css('margin-left').indexOf('p')));
    if (0 < (marginLeft + 1200)) {
        marginLeft = 0;
    } else {
        marginLeft += 1200;
    }
    selector.css('margin-left', Number(marginLeft));
}
function nextbtnclicked(selector: JQuery, itemLength: number, productLength: number) {
    marginLeft = Number(selector.css('margin-left').substring(0, selector.css('margin-left').indexOf('p')));
    if (marginLeft - 1200 < ((productLength * -itemLength) + 1200)) {
        marginLeft = (productLength * -itemLength) + 1200;
    } else {
        marginLeft -= 1200;
    }
    selector.css('margin-left', Number(marginLeft));
}