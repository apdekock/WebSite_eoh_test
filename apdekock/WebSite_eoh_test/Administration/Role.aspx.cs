using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.DataBase.DataAccess;
using Microsoft.AspNet.Identity;

public partial class _Role : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!UserAccess.IsAdmin(User.Identity.GetUserId()))
        {
            roleGridView.Columns[3].Visible = false;
            AddPanel.Visible = false;
        }
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        var da = new RoleDataAccess();
        roleGridView.DataSource = da.GetRoles();
        roleGridView.DataBind();
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        roleGridView.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }

    protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        roleGridView.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int roleId = Convert.ToInt32(roleGridView.DataKeys[e.RowIndex].Values[0]);

        GridViewRow row = roleGridView.Rows[e.RowIndex];
        string role = (row.FindControl("txtRole") as TextBox).Text;
        string description = (row.FindControl("txtDescription") as TextBox).Text;
        double baseRate = Double.Parse((row.FindControl("txtBaseRate") as TextBox).Text);

        var da = new RoleDataAccess();
        var employee = da.GetRoles().First(role1 => role1.RoleId == roleId);
        employee.Role1 = role;
        employee.Description = description;
        employee.BaseRate = baseRate;
        da.SaveChanges();

        roleGridView.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int roleId = Convert.ToInt32(roleGridView.DataKeys[e.RowIndex].Values[0]);

        var da = new RoleDataAccess();

        var role = da.GetRoles().First(role1 => role1.RoleId == roleId);
        da.RemoveRole(role);
        da.SaveChanges();

        this.BindGrid();
    }

    protected void Insert(object sender, EventArgs e)
    {
        var newRole = new Role { Role1 = txtRoleAdd.Text, Description = txtDescriptionAdd.Text, BaseRate = Double.Parse(txtBaseRateAdd.Text) };

        var da = new RoleDataAccess();
        da.AddRole(newRole);
        da.SaveChanges();

        txtRoleAdd.Text = String.Empty;
        txtDescriptionAdd.Text = String.Empty;
        txtBaseRateAdd.Text = String.Empty;

        this.BindGrid();
    }
}