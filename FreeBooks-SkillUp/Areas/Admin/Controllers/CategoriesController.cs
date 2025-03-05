using Domin.Entity;
using Infrastructuree.IRepository;
using Infrastructuree.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebBooks_SkillUp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IServicesRepository<Category> _servicesCategory;
        private readonly IServicesRepositoryLog<LogGategory> _servicesRepositoryLog;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoriesController(IServicesRepository<Category> servicesCategory,
            IServicesRepositoryLog<LogGategory> servicesRepositoryLog, UserManager<ApplicationUser> userManager)
        {
            _servicesCategory = servicesCategory;
            _servicesRepositoryLog = servicesRepositoryLog;
            _userManager = userManager;
        }

        public IActionResult Categories()
        {
            return View(new CategoryViewModel()
            {
                Categories = _servicesCategory.GetAll(),
                LogGategories = _servicesRepositoryLog.GetAll(),
                NewCategory = new Category()
            });
        }

        public IActionResult Delete(Guid Id)
        {
            var userId = _userManager.GetUserId(User);
            if (_servicesCategory.Delete(Id) && _servicesRepositoryLog.Delete(Id, Guid.Parse(userId)))
                return RedirectToAction(nameof(Categories));

            return RedirectToAction("Categories");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Save(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                if (model.NewCategory.Id == Guid.Parse(Guid.Empty.ToString()))
                {
                    // Save
                    if (_servicesCategory.FindByName(model.NewCategory.Name) != null)
                        SessionMsg("Error", "اسم الفئة موجود بالفعل", "اسم الفئة موجود بالفعل");
                    else
                    {
                        if (_servicesCategory.Save(model.NewCategory) && _servicesRepositoryLog.Save(model.NewCategory.Id, Guid.Parse(userId)))
                            SessionMsg("Success", "تم الحفظ بنجاح", "تم اضافة الفئة بنجاح");
                        else
                            SessionMsg("Error", "لم يتم الحفظ", "اسم الفئة موجود بالفعل");
                    }
                }
                else
                {
                    // Update
                    if (_servicesCategory.Save(model.NewCategory) && _servicesRepositoryLog.Update(model.NewCategory.Id, Guid.Parse(userId)))
                        SessionMsg("Success", "تم الحفظ بنجاح", "تم اضافة الفئة بنجاح");
                    else
                        SessionMsg("Error", "لم يتم الحفظ", "اسم الفئة موجود بالفعل");
                }

            }
            return RedirectToAction(nameof(Categories));
        }

        private void SessionMsg(string msgtype, string title, string msg)
        {
            // msgtype == Success || Error
            HttpContext.Session.SetString("msgType", msgtype);
            HttpContext.Session.SetString("title", title);
            HttpContext.Session.SetString("msg", msg);
        }
    }
}
