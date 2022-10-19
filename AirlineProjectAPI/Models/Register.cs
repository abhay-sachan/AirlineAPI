using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineProjectAPI.Models
{
    public class Register
    {
        [StringLength(100)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmailId { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }

        [NotMapped]
        public virtual ICollection<Booking> Booking { get; set; }


    }
}

