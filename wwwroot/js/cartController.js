var cart = {
    init: function () {
        cart.addCoupon();
        cart.removeCoupon();
        cart.changeCoupon();
    },
    addCoupon: function () {
        $("#btn-maKhuyenMai").off('click').on('click', function (e) {
            e.preventDefault();
            const maKm = $('#maKhuyenMai').val();
            const oldTotal = $('#oldTotal').val();
            $.ajax({
                url: '/Cart/AddCoupon',
                type: 'POST',
                data: { maKm: maKm },
                dataType: 'JSON',
                success: function (msg) {
                    if (msg.status == 1) {
                        $('#couponNotification').html('Mã không hợp lệ');
                    }
                    if (msg.status == 2) {
                        const couponVal = (msg.giatri * oldTotal) / 100;
                        $('#coupon').html(couponVal);
                        const total = oldTotal - couponVal;
                        $('#total').html(total);
                        $('#btn-maKhuyenMai').css('display', 'none');
                        $('#detailCoupon').css('display', 'inline');
                        $('#btn-huyMaKhuyenMai').css('display', 'inline');
                        $('#maKhuyenMai').attr("disabled", true);
                        $('#nMaKhuyenMai').val(maKm);
                    }
                }
            });
        });
    },
    removeCoupon: function () {
        $("#btn-huyMaKhuyenMai").off('click').on('click', function (e) {
            e.preventDefault();
            const oldTotal = $('#oldTotal').val();
            $('#maKhuyenMai').val('');

            $.ajax({
                url: '/Cart/RemoveCoupon',
                type: 'POST',
                data: {},
                dataType: 'JSON',
                success: function (msg) {
                    $('#coupon').html(0);
                    $('#total').html(oldTotal);
                    $('#btn-maKhuyenMai').css('display', 'inline');
                    $('#btn-huyMaKhuyenMai').css('display', 'none');
                    $('#maKhuyenMai').attr("disabled", false);
                    $('#detailCoupon').css('display', 'none');
                    $('#nMaKhuyenMai').val('');
                }
            });
        });
    },
    changeCoupon: function () {
        $("#maKhuyenMai").on('keydown', function () {  
            $(this).next().text('');
        });
    }
}
cart.init();