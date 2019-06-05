
function showalert(message, type, time, redirect, trediret) {
    var tr = trediret;
    if (time == 0)
        time = 2000000;

    var t = type;
    var icon;
    if (t == 1) {
        type = '"alert alert-success  alert-dismissible"';
        icon = '"fa fa-check-circle fa-2x"';
    }
    else if (t == 2) {
        type = '"alert alert-danger  alert-dismissible"';
        icon = '"fa fa-warning fa-2x"';
    }
    else if (t == 3) {
        type = '"alert alert-warning  alert-dismissible"';
        icon = '"fa fa-warning fa-2x"';
    }
    else if (t == 4) {
        type = '"alert alert-info  alert-dismissible"';
        icon = '"fa fa-info-circle fa-2x"';
    }

    $('#alert_placeholder').html
        ('<div class=' + type + '><i class=' + icon + '></i><span>' + message + '</span><a class="close" data-dismiss="alert">×</a></div>');
    $("#alert_placeholder").hide().show('medium');
    $("#alert_placeholder").fadeTo(time, 600).slideUp(600, function () {
        $("#alert_placeholder").slideUp(5000);

        if (tr == 1) {
            window.location.href = redirect;
        }
    });

};
