using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Test.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Please make sure Exact 7 digit")]
        [Display(Name = "Student Id")]
        public string StudentId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Contact No")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Please make sure Exact 11 digit")]
        public string ContactNo { get; set; }
        [Required]
        [Display(Name = "Select Your Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }



        public string FileName { get; set; }
        public string FileType { get; set; }
        [Display(Name = "Select Your Image")]

        public byte[] BinaryDataImage { get; set; }
    }
}