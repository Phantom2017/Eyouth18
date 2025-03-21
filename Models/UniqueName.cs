using System.ComponentModel.DataAnnotations;

namespace Eyouth1.Models
{
    public class UniqueName:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value.ToString().StartsWith('A');
        }
    }
}
