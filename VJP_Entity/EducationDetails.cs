using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class EducationDetails : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Degree is required.")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Institute is required.")]
        public string Institute { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Starting Date")]
        public DateTime? StartingDate { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Completion Date")]
        public DateTime? CompletionDate { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
