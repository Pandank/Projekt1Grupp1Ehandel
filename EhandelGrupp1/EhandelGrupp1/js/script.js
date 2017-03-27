﻿$(document).ready(function () {
    // om användaren är inloggad visa funktioner för inloggade
    if (localStorage.getItem('userId') != null || sessionStorage.getItem('userId') != null) {
        // kolla om användaren är administratör
        if (localStorage.getItem('isAdmin') == 1 || sessionStorage.getItem('isAdmin') == 1) {
            loginAdmin();
        }
        // om användaren inte är administratör
        else {
            loginUser();
        }
    }

    /* LOGGA UT */
    $('#logoutButton').click(function () {
        // ta bort session
        localStorage.clear();
        sessionStorage.clear();
        // ta bort "Logga ut"-knapp
        $('#logoutButton').hide();
        // ändra text i fotnavigationen i mobilvyn
        $('#loginText').text('Logga in');
    });
    /* Vid klick på "Logga in" / "Konto" i fotnavigationen i mobilvy */
    $('#userLink').click(function () {
        // om användaren är inloggad ska den skickas till kontosidan
        if (localStorage.getItem('userId') != null || sessionStorage.getItem('userId') != null) {
            $('#userLink').prop('href', '');
        }
        // om användaren inte är inloggaf ska inloggningsfönstret öppnas
        else {
            $('#userLink').prop('href', '#loginModal');
        }
    });

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
        var rememberMe = $('#rememberMe').prop('checked');
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
        // kolla om användaren finns i databasen
        if (isValid) {
            $.getJSON({
                url: 'services/svc-login.aspx',
                data: {
                    email: email,
                    password: password
                }
            }).done(function(result) {
                console.log(result)
                if (result.length != 0) {
                    // om användaren har bockat för "Kom ihåg mig" sätt localStorage
                    if (rememberMe) {
                        localStorage.setItem('userId', result[0].userId);
                        localStorage.setItem('isAdmin', result[0].isAdmin);
                    }
                    // om användaren inte vill bli ihågkommen sätt sessionStorage
                    else {
                        sessionStorage.setItem('userId', result[0].userId);
                        sessionStorage.setItem('isAdmin', result[0].isAdmin);
                    }
                    // töm fälten
                    $('#email').val('');
                    $('#password').val('');
                    // TODO avbocka
                    // stäng modal-fönstret
                    $('#loginModal').modal('hide');
                    // om användaren är admin
                    if (result[0].isAdmin == 1) {
                        loginAdmin();
                    }
                    // om användaren inte är admin
                    else {
                        loginUser();
                    }
                }
                else {
                    $('<p class="error">Felaktig inloggning</p>').insertAfter('#loginButton');
                }
            });
        }
    });
    /* Visa funktioner för inloggade användare */
    function loginUser() {
        console.log('visa funktioner för inloggade')
        $('#loginText').text("Konto");
        $('#topNavbar ul').append('<li><a href="#" id="logoutButton">Logga ut</a></li>');
    }

    /* Visa funktioner för inloggade administratörer */
    function loginAdmin() {
        loginUser();
        console.log('visa funktioner för administratörer')
    }

    /* Inkl/exkl moms */
    $('#vatButton').click(function () {
        console.log("Session: " + sessionStorage.getItem("userId"))
        console.log("Local: " + localStorage.getItem("userId"))
        if ($('#vatText').text() == 'Inkl. moms') {
            $('#vatText').text('Exkl. moms');
            // visa priser med moms
        }
        else {
            $('#vatText').text('Inkl. moms');
            // visa priser utan moms
        }
    });

    /***********************************
    PRODUKTSIDA
    ***********************************/
    /* Klick på produkt-länk */
    $('.product').click(function (e) {
        // Hämta id
        var id = $(this).parent().prop('id');
        // Hämta och skriv ut produkt
        getProduct(id);
    });

    /* Hämta och skriv ut produkt */
    function getProduct(id) {
        $.getJSON('services/svc-product.aspx?id=' + id)
        .done(function (result) {
            var productInfo = '<div id="' + id + '">';
            productInfo += '<h2 class="h2">' + result[0].name + '</h2>';
            productInfo += '<img src="img/Papper.jpg" alt="" class="img-responsive" />';
            productInfo += '<p><span class="price">' + result[0].price + '</span> kr</p>';
            productInfo += '<input type="number" value="1" id="itemCounter" />';
            productInfo += '<button type="button" class="btn btn-primary addToCartButton">Köp</button>';
            productInfo += '<p>' + result[0].description + '</p>';
            productInfo += '</div>';
            $('#productSite').append(productInfo);
        });
    }

    /* Lägg produkt i varukorg */
    $('.addToCartButton').click(function () {
        // Läs in produkt-id
        var id = $(this).parent().prop('id');
        // Läs in produktnamn
        var productName = $('#' + id + ' h2').text();
        // Antal produkter
        var counter = $('#itemCounter').val();
        // Läs in pris
        var price = $('#' + id + ' .price').text();
        // Räkna ut summa
        var sum = counter * price;
        // Funktion: lägg till produktsumma till resterande varukorg
        // Öka varukorg-counter med 1
        addToCart(id, productName, counter, price, sum);
        // Lägg till html i varukorg
    });

    function addToCart(id, productName, counter, price, sum) {
        
    }
});

/* Hämta url-parameter */
function getUrlParam(name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results == null) {
        return null;
    }
    else {
        return results[1] || 0;
    }
}