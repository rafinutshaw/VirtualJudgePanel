using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    public class JobApplyActivity : Entity
    {
        public int Id { get; set; }

        [ForeignKey("Student"), Display(Name = "Applicant")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [ForeignKey("JobPost"), Display(Name = "Job Post")]
        public int JobPostId { get; set; }

        public virtual JobPost JobPost { get; set; }

        [Column(TypeName = "DateTime2"), Display(Name = "Apply Date")]
        public DateTime ApplyDate { get; set; }
    }
}
