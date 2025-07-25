function onPriceDropdownChange(ddl) {
    var indexValue = $(ddl).attr("index");
    var priceValue = $(ddl).val();
    $("#Items_" + indexValue + "__Price").val(priceValue);
    var quantity = $("#Items_" + indexValue + "__Quantity").val();
    if (quantity) {
        var totalPrice = parseInt(priceValue) * parseInt(quantity);
        $("#Items_" + indexValue + "__TotalPrice").val(totalPrice);
    } else {
        $("#Items_" + indexValue + "__TotalPrice").val("");
    }

    if ($(ddl).find("option:selected").text() == "Other") {
        $('.customItemName[index=' + indexValue + ']').show();
    }
    else {
        $("#Items_" + indexValue + "__CustomItemName").val("");
        $('.customItemName[index=' + indexValue + ']').hide();
    }
}

function onQuantityChange(input) {
    var indexValue = $(input).attr("index");
    var priceValue = $("#Items_" + indexValue + "__Price").val();
    if (priceValue) {
        var quantity = $(input).val();
        if (quantity) {
            var totalPrice = parseFloat(priceValue) * parseFloat(quantity);
            $("#Items_" + indexValue + "__TotalPrice").val(totalPrice);
        } else {
            $("#Items_" + indexValue + "__TotalPrice").val("");
        }
    }
}

function onPriceChange(input) {
    var indexValue = $(input).attr("index");
    var priceValue = $(input).val();
    if (priceValue) {
        var quantity = $("#Items_" + indexValue + "__Quantity").val();
        if (quantity) {
            var totalPrice = parseFloat(priceValue) * parseFloat(quantity);
            $("#Items_" + indexValue + "__TotalPrice").val(totalPrice);
        } else {
            $("#Items_" + indexValue + "__TotalPrice").val("");
        }
    }
}