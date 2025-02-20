using Domin.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.ViewModels
{
    public class RegisterViewModel
    {
        public List<VwUser>? VwUsers { get; set; }
        
        public List<IdentityRole>? Roles { get; set; }

        public NewRegister NewRegister { get; set; }

        public ChangePassword? ChangePassword { get; set; }

    }

    public class NewRegister
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [MinLength(3, ErrorMessage = "يجب الا يقل عدد حروف الكلمة عن 3 حروف")]
        [MaxLength(20, ErrorMessage = "يجب الا يزيد عدد حروف الكلمة عن عشرون حرف")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [EmailAddress(ErrorMessage = "ادخل الايميل بشكل صحيح")]
        public string Email { get; set; }

        public string? ImageUser { get; set; }

        public bool ActiveUser { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [MinLength(8, ErrorMessage = "يجب ان لا تقل كلمة السر عن 8 خانات ")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "لم تتطابق كلمة المرور")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePassword
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [MinLength(8, ErrorMessage = "يجب ان لا تقل كلمة السر عن 8 خانات ")]
        [PasswordPropertyText]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "لم تتطابق كلمة المرور")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string ConfirmNewPassword { get; set; }
    }


}
