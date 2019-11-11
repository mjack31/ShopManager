using System.Threading.Tasks;

namespace ShopManager.APIAccess
{
    public interface IAPIClient
    {
        Task<AuthenticatedUser> AuthenticateUser(string username, string password);
    }
}