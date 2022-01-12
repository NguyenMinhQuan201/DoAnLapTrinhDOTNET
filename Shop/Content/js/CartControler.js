
class CartController {

    constructor() {
        this.renderCartsContent();
        this.allPrice();
        $('#icolour').on('change', function () {
            var size = $('#isize').val();
            var colour = $('#icolour').val();
            var Id = $('.button_add_to_cart').data('id');
            $.ajax({
                url: "/Events/onCheck",
                data: { id: Id, mau: colour, kich: size },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == false) {
                        $('.button_add_to_cart').attr("disabled", true);
                        $('.button_add_to_cart').html("Đã hết hàng")
                    }
                    else {
                        $('.button_add_to_cart').attr("disabled", false);
                        $('.button_add_to_cart').html("ADD TO CART")

                    }
                }
            })
        });
        $('#isize').on('change', function () {
            var size = $('#isize').val();
            var colour = $('#icolour').val();
            var Id = $('.button_add_to_cart').data('id');
            $.ajax({
                url: "/Events/onCheck2",
                data: { id: Id, mau: colour, kich: size },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == false) {
                        $('.button_add_to_cart').attr("disabled", true);
                        $('.button_add_to_cart').html("Đã hết hàng")
                    }
                    else {
                        $('.button_add_to_cart').attr("disabled", false);
                        $('.button_add_to_cart').html("ADD TO CART")
                    }
                }
            })
        });
        $('.change-price').on('change', function () {
            
            /*$(`.total-price-${Id}-${Colour}-${Size}`).html(Quanity * response.Price)*/
            var click = $(this);
            var Quanity= click.val();
            var Id= click.data('id');
            let Carts = localStorage.getItem('Carts') ? JSON.parse(localStorage.getItem('Carts')) : [];
            if (Carts.length > 0) {
                for (var i = 0; i < Carts.length; i++) {
                    if (Id == Carts[i].Prime) {
                        Carts[i].SoLuong = Quanity;
                        Carts[i].Tong = Carts[i].SoLuong * Carts[i].Gia
                        $(`.total-price-${Id}`).html(Carts[i].Tong);
                        localStorage.setItem('Carts', JSON.stringify(Carts));
                    }
                }
                var tongtien = 0;
                for (var i = 0; i < Carts.length; i++) {
                    tongtien = tongtien + Carts[i].Tong;
                }
                localStorage.setItem('TT', tongtien)
                localStorage.setItem('Carts', JSON.stringify(Carts));
                let TT = localStorage.getItem('TT')
                $('.total-checkout').html(tongtien)
                localStorage.setItem('Carts', JSON.stringify(Carts));
            }
            
        });
        $('.button_add_to_cart').on('click', function () {
            console.log("ok");
            let Carts = localStorage.getItem('Carts') ? JSON.parse(localStorage.getItem('Carts')) : [];
            var click = $(this);
            var Id = click.data('id');
            var size = $('#isize').val();
            var colour = $('#icolour').val();
            let Temp = [];
            Temp.push({
                Id: Id,
                Colour: colour,
                Size: size,
            });
            $.ajax({
                url: "/Carts/AddCart",
                data: { cartTemp: JSON.stringify(Temp) },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        var a = 0;
                        if (Carts.length > 0) {
                            for (var i = 0; i < Carts.length; i++) {
                                if (Carts[i].Prime == response.Prime) {
                                    Carts[i].SoLuong = Carts[i].SoLuong + 1;
                                    Carts[i].Tong = Carts[i].Tong + Carts[i].Gia;
                                    a = 1;
                                }
                            }
                            if (a == 0) {
                                Carts.push({
                                    Prime: response.Prime,
                                    SoLuong: 1,
                                    Img: response.Img,
                                    Gia: response.Gia,
                                    Name: response.Ten,
                                    Mau: response.Mau,
                                    Kich: response.Kich,
                                    Tong: 0 + response.Gia,
                                });
                            }
                        }
                        else {
                            Carts.push({
                                Prime: response.Prime,
                                SoLuong: 1,
                                Img: response.Img,
                                Gia: response.Gia,
                                Name: response.Ten,
                                Mau: response.Mau,
                                Kich: response.Kich,
                                Tong: 0+response.Gia,
                            });
                        }
                    }
                    localStorage.setItem('Carts', JSON.stringify(Carts));
                    var tongtien = 0;
                    for (var i = 0; i < Carts.length; i++) {
                        tongtien = tongtien + Carts[i].Tong;
                    }
                    localStorage.setItem('TT', tongtien)
                    
                    let TT = localStorage.getItem('TT')
                    $('.total-checkout').html(TT);
                    window.location.href = "/Carts";
                }
            })
            
            
        });
        $('.checkout').off('click').on('click', function () {
            if (localStorage) {
                var cartsDataAsJson = localStorage.getItem("Carts")
                if (cartsDataAsJson) {
                    /**
                     * @type{ {
                     *  Size: string;
                     *  Colour: string;
                     *  Img: string;
                     *  
                     * }[]}
                    * */
                    var Carts = [];
                    var carts = JSON.parse(cartsDataAsJson);
                    var rows = "";
                    for (var i = 0; i < carts.length; i++) {
                        var cart = carts[i];
                        Carts.push(cart);
                    }
                }
                $.ajax({
                    url: "/Carts/PaymentWithPaypal",
                    data: { cartTemp: JSON.stringify(Carts)},
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        if (response.status == true && response.url=="") {
                            window.location.href = "/Home/Index";
                        }
                        if (response.status == true ) {
                            var link = response.url;
                            Carts = [];
                            localStorage.setItem('Carts', JSON.stringify(Carts));
                            localStorage.setItem('TT', 0);
                            /*alert("XONG!");*/
                            /*window.location.href = "";*/
                            location.href = link
                            /*window.location.href = "/Carts";*/
                        }
                        
                        else {
                            window.location.href = "/Carts";
                        }
                    }
                })
            }
        });
        $('.make-order').off('click').on('click', function () {
            if (localStorage) {
                var cartsDataAsJson = localStorage.getItem("Carts")
                var TT = localStorage.getItem('TT')
                $('.all-money').html(TT);
                if (TT > 0) {
                    window.location.href = "/Order/Index";
                }
                else {
                    alert("Gio hang dang ko co gi ! ");
                }
            }
        });
        $('.done').off('click').on('click', function () {
            var AllPrice = $('.all-money').val();
            var AddRess = $('.Address').val();
            var Phone = $('.Phone').val();
            var TT = localStorage.getItem('TT')
            if (AddRess == "") {
                alert("Nhap lai dia chi !");
            }
            else if (Phone == "") {
                alert("Nhap lai so dien thoai !");
            }
            else {
                if (localStorage) {
                    var cartsDataAsJson = localStorage.getItem("Carts")
                    if (cartsDataAsJson) {
                        /**
                         * @type{ {
                         *  Size: string;
                         *  Colour: string;
                         *  Img: string;
                         *  
                         * }[]}
                        * */
                        var Carts = [];
                        var carts = JSON.parse(cartsDataAsJson);
                        var rows = "";
                        for (var i = 0; i < carts.length; i++) {
                            var cart = carts[i];
                            Carts.push(cart);
                        }
                    }
                    $.ajax({
                        url: "/Order/MakeOrder",
                        data: { cartUser: JSON.stringify(Carts), addRess: AddRess, phone: Phone },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.status == true) {
                                Carts = [];
                                localStorage.setItem('Carts', JSON.stringify(Carts));
                                localStorage.setItem('TT', 0);
                                alert("XONG!");
                                window.location.href = "/Events/Index";
                            }
                        }
                    })
                }
            }
        });
        $('.button_remove').off('click').on('click', function () {
            var rows = "";
            var click = $(this);
            var Id = click.data('id');
            let Carts = localStorage.getItem('Carts') ? JSON.parse(localStorage.getItem('Carts')) : [];
            if (Carts.length > 0) {
                for (var i = 0; i < Carts.length; i++) {
                    if (Id == Carts[i].Prime) {
                        var tongtien = localStorage.getItem('TT');
                        let TT = tongtien - Carts[i].Gia;
                        localStorage.setItem('TT', TT)
                        var tmp = Carts[i]
                        Carts[i] = Carts[0]
                        Carts[0] = tmp
                        Carts.splice(0, 1);
                        localStorage.setItem('Carts', JSON.stringify(Carts));
                        if (localStorage) {
                            var cartsDataAsJson = localStorage.getItem("Carts")
                            if (cartsDataAsJson) {
                                /**
                                 * @type{ {
                                 *  Size: string;
                                 *  Colour: string;
                                 *  Img: string;
                                 *  
                                 * }[]}
                                 * */
                                var carts = JSON.parse(cartsDataAsJson);

                                for (var i = 0; i < carts.length; i++) {
                                    var cart = carts[i];
                                    rows += `<tr>
                                        <td class="PRODUCT">
                                            <img style="height: 200px;float: left; margin-top: 5px;" src="/Content/img/${cart.Img}">
                                            <div class="thongtin">
                                                <h3>${cart.Name}</h3>
                                                Size: ${cart.Kich}
                                                <br>
                                                Color: ${cart.Mau}
                                                <br>
                                                <a style="margin-left: 15px; color: pink" class="button_remove" data-id="${cart.Prime}">Remove</a>
                                            </div>
                                        </td>

                                        <td class="PRICE">
                                            <h4>€${cart.Gia}</h4>
                                        </td>
                                        <td class="QUANTITY">
                                            <input class="change-price" data-id="${cart.Prime}" value="${cart.SoLuong}" type="number" min="1" max="10">
                                        </td>

                                        <td class="TOTAL">
                                            €<h4 style="float:right" class="total-price-${cart.Prime}">${cart.Tong}</h4>
                                        </td>
                                    </tr>
                                        `
                                }
                                $('.js__cart-content').html(rows);
                            }
                        }
                    }
                }
            }
            if (Carts.length == 0) {
                $('.total-checkout').html("0");
            }
            if (Carts.length>0) {
                new CartController()
            }
        });
    }

    allPrice() {
        var TT = localStorage.getItem('TT')
        $('.all-money').html(TT);
        $('.total-checkout').html(TT);
    }
    renderCartsContent() {
        if (localStorage) {
            var cartsDataAsJson = localStorage.getItem("Carts")
            if (cartsDataAsJson) {
                /**
                 * @type{ {
                 *  Size: string;
                 *  Colour: string;
                 *  Img: string;
                 *  
                 * }[]}
                 * */
                var carts = JSON.parse(cartsDataAsJson);
                var rows = "";
                for (var i = 0; i < carts.length; i++) {
                    var cart = carts[i];
                    rows += `<tr>
                            <td class="PRODUCT">
                                <img style="height: 200px;float: left; margin-top: 5px;" src="/Content/img/${cart.Img}">
                                <div class="thongtin">
                                    <h3>${cart.Name}</h3>
                                    Size: ${cart.Kich}
                                    <br>
                                    Color: ${cart.Mau}
                                    <br>
                                    <a style="margin-left: 15px; color: pink" class="button_remove" data-id="${cart.Prime}">Remove</a>
                                </div>
                            </td>

                            <td class="PRICE">
                                <h4>€${cart.Gia}</h4>
                            </td>
                            <td class="QUANTITY">
                                <input class="change-price" data-id="${cart.Prime}" value="${cart.SoLuong}" type="number" min="1" max="10">
                            </td>

                            <td class="TOTAL">
                                €<h4 style="float:right" class="total-price-${cart.Prime}">${cart.Tong}</h4>
                            </td>
                        </tr>
`
                }
                $('.js__cart-content').html(rows);
            }
           /* else {
                
                    $('.js__cart-content').html("DJHGSFDUKSFDJSGFJSHGFJKLSGFILS");
                
            }*/
        }
        
    }
}
new CartController();
