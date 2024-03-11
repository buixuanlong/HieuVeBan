using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.ViewComponents
{
    public class AppTitleViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
