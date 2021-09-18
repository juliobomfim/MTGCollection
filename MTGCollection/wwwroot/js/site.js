// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var ptd;
var name;

$('.dialogCallButtom').click(function () {
    ptd = LimparDados($(this).data('path'));
    name = $(this).data('id');
    $('#card-name-modal').text(name);
});

$('#dialogConfirmButtom').click(function () {
    if (ptd.includes("Delete")) {
        var req = ptd.split('/');
        var controller = LimparDados(req[0]);
        var id = LimparDados(req[2]);
        $.post(controller + '/Delete/', { id: id }, setTimeout(function () {location.reload()}, 1000));
    }
});

$('a[data-toggle="tooltip"]').tooltip({
    placement: 'bottom',
    html: true
});

$('#card-color').change(function () {
    var selectItem = $(this).children("option:selected").val(); 
    switch (selectItem) {
        case '0':
            $(this).css("backgroundColor", "rgba(204, 0, 0, 0.3)");
            $(this).css("color", "white");
            break;
        case '1':
            $(this).css("backgroundColor", "rgba(0, 102, 204, 0.3)");
            $(this).css("color", "white");
            break;
        case '2':
            $(this).css("backgroundColor", "rgba(32, 32, 32, 0.3)");
            $(this).css("color", "white");
            break;
        case '3':
            $(this).css("backgroundColor", "rgba(0, 204, 102, 0.3)");
            $(this).css("color", "white");
            break;
        case '4':
            $(this).css("backgroundColor", "#e5e5e5");
            $(this).css("color", "black");
            break;
        case '5':
            $(this).css("backgroundColor", "rgba(250, 250, 250, 0.3)");
            $(this).css("color", "black");
            break;
        case '6':
            $(this).css("backgroundColor", "rgba(153, 153, 0, 0.3)");
            $(this).css("color", "black");
            break;
    }
});

function LimparDados(path) {
    path.replace('{', '').replace('}', '').replace('"', '').replace('/', '').replace('$', '');
    return path;
}