using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.ViewModels
{
    public class RolesViewModel
    {
        public List<IdentityRole>? Roles { get; set; }

        public NewRole NewRole { get; set; }
    }

    public class NewRole
    {
        public string? RoleId { get; set; }

        [Required(ErrorMessage = "يجب ادخال اسم المجموعة")]
        public string RoleName { get; set; }
    }
}
