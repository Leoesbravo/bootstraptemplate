/*!
* Start Bootstrap - Freelancer v7.0.6 (https://startbootstrap.com/theme/freelancer)
* Copyright 2013-2022 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-freelancer/blob/master/LICENSE)
*/
//
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Navbar shrink function
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink')
        } else {
            navbarCollapsible.classList.add('navbar-shrink')
        }

    };

    // Shrink the navbar 
    navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            offset: 72,
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );
    responsiveNavItems.map(function (responsiveNavItem) {
        responsiveNavItem.addEventListener('click', () => {
            if (window.getComputedStyle(navbarToggler).display !== 'none') {
                navbarToggler.click();
            }
        });
    });

});
function GetAll() {
    $.ajax({

        type: 'GET',
        url: 'http://localhost:5065/Empleado/GetAll',
        success: function (result) {
            $('#table_usuarios tbody').empty();
            $.each(result.objects, function (i, empleado) {
                var filas = '<tr>' + '<td class="text-center"> ' + '<button class="btn btn-warning" onclick="GetById(' + empleado.idEmpleado + ')">' + '<i class="fa-solid fa-user-pen fa-bounce"></i>' + '</button> ' + '</td>' + "<td  id='id' class='text-center'>" + empleado.idEmpleado + "</td>" + "<td class='text-center'>" + empleado.nombre + "</td>" + "<td class='text-center'>" + empleado.departamento.descripcion + "</ td>" + "<td class='text-center'>" + empleado.puesto.descripcion + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><i class="fa-solid fa-user-xmark fa-beat"></i></button></td>'

                    + "</tr>";
                $("#table_usuarios tbody").append(filas);
            });
            $('#portfolioModal1').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    })
}