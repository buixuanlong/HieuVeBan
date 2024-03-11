
function formObj2Json(formArray) { //serialize data function
    var returnArray = {};
    for (var i = 0, len = formArray.length; i < len; i++)
        returnArray[formArray[i].name] = formArray[i].value;
    return returnArray;
}

function swalInfo(info, useHtml, time, title, callback) {
    time = (typeof time !== 'undefined' && time !== null) ? time : 5000;
    useHtml = typeof useHtml !== 'undefined' ? useHtml : false;
    title = !!title ? title : "Thông tin!"
    if (useHtml) swal({
        type: 'info',
        title: title,
        allowOutsideClick: true,
        html: info,
        timer: time
    });
    else swal({
        type: 'info',
        title: 'Thông tin!',
        allowOutsideClick: true,
        text: info,
        timer: time
    });
    if (callback !== undefined) {
        option['onClose'] = callback;
    }
}

function swalSuccess(time, callback, title) {
    time = (typeof time != 'undefined' && time != null) ? time : 5000;
    title = '<p class="sweetalert2-success-title">' + (title || 'Update success') + '</p>';
    var option = {
        type: 'success',
        title: title,
        allowOutsideClick: true,
        timer: time,
        confirmButtonText: 'Xác nhận',
        confirmButtonColor: '#3085d6',
        confirmButtonClass: 'btn btn-success btn-yes-warning',
        buttonsStyling: false,
        reverseButtons: true
    };
    if (callback !== undefined) {
        option['onClose'] = callback;
    }
    swal(option);
}

function swalWarning(title, time, callback) {
    time = (typeof time != 'undefined' && time != null) ? time : 5000;
    title = '<p class="sweetalert2-success-title">' + title + '</p>';
    var option = {
        type: 'warning',
        title: title,
        allowOutsideClick: true,
        timer: time,
        confirmButtonText: 'Xác nhận',
        confirmButtonColor: '#3085d6',
        confirmButtonClass: 'btn btn-success btn-yes-warning',
        buttonsStyling: false
    };
    if (callback !== undefined) {
        option['onClose'] = callback;
    }
    swal(option);
}

function swalError(title, time) {
    time = (typeof time != 'undefined' && time != null) ? time : 5000;
    swal({
        type: 'error',
        title: title,
        allowOutsideClick: true,
        timer: time,
        confirmButtonColor: '#3085d6',
        confirmButtonClass: 'btn btn-success btn-yes-warning',
        buttonsStyling: false,
        reverseButtons: true
    });
}

function swalComfirm(input, callback) {
    swal({
        title: input.title,
        text: input.content,
        type: 'warning',
        showCancelButton: true,
        cancelButtonColor: '#d33',
        confirmButtonColor: '#3085d6',
        cancelButtonText: input.no,
        confirmButtonText: input.yes,
        cancelButtonClass: 'btn btn-danger btn-no',
        confirmButtonClass: 'btn btn-success btn-yes',
        buttonsStyling: false,
        reverseButtons: true
    }).then(function (result) {
        callback(true);
    }, function (dismiss) {
       callback(false);
    });
}

function showLoading(title) {
    title = !!title ? title : 'Đang xử lý...!';
    $('#progress_status').text(title);
    $('#spinner_layout').removeClass('hidden');
}

function hideLoading() {
    $('#progress_status').text('Đang xử lý...!');
    $('#spinner_layout').addClass('hidden');
}



