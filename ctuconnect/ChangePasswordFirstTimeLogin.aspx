<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePasswordFirstTimeLogin.aspx.cs" Inherits="ctuconnect.ApplyJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container {
            background: #FFFFFF;
            padding: 30px;
            border-radius: 5px;
            width: 350px;
            margin: auto;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }

        .txtbox {
            border-radius: 8px;
            display: block;
            min-width: 420px;
        }

        .txtbox1 {
            border-radius: 8px;
            display: block;
            min-width: 150px;
        }

        .button {
            border: 1px #F7941F;
            border-radius: 5px;
            background-color: #F7941F;
            position: center;
            border-radius: 25px;
            width: 200px;
            color: #FFFFFF;
            height: 30px;

        }
    </style>
    <br />
    <br />
    <div class="container" id="ChangePasswordBox" runat="server">
        <div class="display-container">
            <h2><b>Change Password</b></h2>
            <br />
            <div class="form-group">
                <asp:Label runat="server" Style="left: 0px; top: 10px;">New Password</asp:Label>
                <asp:TextBox ID="Newpass" runat="server" TextMode="Password" CssClass="form-control" Width="300px" placeholder="Enter new password"></asp:TextBox>
                <asp:Label ID="NewpassErrorMessage" Font-Size="15px" runat="server" Text="New password must be different from current password!" CssClass="text-danger"></asp:Label>
                <asp:RequiredFieldValidator ID="reqnewpassword" Font-Size="15px" runat="server" ErrorMessage="Required Field!" ControlToValidate="Newpass" Display="Dynamic" CssClass="text-danger" ValidationGroup="UpdateSave"></asp:RequiredFieldValidator>
                <!-- "^(?=.*\d)(?=.*[A-Z])(?=.*\W)(?!.*\s).{8,}$"-->
                <asp:RegularExpressionValidator ID="regnewPassword" Font-Size="15px" runat="server" ErrorMessage="Password length must be minimum of 8 characters! Must be alphanumeric, atleast 1 uppercase and lowercase letter, and 1 symbol." Display="Dynamic" CssClass="text-danger" ControlToValidate="Newpass" ValidationExpression="(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w])(?!.*\s)^.{8,16}$"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Style="left: 0px; top: 10px;">Confirm New Password</asp:Label>

                <asp:TextBox ID="confirmNewPass" runat="server" TextMode="Password" CssClass="form-control" Width="300px" placeholder="Enter new confirm password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqConfirmNewPass" Font-Size="15px" runat="server" ErrorMessage="Required Field!" ControlToValidate="confirmNewPass" Display="Dynamic" CssClass="text-danger" ValidationGroup="UpdateSave"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="comNewPassword" Font-Size="15px" runat="server" ErrorMessage="The new password did not match!" ControlToCompare="Newpass" Display="Dynamic" ControlToValidate="confirmNewPass" CssClass="text-danger"></asp:CompareValidator>

            </div>
            <div class="form-group mt-5">
                <div>
                    <asp:Button ID="BtnUpdatePass" class="btn btn-success w-100" runat="server" Text="Change Password" OnClick="BtnUpdatePass_Click" ValidationGroup="UpdateSave" />                    
                </div>
            </div>

        </div>
     </div>    
</asp:Content>
