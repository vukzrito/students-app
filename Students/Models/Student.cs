using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Student
    {
        public string Id { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        [NotMapped] public string FullName => $"{Salutation} {FirstName} {LastName}";
    }

    public enum Gender
    {
        Male,
        Female
    }
}