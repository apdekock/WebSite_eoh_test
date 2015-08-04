using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataBase.DataAccess;

namespace DAL
{
    public class EmployeeRoleDataAccess : DataAccessBase
    {
        public void AddRole(int empId, int roleId)
        {
            _dbEntities.EmployeeRoles.Add(new EmployeeRole { EmployeeId = empId, RoleId = roleId });
        }

        public void SaveChanges()
        {
            _dbEntities.SaveChanges();
        }

        public void RemoveRole(Employee employee, Role role)
        {
            employee.EmployeeRoles.Remove(employee.EmployeeRoles.First(employeeRole => employeeRole.EmployeeId == employee.EmployeeId && employeeRole.RoleId == role.RoleId));
            role.EmployeeRoles.Remove(role.EmployeeRoles.First(employeeRole => employeeRole.EmployeeId == employee.EmployeeId && employeeRole.RoleId == role.RoleId));
            _dbEntities.EmployeeRoles.Remove(_dbEntities.EmployeeRoles.First(f => f.EmployeeId == employee.EmployeeId && f.RoleId == role.RoleId));
        }
    }
}
