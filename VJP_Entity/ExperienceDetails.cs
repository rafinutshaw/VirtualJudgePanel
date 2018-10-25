using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class ExperienceDetails : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required."), Display(Name = "Title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Company Name is required."), Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public bool IsCurrent { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Starting Date")]
        public DateTime? StartingDate { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Completion Date")]
        public DateTime? CompletionDate { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
