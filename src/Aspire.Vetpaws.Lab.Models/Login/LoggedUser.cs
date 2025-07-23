using Aspire.Vetpaws.Lab.Models.Enum;

namespace Aspire.Vetpaws.Lab.Models.Login
{
    public class LoggedUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public ELoggedUserRole Role { get; set; }
    }
}
