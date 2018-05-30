using FileSystem.BusinessLogic.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.BusinessLogic.Interface.Interfaces
{
    public interface IRoleService
    {
        bool CreateRole(RoleModelBL role);

        bool DeleteRole(int id);

        RoleModelBL GetRoleByName(string name);

        List<RoleModelBL> GetAllRoles();

        RoleModelBL GetRoleById(int id);

    }
}
