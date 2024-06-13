namespace SpaProjectManagement.Services;

public interface IJwtProvider
{
    public string GenerateToken(string login, string role);
}