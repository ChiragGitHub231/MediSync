<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="HCRS_Client.Pages.Admin.Appointments" %>

<asp:Content ID="AppointmentHeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="AppointmentContent" ContentPlaceHolderID="AdminMasterPage" runat="server">
    <div class="container">
        <form runat="server">
            <h3>Appointments Details</h3>
            <button type="button" class="btn btn-success create-btn"><a class="create-btn-link" href="CreateAppointment.aspx">Create New Appointment</a></button>

            <h4>Search Appointments</h4>
            <div class="row">
                <div class="col-md-3">
                    <label for="txtPatientName">Patient Name:</label>
                    <asp:TextBox ID="txtPatientName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPatientName_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txtDoctorName">Doctor Name:</label>
                    <asp:TextBox ID="txtDoctorName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDoctorName_TextChanged"></asp:TextBox>
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

            <h4>List of Appointments</h4>
            <asp:GridView ID="AppointmentGridView" runat="server" CssClass="table table-striped table-bordered table-responsive">
                <Columns>
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <a href='<%# "ViewAppointment.aspx?Id=" + Eval("Appointment_Id") %>' class="btn btn-primary">View</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <a href='<%# "UpdateAppointment.aspx?Id=" + Eval("Appointment_Id") %>' class="btn btn-success">Update</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <a href='<%# "DeleteAppointment.aspx?Id=" + Eval("Appointment_Id") %>' class="btn btn-danger">Delete</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>
    </div>
</asp:Content>
