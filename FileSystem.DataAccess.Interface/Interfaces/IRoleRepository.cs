using FileSystem.DataAccess.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.DataAccess.Interface.Interfaces
{
    public interface IRoleRepository
    {
        bool Create(RoleModelDA role);

        bool Delete(int id);

        RoleModelDA GetRoleById(int id);

        RoleModelDA GetRoleByName(string name);

        List<RoleModelDA> GetAllRoles();
    }
}
