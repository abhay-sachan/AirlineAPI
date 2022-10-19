using AirlineProjectAPI.Models;
using System.Security.Cryptography;

namespace AirlineProjectAPI.Controllers
{
    public class ApplicationOwnerImpl : IApplicationOwner
    {
        readonly AirlineProjectAPIDbContext db;
        public ApplicationOwnerImpl(AirlineProjectAPIDbContext db)
        {
            this.db = db;
        }

        public bool AddRoute(Routes ro)
        {
            try
            {
                db.Routes.Add(ro);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool DeleteRoute(string city)
        {
            try
            {
                var remove = db.Routes.Where(c => c.FromCity == city).FirstOrDefault();
                if (remove == null)
                    throw new Exception("City Name Not Present");
                else
                {
                    var removeflights = db.Flight.Where(c => c.FromCity==city || c.ToCity==city).ToList();
                    db.Flight.RemoveRange(removeflights);
                    db.Routes.Remove(remove);
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

        public List<Booking> ShowAllBookings()
        {
            return db.Booking.ToList();
        }

        public List<Routes> ShowAllRoutes()
        {
            return db.Routes.ToList();
        }
    }
}
