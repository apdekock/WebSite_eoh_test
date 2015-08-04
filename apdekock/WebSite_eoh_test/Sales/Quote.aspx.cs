using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using DAL;
using DAL.DataBase.DataAccess;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

public partial class _Quote : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        var searchValue = txtSearch.Text.ToLower().Trim();

        var dataSource = new List<Employee>();

        dataSource.AddRange(GetRates(searchValue));
        dataSource.AddRange(GetRoles(searchValue));
        dataSource.AddRange(GetEmployees(searchValue));

        employeeGridView.DataSource = dataSource.DistinctBy(employee => employee.EmployeeId);
        employeeGridView.DataBind();
    }

    private static List<Employee> GetEmployees(string searchValue)
    {
        var da = new EmployeeDataAccess();
        return da.GetEmployees().Where(emp => emp.FirstName.ToLower().Contains(searchValue) || emp.Surname.ToLower().Contains(searchValue)).ToList();
    }

    private static List<Employee> GetRoles(string searchValue)
    {
        var da = new EmployeeDataAccess();
        return da.GetEmployees().Where(emp => emp.EmployeeRoles.Any(r => r.Role.Role1.ToLower().Contains(searchValue))).ToList();
    }

    private static List<Employee> GetRates(string searchValue)
    {
        var da = new EmployeeDataAccess();
        return da.GetEmployees().Where(emp => emp.EmployeeRoles.Any(r => r.Role.BaseRate.ToString().Contains(searchValue))).ToList();
    }
}
