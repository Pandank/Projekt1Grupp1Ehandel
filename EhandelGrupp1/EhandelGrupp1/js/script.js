$(document).ready(function () {
    var cCounter = sessionStorage.getItem('cartCounter');
    $('#itemCount').text(cCounter);

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
            }).done(function (result) {
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
    REGISTRERING
    ***********************************/
    /* Klick på "Registrera */
    $('#registerButton').click(function () {
        // ta bort felmeddelanden
        $('.error').remove();

        var isValid = true;
        var firstname = $('#registerfirstname').val();
        var lastname = $('#registerlastname').val();
        var email = $('#registeremail').val();
        var password = $('#registerpassword').val();
        var passwordCheck = $('#verifyregisterpassword').val();
        var street = $('#registerstreet').val();
        var zip = $('#registerzip').val();
        var city = $('#registercity').val();
        var country = $('#registercountry').val();

        /* Validera att alla fält i ifyllda */
        if (firstname == '') {
            $('<p class="error">Förnamn saknas</p>').insertAfter('#registerfirstname');
            $('.register-firstname').addClass('has-error');
            isvalid = false;
        }
        if (lastname == '') {
            $('<p class="error">Efternamn saknas</p>').insertAfter('#registerlastname');
            $('.register-lastname').addClass('has-error');
            isvalid = false;
        }
        if (email == '') {
            $('<p class="error">E-post saknas</p>').insertAfter('#registeremail');
            $('.register-email').addClass('has-error');
            isvalid = false;
        }
        if (password == '') {
            $('<p class="error">Lösenord saknas</p>').insertAfter('#registerpassword');
            $('.register-password').addClass('has-error');
            isValid = false;
        }
        if (passwordCheck == '') {
            $('<p class="error">Lösenord saknas</p>').insertAfter('#verifyregisterpassword');
            $('.register-passwordCheck').addClass('has-error');
            isValid = false;
        }
        else {
            // kolla att lösenorden överensstämmer med varandra
            if (password != passwordCheck) {
                $('<p class="error">Lösenorden överensstämmer inte med varandra</p>').insertAfter('#verifyregisterpassword');
                $('.register-passwordCheck').addClass('has-error');
                isValid = false;
            }
        }
        if (street == '') {
            $('<p class="error">Gatuadress saknas</p>').insertAfter('#registerstreet');
            $('.register-street').addClass('has-error');
            isValid = false;
        }
        if (zip == '') {
            $('<p class="error">Postnummer saknas</p>').insertAfter('#registerzip');
            $('.register-zip').addClass('has-error');
            isValid = false;
        }
        if (city == '') {
            $('<p class="error">Stad saknas</p>').insertAfter('#registercity');
            $('.register-city').addClass('has-error');
            isValid = false;
        }
        if (country == '') {
            $('<p class="error">Land saknas</p>').insertAfter('#registercountry');
            $('.register-country').addClass('has-error');
            isValid = false;
        }
        // Om formuläret validerar
        if (isValid) {
            $.getJSON({
                url: 'services/svc-registeruser.aspx',
                data: {
                    firstname: firstname,
                    lastname: lastname,
                    email: email,
                    password: password,
                    street: street,
                    zip: zip,
                    city: city,
                    country: country
                }
            }).done(function (result) {
                console.log(result)
                /*if (result.length != 0) {
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
                }*/
            });
        }
    });



    /***********************************
    VARUKORG
    ***********************************/
    /* Klick på varukorg */
    $('#cartButton').click(function () {
        
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
        // Antal produkter
        var counter = $('#itemCounter').val();
        // Läs in pris
        var price = $('#' + id + ' .price').text();
        jsPrice = price.replace(',', '.');
        // Räkna ut summa
        var sum = counter * jsPrice;
        sumString = sum.toString();
        sumString = sumString.replace('.', ',');

        // om produkten redan finns i varukorgen, öka på antalet och summa
        if ($('#cartProduct_' + id).length) {
            // Antal
            var oldCounter = $('#cartProduct_' + id + ' .productCounter').val();
            newCounter = counter * 1 + oldCounter * 1;
            $('#cartProduct_' + id + ' .productCounter').val(newCounter);
            // Summa
            //var oldSum = $('#cartProduct_' + id + ' .productSum').text();
            //console.log('#cartProduct_' + id + ' .productSum')
            //oldSum = oldSum.replace(',', '.');
            //console.log(oldSum * 1)

            //var newSum = sum * 1 + oldSum * 1;
            //console.log(newSum)
            //$('#cartProduct_' + id + ' .productSum').text(newSum);
        }
        // lägg till i varukorgen
        else {
            // Läs in produktnamn
            var productName = $('#' + id + ' h2').text();

            // Öka varukorg-counter med 1
            $('#itemCount').css('display', 'block');
            var cartCounter = $('#itemCount').text();
            cartCounter = cartCounter * 1;
            cartCounter++;
            $('#itemCount').text(cartCounter);

            sessionStorage.setItem('cartCounter', cartCounter);
            //sessionStorage.setItem('product', counter);

            //sessionStorage.setItem('productCounter', counter);
            //sessionStorage.setItem('productName', productName);
            //sessionStorage.setItem('productPrice', price);
            //sessionStorage.setItem('productSum', sum);

            // Funktion: lägg till produktsumma till resterande varukorg
            addToCart(id, productName, counter, price, sumString);
        }
        
        
        
    });

    function addToCart(id, productName, counter, price, sum) {
        var cartItem = '<div id="cartProduct_' + id + '">';
        cartItem += '<input class="productCounter" type="number" value="' + counter + '" />';
        cartItem += '<span>' + productName + '</span>';
        cartItem += '<span class="productPrice">' + price + '</span>';
        cartItem += '<span class="productSum">' + sum + '</span>';
        cartItem += '<p>Totalsumma: </p>';
        cartItem += '</div>';

        $('.modal-body').append(cartItem);
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