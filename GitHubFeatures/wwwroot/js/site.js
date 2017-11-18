
$('#githubinfo_submit').click(function () {
    var token = $('input[name="__RequestVerificationToken"]', $('#githubinfo_form')).val();
    var dataToSend = {
        userName: $('#users_name').val(),
        repositoryName: $('#repo_name').val(),
        requestType: $("#request_type").val()
    };

    var dataWithAntiforgeryToken = $.extend(dataToSend, { '__RequestVerificationToken': token });

    $.ajax({
        url: "/Home/CheckRepository",
        type: "POST",
        data: dataWithAntiforgeryToken,
        success: function (data) {
            $("#result_window_pl").html(data);
            $("#result_window").modal('show');
        }
    });
});
