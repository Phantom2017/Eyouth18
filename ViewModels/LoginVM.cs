using System.ComponentModel.DataAnnotations;

namespace Eyouth1.ViewModels
{
    public class LoginVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
