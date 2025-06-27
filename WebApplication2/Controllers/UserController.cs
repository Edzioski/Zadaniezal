using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        DataContextDapper _dapper;

        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("GetDate")]
        public DateTime TestConnetion()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        }

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            string sql = 
            @"SELECT 
                [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
            FROM TutorialAppSchema.Users";       

            return _dapper.LoadData<User>(sql);
        }

        [HttpGet("GetSingleUser,{UserID}")]
        public User GetUser(int UserID) 
        {
            string sql = 
            $"SELECT " +
                $"[UserId]," +
                $"[FirstName]," +
                $"[LastName]," +
                $"[Email]," +
                $"[Gender]," +
                $"[Active] " +
            $"FROM TutorialAppSchema.Users WHERE UserId = {UserID.ToString()}";

            return _dapper.LoadDataSingle<User>(sql);
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(User user)
        {
            string sql = 
            @"UPDATE TutorialAppSchema.Users SET " +
                @"[FirstName] = '" + user.FirstName + "'," +
                @"[LastName] = '" + user.LastName + "'," +
                @"[Email] = '" + user.Email + "'," +
                @"[Gender] = '" + user.Gender + "'," +
                @"[Active] = '" + user.Active + "'" +
            @" WHERE UserId = " + user.UserID;

            if(_dapper.Execute(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to update User");
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserToAddDto user)
        {
            string sql =
            @"INSERT INTO TutorialAppSchema.Users(
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active]) 
            VALUES(
                '" + user.FirstName + "'," +
                "'" + user.LastName + "'," +
                "'" + user.Email + "'," +
                "'" + user.Gender + "'," +
                "'" + user.Active + "')";

            if (_dapper.Execute(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to add User");
        }

        [HttpDelete("DeleteUser,{UserID}")]
        public IActionResult DeleteUser(int UserID)
        {
            string sql = @"DELETE FROM TutorialAppSchema.Users WHERE USERID =" + UserID;

            if (_dapper.Execute(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to delete User");
        }

        [HttpGet("GetUserSalary,{UserID}")]
        public UserSalary GetUserSalary(int UserID)
        {
            string sql = @"SELECT * FROM TutorialAppSchema.UserSalary WHERE USERID = " + UserID.ToString();

            UserSalary? userSalary = _dapper.LoadDataSingle<UserSalary>(sql);

            if (userSalary != null) 
            {
                return userSalary;
            }


            throw new Exception("Failed to get UserSalary");
        }

        [HttpPost("AddUserSalary")]
        public IActionResult AddUserSalary (UserSalary userSalary)
        {
            string sql = @"INSERT INTO TutorialAppSchema.UserSalary (" +
                "[UserId]," +
                "[Salary])" +
                " VALUES (" +
                userSalary.UserID + ", " +
                userSalary.Salary + " )";

            if(_dapper.Execute(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to add user salary");
        }

        [HttpPut("EditUserSalary")]
        public IActionResult EditUserSalary(UserSalary userSalary)
        {
            string sql = @"Update TutorialAppSchema.UserSalary Set"
                + "[Salary] = '" + userSalary.Salary + "'"
                + "WHERE UserId = " + userSalary.UserID;
                 
            if (_dapper.Execute(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to edit user salary");
        }

        [HttpDelete("DeleteUserSalary,{userId}")]
        public IActionResult DeleteUserSalary(int userId)
        {         
            string sql = @"DELETE FROM TutorialAppSchema.UserSalary WHERE USERID =" + userId.ToString();

            Console.WriteLine(sql);

            if (_dapper.Execute(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to delete user salary");
        }

    }
}