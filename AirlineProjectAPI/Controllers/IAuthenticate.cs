using AirlineProjectAPI.Models;

namespace AirlineProjectAPI.Controllers
{
    public interface IAuthenticate
    {
        string Login(string email, string password);
        bool NewRegister(Register r);
        bool ChangePassword(string email, string oldpwd, string newpwd);
    }
}
