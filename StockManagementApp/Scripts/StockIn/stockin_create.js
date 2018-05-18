
//AJAX Data Colling...........
$(document).ready(function() {
    $("#categoryDD").
    change(function() {
        var selectedCategoryId = $("#categoryDD").val();
        var jsonData = { categoryId: selectedCategoryId };

            $.ajax({
                url: "/Products/GetByCategory",
                data: jsonData,
                type: "POST",
                success: function(response) {
                    $("#productDD").empty();
                    var options = "<option>..Products..</option>";
                    $.each(response, function(key, productObj) {
                        options += "<option value='" + productObj.Id + "'>" + productObj.Name + "</option>";
                    });
                    $("#productDD").append(options);
                },
                error: function() {
                    alert("Data not found!");
                }
        });
        });
});

//Create Table............
var slNo = 0;
var index = 0;
$("#addToList").click(function() {
    var product = getProductForForm();
    var tableBody = $("#tableProducts");

    var slCell = "<td>"+product.slNo+"</td>";
    var indexCell = "<td style='display:none'><input type='hidden' name='StockInDetails.Index' value='" + index + "'/></td>";
    var productNameCell = "<td><input type='hidden' name='StockInDetails[" + index + "].ProductId' value='" + product.productId + "'/>" + product.productName + "</td>";
    var productQtyCell = "<td><input type='hidden' name='StockInDetails[" + index + "].Qty' value='" + product.Qty + "'/>" + product.Qty + "</td>";

    var tr = "<tr>" + slCell + indexCell + productNameCell + productQtyCell + '<td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td>' + "</tr>";

    //var tr = '<tr><td>' + product.slNo + '</td><td>' + product.productName + '</td><td>' + product.Qty + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
    //var tr = "<tr>" +"" +"<td> "+product.slNo+"<td>"+"<td> "+product.productName+"<td>"+"<td>"+product.Qty+"<td/>"+"</tr>";
    tableBody.append(tr);
    ++index;
    clearItem();
});

function getProductForForm() {
    ++slNo;
    var sl = slNo;
    var productId = $("#productDD").val();
    var productName = $("#productDD option:selected").text();
    var qty = $("#stockQty").val();
    return {
        productId: productId, slNo: sl, productName: productName, Qty: qty
    }
}
//Clear text box....
function clearItem() {
    $("#categoryDD").val('');
    $("#productDD").val('');
    $("#stockQty").val('');
}
// After Add A New Order In The List, If You Want, You Can Remove It.
$(document).on('click', 'a.deleteItem', function (e) {
    e.preventDefault();
    var $self = $(this);
    if ($(this).attr('data-itemId') === "0") {
        $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
            $($self).remove();
        });
        

    }
});
