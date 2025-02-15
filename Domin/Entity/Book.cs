using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Book
    {
        public Guid Id { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "Name")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "Name")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength")]
        public string Auther { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public string FileName { get; set; }

        public bool Publish { get; set; }

        public int CurrentState { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }


        public Guid SubCategoryId { get; set; }
        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }




    }
}
