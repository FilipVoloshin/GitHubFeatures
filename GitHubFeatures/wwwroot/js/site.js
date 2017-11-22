
$('#githubinfo_submit').click(function () {
    var requestType = $("#request_type").val();
    var token = $('input[name="__RequestVerificationToken"]', $('#githubinfo_form')).val();
    var dataToSend = {
        userName: $('#users_name').val(),
        repositoryName: $('#repo_name').val(),
        request: requestType
    };

    var dataWithAntiforgeryToken = $.extend(dataToSend, { '__RequestVerificationToken': token });
    var url = "";
    switch (requestType) {
        case "0":
            url = "/Home/CheckRepository";
            break;
        case "1":
            url = "/Home/CheckPullRequests";
            break;
        case "2":
            url = "/Home/CheckBranches";
            break;
    }
    $.ajax({
        url: url,
        type: "POST",
        data: dataWithAntiforgeryToken,
        success: function (data) {
            $("#result_window_pl").html(data);
            $("#result_window").modal('show');
        }
    });
});
