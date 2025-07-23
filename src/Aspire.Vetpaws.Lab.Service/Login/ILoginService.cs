using Aspire.Vetpaws.Lab.Models.Login;

namespace Aspire.Vetpaws.Lab.Service.Login
{
    public interface ILoginService
    {
        bool ValidateUser(LoginUser user);
        LoggedUser GetUserInfo(string userName);
    }
}
