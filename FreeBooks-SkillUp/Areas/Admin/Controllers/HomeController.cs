using Microsoft.AspNetCore.Mvc;

namespace FreeBooks_SkillUp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

    }
}
