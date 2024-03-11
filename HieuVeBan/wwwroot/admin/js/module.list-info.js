/*
 * Author: buixuanlong1004
 * Create: 13/09/2022
 * LIST RESULT
 */

var table;
var listInfosPlugin = (function () {
    return {
        init: function () {
            $('#fromDt').val(moment().utc().subtract(1, 'day').format('DD/MM/YYYY'));
            $('#toDt').val(moment().utc().subtract(-1, 'day').format('DD/MM/YYYY'));
            $.fn.datepicker.dates['vi'] = {
                days: ["CN", "T2", "T3", "T4", "T5", "T6", "T7", "CN"],
                daysShort: ["CN", "T2", "T3", "T4", "T5", "T6", "T7", "CN"],
                daysMin: ["CN", "T2", "T3", "T4", "T5", "T6", "T7", "CN"],
                months: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
                monthsShort: ["T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12"],
                today: "Hôm nay"
            };

            $.fn.datepicker.defaults.language = 'vi';

            $(".date-input").datepicker({
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                language: 'vi'
            });
            this.eventListener();
        },
        token: function () {
            return $('input[name=__RequestVerificationToken]').val();
        },
        eventListener: function () {
            var fromDt = $('#fromDt').val(),
                toDt = $('#toDt').val();
            listInfosPlugin.loadData(fromDt, toDt);


            $(document).off('submit', '#searchForm');
            $(document).on('submit', '#searchForm', function (e) {
                e.preventDefault();
                $('#recordTable').DataTable().clear().destroy();
                var fromDt = $('#fromDt').val(),
                    toDt = $('#toDt').val();
                listInfosPlugin.loadData(fromDt, toDt);
            });
            $('#search').on('click', function (e) {
                e.preventDefault();
            });

            //export excel
            $(document).off('click', '#exportExcel');
            $(document).on('click', '#exportExcel', function (e) {
                e.preventDefault();
                var fromDt = $('#fromDt').val(),
                    toDt = $('#toDt').val();
                listInfosPlugin.exportExcel(fromDt, toDt);
            });
        },
        loadData: function (fromDt, toDt) {
            table = $('#recordTable').on('init.dt', function () {
            }).DataTable({
                responsive: true,
                ordering: true,
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
                    url: '/admin/info/load-data',
                    type: 'POST',
                    datatype: 'json',
                    data: function (d) {
                        d.__RequestVerificationToken = listInfosPlugin.token(),
                            d.fromDt = fromDt,
                            d.toDt = toDt
                    }
                },
                columns: [
                    { name: 'name', data: 'name', orderable: false },
                    { name: 'birthDay', data: 'birthDay', orderable: false },
                    { name: 'email', data: 'email', orderable: false },
                    { name: 'phoneNumber', data: 'phoneNumber', orderable: false },
                    { name: 'thpt', data: 'thpt', orderable: false },
                    { name: 'city', data: 'city', orderable: false },
                    { name: 'type', data: 'type', orderable: false }
                ]
            });
        },
        exportExcel: function (fromDt, toDt) {
            showLoading();
            $.ajax({
                url: `/admin/info/export-excel`,
                type: 'POST',
                data: {
                    __RequestVerificationToken: listInfosPlugin.token(),
                    fromDt: fromDt,
                    toDt: toDt
                },
                dataType: 'json',
                success: function (rs) {
                    hideLoading();
                    if (rs.status === 'success') {
                        swalSuccess(5000, null, rs.message);
                        window.location = `/admin/download-excel?fileName=${rs.fileName}`;
                    }
                    else if (rs.status === 'error') {
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
    listInfosPlugin.init();
});