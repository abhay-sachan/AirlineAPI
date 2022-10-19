using AirlineProjectAPI.Models;

namespace AirlineProjectAPI.Controllers
{
    public interface ICustomer
    {
        bool AddBooking(Booking b);

        List<Booking> ShowCustomerBookings(string email);

        List<Flight> ShowFlightsByStatus();

        Booking ShowLatestBooking();

    }
}
