using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
