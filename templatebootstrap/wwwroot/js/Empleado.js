


function GetAll() {
    $.ajax({

        type: 'GET',
        url: 'http://localhost:5065/Empleado/GetAll',
        success: function (result) { 
            $('#table_usuarios tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas = '<tr>' + '<td class="text-center"> ' + '<a href="#" onclick="GetById(' + empleado.IdEmpleado + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />' + '</a> ' + '</td>' + "<td  id='id' class='text-center'>" + empleado.IdEmpleado + "</td>" + "<td class='text-center'>" + empleado.Nombre + "</td>" + "<td class='text-center'>" + empleado.Nombre + "</td>" + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>" + "<td class='text-center'>" + empleado.ApellidoMaterno + "</td>" + "<td class='text-center'>" + empleado.Estado.Nombre + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SubCategorias tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    })
}