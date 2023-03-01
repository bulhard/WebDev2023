// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$().ready(function () {
    $("#theForm").validate({
        rules: {
            FirstName: {
                required: true
            },
            LastName: {
                required: true
            },
            EMail: {
                required: true
            },
            Country: {
                required: true
            }
        }
    });
});

function SubmitForm() {
    debugger;

    $("#theForm").valid();

    // $("#theForm").ajaxSubmit({ url: "/Home/Index", type: 'get' });

    // debugger;

    let url = "/Home/Index";
    let params = $("#theForm").serialize();

    //$.get(url + "?" + params);

    $.post(url, params)
        .done(function (data) {
            console.log(data);
        })
        .fail(function () {
            console.log("error");
        })
        .always(function () {
            console.log("finished");
        });
}