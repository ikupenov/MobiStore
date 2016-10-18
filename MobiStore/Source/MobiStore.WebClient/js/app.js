$(function () {
    $(".fakeFile").each(function () {
        let $this = $(this),
            $browse = $this.children(".browse"),
            $file = $this.prev("input");

        $this.bind({
            click: () => $file.trigger("click"),
            mousedown: () => $browse.addClass("active"),
            mouseup: () => $browse.removeClass("active"),
            mouseover: () => $browse.addClass("hover"),
            mouseout: () => $browse.removeClass("hover active")
        });

        $file.change(function () {
            $this.children(".text").text($(this).val());
        });
    });

    let handleFileSelect = function (ev) {
        let filePicker = $(ev.target).parent().find("input#filePicker")[0];
        let files = filePicker.files;
        let file = files[0];

        if (files && file) {
            let reader = new FileReader();

            reader.onload = function (readerEv) {
                let binaryString = readerEv.target.result,
                    url = 'http://localhost:13444/api/file', // every user may have different port
                    headers = {
                        'Content-Type': 'application/json'
                    },
                    data = {
                        Content: btoa(binaryString)
                    };

                requester
                    .post(url, headers, data)
                    .then(response => console.log(response));
            };

            reader.readAsBinaryString(file);
        }
    };

    if (window.File && window.FileReader && window.FileList && window.Blob) {
        $('.upload').on('click', handleFileSelect);
    } else {
        alert('The File APIs are not fully supported by this browser.');
    }
});