using System.ComponentModel.DataAnnotations;

namespace MyProjectSql.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; } = string.Empty;

        public string Prenom { get; set; } = string.Empty;

        public int Age { get; set; }

        public double Salaire { get; set; }
       
    }
}
