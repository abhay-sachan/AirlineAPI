using AirlineProjectAPI.Models;

namespace AirlineProjectAPI.Controllers
{
    public class AdminImpl : IAdmin
    {
        readonly AirlineProjectAPIDbContext db;
        public AdminImpl(AirlineProjectAPIDbContext db)
        {
            this.db = db;
        }

        public bool AddFlight(Flight f)
        {
            try
            {
                f.Status = true;
                f.AvailableSeats = 100;
                db.Flight.Add(f);
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
            return false;
        }

        public bool DisableFlight(int fid)
        {
            try
            {
                var olddata = db.Flight.Where(x => x.FlightId == fid).FirstOrDefault();
                if (olddata != null)
                {
                    olddata.Status = !olddata.Status;
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public List<Flight> GetAllFlightList()
        {
            return db.Flight.ToList();
        }
    }
}
