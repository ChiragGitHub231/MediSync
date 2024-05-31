<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="HCRS_Client.Pages.Admin.ViewAppointment" %>

<asp:Content ID="ViewAppointmentHeader" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ViewAppointmentContent" ContentPlaceHolderID="AdminMasterPage" runat="server">
    <div class="container">
        <div class="page-title">
            Appointment Information
        </div>
        <div class="row appointment-content">
            <div class="col-md-6">
                <form runat="server">
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="ddlPatientName" CssClass="col-md-3 col-form-label">Patient Name</asp:Label>
                        <div class="col-md-9">
                            <asp:DropDownList runat="server" ID="ddlPatientName" CssClass="form-control" required="required" Enabled="false">
                                <asp:ListItem Value="">Select Patient</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="ddlDoctorName" CssClass="col-md-3 col-form-label">Doctor Name</asp:Label>
                        <div class="col-md-9">
                            <asp:DropDownList runat="server" ID="ddlDoctorName" CssClass="form-control" required="required" Enabled="false">
                                <asp:ListItem Value="">Select Doctor</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="txtDate" CssClass="col-md-3 col-form-label">Date</asp:Label>
                        <div class="col-md-9">
                            <input runat="server" type="date" id="txtDate" class="form-control" placeholder="Select date" required="required" disabled="disabled"
                                oninvalid="this.setCustomValidity('Please select date')" oninput="this.setCustomValidity('')" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="txtTime" CssClass="col-md-3 col-form-label">Time</asp:Label>
                        <div class="col-md-9">
                            <input runat="server" type="time" id="txtTime" class="form-control" placeholder="Select time" required="required" disabled="disabled"
                                oninvalid="this.setCustomValidity('Please select time')" oninput="this.setCustomValidity('')" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-md-9 offset-md-3">
                            <p class="mt-2"><a href="Appointments.aspx">Go Back</a></p>
                        </div>
                    </div>

                </form>
            </div>
            <div class="col-md-6 appointment-image">
                <img src="../../Assets/Images/appointment_image.jpg" alt="Appointment Image" width="350" height="250" class="img-fluid doctor-img" />
            </div>
        </div>
    </div>
</asp:Content>
