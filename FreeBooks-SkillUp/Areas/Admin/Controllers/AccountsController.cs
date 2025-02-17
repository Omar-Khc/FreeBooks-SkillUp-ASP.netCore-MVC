using Infrastructuree.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebBooks_SkillUp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Role()
        {
            var rols = new RolesViewModel()
            {
                NewRole = new NewRole(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList()
            };
            return View(rols);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Role(RolesViewModel rolesViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Id = rolesViewModel.NewRole.RoleId,
                    Name = rolesViewModel.NewRole.RoleName
                };

                // create
                if (role.Id == null)
                {
                    role.Id = Guid.NewGuid().ToString();
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        // Succeeded
                        HttpContext.Session.SetString("msgType", "Success");
                        HttpContext.Session.SetString("title", "تم الحفظ بنجاح");
                        HttpContext.Session.SetString("msg", "تم اضافة مجموعة المستخدمين بنجاح");

                        return RedirectToAction(nameof(Role));
                    }
                    else
                    {
                        rolesViewModel.NewRole.RoleName = null;
                        // Not Succeeded
                        HttpContext.Session.SetString("msgType", "Error");
                        HttpContext.Session.SetString("title", "لم يتم الحفظ ");
                        HttpContext.Session.SetString("msg", "لم يتم اضافة مجموعة المستخدمين ");

                        return RedirectToAction(nameof(Role));
                    }
                }
                // Update
                else
                {
                    var roleUpdate = await _roleManager.FindByIdAsync(role.Id);
                    roleUpdate.Id = role.Id;
                    roleUpdate.Name = role.Name;

                    if ((await _roleManager.UpdateAsync(roleUpdate)).Succeeded)
                    {
                        // Succeeded
                        HttpContext.Session.SetString("msgType", "Success");
                        HttpContext.Session.SetString("title", "تم التعديل بنجاح");
                        HttpContext.Session.SetString("msg", "تم تعديل مجموعة المستخدمين بنجاح");

                        return RedirectToAction(nameof(Role));
                    }
                    else
                    {
                        // Not Succeeded
                        HttpContext.Session.SetString("msgType", "Error");
                        HttpContext.Session.SetString("title", "لم يتم التعديل ");
                        HttpContext.Session.SetString("msg", "لم يتم اضافة مجموعة المستخدمين ");

                        return RedirectToAction(nameof(Role));
                    }
                }
            }
            return RedirectToAction(nameof(Role));
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if ((await _roleManager.DeleteAsync(role)).Succeeded)
            {
                return RedirectToAction(nameof(Role));
            }
            return RedirectToAction(nameof(Role));
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
