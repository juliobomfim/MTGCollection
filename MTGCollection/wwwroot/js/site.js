﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var ptd;
var name;

$('.dialogCallButtom').click(function () {
    ptd = $(this).data('path').replace('"','').replace('$','');
    name = $(this).data('id');
    $('#card-name-modal').text(name);
});

$('#dialogConfirmButtom').click(function () {
    if (ptd.includes("Delete")) {
        var req = ptd.split('/');
        var controller = req[0].replace('{', '').replace('}', '').replace('"', '');
        var id = req[2].replace('{', '').replace('}', '').replace('"', '').replace('/', '');
        $.post(controller + '/Delete/', { id: id });
        location.reload();
    }
});

$('a[data-toggle="tooltip"]').tooltip({
    placement: 'bottom',
    html: true
});

$('#card-color').change(function () {
    var selectItem = $(this).children("option:selected").val(); 
    switch (selectItem) {
        case 'Red':
            $(this).css("backgroundColor", "rgba(204, 0, 0, 0.3)");
            $(this).css("color", "white");
            break;
        case 'Blue':
            $(this).css("backgroundColor", "rgba(0, 102, 204, 0.3)");
            $(this).css("color", "white");
            break;
        case 'Black':
            $(this).css("backgroundColor", "rgba(32, 32, 32, 0.3)");
            $(this).css("color", "white");
            break;
        case 'Green':
            $(this).css("backgroundColor", "rgba(0, 204, 102, 0.3)");
            $(this).css("color", "white");
            break;
        case 'White':
            $(this).css("backgroundColor", "#e5e5e5");
            $(this).css("color", "black");
            break;
        case 'Colorless':
            $(this).css("backgroundColor", "rgba(250, 250, 250, 0.3)");
            $(this).css("color", "black");
            break;
        case 'Multicolor':
            $(this).css("backgroundColor", "rgba(153, 153, 0, 0.3)");
            $(this).css("color", "black");
            break;
    }
});