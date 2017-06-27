$(function () {
    $(".reject").on('click', function () {
        var button = $(this);
        var params = {
            id: button.data("id"),
            status: 2
        }
        $.post("/home/updatestatus", params, function (data) {
            $(".btn").hide();
            $("#status").text("Rejected");
            updateNavbar(data);
        });
    });
    $(".accept").on('click', function () {

        var button = $(this);
        var params = {
            id: button.data("id"),
            status: 1
        }
        $.post("/home/updatestatus", params, function (data) {
            $(".btn").hide();
            $("#status").text("Accepted");
            updateNavbar(data);
        });
    });
    function updateNavbar(data) {
        $("#pending").text("Pending (" + data.pending + ")");
        $("#accepted").text("Accepted (" + data.accepted + ")");
        $("#rejected").text("Rejected (" + data.rejected + ")");
    }
});
