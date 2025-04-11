using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eyouth1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter valid name")]
        [StringLength(50,MinimumLength =10)]
        [UniqueName(AnyField ="ABC")]
        //[Compare("Password")]
        public string Name { get; set; }
        //[EmailAddress]
        //[DataType(DataType.EmailAddress)]
        [MinLength(10)]
        [MaxLength(50)]
        public string Address { get; set; }
        //[DataType(DataType.PhoneNumber)]
        [Range(6000,10000)]
        // [RegularExpression(@"\d{6}")]
        //Only in MVC
        [Remote("MutipleThree","Employee",AdditionalFields ="Name")]
        public decimal Salary { get; set; }
        [Url]
        public string Img { get; set; }
        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
