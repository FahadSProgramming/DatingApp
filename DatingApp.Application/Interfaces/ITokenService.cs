namespace DatingApp.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string[] attributes);
    }
}
