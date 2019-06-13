namespace QuickReach.Ecommerce
{
    public interface ILoginManager
    {
        bool Validate(string username, string password);
    }
}