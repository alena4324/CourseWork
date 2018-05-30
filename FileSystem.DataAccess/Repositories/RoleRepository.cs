using FileSystem.DataAccess.Interface.Interfaces;
using FileSystem.DataAccess.Interface.Models;
using FileSystem.DataAccess.Mapper;
using FileSystem.ORM.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UsersContext _context;

        public RoleRepository(UsersContext context)
        {
            _context = context;
        }


        public bool Create(RoleModelDA createRole)
        {
            var role = _context.Roles.FirstOrDefault(u => u.Name == createRole.Name);

            if (role == null)
                _context.Roles.Add(RoleMapDA.RoleModelDAToRole(createRole));
            else
                throw new Exception("The role is exist.");

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var role = _context.Roles.FirstOrDefault(u => u.Id == id);

            if (role != null)
                _context.Roles.Remove(role);
            else
                throw new NullReferenceException("The role isn't exist.");

            _context.SaveChanges();

            return true;
        }

        public RoleModelDA GetRoleByName(string name)
        {
            var role = _context.Roles.FirstOrDefault(u => u.Name == name);

            if (role != null)
                return RoleMapDA.RoleToRoleModelDA(role);
            else
                throw new NullReferenceException("The role isn't exist.");
        }

        public RoleModelDA GetRoleById(int id)
        {
            var role = _context.Roles.FirstOrDefault(u => u.Id == id);

            if (role == null)
                return RoleMapDA.RoleToRoleModelDA(role);
            else
                throw new NullReferenceException("The role isn't exist.");
        }

        public List<RoleModelDA> GetAllRoles()
        {
            var roles = new List<RoleModelDA>();
            _context.Roles.ToList().ForEach(s => roles.Add(RoleMapDA.RoleToRoleModelDA(s)));

            if (roles != null)
                return roles;
            else
                throw new Exception("There are no roles.");
        }
    }
}
