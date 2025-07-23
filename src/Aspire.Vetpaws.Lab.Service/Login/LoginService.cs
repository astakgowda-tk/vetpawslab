using Aspire.Vetpaws.Lab.Models.Enum;
using Aspire.Vetpaws.Lab.Models.Login;

namespace Aspire.Vetpaws.Lab.Service.Login
{
    public class LoginService : ILoginService
    {
        public LoginService() { }

        public bool ValidateUser(LoginUser user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }

            return user.UserName == "xyz@gmail.com" && user.Password == "xyz123";
        }

        public LoggedUser GetUserInfo(string userName)
        {
            var user = new LoggedUser()
            {
                UserName = userName,
                Email = userName
            };

            user.Role = userName switch
            {
                "xyz@gmail.com" => ELoggedUserRole.SuperAdmin,
                "abc@gmail.com" => ELoggedUserRole.User,
                "pqr@gmail.com" => ELoggedUserRole.Guest,
                _ => throw new NotImplementedException()
            };

            return user;
        }
    }
}