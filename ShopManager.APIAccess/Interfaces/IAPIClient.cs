using System.Threading.Tasks;

namespace ShopManager.APIAccess
{
    public interface IAPIClient
    {
        Task<AuthUser> AuthenticateUser(string username, string password);
    }
}