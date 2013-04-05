// Some general UI pack related JS

$(function () {
    // Custom selects
    $("select").dropkick();
});

$(document).ready(function() {
    // Todo list
    $(".todo li").click(function() {
        $(this).toggleClass("todo-done");
    });

    // Init tooltips
    $("[data-toggle=tooltip]").tooltip("show");

    // Init tags input
    $("#tagsinput").tagsInput();

    // Init jQuery UI slider
    $("#slider").slider({
        min: 1,
        max: 5,
        value: 2,
        orientation: "horizontal",
        range: "min",
    });

    // JS input/textarea placeholder
    $("input, textarea").placeholder();

    // Make pagination demo work
    $(".pagination a").click(function() {
        if (!$(this).parent().hasClass("previous") && !$(this).parent().hasClass("next")) {
            $(this).parent().siblings("li").removeClass("active");
            $(this).parent().addClass("active");
        }
    });

    $(".btn-group a").click(function() {
        $(this).siblings().removeClass("active");
        $(this).addClass("active");
    });

    // Disable link click not scroll top
    $("a[href='#']").click(function() {
        return false
    });

});

CreateApp = function () {
    var self = {
        startMonitoring: function () {
            $.get('/sysmon/check', function (data) {
                $("#cpu-load span").text(data.cpuLoad + "%");
                $("#cpu-load .progress .bar").css("width", data.cpuLoad + "%");
                $("#memory-load span").text(data.memoryLoad + "%");
                $("#memory-load .progress .bar").css("width", data.memoryLoad + "%");
                setTimeout(self.startMonitoring, 1000);
            });
        }
    };

    return self;
};

var app = CreateApp();

