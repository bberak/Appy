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

