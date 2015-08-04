using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DAL;

namespace ExternalAPI
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ConnectionUtil _connectionUtil = new ConnectionUtil();

        public List<string> GetEmployees()
        {
            var da = new EmployeeDataAccess(_connectionUtil.GetConnectionString(1));
            return da.GetEmployees().Select(e => string.Format("{0} {1}", e.FirstName, e.Surname)).ToList();
        }
    }
}
