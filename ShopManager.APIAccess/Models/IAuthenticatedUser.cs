namespace ShopManager.APIAccess
{
    public interface IAuthenticatedUser
    {
        string Access_token { get; set; }
        string Username { get; set; }
    }
}