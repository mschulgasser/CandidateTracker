$(function () {
    $("#toggle").on("click", function () {
        $(".table").find("tr").find("th:eq(4)").toggle();
        $(".table").find("tr").find("td:eq(4)").toggle();
    });
});