using AirlineProjectAPI.Models;

namespace AirlineProjectAPI.Controllers
{
    public class AuthenticateImpl :IAuthenticate
    {
        readonly AirlineProjectAPIDbContext db;
        public AuthenticateImpl(AirlineProjectAPIDbContext db)
        {
            this.db = db;
        }

        public bool ChangePassword(string email, string oldpwd, string newpwd)
        {
            try
            {
                var olddata = db.Register.Where(x => x.EmailId == email && x.Password ==
                oldpwd).FirstOrDefault();
                if (olddata == null)
                {
                    throw new Exception("Invalid Email or Password");
                }
                else
                {
                    olddata.Password = newpwd;
                    var res = db.SaveChanges();
                    if (res > 0)
                        return true;
                }

            }
            catch
            {
                throw;
            }
            return false;

        }
        public string Login(string email, string password)
        {
            try
            {
                var olddata = db.Register.Where(x => x.EmailId == email && x.Password == password).FirstOrDefault();
                if (olddata == null)
                {
                    throw new Exception("Invalid Email or Password");
                }
                else
                {
                    return olddata.UserType;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool NewRegister(Register r)
        {
            try
            {
                db.Register.Add(r);
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            catch
            {
                throw;
            }
            return false;
        }

    }
}
