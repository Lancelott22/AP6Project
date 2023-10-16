<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="ctuconnect.EditAccount" %>
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
            padding-left:22em;
            padding-right:2em;
            padding-top:1em;
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
                    <asp:Image ID="imgProfilePicture" runat="server" CssClass="profile-picture" />
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
                    First Name
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtfname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Middle Initial
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtinitials" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>                    
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Student Status
                </div>
                <div class="col-sm-9">
                    <asp:DropDownList ID="drpStudentStatus" CssClass="txtbox" runat="server" Width="400px" Height="30px">
                    <asp:ListItem>Intern</asp:ListItem>
                    <asp:ListItem>Alumni</asp:ListItem>
                    <asp:ListItem>Withdraw</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    Resume
                </div>
                <div class="col-sm-9">
                    <asp:FileUpload ID="resumeUpload" runat="server" Width="300px"/>
                </div>
            </div>
            <br />
            
        </div>
    </div>
    <br />
    <div class="container2">
        <div class="row">
            <div class="col-2 d-flex flex-column">
                <asp:Button ID="btnSave" class="btn btn-primary btn-md" runat="server" Text="Save" OnClick="btnSave_Click"/>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <div class="col-2 d-flex flex-column">
                <asp:Button ID="btnCancel" class="btn btn-primary btn-md btn-cancel" runat="server" Text="Back" OnClick="btnCancel_Click"/>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</div>
</asp:Content>
