//*const { post } = require("jquery");/

function inputValues() {
    const container = document.getElementById("ContentPlaceHolder1_contentArea");
    const divs = container.getElementsByTagName('div');
    const arrData = [];
    let arr = [];

    for (var i = 0; i < divs.length; i++) {
        for (var j = 0; j < divs.item(i).childElementCount; j++) {
            if (divs.item(i).children.item(j).localName == 'input') {
                if (divs.item(i).children.item(j).type == 'radio') {
                    if (divs.item(i).children.item(0).checked) {
                        arr.push(divs.item(i).children.item(j));
                    }
                }
                else {
                    arr.push(divs.item(i).children.item(j));
                }
            }
        }
    }
    for (var i = 0; i < arr.length; i++) {
        arrData.push(arr[i].value);
    }
    let arrStr = arrData.join(';');

    console.log(arrData);

    $.ajax({
        type: "POST",
        url: "CargarFormularios.aspx/Ejemplo",
        data: JSON.stringify({ arr: arrStr }),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (info) {
        //Respuesta
        console.log(info);
    })
}