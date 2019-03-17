var sepetArray = [];
var toplamFiyat = 0;

$(document).ready(function () {
    $("a#sepeteEkle").on("click", sepeteEkle);
    sepetiYukle();
})

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
        url: "/api/Service/Logout?cookie=" + cookie,
        data: cookie,
        success: function () {
            Cookies.remove('user');
            window.location.href = "/";
        }
    });
});

function sepeteEkle() {
    var id = parseInt($(this).attr('data-id'));
    var sayisi = parseInt($("#menuSayisi[data-id='" + id + "'").val());
    if (sepetArray.length > 0) {
        var sepetteVarMi = false;
        for (var k in sepetArray) {
            if (sepetArray[k][0] == id) {
                sepetteVarMi = true;
                var suankiMiktar = parseInt(sepetArray[k][1]);
                var toplamMiktar = parseInt(suankiMiktar + sayisi);
                if (toplamMiktar > 99) {
                    $.notify("Bu kadar ürün sepete eklenemez!", { className: 'danger', position: 'bottom right' });
                } else {
                    sepetArray[k][1] = toplamMiktar;
                    $.notify("Sepet miktarı güncellendi.", { className: 'success', position: 'bottom right' });
                    sepetiGuncelle(id, sayisi);
                    Cookies.set("cart", JSON.stringify(sepetArray));
                }
                break;
            }
        }

        if (sepetteVarMi == false) {
            sepetArray.push([id, sayisi]);
            $.notify("Sepete eklendi.", { className: 'success', position: 'bottom right' });
            Cookies.set("cart", JSON.stringify(sepetArray));
            sepetiYukle();
        }
    } else {
        sepetArray.push([id,sayisi]);
        $.notify("Sepete eklendi.", { className: 'success', position: 'bottom right' });
        Cookies.set("cart", JSON.stringify(sepetArray));
        sepetiYukle();
    }

}

function sepetiGuncelle(id, sonAdet) {
    for (var k in sepetArray) {
        if (sepetArray[k][0] == id) {
            var sepetUrunID = parseInt(id);
            var sepetAdedi = parseInt(sepetArray[k][1]);
            //  var suankiMiktar = parseFloat($("span.menuFiyati[data-sepetUrunID='" + sepetUrunID + "'").html());
            //   var birimFiyat = parseFloat(suankiMiktar / (sepetAdedi - sonAdet));
            $("span.menuAdedi[data-sepetUrunID='" + sepetUrunID + "'").html(sepetAdedi);
            //  $("span .menuFiyati[data-sepetUrunID='" + sepetUrunID + "'").html((birimFiyat * sepetAdedi).toFixed(2));
            break;
        }
    }
}

function sepetiYukle() {
    var sepettekiler = Cookies.get("cart");
    if (sepettekiler != null) {
        sepetArray = JSON.parse(sepettekiler);
        if (sepetArray.length == 0) {
            $("#sepetim").fadeOut(200);
            $("#sepetMesaji").delay(200).fadeIn(100);
        } else {
            $("#sepetMesaji").fadeOut(200);
            $("#sepetim").delay(200).fadeIn(200);
            $("#sepettekiler").html("");
            for (var k in sepetArray) {
                $.ajax({
                    method: "post",
                    url: "/api/Service/GetMenu",
                    data: {
                        MenuID: sepetArray[k][0],
                        MenuAdedi: sepetArray[k][1]
                    },
                    success: function (data) {
                        $("#sepettekiler").append("<tr><td>" + data.MenuAdi + "</td><td><span class='menuAdedi' data-sepetUrunID='" + data.MenuID + "'>" + data.MenuAdedi + "</span></td></tr>");
                    }
                });
            }
        }

    } else {
        $("#sepetMesaji").fadeIn(200);
    }
}

