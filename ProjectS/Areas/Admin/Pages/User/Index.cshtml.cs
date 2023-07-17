using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Admin.User
{
	[Authorize(Roles = "Admin")]

	public class IndexModel : PageModel
	{
		private readonly UserManager<IdentityUser> _userManager;
		public IndexModel(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}
		public List<UserAndRole> users { get; set; }

		

		[TempData]
		public string StatusMessage { get; set; }

		public class UserAndRole : IdentityUser
		{
			public string RoleNames { get; set; }

		}
		public async Task OnGet()
        {
            users = await _userManager.Users.OrderBy(u => u.UserName)
    .Select(u => new UserAndRole
    {
        Id = u.Id,
        UserName = u.UserName
    })
    .ToListAsync();

            foreach (var user in users)
			{
				var roles = await _userManager.GetRolesAsync(user);
				user.RoleNames =  string.Join(",", roles);
			}

		

		}

		public void OnPost() =>RedirectToPage();
    }
}
