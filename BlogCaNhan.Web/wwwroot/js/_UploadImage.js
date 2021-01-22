//Hiển thị ảnh review
$("#AnhBia").change((e) => {
    var avt = e.target.parentElement;
    var data = new FileReader();
    var text = "Chọn một bức ảnh";
    if (e.target.files[0]) {
        data.readAsDataURL(e.target.files[0]);
        data.onload = (ev) => {
            avt.style.backgroundImage = "url('" + ev.target.result + "')";
        }
        avt.firstElementChild.innerText = "";
    }
    else {
        avt.style.backgroundImage = "";
        avt.firstElementChild.innerText = text;
    }
});

$(document).ready(function () {
    if ($('.avatar').attr('style')) {
        $('.avatar>span').text('');
    }
});

$(".custom-file-input").change(function (ev) {
    var files = ev.currentTarget.files;
    var fileName = '';
    if (files && files[0]) {
        fileName = ev.target.value.split(/\\|\//).pop();
        if (fileName.length > 25) {
            fileName = fileName.substr(0, 9) + '...' + fileName.substr(fileName.length - 13);
        }
    }
    if (fileName) {
        $(this).next().text(fileName);
    }
    else $(this).next().text("Chọn file...");
});

function updateFileName() {
    var fileNames = $(".custom-file-label");
    fileNames.each(function (index, ele) {
        let fileName = $(ele).text();
        if (fileName.length > 35) {
            fileName = fileName.substr(0, 20) + '...' + fileName.substr(fileName.length - 12);
            $(ele).text(fileName);
        }
    });
}