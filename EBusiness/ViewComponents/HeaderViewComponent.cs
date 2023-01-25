using EBusiness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = new AppUser();
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            return View(await Task.FromResult(user));
        }
    }
}
