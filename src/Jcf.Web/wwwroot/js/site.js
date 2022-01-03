$(".link_logout_menu_top").on("click", function () {
    console.log("logout");
    $(".form_logout_menu_top").submit();
});

$('.mask_cpf').mask('000.000.000-00');

$('.datepicker-data-simple').datepicker({
    format: 'dd/mm/yyyy',
    language: 'pt-BR',
    todayBtn: 'linked',
    todayHighlight: true,
});

var SPMaskBehavior = function (val) {
    return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
},
    spOptions = {
        onKeyPress: function (val, e, field, options) {
            field.mask(SPMaskBehavior.apply({}, arguments), options);
        }
    };
$('.mask_telefone').mask(SPMaskBehavior, spOptions);

$(".Select-Estatos").select2();

$(".mask-cep").mask("99.999-999");

$(".mask-data").mask("99/99/9999");