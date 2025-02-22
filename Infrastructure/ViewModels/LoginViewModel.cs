using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "يجب ان لا تقل كلمة المرور عن 8")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
