using API.Entites;

namespace API.interfaces
{
    public interface ITokanSercivce
    {
         string CreateToken(AppUser user);
    }
}