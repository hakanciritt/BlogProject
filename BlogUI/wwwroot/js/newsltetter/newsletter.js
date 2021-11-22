$("#newsLetterPost").click(function (event) {

    var mail = $("#mail").val();
    var message = $("#message");

    event.preventDefault();

    $.ajax({
        type: "POST",
        url: "/NewsLetter/SubscribeMail",
        data: { Mail: mail },
        dataType: "json",
        success: function (data) {
            message.css({ "display": "block" });

            if (data.success) {
                message.html(data.message).css({ "color": "green" });
            } else {
                message.html(data.data.filter(x => x.propertyName == 'Mail')[0].errorMessage).css({ "color": "red" });
            }
        }
    });

});
