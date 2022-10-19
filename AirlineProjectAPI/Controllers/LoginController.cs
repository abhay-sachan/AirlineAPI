using AirlineProjectAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineProjectAPI.Controllers
{
    [Route("api/RegisterLogin")]
    [ApiController]
    [EnableCors(PolicyName = "AirlineProject")]
    public class LoginController : ControllerBase
    {
        readonly AirlineProjectAPIDbContext db;
        readonly IAuthenticate auth;
        public LoginController(AirlineProjectAPIDbContext db, IAuthenticate auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPost]
        [Route("/api/RegisterLogin/NewRegister")]
        public bool Post([FromBody] Register r)
        {
            
            return auth.NewRegister(r);
        }
        [HttpGet]
        [Route("/api/RegisterLogin/Login/{email}/{pwd}")]
        public string Get(string email, string pwd)
        {
            
            return auth.Login(email, pwd);
        }
        [HttpPut]
        [Route("/api/RegisterLogin/UpdatePwd/{email}/{oldp}/{newp}")]
        public bool Put(string email, string oldp, string newp)
        {
           
            return auth.ChangePassword(email, oldp, newp);
        }
    }
}
