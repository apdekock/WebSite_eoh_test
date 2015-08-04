<%@ Page Title="Quotes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Quote.aspx.cs" Inherits="_Quote" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1>Quote</h1>
        <p class="lead">Search for employees, rates and roles</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Search:"></asp:Label>
                    <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-default" OnClick="btnSearch_OnClick" />
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div class="row">
        <asp:GridView ID="employeeGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId" CssClass="table table-hover table-striped" EmptyDataText="No records found.">
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
                <asp:TemplateField HeaderText="Roles & Rates" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Repeater DataSource='<%#Eval("EmployeeRoles") %>' runat="server">
                            <ItemTemplate>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label1" Text='<%# Eval("Role.Role1") %>' /> (R<asp:Label runat="server" ID="Label2" Text='<%# Eval("Role.BaseRate") %>' />)<br/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
