<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="EditIndustryProfile.aspx.cs" Inherits="ctuconnect.EditIndustryProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .container {
        min-height: 550px;
        background-color: #FFFFFF;
        width:55%;
        border: 1px solid #FFFFFF;
        padding-top:2em;
        padding-left:2em;
        padding-right:2em;
        font-size:20px;
  
    }

    .txtbox{
        border-radius: 5px;


    }

    .btn-md{
        border: 1px #F7941F;
        background-color: #F7941F;
        position:center;
        width: 120px;
        height:45px;
    }

    .btn-cancel{
        border: 1px solid #F7941F;
        background-color: #F0EBEB;
        position:center;
        width: 120px;
        height:45px;
        color:  #F7941F;
    }

    .container2{
        min-height: 550px;
        width:55%;
        padding-top:2em;
        padding-left:400px;
        padding-right:2em;
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
                    <b>Industry Details</b>
                </div>         
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Name
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Location
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtlocation" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="row">
                    <div class="col-sm-12">
                        <b>Contact Person</b>
                    </div>         
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    First Name
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtfname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Last Name
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtlname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Position
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtposition" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Contact Number
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtContactNum" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Email
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtContactEmail" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
        </div>
    </div>
    <br />
    <div class="container2">
        <div class="col-12 d-flex flex-column">
            <div class="row">
                <div class="col-sm-3">
                    <asp:Button ID="btnSave" class="btn btn-primary btn-md" runat="server" Text="Save" OnClick="btnSave_Click"/>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="col-sm-2">
                    <asp:Button ID="btnCancel" class="btn btn-primary btn-md btn-cancel" runat="server" Text="Back" OnClick="btnCancel_Click"/>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</div>
</asp:Content>
