using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProjectSql.Models
{
    public class Professeur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ClassroomId { get; set; }

        public Classroom Classroom { get; set; }

        [ForeignKey("AuthorId")]
        public ICollection<Course> CoursesWritten { get; set; }

        [ForeignKey("EditorId")]
        public ICollection<Course> CoursesEditted { get; set; }
    }
}
