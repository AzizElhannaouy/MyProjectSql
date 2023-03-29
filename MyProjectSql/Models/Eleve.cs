using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProjectSql.Models
{
    public class Eleve
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public Classroom Classroom { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
