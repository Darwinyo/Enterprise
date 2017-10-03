
let deliveryDropped: boolean = false;
let deliveryPriceDropped: boolean = false;

function deliverClick() {
    if (deliveryDropped) {
        $('#deliverydropdown').attr('src', '/images/icons/arrow_up.png');
        $('#deliverdropcontent').removeAttr('hidden');
    } else {
        $('#deliverydropdown').attr('src', '/images/icons/arrow_down.png');
        $('#deliverdropcontent').attr('hidden','hidden');
    }
    deliveryDropped = !deliveryDropped;
}
function deliverPriceClick() {
    if (deliveryPriceDropped) {
        $('#deliverypricedropdown').attr('src', '/images/icons/arrow_up.png');
        $('#deliverpricecontent').removeAttr('hidden');
    } else {
        $('#deliverypricedropdown').attr('src', '/images/icons/arrow_down.png');
        $('#deliverpricecontent').attr('hidden', 'hidden');
    }
    deliveryPriceDropped = !deliveryPriceDropped;
}