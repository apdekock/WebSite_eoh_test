<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="_Employee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Employee</h1>
        <p class="lead">Maintain employee records</p>
    </div>

    <div class="row">
        <asp:GridView ID="employeeGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId"
            OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" CssClass="table table-hover table-striped"
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added.">
            <Columns>
                <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Surname" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("Surname") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSurname" runat="server" Text='<%# Eval("Surname") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Roles" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Repeater DataSource='<%#Eval("EmployeeRoles") %>' runat="server">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label1" Text='<%# Eval("Role.Role1") %>'/><br/>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Repeater DataSource='<%#Eval("EmployeeRoles") %>' OnItemDataBound="OnItemDataBound" runat="server">
                            <ItemTemplate>          
                                <div class="form-group">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("Role.Role1") %>' />
                                        <asp:ImageButton runat="server" AlternateText="Remove" CssClass="btn" CausesValidation="False" ImageUrl="~/images/delete.png" OnClick="RemoveItem" />
                                    </asp:Panel>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlRoles" AutoPostBack="False" runat="server"></asp:DropDownList>
                                <asp:ImageButton runat="server" AlternateText="Add" CssClass="btn" CausesValidation="False" ImageUrl="~/images/add.png" OnClick="AddItem" />
                            </FooterTemplate>
                        </asp:Repeater>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Maintain" ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" CausesValidation="False" />
            </Columns>
        </asp:GridView>

        <asp:Panel ID="AddPanel" runat="server">
            <div class="row">
                <div class="col-md-8">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtFirstNameAdd" CssClass="col-md-2 control-label">Name</asp:Label>
                            <asp:TextBox ID="txtFirstNameAdd" runat="server" Width="140" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstNameAdd"
                                CssClass="text-danger" ErrorMessage="The name field is required." />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtSurnameAdd" CssClass="col-md-2 control-label">Surname</asp:Label>
                            <asp:TextBox ID="txtSurnameAdd" runat="server" Width="140" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSurnameAdd"
                                CssClass="text-danger" ErrorMessage="The surname field is required." />
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="return ($('[id$=txtFirstNameAdd]').val().trim() !== '' && $('[id$=txtSurnameAdd]').val().trim() !== '');" class="btn btn-default" OnClick="Insert" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
