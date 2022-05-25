class token {
    constructor() {
        this.renderToken();
    }
    renderToken() {
        $('#lay_token').on('click', function () {
            console.log("heheheheh");
            var user = $('#tk').val();
            var pass = $('#mk').val();
            console.log(user);
            console.log(pass);
            $.ajax({
                url: "https://localhost:44314/token",
                data: {
                    UserName: user,
                    Password: pass,
                    grant_type: 'password'
                },
                contentType: "application/json",
                type: "POST",
                success: function (response) {
                    console.log(response.access_token);
                    if (response.error_description == null) {
                        localStorage.setItem('token', response.access_token)
                        var key = localStorage.getItem('token')
                        console.log("2");
                        $.ajax({
                            url: "/Admin/Gettoken",
                            data: {
                                token: response.access_token
                            },
                            dataType: "json",
                            type: "GET",
                            success: function (response2) {
                                console.log(response2.status);
                                window.location.href = "/Home/Index"
                            }
                        })
                    }
                    else {
                        
                    }
                }
            })
        });
    }
}
new token();