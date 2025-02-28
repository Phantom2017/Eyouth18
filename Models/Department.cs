using System.ComponentModel.DataAnnotations;

namespace Eyouth1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Manager Name")]
        public string MgrName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
