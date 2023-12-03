<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="EditCoordinatorProfile.aspx.cs" Inherits="ctuconnect.EditCoordinatorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
        }

        .container {
            min-height: 550px;
            background-color: #FFFFFF;
            width: 35%;
            border: 1px solid #e1e1e1;
            padding: 2em;
            margin: 2em auto;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .txtbox {
            border: 1px solid #ced4da;
            border-radius: 5px;
            padding: 8px;
            width: 100%;
            box-sizing: border-box;
        }

        .profile-picture {
            border: 1px solid #ced4da;
            border-radius: 5px;
        }

        .btn-md {
            border: 1px solid #F7941F;
            background-color: #F7941F;
            width: 120px;
            height: 45px;
            color: #fff;
            cursor: pointer;
        }

        .btn-cancel {
            border: 1px solid #F7941F;
            background-color: #F0EBEB;
            width: 120px;
            height: 45px;
            color: #F7941F;
            cursor: pointer;
        }
    </style>





<div class="container-fluid">
    <br />
    <div class="container">
        <div class="col-12 d-flex flex-column">
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
                <div class="col-sm-12">
                    <b>Account Details</b>
                </div>         
            </div>
            <br />
            <div class="row">
                <div class="col-sm-9">
                    Last Name<br />
                    <asp:TextBox ID="txtlname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-9">
                    First Name<br />
                    <asp:TextBox ID="txtfname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-9">
                    Middle Initial<br />
                    <asp:TextBox ID="txtinitials" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>                    
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-9">
                    Email<br />
                    <asp:TextBox ID="txtemail" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>                    
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-9">
                    Password<br />
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>                    
                </div>
            </div>
            <br /><br />
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="btnSave" class="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click"/>
                </div>
                &nbsp;&nbsp;
                <div class="col-sm-2">
                    <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Back" OnClick="btnCancel_Click"/>
                </div>
            </div>
            <br />
            
            
        </div>
    </div>
    <br />   
    <br />
    <br />
    <br />
</div>
</asp:Content>
