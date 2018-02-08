$(function () {
    var text = $('#text');
    var result = $('#result');

    var sample = $('#sample-btn');
    var preview = $('#preview-btn');

    sample.on('click', function () {
        $.ajax({
            method: "POST",
            url: "/api/Generator/GetSample",
            data: JSON.stringify({ Text: text.val() }),
            json: true,
            'contentType': 'application/json',
            'processData': false,
            success: function (data) {
                result.val(data.Text);
            }
        })
    });
    preview.on('click', function () {
        $.ajax({
            method: "POST",
            url: "/api/Generator/GetSample/10",
            data: JSON.stringify({ Text: text.val() }),
            json: true,
            'contentType': 'application/json',
            'processData': false,
            success: function (data) {

                var content = data.map(t => t.Text).join("\r\n-------------------\r\n");

                result.val(content);
            }
        })
    })

})