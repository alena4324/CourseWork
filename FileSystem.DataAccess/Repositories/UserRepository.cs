using FileSystem.DataAccess.Interface.Interfaces;
using FileSystem.DataAccess.Interface.Models;
using FileSystem.DataAccess.Mapper;
using FileSystem.ORM;
using FileSystem.ORM.EF;
using FileSystem.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _context;// = new UsersContext();

        public UserRepository(UsersContext context)
        {
            _context = context;
        }

        public bool Create(UserModelDA createdUser)
        {

            var user = UserMapDA.UserModelDAToUser(createdUser);
            user.IsActive = true;
            user.Roles.Add(_context.Roles.FirstOrDefault(r => r.Name == "user"));

            _context.Users.Add(user);

            _context.SaveChanges();

            return true;
        }

        public bool Delete(string login)
        {
            /*var deletedUser =*/
            _context.Users.FirstOrDefault(u => u.Login == login).IsActive = false;

           // _context.Users.Remove(deletedUser);

            _context.SaveChanges();

            return true;
        }

        public UserModelDA GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return null;

            return UserMapDA.UserToUserModelDA(user);

        }

        public UserModelDA GetUserByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);

            if (user == null)
                return null;

            return UserMapDA.UserToUserModelDA(user);

        }

        public List<UserModelDA> GetAllUsers()
        {
            var users = new List<UserModelDA>();
            _context.Users.ToList().ForEach(s => users.Add(UserMapDA.UserToUserModelDA(s)));

            if (users != null)
                return users;
            else
                throw new Exception("There are no users.");
        }

        public bool UpdateUser(UserModelDA user)
        {
            if (user == null)
                return false;

            var userToUpdate = _context.Users.FirstOrDefault(u => u.Login == user.Login);

            userToUpdate.IsActive = user.IsActive;

            userToUpdate.Password = user.Password;

            _context.Roles.ToList().ForEach(r =>
            {
                if (user.Roles.Where(role => r.Name == role.Name).FirstOrDefault() != null)
                    userToUpdate.Roles.Add(_context.Roles.Where(role => r.Name == role.Name).FirstOrDefault());
                else if(userToUpdate.Roles.Where(role => r.Name == role.Name).FirstOrDefault() != null)                   
                    userToUpdate.Roles.Remove(_context.Roles.Where(role => r.Name == role.Name).FirstOrDefault());
            });

            _context.Entry(userToUpdate).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return true;
        }
    }
}
