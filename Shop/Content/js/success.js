class success {
    constructor() {
        $(document).ready(function () {
            let Carts = [];
            localStorage.setItem('Carts', JSON.stringify(Carts));
            localStorage.setItem('TT', 0);
        });
    }
}
new success();