$("#btnRegister").click(function (e) {
    $("#loginForm").fadeOut(200);
    $("#registerForm").delay(200).fadeIn(200);
    $("#userPanelTitle").text("Kayıt Ekranı");
    e.preventDefault();
    $(this).hide();
    $("#btnLogin").show();
});

$("#btnLogin").click(function (e) {
    $("#registerForm").fadeOut(200);
    $("#loginForm").delay(200).fadeIn(200);
    $("#userPanelTitle").text("Giriş Ekranı");
    e.preventDefault();
    $(this).hide();
    $("#btnRegister").show();
});


$("#loginButton").click(function () {
    var email = $("#email").val();
    var pwd = $("#password").val();
    //TODO: Bu değerler boş mu kontrol edilecek!
    $.ajax({
        method: "post",
        url: "/api/Service/Login",
        data: {
            Email: email,
            Password: pwd
        },
        dataType: "json",
        success: function (cookie) {
            Cookies.set('user', cookie, { expires: 7 });
            window.location.href = "/";
        },
        error: function (xhr) {
            $("#message").hide();
            $("#message").fadeIn(300);
            $("#message").html('<div class="alert alert-danger">' + xhr.responseJSON.Message + '</div>');
        }
    });
});

$("#registerButton").click(function () {
    var email = $("#remail").val();
    var pwd = $("#rpassword").val();
    var name = $("#name").val();
    var surname = $("#surname").val();
    var phone = $("#phone").val();
    //TODO: Bu değerler boş mu kontrol edilecek!
    $.ajax({
        method: "post",
        url: "/api/Service/Register",
        data: {
            FirstName: name,
            LastName: surname,
            Email: email,
            Password: pwd,
            Phone: phone
        },
        dataType: "json",
        success: function (cookie) {
            Cookies.set('user', cookie, { expires: 7 });
            window.location.href = "/";
        },
        error: function (xhr) {
            var message = xhr.responseJSON.Message;
            $("#message").hide();
            $("#message").fadeIn(300);
            $("#message").html('<div class="alert alert-danger">' + message + '</div>');
        }
    });
});


$("#btnLogout").click(function () {
    var cookie = Cookies.get("user");
    $.ajax({
        method: "post",
        url: "/api/Service/Logout?cookie="+cookie,
        data: cookie,
        success: function () {
            Cookies.remove('user');
            window.location.href = "/";
        }
    });
});