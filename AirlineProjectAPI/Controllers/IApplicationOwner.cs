using AirlineProjectAPI.Models;

namespace AirlineProjectAPI.Controllers
{
    public interface IApplicationOwner
    {
        List<Booking> ShowAllBookings();

        List<Routes> ShowAllRoutes();

        bool AddRoute(Routes ro);

        bool DeleteRoute(string city);
    }
}