function anaSepetiYukle() {
    var sepettekiler = Cookies.get("cart");
    if (sepettekiler != null) {
        sepetArray = JSON.parse(sepettekiler);
        if (sepetArray.length == 0) {
            $("#anaSepet").fadeOut(200);
            $("#anaSepetMesaji").delay(200).fadeIn(100);
        } else {
            toplamFiyat = 0;
            $("#anaSepetMesaji").fadeOut(200);
            $("#anaSepet").delay(200).fadeIn(200);
            $("#anaSepettekiler").html("");
            for (var k in sepetArray) {
                $.ajax({
                    method: "post",
                    url: "/api/Service/GetMenu",
                    data: {
                        MenuID: sepetArray[k][0],
                        MenuAdedi: sepetArray[k][1]
                    },
                    success: function (data) {
                        $("#anaSepettekiler").append("<tr style='font-size:14pt;' data-id='" + data.MenuID + "'><td><button href='#' data-urunID='" + data.MenuID + "' onclick='sepettenCikar(" + data.MenuID + ")' class='btn btn-danger btn-sm sepettenCikar'><span class='glyphicon glyphicon-trash'></span></button></td><td>" + data.MenuAdi + "</td><td><button id='miktarAzalt' onclick='miktarAzalt(" + data.MenuID + ")' class='btn btn-default'><span class='glyphicon glyphicon-minus text-danger' ></span></button> <span style='font-size:18pt;margin-left:5px;margin-right:5px;' class='anaMenuAdedi' data-sepetUrunID='" + data.MenuID + "'>" + data.MenuAdedi + "</span> <button class='btn btn-default' id='miktarArtir' onclick='miktarArtir(" + data.MenuID + ")'><span class='glyphicon glyphicon-plus text-success'></span></button></td><td><span class='anaMenuFiyati' data-sepetUrunID='" + data.MenuID + "'>" + data.MenuFiyati.toFixed(2) + "</span> ₺</td></tr>");
                        toplamFiyat = parseFloat(toplamFiyat + data.MenuFiyati);
                        $("#toplamFiyat").html(toplamFiyat.toFixed(2));
                    }
                });
            }
        }

    } else {
        $("#anaSepetMesaji").fadeIn(200);
    }
}

function sepettenCikar(urunID) {
    $("tr[data-id='" + urunID + "']").fadeOut(200);
    var fiyati = parseFloat($("span.anaMenuFiyati[data-sepetUrunID='" + urunID + "']").text());
    for (var k in sepetArray) {
        if (sepetArray[k][0] == urunID) {
            sepetArray.splice(k, 1);
            Cookies.set("cart", JSON.stringify(sepetArray));
            sepetiYukle();
            toplamFiyat = parseFloat(toplamFiyat - fiyati);
            $("#toplamFiyat").html(toplamFiyat.toFixed(2));
            if (sepetArray.length == 0) {
                $("#anaSepet").fadeOut(200);
                $("#anaSepetMesaji").delay(200).fadeIn(100);
            }
            break;
        }
    }
}

function miktarArtir(menuID) {
    var adetText = $("span.anaMenuAdedi[data-sepetUrunID='" + menuID + "']").text();
    var adedi = parseInt(adetText);
    if (adedi < 99) {
        var fiyatText = $("span.anaMenuFiyati[data-sepetUrunID='" + menuID + "']").text();
        var fiyati = parseFloat(fiyatText);
        var birimfiyat = parseFloat(fiyati / adedi);
        toplamFiyat = parseFloat(toplamFiyat + birimfiyat);
        $("#toplamFiyat").html(toplamFiyat.toFixed(2));
        $("span.anaMenuFiyati[data-sepetUrunID='" + menuID + "']").html((fiyati + birimfiyat).toFixed(2));
        $("span.anaMenuAdedi[data-sepetUrunID='" + menuID + "']").html(adedi + 1);
        for (var k in sepetArray) {
            if (sepetArray[k][0] == menuID) {
                sepetArray[k][1] = (adedi + 1);
                Cookies.set("cart", JSON.stringify(sepetArray));
                sepetiGuncelle(menuID, (adedi + 1));
                break;
            }
        }
    }
}

function miktarAzalt(menuID) {
    var adetText = $("span.anaMenuAdedi[data-sepetUrunID='" + menuID + "']").text();
    var adedi = parseInt(adetText);
    if (adedi > 1) {
        var fiyatText = $("span.anaMenuFiyati[data-sepetUrunID='" + menuID + "']").text();
        var fiyati = parseFloat(fiyatText);
        var birimfiyat = parseFloat(fiyati / adedi);
        toplamFiyat = parseFloat(toplamFiyat - birimfiyat);
        $("#toplamFiyat").html(toplamFiyat.toFixed(2));
        $("span.anaMenuFiyati[data-sepetUrunID='" + menuID + "']").html((fiyati - birimfiyat).toFixed(2));
        $("span.anaMenuAdedi[data-sepetUrunID='" + menuID + "']").html(adedi - 1);
        for (var k in sepetArray) {
            if (sepetArray[k][0] == menuID) {
                sepetArray[k][1] = (adedi - 1);
                Cookies.set("cart", JSON.stringify(sepetArray));
                sepetiGuncelle(menuID, (adedi - 1));
                break;
            }
        }
    }
}

$("#sepetiOnayla").click(function () {
    var cookie = Cookies.get("user");
    if (cookie != null) {
        if (sepetArray.length != 0) {
            var orderArray = JSON.stringify(sepetArray);
            $.ajax({
                method: "post",
                url: "/api/Service/ConfirmOrder",
                dataType: "json",
                data: {
                    Cookie: cookie,
                    OrderArray: orderArray
                },
                success: function (result) {
                    alert("success!: " + result);
                }
            });
        }
    } else {
        $.notify("Siparişi tamamlamak için giriş yapınız!", { className: 'danger', position: 'bottom right' });
    }
});