using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineProjectAPI.Models
{
    public class Routes
    {
        [StringLength(100)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FromCity { get; set; }

        [NotMapped]
        public virtual ICollection<Flight> Flight { get; set; }
    }
}
