function showOrders() {
    $.ajax({
        
        contentType: "application/json",
        url: "https://localhost:7144/api/ordenes/getall",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $('#orderstable').append("<tr>\
										<td>"+ value.menuuItem + "</td>\
										<td>"+ value.mesa + "</td>\
										</tr>");
            })
        }

    })
        .done(function (data) {
            console.log(data)
            $("#orderstable").show()

        });


}


function createOrder(tableId, miId) {

    $.ajax({
        contentType: "application/json",
        method: "POST",
        url: "https://localhost:7144/api/ordenes/create",
        data: JSON.stringify({
            "mesa": tableId,
            "menuitemid": miId
            
        }),
        dataType: "text",

    })
        




}

