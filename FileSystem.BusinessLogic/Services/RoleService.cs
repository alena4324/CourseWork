using FileSystem.BusinessLogic.Interface.Interfaces;
using FileSystem.BusinessLogic.Interface.Models;
using FileSystem.BusinessLogic.Mapper;
using FileSystem.DataAccess.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public bool CreateRole(RoleModelBL role)
        {
            var newRole = _roleRepository.GetRoleByName(role.Name);

            if (newRole != null)
                return false;

            _roleRepository.Create(RoleMapBL.RoleModelBLToRoleModelDA(role));

            return true;
        }

        public bool DeleteRole(int id)
        {
            var role = _roleRepository.GetRoleById(id);

            if (role == null)
                return false;

            _roleRepository.Delete(role.Id);

            return true;
        }

        public List<RoleModelBL> GetAllRoles()
        {
            var roles = new List<RoleModelBL>();

            _roleRepository.GetAllRoles().ForEach(u => roles.Add(RoleMapBL.RoleModelDAToRoleModelBL(u)));

            return roles;
        }

        public RoleModelBL GetRoleByName(string name)
        {
            var role = _roleRepository.GetRoleByName(name);

            if (role != null)
                return RoleMapBL.RoleModelDAToRoleModelBL(role);

            return null;
        }
        public RoleModelBL GetRoleById(int id)
        {
            var role = _roleRepository.GetRoleById(id);

            if (role != null)
                return RoleMapBL.RoleModelDAToRoleModelBL(role);

            return null;
        }

    }
}
