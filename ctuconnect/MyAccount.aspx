<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="ctuconnect.MyAccount1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <style>
        
        .nav{
            padding:10px 10px 10px 10px;
            width:200px;
            margin:auto;
            margin-top:auto;
          
        }

        .nav a{
            font-size:18px;
            font-family:'Arial Rounded MT';
            color:#000000;
            padding-left:3px;
             text-decoration:none;
        }

        .nav a.active{
            background-color:rgb(255, 194, 102);
            border-radius:10px;
            min-height:10px;
            
        }

        .nav a:hover{
            background-color:rgb(255, 194, 102);
            border-radius:10px;
            min-height:10px;
            
        }

        .container2{
           margin: 15px 0 0 0;
        }

        .top {
          height: 200px;
          background-color: #F7941F;
          width:80%;
          
        }


        .bottom {
          min-height: 180px;
          width:80%;
          background-color: #ffffff;
          padding-left:2em;
          
        }

        .profile {
          
          border-radius: 50px;
          position: relative;
          top: -50px;
          
          
        }

        .line{
            height:2px;
            width:95%;
            background-color:#881A30;
            color:#881A30;
            position:center;
        }

        .btn-md{
            border: 1px #881A30;
            background-color: #881A30;
            position:center;
            width: 120px;
            height:45px;
        }



    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column" >
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">

                    <a class="active" href="#myaccount">
                            <i class='bx bx-user-circle icon' ></i>
                            <span class="text nav-text">My Account</span>
                    </a>
                    <a href="Resume.aspx">
                            <i class='bx bx-file-blank icon' ></i>
                            <span class="text nav-text">Resume</span>
                    </a>
                    <a href="MyJobApplication.aspx">
                            <i class='bx bx-layer icon' ></i>
                            <span class="text nav-text">Application</span>
                    </a>
                    <a href="#settings">
                            <i class='bx bx-cog icon' ></i>
                            <span class="text nav-text">Account Settings</span>
                    </a>
                    <a href="#help">
                            <i class='bx bx-help-circle icon' ></i>
                            <span class="text nav-text">Help</span>
                    </a>
                    <hr style="height:2px;border-width:0;color:#881A30;background-color:#881A30">
                    <a href="#signout">
                            <i class='bx bx-log-out icon' ></i>
                            <span class="text nav-text">Sign-out</span>
                    </a>
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="top"></div>
                <div class="bottom">
                    <center>
                    
                        <asp:Image ID="profileImage" CssClass="profile" Width="100px" Height="100px" runat="server" />
                    </center>
                    <div class="row">
                        <div class="col-sm-3">
                            Full Name:
                        </div>
                        <div class="col-sm-9">
                           <asp:Label ID="disp_name" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <hr class="line"/>
                    <div class="row">
                        <div class="col-sm-3">
                            Student ID:
                        </div>
                        <div class="col-sm-9">
                            <asp:Label ID="disp_studentID" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <hr class="line"/>
                    <div class="row">
                        <div class="col-sm-3">
                            Student Status:
                        </div>
                        <div class="col-sm-9">
                            <asp:Label ID="disp_studentStatus" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <hr class="line"/>
                    <div class="row">
                        <div class="col-sm-3">
                            Course:
                        </div>
                        <div class="col-sm-9">
                            <asp:Label ID="disp_course" runat="server" Text=""></asp:Label>  
                        </div>
                    </div>
                    <hr class="line"/>
                        <div class="row">
                            <div class="col-sm-3">
                                Resume:
                            </div>
                            <div class="col-sm-9">
                                <asp:Label ID="lblResume" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    <br /><br />
                </div>
                <div class="container2">                 
                            <asp:Button ID="btnEdit" class="btn btn-primary btn-md" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                 </div>
            </div>
           
        </div>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>