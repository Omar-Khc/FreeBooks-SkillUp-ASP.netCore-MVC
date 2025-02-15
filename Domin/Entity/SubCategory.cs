using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SubCategory
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "Name")]
        [MaxLength(20, ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }


        public int CurrentState { get; set; }

    }
}
