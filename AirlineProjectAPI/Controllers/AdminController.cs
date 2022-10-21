using AirlineProjectAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineProjectAPI.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    [EnableCors(PolicyName = "AirlineProject")]
    public class AdminController : ControllerBase
    {
        readonly AirlineProjectAPIDbContext db;
        readonly IAdmin adm;
        public AdminController(AirlineProjectAPIDbContext db, IAdmin adm)
        {
            this.db = db;
            this.adm = adm;
        }

        [HttpPost]
        [Route("/api/Admin/AddFlight")]
        public bool AddFlight([FromBody] Flight f)
        {

            return adm.AddFlight(f);
        }

        [HttpPut]
        [Route("/api/Admin/DisableFlight/{fid}")]

        public bool DisableFlight(int fid)
        {
            return adm.DisableFlight(fid);
        }

        [HttpGet]
        [Route("/api/Admin/GetAllFlight")]
        public List<Flight> GetAllFlightList()
        {
            return adm.GetAllFlightList();
        }

        [HttpGet]
        [Route("/api/Admin/GetAllFlightsOfAdmin/{email}")]
        public List<Flight> GetAllFlightsOfAdmin(string email)
        {
            return adm.GetAllFlightsOfAdmin(email);
        }


    }
}
