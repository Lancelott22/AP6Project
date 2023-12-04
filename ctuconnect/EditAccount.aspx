<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="ctuconnect.EditAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
    body {
        background-color: #f8f9fa;
        font-family: 'Poppins', sans-serif;
    }

    .container-fluid {
        margin-top: 20px;
    }

    .container {
        background-color: #fff;
        border: 1px solid #ddd;
        border-radius: 8px;
        padding: 20px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        width: 60%; /* Adjusted width */
        margin: 0 auto; /* Center the container */
    }

    .profile-picture {
        border-radius: 50%;
        border: 2px solid #F7941F;
    }

    .txtbox {
        border: 1px solid #ced4da;
        border-radius: 5px;
        padding: 8px;
        margin-bottom: 10px;
        width: 100%;
    }

    .btn-md {
        border: 1px solid #F7941F;
        background-color: #F7941F;
        width: 120px;
        height: 45px;
        color: #fff;
        cursor: pointer;
        transition: background-color 0.3s;
    }

    .btn-md:hover {
        background-color: #d17a00;
    }

    .btn-cancel {
        border: 1px solid #F7941F;
        background-color: #F0EBEB;
        width: 120px;
        height: 45px;
        color: #F7941F;
        cursor: pointer;
        transition: background-color 0.3s, color 0.3s;
    }

    .btn-cancel:hover {
        background-color: #F7941F;
        color: #fff;
    }

    .container2 {
        margin-top: 20px;
    }

    .upper-section,
    .lower-section {
        border: 1px solid #ddd;
        border-radius: 8px;
        padding: 15px;
        margin-bottom: 20px;
        background-color: #fff;
    }

    .row {
        margin-bottom: 15px;
    }

    .col-sm-3 {
        font-weight: bold;
        font-size: 16px;
    }

    .col-sm-9 {
        margin-bottom: 10px;
    }

    .validation-error {
        color: #dc3545; 
        font-size: 14px;
        margin-top: 5px;
    }
    </style>





<div class="container-fluid">
    <br />
    <div class="container">
        <div class="col-12 d-flex flex-column">
            <div class="upper-section">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="lblProfilePicture" runat="server" Text="Profile Picture:"></asp:Label>
                        <asp:FileUpload ID="fileUploadProfilePicture" runat="server" />
                        <br />
                        <asp:Image ID="imgProfilePicture" runat="server" CssClass="profile-picture" height="144px" Width="144px"/>
                        <br />
                        <asp:Button ID="btnUploadPicture" runat="server" Text="Upload" OnClick="btnUploadPicture_Click" />
                        <br />
                    </div>   
                </div>
                <br />
                <div class="row">
                    <div class="col-4">
                        Last Name *<br />
                        <asp:TextBox ID="txtlname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        First Name *<br />
                        <asp:TextBox ID="txtfname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        Middle Initial *<br />
                        <asp:TextBox ID="txtinitials" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>                    
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-4">
                        Contact Number *<br />
                        <asp:TextBox ID="txtcontact" runat="server" CssClass="txtbox" Width="400px" Height="30px" Text="09"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ValidationGroup="Group1" ControlToValidate="txtcontact" InitialValue="09" ErrorMessage="Contact Number is required." Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revContactNumber" runat="server" ControlToValidate="txtcontact" ErrorMessage="Enter a valid Philippine phone number starting with 09." Display="Dynamic" ValidationExpression="^09\d{9}$" CssClass="validation-error"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-8">
                        Address *<br />
                        <asp:TextBox ID="txtaddress" runat="server" CssClass="txtbox" Width="600px" Height="30px"></asp:TextBox>                    
                    </div>
                </div>
                <br />
                
            </div>

            <div class="lower-section">
                <div class="row">
                    <div class="col-12">
                        CTU Email *<br />
                        <asp:TextBox ID="txtctuemail" runat="server" CssClass="txtbox" Width="700px" Height="30px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCTUEmail" runat="server" ControlToValidate="txtctuemail" ValidationGroup="Group2" ErrorMessage="CTU Email is required." Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCTUEmail" runat="server" ControlToValidate="txtctuemail" ErrorMessage="Enter a valid CTU Email address (e.g., yourname@ctu.edu.ph)." Display="Dynamic" ValidationExpression="\b[A-Za-z0-9._%+-]+@ctu\.edu\.ph\b" CssClass="validation-error"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        Personal Email *<br />
                        <asp:TextBox ID="txtPersonalEmail" runat="server" CssClass="txtbox" Width="700px" Height="30px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPersonalEmail" runat="server" ControlToValidate="txtPersonalEmail" ValidationGroup="Group2" ErrorMessage="Personal Email is required." Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPersonalEmail" runat="server" ControlToValidate="txtPersonalEmail" ErrorMessage="Enter a valid Gmail address (e.g., yourname@gmail.com)." Display="Dynamic" ValidationExpression="\b[A-Za-z0-9._%+-]+@gmail\.com\b" CssClass="validation-error"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvGmailValidation" runat="server" ControlToValidate="txtPersonalEmail" OnServerValidate="ValidateGmailAccount" ErrorMessage="The provided Gmail account is not valid or active." Display="Dynamic" CssClass="validation-error"></asp:CustomValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-1">
                        <asp:Button ID="btnSave" class="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
    
                    <div class="col-sm-2">
                        <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Back" OnClick="btnCancel_Click" CausesValidation="true"/>
                    </div>
                </div>
            </div>
            

        </div>
    </div>
    
    <br />
    <br />
</asp:Content>
