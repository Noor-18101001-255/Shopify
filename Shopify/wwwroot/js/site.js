

function GetPopup(url,Mode) {
    //alert("fun")
    $.get(url, function (data) {
        $("#PopupContent").html(data);

        $("#ModalHeading").text(Mode);
        $("#PopupModal").modal("show");
    });
}