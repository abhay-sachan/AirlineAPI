using AirlineProjectAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineProjectAPI.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [EnableCors(PolicyName = "AirlineProject")]
    public class CustomerController : ControllerBase
    {
        readonly AirlineProjectAPIDbContext db;
        readonly ICustomer cus;
        public CustomerController(AirlineProjectAPIDbContext db, ICustomer cus)
        {
            this.db = db;
            this.cus = cus;
        }

        [HttpPost]
        [Route("/api/Customer/AddBooking")]
        public bool AddBooking(Booking b)
        {
            return cus.AddBooking(b);
        }

        [HttpGet]
        [Route("/api/Customer/ShowCustomerBookings/{email}")]

        public List<Booking> ShowCustomerBookings(string email)
        {
            return cus.ShowCustomerBookings(email);
        }
        [HttpGet]
        [Route("/api/Customer/ShowFlightsByStatus")]

        public List<Flight> ShowFlightsByStatus()
        {
            return cus.ShowFlightsByStatus();
        }
        [HttpGet]
        [Route("/api/Customer/ShowLatestBooking")]
        public Booking ShowLatestBooking()
        {
            return cus.ShowLatestBooking();
        }
    }


}
