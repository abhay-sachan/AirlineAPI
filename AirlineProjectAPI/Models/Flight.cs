using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace AirlineProjectAPI.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(100)]
        public string FromCity { get; set; }

        [ForeignKey("FromCity")]
        public virtual Routes? Routes { get; set; }

        [Required]
        [StringLength(100)]
        public string ToCity { get; set; }
        [Required]
        public int AvailableSeats { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [StringLength(100)]
        public string PickTime { get; set; }
        [Required]
        [StringLength(100)]
        public string DropTime { get; set; }

        [NotMapped]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
