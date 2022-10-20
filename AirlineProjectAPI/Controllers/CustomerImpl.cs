using AirlineProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineProjectAPI.Controllers
{
    public class CustomerImpl : ICustomer
    {
        readonly AirlineProjectAPIDbContext db;
        public CustomerImpl(AirlineProjectAPIDbContext db)
        {
            this.db = db;
        }

        public bool AddBooking(Booking b)
        {
            var olddata = db.Flight.Where(c => c.FlightId == b.FlightId).FirstOrDefault();
            if (olddata.AvailableSeats < 0 || olddata.AvailableSeats == 0)
            {
                return false;
            }
            else
            {
                var Seats = olddata.AvailableSeats - b.BookedSeats;
                olddata.AvailableSeats = Seats;
                try
                {
                    
                    if(b.BookedSeats < 3)
                    {
                        b.Discount = 0;
                    }
                    else if(b.BookedSeats >= 3 && b.BookedSeats <5)
                    {
                        b.Discount = 30;
                    }
                    else if(b.BookedSeats >=5)
                    {
                        b.Discount = 50;
                    }
                    b.TotalPrice = b.BookedSeats * olddata.Price;
                    b.DiscountedPrice = b.TotalPrice - (Convert.ToInt32((b.Discount * 0.01) * b.TotalPrice));
                    db.Booking.Add(b);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                    throw;
                }
            }
            return false;
        }

        public List<Booking> ShowCustomerBookings(string email)
        {
            var data = db.Booking.Where(c => c.EmailId == email).ToList();
            if (data.Count == 0)
            {
                List<Booking> list = new List<Booking>();
                return list;
            }
            else
                return data;
        }

        public List<Flight> ShowFlightsByFromAndTo(string from, string to)
        {
            var data = db.Flight.Where(c => c.FromCity == from && c.ToCity == to && c.Status == true).ToList();
            if (data.Count == 0)
            {
                List<Flight> list = new List<Flight>();
                return list;
            }
            else
                return data;
        }

        public List<Flight> ShowFlightsByStatus()
        {
            var data = db.Flight.Where(c => c.Status == true).ToList();
            if (data.Count == 0)
            {
                List<Flight> list = new List<Flight>();
                return list;
            }
            else
                return data;
        }

        public Booking ShowLatestBooking()
        {
            var max = db.Booking.Max(x => x.BookingId);
            var data = db.Booking.Where(x => x.BookingId == max).FirstOrDefault();
            return data;
            
        }
    }
}
