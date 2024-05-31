<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HCRS_Client.Pages.Admin.Home" MasterPageFile="~/Pages/Admin/Admin.master" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="AdminMasterPage" runat="server">
    <div class="card-container">
        <div class="card">
            <i class="fa fa-wheelchair fa-2x" style="font-size: 40px;"></i>
            <span class="nav-text">Patients</span>
            <asp:Label Text="0" runat="server" ID="PatientCount" />
        </div>

        <div class="card">
            <i class="fa fa-user-md fa-2x" style="font-size: 40px;"></i>
            <span class="nav-text">Doctors</span>
            <asp:Label Text="0" runat="server" ID="DoctorCount" />
        </div>

        <div class="card">
            <i class="fa fa-calendar fa-2x" style="font-size: 40px;"></i>
            <span class="nav-text">Appointments</span>
            <asp:Label Text="0" runat="server" ID="AppointmentCount" />
        </div>
    </div>

    <div class="container">
        <form runat="server">
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
            <p class="mt-2"><a href="Patients.aspx">View More</a></p>

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
            <p class="mt-2"><a href="Doctors.aspx">View More</a></p>

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
            <p class="mt-2"><a href="Appointments.aspx">View More</a></p>
        </form>
    </div>
</asp:Content>
