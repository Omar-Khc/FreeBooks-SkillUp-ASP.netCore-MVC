using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class LogBook
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }


        public Guid BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

    }
}
