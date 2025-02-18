using Infrastructuree.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Infrastructuree.Data;
using Domin.Entity;
using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace WebBooks_SkillUp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BookDbContext _bookDbContext;

        public AccountsController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, BookDbContext bookDbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _bookDbContext = bookDbContext;
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
                        SessionMsg("Success", "تم الحفظ بنجاح", "تم اضافة مجموعة المستخدمين بنجاح");
                        return RedirectToAction(nameof(Role));
                    }
                    else
                    {
                        rolesViewModel.NewRole.RoleName = null;

                        // Not Succeeded
                        SessionMsg("Error", "لم يتم الحفظ", "لم يتم اضافة مجموعة المستخدمين");

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
                        SessionMsg("Success", "تم التعديل بنجاح", "تم تعديل مجموعة المستخدمين بنجاح");

                        return RedirectToAction(nameof(Role));
                    }
                    else
                    {
                        // Not Succeeded
                        SessionMsg("Error", "لم يتم التعديل", "لم يتم اضافة مجموعة المستخدمين");

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
                SessionMsg("Success", "تم الحذف بنجاح", "تم حذف مجموعة المستخدمين");

                return RedirectToAction(nameof(Role));
            }
            return RedirectToAction(nameof(Role));
        }
        public IActionResult Register()
        {
            var model = new RegisterViewModel
            {
                NewRegister = new NewRegister(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
                VwUsers = _bookDbContext.UsersView.OrderBy(x => x.Role).ToList() //_userManager.Users.OrderBy(x=>x.Name).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count() > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                    var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.PathSaveImageuser, ImageName), FileMode.Create);
                    file[0].CopyTo(fileStream);
                    model.NewRegister.ImageUser = ImageName;
                }
                else
                {
                    model.NewRegister.ImageUser = model.NewRegister.ImageUser;
                }
                var user = new ApplicationUser
                {
                    Id = model.NewRegister.Id,
                    Name = model.NewRegister.Name,
                    UserName = model.NewRegister.Email,
                    Email = model.NewRegister.Email,
                    ActiveUser = model.NewRegister.ActiveUser,
                    ImageUser = model.NewRegister.ImageUser
                };
                if (user.Id == null)
                {
                    //Craete
                    user.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(user, model.NewRegister.Password);
                    if (result.Succeeded)
                    {
                        //Succsseded
                        var Role = await _userManager.AddToRoleAsync(user, model.NewRegister.RoleName);
                        if (Role.Succeeded)
                            SessionMsg(Helper.Success, "تم الحفظ", "لم يتم حفظ مجموعة المستخدم");
                        else
                            SessionMsg(Helper.Error, "لم يتم الحفظ", "لم يتم حفظ المستخدم");
                    }
                    else //Not Successeded
                        SessionMsg(Helper.Error, "لم يتم الحفظ", "لم يتم تعديل المستخدم");
                }
                else
                {
                    //Update
                    var userUpdate = await _userManager.FindByIdAsync(user.Id);
                    userUpdate.Id = model.NewRegister.Id;   
                    userUpdate.Name = model.NewRegister.Name;
                    userUpdate.UserName = model.NewRegister.Email;
                    userUpdate.Email = model.NewRegister.Email;
                    userUpdate.ActiveUser = model.NewRegister.ActiveUser;
                    userUpdate.ImageUser = model.NewRegister.ImageUser;
                
                    var result = await _userManager.UpdateAsync(userUpdate);
                    if (result.Succeeded)
                    {
                        var oldRole = await _userManager.GetRolesAsync(userUpdate);
                        await _userManager.RemoveFromRolesAsync(userUpdate, oldRole);
                        var AddRole = await _userManager.AddToRoleAsync(userUpdate, model.NewRegister.RoleName);
                        if (AddRole.Succeeded)
                            SessionMsg(Helper.Success, "تم التعديل", "لم يتم تعديل مجموعة المستخدم");
                        else
                            SessionMsg(Helper.Error, "لم يتم التعديل", "لم يتم تعديل مجموعة المستخدم");
                    }
                    else // Not Successeded
                        SessionMsg(Helper.Error, "لم يتم التعديل", "لم يتم تعديل المستخدم");
                }
                return RedirectToAction("Registers", "Accounts");
            }
            return RedirectToAction("Registers", "Accounts");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var User = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            if (User.ImageUser != null && User.ImageUser != Guid.Empty.ToString())
            {
                var PathImage = Path.Combine(@"wwwroot/", Helper.PathImageuser, User.ImageUser);
                if (System.IO.File.Exists(PathImage))
                    System.IO.File.Delete(PathImage);
            }
            if ((await _userManager.DeleteAsync(User)).Succeeded)
                return RedirectToAction("Registers", "Accounts");

            return RedirectToAction("Registers", "Accounts");
        }

        private void SessionMsg(string msgtype, string title, string msg)
        {
            // msgtype == Success || Error
            HttpContext.Session.SetString("msgType", msgtype);
            HttpContext.Session.SetString("title", title);
            HttpContext.Session.SetString("msg", msg);
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
