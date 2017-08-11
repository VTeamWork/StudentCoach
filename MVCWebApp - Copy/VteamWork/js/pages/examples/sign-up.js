$(function () {
    $('#sign_up').validate({
        rules: {
            'terms': {
                required: true
            },
            'ctl00$LoginFormPlaceHolder$confirm': {
                equalTo: '[name="ctl00$LoginFormPlaceHolder$PASSWORD"]'
            }
        },
        highlight: function (input) {
            console.log(input);
            $(input).parents('.form-line').addClass('error');
        },
        unhighlight: function (input) {
            $(input).parents('.form-line').removeClass('error');
        },
        errorPlacement: function (error, element) {
            $(element).parents('.input-group').append(error);
            $(element).parents('.form-group').append(error);
        }
    });
});