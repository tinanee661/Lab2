$(document).ready(function () {
    $('li.active').removeClass('active');
    $('a[href="' + location.pathname + '"]').closest('li').addClass('active');
});


$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#myTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

$("#create-form").submit(function (e) {
    e.preventDefault();
    console.log("testtt");
    let name = document.getElementById("fname").value;
    let lastname = document.getElementById("lname").value;
    let subject = document.getElementById("subject").value;
    let message = document.getElementById("Message").value;
    let user = "56ec1cf8-76bd-44a1-b3b1-f659710eac59";
    var form = $('#create-form');
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    let data = {
        name,
        lastname,
        subject,
        message,
        user,
        __RequestVerificationToken: token
    };

    $.ajax({
        type: "POST",
        url: e.currentTarget.action,
        data: data,
        success: (e => {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'We will reply to you as soon as we can',
                showConfirmButton: false,
                timer: 1500,

            }).then(function () {
                location.reload();
            });
        }),

    })
});

