using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineProjectAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int? FlightId { get; set; }
        [ForeignKey("FlightId")]
        public virtual Flight? Flight { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [Required]
        public string? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public virtual Register? Register  { get; set; }

        [Required]
        public int BookedSeats { get; set; }
        [Required]
        public int TotalPrice { get; set; }

        public int Discount { get; set; }

        public int DiscountedPrice { get; set; }

    }
}
