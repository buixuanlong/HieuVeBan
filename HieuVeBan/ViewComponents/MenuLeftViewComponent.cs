using HieuVeBan.Models.OldModel;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.ViewComponents
{
    public class MenuLeftViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity?.IsAuthenticated == true && User.IsInRole("admin"))
            {
                var lstMenu = new List<Menu>();
                lstMenu.Add(new Menu("Tài khoản", "/admin/tai-khoan", "fa fa-user"));
                lstMenu.Add(new Menu("Thông tin người dùng", "/admin/info", "fa fa-list"));
                ViewData["lstMenu"] = lstMenu;
                ViewData["fullname"] = User.Identity.Name;
            }
            return await Task.FromResult(View());
        }
    }
}
