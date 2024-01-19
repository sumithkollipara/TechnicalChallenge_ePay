using CustomerManagement.Common.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Common.Models
{
    [Serializable]
    public class CustomerModel : BaseModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinValue(19)]
        public int Age { get; set; }

        public CustomerModel(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
