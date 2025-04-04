using System.ComponentModel.DataAnnotations;

namespace Eyouth1.Models
{
    public class UniqueName:ValidationAttribute
    {
        public string AnyField { get; set; }

        CompanyCtx companyCtx;
        public UniqueName()
        {
            companyCtx = new CompanyCtx();
        }
        //public override bool IsValid(object? value)
        //{
        //    return value.ToString().StartsWith('A');
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Employee employee = validationContext.ObjectInstance as Employee;

            if (!companyCtx.Employees.Any(e=>e.Name==value.ToString() && e.Id != employee.Id))
            {
                return ValidationResult.Success;
            }
            //if (value.ToString().StartsWith('B'))
            //    return ValidationResult.Success;
            return new ValidationResult("This Name is taken");
        }
    }
}
