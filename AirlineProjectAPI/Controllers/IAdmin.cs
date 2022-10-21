using AirlineProjectAPI.Models;

namespace AirlineProjectAPI.Controllers
{
    public interface IAdmin
    {
        bool AddFlight(Flight f);

        bool DisableFlight(int fid);

        List<Flight> GetAllFlightList();

        List<Flight> GetAllFlightsOfAdmin(string email);

    }
}
