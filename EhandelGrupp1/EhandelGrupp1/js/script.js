/// <reference path="C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Projekt\1-ehandel\EhandelGrupp1\EhandelGrupp1\administerproducts.aspx" />
$(document).ready(function () {
    // om varor finns i varukorgen, skriv ut antal unika produkter
    if (sessionStorage.getItem('cartCounter')) {
        
        var mq = window.matchMedia("(min-width: 768px)");
        if (mq.matches) {
            // window width is at least 768px
            $('header .itemCount').css('display', 'block');
        }
        else {
            $('.navbar-fixed-bottom .itemCount').css('display', 'block');
        }
        $('.itemCount').text(sessionStorage.getItem('cartCounter'));
    }

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

    if (sessionStorage.getItem('vatJS')) {
        if (sessionStorage.getItem('vatJS') == 'true') {
            $('#vatText').text('Inkl. moms');
        }
        else {
            $('#vatText').text('Exkl. moms');
        }
    }

    /***********************************
     LOGGA UT
     ***********************************/
    $('#logoutButton').click(function () {
        // ta bort session
        localStorage.clear();
        sessionStorage.clear();
        // ta bort "Logga ut"-knapp
        $('#logoutButton').hide();
        // ändra text i fotnavigationen i mobilvyn
        $('#loginText').text('Logga in');
        // visa "Logga in"
        $('#login').show();
        // ta bort "logga ut"
        $('#logout').hide();
    });
    /* Vid klick på "Logga in" / "Konto" i fotnavigationen i mobilvy */
    $('.userLink').click(function () {
        // om användaren är inloggad ska den skickas till kontosidan
        if (localStorage.getItem('userId') != null || sessionStorage.getItem('userId') != null) {
            $('.userLink').prop('href', 'userprofile.aspx');
            window.location.href = 'userprofile.aspx';
        }
            // om användaren inte är inloggad ska inloggningsfönstret öppnas
        else {
            $('.userLink').prop('href', '#loginModal');
        }
    });

    /***********************************
    LOGGA IN
    ***********************************/
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
        $('#login').text('Konto');
        $('#login').prop('href', 'userprofile.aspx');

        $('#loginText').text("Konto");
        $('#logout').show();
    }

    /* Visa funktioner för inloggade administratörer */
    function loginAdmin() {
        loginUser();
        // adminmeny-val
        var adminMenu = '<li class="admin">Administration</li>';
        adminMenu += '<li class="admin"><a href="administerproducts.aspx">Lägg till produkt</a></li>';
        adminMenu += '<li class="admin"><a href="#">Beställningar</a></li>';
        $('#topNavbar .nav').append(adminMenu);
        console.log('visa funktioner för administratörer')
    }

    /* Inkl/exkl moms */

    $('#vatButton').click(function () {
        var vat = "false";

        if ($('#vatText').text() == 'Exkl. moms') {
            vat = "true";
            $('#vatText').text('Inkl. moms');
            // visa priser med moms
        }
        else {
            $('#vatText').text('Exkl. moms');
            // visa priser utan moms
        }
        sessionStorage.setItem('vatJS', vat);

        $.get("services/svc-vat.aspx?vat=" + vat).
        done(function () {
            console.log("VAT: " + vat);
            location.reload();
        });
    });

    /***********************************
    REGISTRERING
    ***********************************/
    /* Klick på "Registrera */
    $('#register-user-button').click(function () {
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
            console.log("Validerar")
            $.getJSON({
                url: 'services/svc-createcustomer.aspx',
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
            }).done(function (userId) {
                if (userId.length != 0) {
                    sessionStorage.setItem('userId', userId);
                    sessionStorage.setItem('isAdmin', userId);
                    // töm fälten
                    $('#registerfirstname').val('');
                    $('#registerlastname').val('');
                    $('#registeremail').val('');
                    $('#registerpassword').val('');
                    $('#verifyregisterpassword').val('');
                    $('#registerstreet').val('');
                    $('#registerzip').val('');
                    $('#registercity').val('');
                    $('#registercountry').val('');
                    
                    loginUser();

                    window.location.href = "index.aspx";
                }
                else {
                    $('<p class="error">Tyvärr, något blev under registreringen. Försök gärna igen.</p>').insertAfter('#register-user-button');
                }
            });
        }
    });

    /***********************************
    PROFILSIDA
    ***********************************/
    if ($('#profilePage').length > 0) {
        if (sessionStorage.getItem('userId') != null) {
            var id = sessionStorage.getItem('userId');
        }
        else if (localStorage.getItem('userId') != null) {
            var id = sessionStorage.getItem('userId');
        }
            // om användaren inte är inloggad skickas den till startsidan
        else {
            window.location.href = 'index.aspx';
        }
        // hämta användarens uppgifter
        $.getJSON('services/svc-profile.aspx?userId=' + id)
        .done(function (result) {
            $('#editfirstname').val(result[0].firstname);
            $('#editlastname').val(result[0].lastname);
            $('#editemail').val(result[0].email);
        });
        // hämta användarens adress
        $.getJSON('services/svc-getuseraddress.aspx?userId=' + id)
        .done(function (result) {
            if (result.length > 0) {
                $('#editstreet').val(result[0].street);
                $('#editzip').val(result[0].zip);
                $('#editcity').val(result[0].city);
                $('#editcountry').val(result[0].country);
            }
        });
        // hämta tidigare ordrar
        $.getJSON('services/svc-order.aspx?userId=' + id)
        .done(function (result) {
            console.log(result)

            var orderItems = "";

            for (var i = 0; i < result.length; i++) {
                orderItems += '<tr id="order_' + result[i].orderId + '">';
                orderItems += '<td>' + result[i].orderId + '</td>';
                orderItems += '<td>' + result[i].date + '</td>';
                orderItems += '<td>' + result[i].status + '</td>';
                orderItems += '<td><a id="' + result[i].orderId + '" href="#">Läs mer</a></td>';
                orderItems += '</tr>';
            }
            // lägg till i kassan
            $('#orderTable tbody').append(orderItems);
        });
    }

    /* Uppdatera profiluppgifter */
    $('#updateUser').click(function () {
        console.log("Uppdatera användare")
        // TODO Validera fält
    });

    /* Uppdatera lösenord */
    $('#updatePassword').click(function () {
        console.log("Uppdatera lösenord")
        // TODO validera lösenordsfälten
    });




    /***********************************
    VARUKORG
    ***********************************/
    /* Klick på varukorg */
    $('.cartButton').click(function () {
        displayCartItems();
    });

    /* Visa innehållet i varukorgen */
    function displayCartItems() {
        // radera tidigare varukorgsinnehåll
        $('.modal-body').html('');
        // kolla om det finns några produkter tillagda
        if (sessionStorage.getItem('products')) {
            var products = [];
            productsInCart = sessionStorage.getItem('products');
            products = JSON.parse(productsInCart);

            var cartItem = "";
            var totalsum = 0;

            for (var i = 0; i < products.length; i++) {
                cartItem += '<div id="cartProduct_' + products[i].id + '">';
                cartItem += '<input class="productCounter" type="number" value="' + products[i].counter + '" />';
                cartItem += '<span>' + products[i].name + '</span>';
                cartItem += '<span class="productPrice">' + products[i].price + ' kr</span>';
                cartItem += '<span class="productSum">' + products[i].sum + ' kr</span>';
                cartItem += '</div>';
                totalsum += (products[i].sum * 1);
            }
            cartItem += '<p class="totalSum">Totalsumma: ' + totalsum + ' kr</p>';

            // lägg till i varukorgen
            $('.modal-body').append(cartItem);
        }
    }

    /* Skicka användaren till kassan vid klick på knapp */
    $('#goToCheckoutButton').click(function () {
        window.location.href = 'checkout.aspx';
    });


    /***********************************
    PRODUKTSIDA
    ***********************************/
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
        //if ($('#cartProduct_' + id).length) {
        //    // Antal
        //    var oldCounter = $('#cartProduct_' + id + ' .productCounter').val();
        //    newCounter = counter * 1 + oldCounter * 1;
        //    $('#cartProduct_' + id + ' .productCounter').val(newCounter);
        //    // Summa
        //    //var oldSum = $('#cartProduct_' + id + ' .productSum').text();
        //    //console.log('#cartProduct_' + id + ' .productSum')
        //    //oldSum = oldSum.replace(',', '.');
        //    //console.log(oldSum * 1)

        //    //var newSum = sum * 1 + oldSum * 1;
        //    //console.log(newSum)
        //    //$('#cartProduct_' + id + ' .productSum').text(newSum);
        //}
        //    // lägg till i varukorgen
        //else {
        // Läs in produktnamn
        var productName = $('#' + id + ' h2').text();

        // Öka varukorg-counter med 1
        $('.itemCount').css('display', 'block');
        var cartCounter = $('header .itemCount').text();
        console.log(cartCounter)
        cartCounter = cartCounter * 1;
        cartCounter++;
        $('.itemCount').text(cartCounter);

        var product = new Product(id, counter, productName, price, sum);
        // skapa array
        var products = [];

        // om det redan finns produkter i varukorgen, hämta dessa och lägg in i arrayen products
        if (sessionStorage.getItem('products')) {
            products = JSON.parse(sessionStorage.getItem('products'));
        }
        // lägg till produkten till arrayen
        products.push(product);
        // spara arrayen med produkter
        sessionStorage.setItem('products', JSON.stringify(products));
        // spara antalet unika produkter i varukorgen
        sessionStorage.setItem('cartCounter', cartCounter);
    });

    // skapa objektet Product
    function Product(id, counter, name, price, sum) {
        this.id = id;
        this.counter = counter;
        this.name = name;
        this.price = price;
        this.sum = sum;
    }

    /***********************************
    KASSA
    ***********************************/
    if ($('#checkoutPage').length > 0) {

        // kolla om det finns några produkter tillagda
        if (sessionStorage.getItem('products')) {
            var products = [];
            productsInCart = sessionStorage.getItem('products');
            products = JSON.parse(sessionStorage.getItem('products'));

            var cartItem = "";
            var totalsum = 0;

            for (var i = 0; i < products.length; i++) {
                cartItem += '<tr id="cartProduct_' + products[i].id + '">';
                cartItem += '<td>' + products[i].name + '</td>';
                cartItem += '<td>' + products[i].price + '</td>';
                cartItem += '<td><input type="number" value="' + products[i].counter + '" /></td>';
                cartItem += '<td>' + products[i].sum + '</td>';
                cartItem += '</tr>';
                totalsum += (products[i].sum * 1);
            }
            // lägg till i kassan
            $('#checkoutTable tbody').append(cartItem);
            $('<p class="totalSum">Totalsumma: ' + totalsum + ' kr</p>').insertAfter('#checkoutTable');
        }

        // kolla om användaren är inloggad
        if (sessionStorage.getItem('userId')) {
            var id = sessionStorage.getItem('userId');
            // hämta användarens uppgifter
            $.getJSON('services/svc-profile.aspx?userId=' + id)
            .done(function (result) {
                $('#customerfirstname').val(result[0].firstname);
                $('#customerlastname').val(result[0].lastname);
                $('#customeremail').val(result[0].email);
            });
            // hämta användarens adress
            $.getJSON('services/svc-getuseraddress.aspx?userId=' + id)
            .done(function (result) {
                if (result.length > 0) {
                    $('#customerstreet').val(result[0].street);
                    $('#customerzip').val(result[0].zip);
                    $('#customercity').val(result[0].city);
                    $('#customercountry').val(result[0].country);
                }
            });
        }
    }

    $('#addAnotherAddress').click(function () {
        $('#otherAddress').slideToggle();
    });
    
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