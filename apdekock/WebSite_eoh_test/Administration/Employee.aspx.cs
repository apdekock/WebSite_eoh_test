using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.DataBase.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

public partial class _Employee : Page
{
    public static List<string> Roles
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!UserAccess.IsAdmin(User.Identity.GetUserId()))
        {
            employeeGridView.Columns[3].Visible = false;
            AddPanel.Visible = false;
        }
        if (!this.IsPostBack)
        {
            PopulateRoles();
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        var da = new EmployeeDataAccess();
        employeeGridView.DataSource = da.GetEmployees();
        employeeGridView.DataBind();
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        PopulateRoles();

        employeeGridView.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }

    private static void PopulateRoles()
    {
        var db = new RoleDataAccess();
        Roles = db.GetRoles().Select(r => r.Role1).ToList();
    }

    protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        employeeGridView.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int employeeId = Convert.ToInt32(employeeGridView.DataKeys[e.RowIndex].Values[0]);

        GridViewRow row = employeeGridView.Rows[e.RowIndex];
        string firstname = (row.FindControl("txtFirstName") as TextBox).Text;
        string surname = (row.FindControl("txtSurname") as TextBox).Text;

        var da = new EmployeeDataAccess();
        var employee = da.GetEmployees().First(emp => emp.EmployeeId == employeeId);
        employee.FirstName = firstname;
        employee.Surname = surname;
        da.SaveChanges();

        employeeGridView.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int employeeId = Convert.ToInt32(employeeGridView.DataKeys[e.RowIndex].Values[0]);

        var da = new EmployeeDataAccess();
        var employee = da.GetEmployees().FirstOrDefault(emp => emp.EmployeeId == employeeId);
        da.RemoveEmployee(employee);
        da.SaveChanges();

        this.BindGrid();
    }

    protected void Insert(object sender, EventArgs e)
    {
        var newEmployee = new Employee { FirstName = txtFirstNameAdd.Text, Surname = txtSurnameAdd.Text };

        var da = new EmployeeDataAccess();
        da.AddEmployee(newEmployee);
        da.SaveChanges();

        var hubContext = GlobalHost.ConnectionManager.GetHubContext<StatusHub>();
        hubContext.Clients.All.broadcastMessage("New employee added! (This is a push message from Signal-R, open other web clients and you will receive this message on both clients.)");

        txtFirstNameAdd.Text = String.Empty;
        txtSurnameAdd.Text = String.Empty;

        this.BindGrid();
    }

    protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var dataItem = e.Item.DataItem;
        if (dataItem != null)
        {
            if (Roles != null)
                Roles.Remove(((EmployeeRole)dataItem).Role.Role1);
        }

        var ddl = (DropDownList)e.Item.FindControl("ddlRoles");
        if (ddl != null)
        {
            foreach (var role in Roles)
            {
                ddl.Items.Add(new ListItem(role, role));
            }
        }
    }

    protected void RemoveItem(object sender, ImageClickEventArgs e)
    {
        var imageButton = (ImageButton)sender;
        if (imageButton == null) return;
        var panel = (Panel)imageButton.Parent;
        if (panel == null) return;
        var roleLabel = (Label)panel.FindControl("Label1");
        if (roleLabel == null) return;

        var employeeDataAccess = new EmployeeDataAccess();
        var employees = employeeDataAccess.GetEmployees();
        var employee = employees[employeeGridView.EditIndex];

        var daRoles = new RoleDataAccess();
        var role = daRoles.GetRole(roleLabel.Text);

        var daEmployeeRoles = new EmployeeRoleDataAccess();
        daEmployeeRoles.RemoveRole(employee, role);
        daEmployeeRoles.SaveChanges();

        Roles.Add(role.Role1);
        this.BindGrid();
    }

    protected void AddItem(object sender, ImageClickEventArgs e)
    {
        var imageButton = (ImageButton)sender;
        if (imageButton == null) return;
        var repeater = imageButton.Parent;
        var ddl = (DropDownList)repeater.FindControl("ddlRoles");
        if (ddl == null) return;
        var selectedItem = ddl.SelectedItem;
        if (selectedItem == null) return;

        var employeeDataAccess = new EmployeeDataAccess();
        var employees = employeeDataAccess.GetEmployees();
        var employee = employees[employeeGridView.EditIndex];

        var daRoles = new RoleDataAccess();
        var role = daRoles.GetRole(selectedItem.Value);

        var daEmployeeRoles = new EmployeeRoleDataAccess();
        daEmployeeRoles.AddRole(employee.EmployeeId, role.RoleId);
        daEmployeeRoles.SaveChanges();
        this.BindGrid();
    }
}