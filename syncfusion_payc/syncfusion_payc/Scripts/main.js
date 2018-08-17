//Menu left
$(document).ready(function () {

    /*Traducci�n syncfusion */

    
 /*---------- Menu - Left - Icono alarma ----------*/

      var trigger = $('.alert-open'),
          overlay = $('.overlay'),
         isClosed = false;

        trigger.click(function () {
          hamburger_cross();      
        });

        function hamburger_cross() {

          if (isClosed == true) {          
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            isClosed = false;
          } else {   
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
          }
      }
      
        $('[data-toggle="offcanvas"]').click(function () {
            $('#wrapper').toggleClass('toggled');
        });

    $.extend($.validator.messages, {
        required: "Este campo es obligatorio.",
        remote: "Por favor, rellena este campo.",
        email: "Por favor, escribe una direcci�n de correo v�lida.",
        url: "Por favor, escribe una URL v�lida.",
        date: "Por favor, escribe una fecha v�lida.",
        dateISO: "Por favor, escribe una fecha (ISO) v�lida.",
        number: "Por favor, escribe un n�mero v�lido.",
        digits: "Por favor, escribe s�lo d�gitos.",
        creditcard: "Por favor, escribe un n�mero de tarjeta v�lido.",
        equalTo: "Por favor, escribe el mismo valor de nuevo.",
        extension: "Por favor, escribe un valor con una extensi�n aceptada.",
        maxlength: $.validator.format("Por favor, no escribas m�s de {0} caracteres."),
        minlength: $.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: $.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: $.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: $.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: $.validator.format("Por favor, escribe un valor mayor o igual a {0}."),
        nifES: "Por favor, escribe un NIF v�lido.",
        nieES: "Por favor, escribe un NIE v�lido.",
        cifES: "Por favor, escribe un CIF v�lido."
    });
});

//Funcion de busqueda en arrays
function search(nameKey, myArray) {
    for (var i = 0; i < myArray.length; i++) {
        if (myArray[i].name === nameKey) {
            return myArray[i];
        }
    }
}







