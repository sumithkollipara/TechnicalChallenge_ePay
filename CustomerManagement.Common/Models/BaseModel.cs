using CustomerManagement.Common.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Common.Models
{
    [Serializable]
    public class BaseModel
    {
        [Required]
        [MinValue(1)]
        public int Id { get; set; }
    }
}
