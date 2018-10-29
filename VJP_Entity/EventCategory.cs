using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class EventCategory : Entity
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Category Name is required"), Display(Name = "Category Name")]
        //public string CategoryName { get; set; }

        ////[ForeignKey("Event"), Display(Name = "Event")]
        ////public int EventId { get; set; }

        //public virtual List<Event> Events { get; set; }
    }
}
