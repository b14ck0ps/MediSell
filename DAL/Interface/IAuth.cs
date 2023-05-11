using DAL.Models;

namespace DAL.Interface
{
    public interface IAuth<out T> : IReopsitory<User, int, bool>
    {
        T Authenticate(string email, string password);
        User GetByEmail(string email);
    }
}