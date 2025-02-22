using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebBooks_SkillUp.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize]
    public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

    }
}
