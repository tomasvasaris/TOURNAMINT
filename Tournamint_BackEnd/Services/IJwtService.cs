namespace Tournamint_BackEnd.Services
{
    public interface IJwtService 
    {
        string GetJwtToken(int userId, string role);
    }
}
