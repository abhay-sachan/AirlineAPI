using AirlineProjectAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineProjectAPI.Controllers
{
    [Route("api/ApplicationOwner")]
    [ApiController]
    [EnableCors(PolicyName = "AirlineProject")]
    public class ApplicationOwnerController : ControllerBase
    {
        readonly AirlineProjectAPIDbContext db;
        readonly IApplicationOwner ao;
        public ApplicationOwnerController(AirlineProjectAPIDbContext db, IApplicationOwner ao)
        {
            this.db = db;
            this.ao = ao;
        }
        [HttpGet]
        [Route("/api/ApplicationOwner/ShowAllBookings")]
        public List<Booking> ShowAllBookings()
        {
            return ao.ShowAllBookings();
        }
        [HttpGet]
        [Route("/api/ApplicationOwner/ShowAllRoutes")]
        public List<Routes> ShowAllRoutes()
        {
            return ao.ShowAllRoutes();
        }
        [HttpPost]
        [Route("/api/ApplicationOwner/AddRoute")]
        public bool AddRoute(Routes ro)
        {
            return ao.AddRoute(ro);
        }

        [HttpDelete]
        [Route("/api/ApplicationOwner/DeleteRoute/{city}")]
        public bool DeleteRoute(string city)
        {
            return ao.DeleteRoute(city);
        }

    }
}
