var home = {
    init: function () {
        home.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            const masp = $(this).data('id'); 
            $.ajax({
                url: '/Home/AddFavorProduct',
                type: 'POST',
                data: { maSp: masp },
                dataType: 'JSON',
                success: function (msg) {
                    alert(msg.status);
                }
            });
        });
    }
}
home.init();