//Basic
function sa_basic(msg) {
    swal(msg);
}

//A title with a text under
function sa_title(title, msg) {
    swal(msg, title)
}

//Success Message
function sa_success(title, msg) {
    swal({
        title: title,
        text: msg,
        type: "success",
        showCancelButton: false,
        closeOnConfirm: false,
        button: "Tamam",
        icon: "success"
    });
}

//Success Message
function sa_error(title, msg) {
    swal({
        title: title,
        text: msg,
        type: "error",
        button: "Tamam",
        showCancelButton: false,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Tamam",
        closeOnConfirm: false,
        icon: "error",
    });
}

//Info Message
function sa_info(title, msg) {
    swal({
        title: title,
        text: msg,
        type: "info",
        button: "Tamam",
        showCancelButton: false,
        confirmButtonText: "Tamam",
        closeOnConfirm: false,
        icon: "info",
    });
}



//Warning Message
function sa_warning(msg, title) {
    swal({
        title: title,
        text: msg,
        type: "warning",
        button: "Tamam",
        showCancelButton: false,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Tamam",
        closeOnConfirm: false
    });
}

//Parameter
$('#sa-params').click(function () {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel plx!",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            swal("Deleted!", "Your imaginary file has been deleted.", "success");
        } else {
            swal("Cancelled", "Your imaginary file is safe :)", "error");
        }
    });
});

//Custom Image
$('#sa-image').click(function () {
    swal({
        title: "Govinda!",
        text: "Recently joined twitter",
        imageUrl: "../plugins/images/users/govinda.jpg"
    });
});

//Auto Close Timer
function sa_close(msg, title, timer = 2000) {
    swal({
        title: title,
        text: msg,
        timer: timer,
        showConfirmButton: false
    });
}

// swal confirm
function sa_delete_confirm(title = "Emin misiniz?", msg = "Silindikten sonra bu dosyayý kurtaramayacaksýnýz!") {
    swal({
        title: title,
        text: msg,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            sa_success("Ýþlem Baþarýlý", "Dosyanýz silindi!");
        } else {
            swal("Your imaginary file is safe!");
        }
    });
}