// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#card-color').change(function () {
    if ($(this).val() == "Red") {
        $(this).css("backgroundColor", "rgba(204, 0, 0, 0.3)");
    }
    else if ($(this).val() == "Blue") {
        $(this).css("backgroundColor", "rgba(0, 102, 204, 0.3)");
    }
    else if ($(this).val() == "Black") {
        $(this).css("backgroundColor", "rgba(32, 32, 32, 0.3)");
    }
    else if ($(this).val() == "Green") {
        $(this).css("backgroundColor", "rgba(0, 204, 102, 0.3)");
    }
    else if ($(this).val() == "White") {
        $(this).css("backgroundColor", "#e5e5e5");
    }
    else if ($(this).val() == "Colorless") {
        $(this).css("backgroundColor", "rgba(250, 250, 250, 0.3)");
    }
    else if ($(this).val() == "Multicolor") {
        $(this).css("backgroundColor", "rgba(153, 153, 0, 0.3)");
    }
});