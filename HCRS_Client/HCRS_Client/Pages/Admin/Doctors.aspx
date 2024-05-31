<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="HCRS_Client.Pages.Admin.Doctors" %>

<asp:Content ID="DoctorHeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="DoctorContent" ContentPlaceHolderID="AdminMasterPage" runat="server">
    <div class="container">
        <form runat="server">
            <h3>Doctor Details</h3>
            <button type="button" class="btn btn-success create-btn"><a class="create-btn-link" href="CreateDoctor.aspx">Create New Doctor</a></button>

            <h4>Search Doctors</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtName">Name:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtSpecialization">Specialization:</label>
                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSpecialization_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtExperience">Experience:</label>
                    <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtExperience_TextChanged"></asp:TextBox>
                </div>
                <br />
                <asp:Label ID="errMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>

            <h4>List of Doctors</h4>
            <asp:GridView ID="DoctorGridView" runat="server" CssClass="table table-striped table-bordered table-responsive">
                <Columns>
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <a href='<%# "ViewDoctor.aspx?Id=" + Eval("Doctor_Id") %>' class="btn btn-primary">View</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <a href='<%# "UpdateDoctor.aspx?Id=" + Eval("Doctor_Id") %>' class="btn btn-success">Update</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <a href='<%# "DeleteDoctor.aspx?Id=" + Eval("Doctor_Id") %>' class="btn btn-danger">Delete</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>
    </div>
</asp:Content>
