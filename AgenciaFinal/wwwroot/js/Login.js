jQuery(document).ready(function ($) {

    $('#login').focus();

    $('#btnEntrar').on('click', function () {

        if ($('#login').val() != "" & $('#password').val() != "")
        {
            Validate($('login').val(), $('password').val());
            RedirectToAction("/Libros/Create");
        } else {
            Swal.fire(
                'Error',
                'Favor de ingresar usuario y password',
                'Error'
            );
        }
    });

    function Validate(usuario, pass) {

        var record = {
            Nombre = usuario,
            Password = pass,
        };

        $.ajax({
            url: '/Clientes/GetUsuario',
            async: false,
            type: 'POST',
            data: record,
            beforeSend: function (xhr, opts) {
            },
            complete: function () {
            },
            success: function (data) {
                if (data.status == true) {
                    window.location.href = "/Home/Index";
                } else if (data.status == false) {
                    Swal.fire(
                        'Error',
                        data.message,
                        'Error');
                }
            },
            error: function (data) {
                Swal.fire(
                    'Error',
                    data.message, 'Error'
                );
            }
        });
    }
});