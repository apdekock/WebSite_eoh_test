using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataBase.DataAccess;

namespace DAL
{
    public class RoleDataAccess : DataAccessBase
    {
        public List<Role> GetRoles()
        {
            return _dbEntities.Roles.ToList();
        }

        public Role GetRole(string role)
        {
            return _dbEntities.Roles.FirstOrDefault(r=>r.Role1 == role);
        }

        public void SaveChanges()
        {
            _dbEntities.SaveChanges();
        }

        public void RemoveRole(Role role)
        {
            if (role == null) return;
            _dbEntities.EmployeeRoles.RemoveRange(_dbEntities.EmployeeRoles.Where(e => e.RoleId == role.RoleId));
            _dbEntities.Roles.Remove(role);
        }

        public void AddRole(Role role)
        {
            if (role == null) return;
            _dbEntities.Roles.Add(role);
        }
    }
}
