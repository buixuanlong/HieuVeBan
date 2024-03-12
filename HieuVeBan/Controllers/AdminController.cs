using HieuVeBan.Contracts.Services;
using HieuVeBan.Helpers;
using HieuVeBan.Models.Entities.OldEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace HieuVeBan.Controllers
{
    [Route("admin")]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IAdminService adminService, IWebHostEnvironment webHostEnvironment)
        {
            _adminService = adminService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Redirect("/admin/info");
            }
            else
            {
                return Redirect("/login");
            }
        }

        [Authorize(Roles = "admin")]
        [Route("tai-khoan")]
        public IActionResult UserAccount()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        //Load dữ liệu tài khoản
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("tai-khoan/load-data")]
        public JsonResult LoadListAccounts()
        {
            try
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    //jQuery DataTables Param
                    var draw = HttpContext.Request.Form["draw"];
                    //Find paging info
                    var start = Request.Form["start"];
                    var length = Request.Form["length"];
                    //Find order columns info
                    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                    var sortColumnDir = Request.Form["order[0][dir]"];
                    //find search columns info
                    string search = Request.Form["search[value]"];

                    int pageSize = string.IsNullOrEmpty(length) ? 0 : Convert.ToInt32(length);
                    int skip = string.IsNullOrEmpty(start) ? 0 : Convert.ToInt32(start);
                    int recordsTotal = 0;

                    List<TaiKhoan> userAccounts = new List<TaiKhoan>();
                    //SEARCHING...
                    if (!string.IsNullOrEmpty(search))
                    {
                        (userAccounts, recordsTotal) = _adminService.GetAccountsPagination(search, pageSize, skip, sortColumn, sortColumnDir);
                    }
                    else
                    {
                        (userAccounts, recordsTotal) = _adminService.GetAccountsPagination(search, pageSize, skip, sortColumn, sortColumnDir);
                    }
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = userAccounts });
                }
                else
                {
                    return Json(new { status = WebConstants.ERROR, message = "Phiên làm việc hết hạn", data = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = WebConstants.ERROR, data = "" });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("tai-khoan/delete")]
        public async Task<JsonResult> DeleteAccount(int uid)
        {
            try
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    var userAccount = _adminService.GetAccount(uid);
                    if (userAccount != null)
                    {
                        int result = await _adminService.DeleteAccount(userAccount);
                        if (result == 0)
                        {
                            return Json(new { status = WebConstants.ERROR, message = "Xóa tài khoản thất bại" });
                        }
                        return Json(new { status = WebConstants.SUCCESS, message = "Xóa tài khoản thành công" });
                    }
                    else
                    {
                        return Json(new { status = WebConstants.ERROR, message = "Tài khoản không tồn tại" });
                    }
                }
                else
                {
                    return Json(new { status = WebConstants.ERROR, message = WebConstants.SessionExpried });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = WebConstants.ERROR, message = e.ToString() });
            }
        }

        //sửa tài khoản
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("tai-khoan/update")]
        public async Task<JsonResult> UpdateAccount(int uid, string role)
        {
            try
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    var userAccount = _adminService.GetAccount(uid);
                    if (userAccount != null)
                    {
                        userAccount.Role = role;
                        int result = await _adminService.UpdateAccount(userAccount);
                        if (result > 0)
                        {
                            return Json(new { status = WebConstants.SUCCESS, message = "Sửa thành công." });
                        }
                        else
                        {
                            return Json(new { status = WebConstants.ERROR, message = "Sửa thất bại." });
                        }
                    }
                    else
                    {
                        return Json(new { status = WebConstants.ERROR, message = "Không tìm thấy tài khoản!" });
                    }
                }
                else
                {
                    return Json(new { status = WebConstants.ERROR, message = WebConstants.SessionExpried });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = WebConstants.ERROR, message = e.ToString() });
            }
        }

        //tạo mới tài khoản
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("tai-khoan/create")]
        public async Task<JsonResult> CreateNewAccount(string maQuanLy, string hoTen, string email, string donVi, string role)
        {
            try
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    var userAccount = _adminService.GetAccountByEmail(email);
                    if (userAccount != null)
                    {
                        return Json(new { status = WebConstants.ERROR, message = "Tài khoản đã tồn tại!" });
                    }
                    else
                    {
                        if (!email.EndsWith("@ueh.edu.vn"))
                        {
                            return Json(new { status = WebConstants.ERROR, message = "Email không thuộc UEH!" });
                        }
                        TaiKhoan user = new TaiKhoan();
                        user.MaQuanLy = maQuanLy;
                        user.HoTen = hoTen.Trim();
                        user.Email = email.Trim();
                        user.DonVi = donVi.Trim();
                        user.Role = role;
                        int result = await _adminService.AddAccount(user);
                        if (result > 0)
                        {
                            return Json(new { status = WebConstants.SUCCESS, message = "Thêm tài khoản thành công." });
                        }
                        else
                        {
                            return Json(new { status = WebConstants.ERROR, message = "Thêm tài khoản thất bại." });
                        }
                    }
                }
                else
                {
                    return Json(new { status = WebConstants.ERROR, message = WebConstants.SessionExpried });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = WebConstants.ERROR, message = e.ToString() });
            }
        }

        [Authorize(Roles = "admin")]
        [Route("info")]
        public IActionResult Info()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("info/load-data")]
        public JsonResult LoadListInfo(string fromDt, string toDt)
        {
            try
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    //jQuery DataTables Param
                    var draw = HttpContext.Request.Form["draw"];
                    //Find paging info
                    var start = Request.Form["start"];
                    var length = Request.Form["length"];
                    //Find order columns info
                    //var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                    //var sortColumnDir = Request.Form["order[0][dir]"];
                    var sortColumn = "id";
                    var sortColumnDir = "desc";
                    //find search columns info
                    string search = Request.Form["search[value]"];

                    int pageSize = string.IsNullOrEmpty(length) ? 0 : Convert.ToInt32(length);
                    int skip = string.IsNullOrEmpty(start) ? 0 : Convert.ToInt32(start);
                    int recordsTotal = 0;

                    List<Information> lstResult = new List<Information>();
                    //SEARCHING...
                    if (!string.IsNullOrEmpty(search))
                    {
                        (lstResult, recordsTotal) = _adminService.GetInfosPagination(search, pageSize, skip, sortColumn, sortColumnDir, fromDt, toDt);
                    }
                    else
                    {
                        (lstResult, recordsTotal) = _adminService.GetInfosPagination(search, pageSize, skip, sortColumn, sortColumnDir, fromDt, toDt);
                    }
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lstResult });
                }
                else
                {
                    return Json(new { status = WebConstants.ERROR, message = "Phiên làm việc hết hạn", data = "" });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = WebConstants.ERROR, data = "" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        [Route("info/export-excel")]
        public async Task<JsonResult> ExportExcel(string fromDt, string toDt)
        {
            try
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    var data = await _adminService.ExportExcelInfos(fromDt, toDt);
                    var stream = new MemoryStream();
                    var fileName = $"ThongTinNguoiDung_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
                    string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "data/export_excel/") + fileName;
                    using (var package = new ExcelPackage(stream))
                    {
                        var sheet = package.Workbook.Worksheets.Add("Thông tin người dùng");
                        sheet.Cells[1, 1].Value = "STT";
                        sheet.Cells[1, 2].Value = "Họ và Tên";
                        sheet.Cells[1, 3].Value = "Ngày sinh";
                        sheet.Cells[1, 4].Value = "Email";
                        sheet.Cells[1, 5].Value = "Số điện thoại";
                        sheet.Cells[1, 6].Value = "THPT";
                        sheet.Cells[1, 7].Value = "Tỉnh / Thành phố";
                        sheet.Cells[1, 8].Value = "Loại";
                        int rowIndex = 2;
                        foreach (var info in data)
                        {
                            sheet.Cells[rowIndex, 1].Value = rowIndex - 1;
                            sheet.Cells[rowIndex, 2].Value = info.Name;
                            sheet.Cells[rowIndex, 3].Value = info.BirthDay;
                            sheet.Cells[rowIndex, 4].Value = info.Email;
                            sheet.Cells[rowIndex, 5].Value = info.PhoneNumber;
                            sheet.Cells[rowIndex, 6].Value = info.Thpt;
                            sheet.Cells[rowIndex, 7].Value = info.City;
                            sheet.Cells[rowIndex, 8].Value = info.Type;
                            rowIndex++;
                        }

                        package.SaveAs(new FileInfo(fullPath));
                    }
                    stream.Position = 0;
                    return Json(new { status = WebConstants.SUCCESS, message = "Đã truy xuất dữ liệu ra file excel!", fileName = fileName });
                }
                else
                {
                    return Json(new { status = WebConstants.ERROR, message = WebConstants.SessionExpried });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = WebConstants.ERROR, message = e.Message });
            }
        }

        [HttpGet]
        [Route("download-excel")]
        public IActionResult DownloadExcel(string fileName)
        {
            string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "data/export_excel/") + fileName;
            byte[] fileByteArray = System.IO.File.ReadAllBytes(fullPath);
            System.IO.File.Delete(fullPath);
            return File(fileByteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}