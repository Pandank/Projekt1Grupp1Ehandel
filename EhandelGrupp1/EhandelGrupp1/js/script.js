$(document).ready(function () {

    /* LOGGA IN */
    // klick på "Logga in"-knappen i modalfönstret
    $('#loginButton').click(function (e) {
        e.preventDefault();
        // ta bort felmeddelanden
        $('.error').remove();
        $('.modal-email').removeClass('has-error');
        $('.modal-password').removeClass('has-error');
        // sätt variabler
        var isValid = true;
        var email = $('#email').val();
        var password = $('#password').val();
        //var rememberMe = 

        // kolla om e-post fyllts i
        if (email == '') {
            $('<p class="error">E-post saknas</p>').insertAfter('#email');
            $('.modal-email').addClass('has-error');
            isvalid = false;
        }
        // kolla om lösenord fyllts i
        if (password == '') {
            $('<p class="error">Lösenord saknas</p>').insertAfter('#password');
            $('.modal-password').addClass('has-error');
            isValid = false;
        }
    });
});

/* LOGGA IN */

// klick på "Logga in"

// kolla om e-post fyllts i
// kolla om lösenord fyllts i
// kolla om "Kom ihåg mig" bockats för

// JSON - kolla om e-post och lösenord stämmer
// om stämmer - stäng fönster och trigga all funktionalitet för om en användare är inloggad
// kolla om användaren är admin
// om admin skriv ut all funktionalitet för det
// om felaktig inloggning skriv ut felmeddelande






// TODO ändra "Logga in" till "Mitt konto" om användaren är inloggad

