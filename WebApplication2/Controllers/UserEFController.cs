using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserEFController : ControllerBase
    {

        DataContextEF _dataContextEF;
        IMapper _mapper;

        IUserRepository _userRepository;

        public UserEFController(IConfiguration config, IUserRepository userRepository)
        {
            _dataContextEF = new DataContextEF(config);

            _userRepository = userRepository;

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserToAddDto, User>()));
        }

        [HttpGet("GetUsersEF")]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _dataContextEF.Users.ToList();
            return users;
        }

        [HttpGet("GetSingleUserEF,{UserID}")]
        public User GetUser(int UserID) 
        {
            if (_dataContextEF.Users.SingleOrDefault(u => u.UserID == UserID) != null) 
            {
                return _dataContextEF.Users.SingleOrDefault(u => u.UserID == UserID);
            }

            throw new Exception("Failed to find User");
        }

        [HttpPut("EditUserEF")]
        public IActionResult EditUser(User user)
        {
            User? UserDb = _dataContextEF.Users.Where(u => u.UserID == user.UserID)
                .SingleOrDefault<User>();

            if (UserDb != null)
            {
                UserDb = _mapper.Map<User>(UserDb);

                if (_dataContextEF.SaveChanges() > 0)
                {
                    return Ok();
                }

                throw new Exception("Failed to update User");
            }

            throw new Exception("Failed to update User");
        }

        [HttpPost("AddUserEF")]
        public IActionResult AddUser(UserToAddDto user)
        {
           User userToAdd = new User
           {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                Active = user.Active,
           };

            _userRepository.Add(userToAdd);

            if (_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to add User");
        }

        [HttpDelete("DeleteUser,{UserID}")]
        public IActionResult DeleteUser(int UserID)
        {
            User? UserDb = _dataContextEF.Users
                .Where(u => u.UserID == UserID)
                .SingleOrDefault();

            if (_userRepository.Delete(UserDb)) 
            {
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
            }

            throw new Exception("Failed to delete User");
        }
    }
}