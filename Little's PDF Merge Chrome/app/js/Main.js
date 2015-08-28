//<![CDATA[
$(function () {
    $('#addbtn').on('click', function () {
        $('#file').trigger('click');
    });
    $('#closebtn').on('click', function () {
        window.close();
    });
    $('#minbtn').on('click', function () {
        chrome.app.window.current().minimize();
    });

    $('#maxbtn').on('click', function () {
        chrome.app.window.current().maximize();
    });
});//]]>
