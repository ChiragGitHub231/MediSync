<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="HCRS_Client.Pages.Admin.Patients" %>

<asp:Content ID="PatientHeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="PatientContent" ContentPlaceHolderID="AdminMasterPage" runat="server">
    <div class="container">
        <form runat="server">
            <h3>Patients Details</h3>
            <button type="button" class="btn btn-success create-btn"><a class="create-btn-link" href="CreatePatient.aspx">Create New Patient</a></button>
            
            <h4>Search Patients</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtName">Name:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtName_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtAddress">Address:</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtAddress_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <label for="txtFromDate">From Date:</label>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <label for="txtToDate">To Date:</label>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <br />
                    <asp:Button ID="searchBtn" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="searchBtn_Clicked" />
                </div>
                <br />
                <asp:Label ID="errMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
            
            <h4>List of Patients</h4>
            <asp:GridView ID="PatientGridView" runat="server" CssClass="table table-striped table-bordered table-responsive">
                <Columns>
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <a href='<%# "ViewPatient.aspx?Id=" + Eval("Patient_Id") %>' class="btn btn-primary">View</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <a href='<%# "UpdatePatient.aspx?Id=" + Eval("Patient_Id") %>' class="btn btn-success">Update</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <a href='<%# "DeletePatient.aspx?Id=" + Eval("Patient_Id") %>' class="btn btn-danger">Delete</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>
    </div>
</asp:Content>
