using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public interface IUserRepository
    {
        public bool SaveChanges();

        public bool Add<T>(T model);

        public bool Delete<T>(T model);

    }
}
