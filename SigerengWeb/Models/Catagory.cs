using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SigerengWeb.Models
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength (30)]

        [DisplayName("Catagory Name") ]
        public string Name { get; set; } = string.Empty;
        [Range (1,100, ErrorMessage ="Value between 1 to 100")]
        [DisplayName("Display order ")]
        public  int DisplayOrder{ get; set; }
    }
}
