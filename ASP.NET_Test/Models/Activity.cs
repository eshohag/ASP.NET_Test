using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Test.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        public int DaysId { get; set; }
        public virtual Days Days { get; set; }
        [Required]
        public bool Present { get; set; }
    }
}