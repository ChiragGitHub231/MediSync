<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ViewPatient.aspx.cs" Inherits="HCRS_Client.Pages.Admin.ViewPatient" %>

<asp:Content ID="ViewPatientHeader" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ViewPatientContent" ContentPlaceHolderID="AdminMasterPage" runat="server">
    <div class="container">
        <div class="page-title">
            Patient Information
        </div>
        <div class="row">
            <div class="col-md-6">
                <form runat="server">
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-3 col-form-label">Name</asp:Label>
                        <div class="col-md-9">
                            <input runat="server" type="text" id="txtName" class="form-control" placeholder="Enter name" required="required"
                                oninvalid="this.setCustomValidity('Name is required')" oninput="this.setCustomValidity('')" disabled="disabled" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="txtDOB" CssClass="col-md-3 col-form-label">Date of Birth</asp:Label>
                        <div class="col-md-9">
                            <input runat="server" type="date" id="txtDOB" class="form-control" placeholder="Select date" required="required"
                                oninvalid="this.setCustomValidity('Please select date')" oninput="this.setCustomValidity('')" disabled="disabled" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="gender" class="col-md-3 col-form-label">Gender</label>
                        <div class="col-md-9">
                            <div class="form-check form-check-inline">
                                <input runat="server" type="radio" id="male" name="gender" value="Male" class="form-check-input" required="required"
                                    oninvalid="this.setCustomValidity('Please select gender')" oninput="this.setCustomValidity('')" disabled="disabled"/>
                                <label for="male" class="form-check-label">Male</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input runat="server" type="radio" id="female" name="gender" value="Female" class="form-check-input" required="required"
                                    oninvalid="this.setCustomValidity('Please select gender')" oninput="this.setCustomValidity('')" disabled="disabled" />
                                <label for="female" class="form-check-label">Female</label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="txtAge" class="col-md-3 col-form-label">Age</label>
                        <div class="col-md-9">
                            <input runat="server" type="text" id="txtAge" class="form-control" placeholder="Enter age" required="required"
                                oninvalid="this.setCustomValidity('Age is required')" oninput="this.setCustomValidity('')" disabled="disabled" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="txtContact" class="col-md-3 col-form-label">Contact No</label>
                        <div class="col-md-9">
                            <input runat="server" type="tel" id="txtContact" class="form-control" pattern="[1-9]{1}[0-9]{9}" title="Ex. 1234567890" placeholder="Enter contact number" required="required"
                                oninvalid="this.setCustomValidity('Please enter 10 digit valid contact no')" oninput="this.setCustomValidity('')" disabled="disabled" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="textEmail" class="col-md-3 col-form-label">Email</label>
                        <div class="col-md-9">
                            <input runat="server" type="email" id="textEmail" class="form-control" placeholder="Enter email" required="required"
                                pattern="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                                title="demo@gmail.com"
                                oninvalid="this.setCustomValidity('Please enter a valid email address')"
                                oninput="this.setCustomValidity('')" disabled="disabled" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="txtAddress" class="col-md-3 col-form-label">Address</label>
                        <div class="col-md-9">
                            <input runat="server" type="text" id="txtAddress" class="form-control" placeholder="Enter address" required="required"
                                oninvalid="this.setCustomValidity('Address is required')" oninput="this.setCustomValidity('')" disabled="disabled" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-md-9 offset-md-3">
                            <p class="mt-2"><a href="Patients.aspx">Go Back</a></p>
                        </div>
                    </div>

                </form>
            </div>
            <div class="col-md-6 sign-in-image">
                <img src="../../../Assets/Images/patient_image.jpg" alt="Sign In Image" width="480" height="480" class="img-fluid" />
            </div>
        </div>
    </div>
</asp:Content>
