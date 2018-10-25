using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJP_Entity
{
    [Table("Account Type")]
    public class AccountType : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
