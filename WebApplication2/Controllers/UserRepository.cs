using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserRepository: IUserRepository
    {

        DataContextEF _dataContextEF;

        IMapper _mapper;

        public UserRepository(IConfiguration config)
        {
            _dataContextEF = new DataContextEF(config);
        }


        public bool SaveChanges()
        {
            return _dataContextEF.SaveChanges() > 0;
        }

        public bool Add<T>(T model)
        {
            if (model != null)
            {
                _dataContextEF.Add(model);
                return true;
            }
            return false;
        }

        public bool Delete<T>(T model)
        {
            if (model != null)
            {
                _dataContextEF.Remove(model);
                return true;
            }
            return false;
        }
    }
}
