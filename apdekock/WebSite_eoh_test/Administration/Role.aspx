<%@ Page Title="Roles" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Role.aspx.cs" Inherits="_Role" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <div class="jumbotron">
        <h1>Role</h1>
        <p class="lead">Maintain roles</p>
    </div>


    <div class="row">
        <asp:GridView ID="roleGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="RoleId"
            OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" CssClass="table table-hover table-striped"
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added.">
            <Columns>
                <asp:TemplateField HeaderText="Role" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role1") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtRole" runat="server" Text='<%# Eval("Role1") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Base Rate" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblBaseRate" runat="server" Text='<%# Eval("BaseRate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBaseRate" onkeypress="return isNumber(event)" runat="server" Text='<%# Eval("BaseRate") %>'></asp:TextBox>
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
                            <asp:Label runat="server" AssociatedControlID="txtRoleAdd" CssClass="col-md-2 control-label">Role</asp:Label>
                            <asp:TextBox ID="txtRoleAdd" runat="server" Width="140" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRoleAdd"
                                CssClass="text-danger" ErrorMessage="The role field is required." />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtDescriptionAdd" CssClass="col-md-2 control-label">Description</asp:Label>
                            <asp:TextBox ID="txtDescriptionAdd" runat="server" Width="140" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtBaseRateAdd" CssClass="col-md-2 control-label">Base Rate</asp:Label>
                            <asp:TextBox ID="txtBaseRateAdd" onkeypress="return isNumber(event)" runat="server" Width="140" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBaseRateAdd"
                                CssClass="text-danger" ErrorMessage="The rate field is required." />
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="return ($('[id$=txtRoleAdd]').val().trim() !== '' && $('[id$=txtBaseRateAdd]').val().trim() !== '');" class="btn btn-default" OnClick="Insert" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
