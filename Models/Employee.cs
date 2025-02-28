using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eyouth1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Img { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }

    }
}
