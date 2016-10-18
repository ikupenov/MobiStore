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

    function getFileExtension(fileUrl) {
        let fileUrlSplit = fileUrl.split('.'),
            fileExtension = fileUrlSplit[1];

        return fileExtension;
    }

    let handleFileSelect = function (ev) {
        let $target = $(ev.target);

        let filePicker = $target.parent().find('input#filePicker')[0],
            files = filePicker.files,
            file = files[0];

        if (files && file) {
            let reader = new FileReader();

            reader.onload = function (readerEv) {
                let binaryString = readerEv.target.result;

                let fileUrl = $target.parent().find('.text').text(),
                    fileExtension = getFileExtension(fileUrl);

                const portNumber = '13444';
                let url = `http://localhost:${portNumber}/api/file`,
                    headers = {
                        'Content-Type': 'application/json'
                    },
                    fileData = {
                        Content: btoa(binaryString),
                        Extension: fileExtension
                    };

                requester
                    .post(url, headers, fileData)
                    .then(response => console.log(response), error => console.log(error));
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