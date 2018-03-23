using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Test.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string Tittle { get; set; }
    }
}