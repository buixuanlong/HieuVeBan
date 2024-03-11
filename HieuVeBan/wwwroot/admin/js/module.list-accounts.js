/*
 * Author: buixuanlong1004
 * Create: 13/09/2022
 * LIST ACCOUNTS
 */

var table;
var listAccountsPlugin = (function () {
    return {
        init: function () {
            this.eventListener();
        },
        token: function () {
            return $('input[name=__RequestVerificationToken]').val();
        },
        eventListener: function () {
            var self = this, isUpdate = false;
            listAccountsPlugin.loadData();
            $(document).off('click', '.info-account');
            $(document).on('click', '.info-account', function () {
                var accountUid = +$(this).parent().find('.account-uid').val();
                listAccountsPlugin.detailAccount(accountUid);
            });

            //add new account
            $(document).off('click', '#btn_add_new_account');
            $(document).on('click', '#btn_add_new_account', function () {
                $('#add_new_title').text(`Thêm tài khoản mới`);
                isUpdate = false;
                $('#add_new_account_fr')[0].reset();
                $('#btn_add_update').text('Thêm mới');
                $('#maquanly').attr('readonly', false);
                $('#fullname').attr('readonly', false);
                $('#email').attr('readonly', false);
                $('#donvi').attr('readonly', false);
                $('#add_new_account').modal('show');
            });

            //Submit create new account
            $(document).off('submit', '#add_new_account_fr');
            $(document).on('submit', '#add_new_account_fr', function (e) {
                e.preventDefault();
                var dataSubmition = {
                    maQuanLy: $('#maquanly').val(),
                    hoTen: $('#fullname').val(),
                    email: $('#email').val(),
                    uid: $('#uid').val(),
                    donVi: $('#donvi').val(),
                    role: $('#role').val()
                }
                if (isUpdate) {
                    listAccountsPlugin.updateAccount(dataSubmition);
                }
                else {
                    listAccountsPlugin.createNewAccount(dataSubmition);
                }
            });

            //edit user
            $(document).off('click', '.edit-account');
            $(document).on('click', '.edit-account', function () {
                isUpdate = true;
                var maQuanLy = $(this).parent().find('.account-ma-quan-ly').val(),
                    hoTen = $(this).parent().find('.account-ho-ten').val(),
                    email = $(this).parent().find('.account-email').val(),
                    donVi = $(this).parent().find('.account-don-vi').val(),
                    uid = $(this).parent().find('.account-uid').val(),
                    role = $(this).parent().find('.account-role').val();
                $('#btn_add_update').text('Cập nhật');
                $('#add_new_account_fr')[0].reset();
                $('#add_new_title').text('Cập nhật tài khoản');
                $('#maquanly').attr('readonly', true);
                $('#fullname').attr('readonly', true);
                $('#email').attr('readonly', true);
                $('#donvi').attr('readonly', true);
                $('#maquanly').val(maQuanLy);
                $('#fullname').val(hoTen);
                $('#email').val(email);
                $('#uid').val(uid);
                $('#donvi').val(donVi);
                $("#role").val(role).change();
                $('#add_new_account').modal('show');
            });

            //delete account
            $(document).off('click', '.delete-account');
            $(document).on('click', '.delete-account', function () {
                var uid = +$(this).parent().find('.account-uid').val();
                swalComfirm({
                    title: "Xóa tài khoản",
                    content: "Bạn muốn xóa tài khoản này?",
                    yes: "Đồng ý",
                    no: "Hủy"
                }, function (result) {
                    if (result) {
                        listAccountsPlugin.deleteAccount(uid);
                    }
                });
            });
        },
        loadData: function () {
            //showLoading('Đang tải dữ liệu');
            table = $('#account_table').on('init.dt', function () {
                //hideLoading();
            }).DataTable({
                responsive: true,
                ordering: true,
                order: [[0, 'desc']],
                aaSorting: [[4, 'desc']],
                pageLength: 10,
                processing: true,
                deferRender: true,
                oLanguage: {
                    sLengthMenu: 'Xem _MENU_ dòng trên một trang',
                    sProcessing: 'Đang tải dữ liệu...<br/><i class="fa fa-refresh fa-spin"></i>',
                    sEmptyTable: 'Không có dữ liệu!',
                    sSearch: '<span>Tìm kiếm:</span> _INPUT_',
                    sInfo: 'Đang xem từ _START_ tới _END_ trong tổng số _TOTAL_ hàng',
                    sInfoEmpty: 'Không có dữ liệu',
                    sInfoFiltered: '(Lọc từ _MAX_ bản ghi)',
                    sZeroRecords: 'Đang tải dữ liệu...',
                    oPaginate: {
                        sPrevious: 'Trang trước',
                        sNext: 'Trang sau',
                        sFirst: 'Trang đầu',
                        sLast: 'Trang cuối'
                    }
                },
                serverSide: true,
                searching: true,
                lengthMenu: [[10, 100, 1000, -1], [10, 100, 1000, 'Tất cả']],
                ajax: {
                    url: '/admin/tai-khoan/load-data',
                    type: 'POST',
                    datatype: 'json',
                    data: function (d) {
                        d.__RequestVerificationToken = listAccountsPlugin.token()
                    }
                },
                columns: [
                    { name: 'Uid', data: 'uid', orderable: true },
                    { name: 'MaQuanLy', data: 'maQuanLy', orderable: true },
                    { name: 'HoTen', data: 'hoTen', orderable: true },
                    { name: 'Email', data: 'email', orderable: true },
                    { name: 'DonVi', data: 'donVi', orderable: true },
                    { name: 'Role', data: 'role', orderable: true },
                    {
                        data: 'uid',
                        searchable: false,
                        autoWidth: true,
                        sortable: false,
                        render: function (data, type, row) {
                            return '<div class="row justify-content-center">\
                                    <input class="account-uid" type="hidden" value="' + row.uid + '">\
                                    <input class="account-ma-quan-ly" type="hidden" value="' + row.maQuanLy + '">\
                                    <input class="account-ho-ten" type="hidden" value="' + row.hoTen + '">\
                                    <input class="account-email" type="hidden" value="' + row.email + '">\
                                    <input class="account-don-vi" type="hidden" value="' + row.donVi + '">\
                                    <input class="account-role" type="hidden" value="' + row.role + '">\
                                    <span class="fa fa-trash control-icon delete-icon delete-account" data-toggle="tooltip" data-placement="top" data-animation="false" title="Xóa tài khoản" style="margin-bottom:5px;">\
                                    </span></div>';
                        }
                    }
                ]
            });
        },
        createNewAccount: function (dataSubmition) {
            dataSubmition.__RequestVerificationToken = listAccountsPlugin.token();
            showLoading();
            $.ajax({
                type: "POST",
                url: "/admin/tai-khoan/create",
                data: dataSubmition,
                dataType: 'json',
                success: function (rs) {
                    hideLoading();
                    if (rs.status === 'success') {
                        $('#add_new_account').modal('hide');
                        swalSuccess(5000, function () {
                            table.ajax.reload();
                        }, rs.message);
                    }
                    else {
                        swalError(rs.message, 5000);
                    }

                },
                error: function (er) {
                    hideLoading();
                    swalError('Vui lòng kiểm tra kết nối internet!', 5000);
                }
            });
        },
        updateAccount: function (dataSubmition) {
            dataSubmition.__RequestVerificationToken = listAccountsPlugin.token();
            showLoading();
            $.ajax({
                type: "POST",
                url: "/admin/tai-khoan/update",
                data: dataSubmition,
                dataType: 'json',
                success: function (rs) {
                    hideLoading();
                    if (rs.status === 'success') {
                        $('#add_new_account').modal('hide');
                        swalSuccess(5000, function () {
                            table.ajax.reload();
                        }, rs.message);
                    }
                    else {
                        swalError(rs.message, 5000);
                    }

                },
                error: function (er) {
                    hideLoading();
                    swalError('Vui lòng kiểm tra kết nối internet!', 5000);
                }
            });
        },
        deleteAccount: function (uid) {
            showLoading();
            $.ajax({
                type: "POST",
                url: "/admin/tai-khoan/delete",
                data: {
                    __RequestVerificationToken: listAccountsPlugin.token(),
                    uid: uid
                },
                dataType: 'json',
                success: function (rs) {
                    hideLoading();
                    if (rs.status === 'success') {
                        swalSuccess(5000, function () {
                            location.reload();
                        }, rs.message);
                    }
                    else {
                        swalError(rs.message, 5000);
                    }

                },
                error: function (er) {
                    hideLoading();
                    swalError('Vui lòng kiểm tra kết nối internet!', 5000);
                }
            });
        }
    };
}());

$(document).ready(function () {
    listAccountsPlugin.init();
});