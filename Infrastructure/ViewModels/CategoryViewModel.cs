using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }

        public List<LogGategory> LogGategories { get; set; }

        public Category NewCategory { get; set; }


    }
}
