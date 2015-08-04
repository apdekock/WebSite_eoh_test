using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DAL.DataBase.DataAccess;

namespace DAL
{
    public class EmployeeDataAccess : DataAccessBase
    {
        public EmployeeDataAccess(string connectionString)
            : base(connectionString)
        {
        }

        public EmployeeDataAccess()
            : base()
        {
        }

        public List<Employee> GetEmployees()
        {
            return _dbEntities.Employees.ToList();
        }
        public Employee GetEmployee(int employeeId)
        {
            return _dbEntities.Employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
        }

        public void RemoveEmployee(Employee employee)
        {
            if (employee == null) return;
            _dbEntities.Employees.Remove(employee);

            var employeeRoles = _dbEntities.EmployeeRoles.Where(f => f.EmployeeId == employee.EmployeeId);
            _dbEntities.EmployeeRoles.RemoveRange(employeeRoles);
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null) return;
            _dbEntities.Employees.Add(employee);
        }

        public void SaveChanges()
        {
            _dbEntities.SaveChanges();
        }

        public void RemoveEmployeeRole(EmployeeRole employeeRole)
        {
            _dbEntities.EmployeeRoles.Remove(employeeRole);
        }
    }
}
