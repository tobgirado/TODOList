using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Model
{
    [Table("Todos", Schema = "dbo")]
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
