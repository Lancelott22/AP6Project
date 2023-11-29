<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="ctuconnect.MyAccount1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        
        .nav{
            padding:10px 10px 10px 10px;
            width:200px;
            margin:auto;
            margin-top:20px;
            position: absolute;
            margin-left:70px;
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

        .student-details{
            min-height: 180px;
            background-color: #ffffff;
            padding-left:2em;
            width:580px;
            float:left;
            margin-left:10px;
            padding-top:2em;
            font-family: 'Poppins', sans-serif;
        }

        .student-details2{
            min-height: 180px;
            background-color: #ffffff;
            padding-left:2em;
            width:580px;
            float:left;
            margin-left:8px;
            padding-top:2em;
            font-family: 'Poppins', sans-serif;
        }

        .student-container{
            width:80%;
            margin-top:30px;
            font-size:18px;
        }

        .profile {
          
          border-radius: 100px;
          position: relative;
          top: -75px;
          
          
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

        .pen-icon {
            display: inline-block;
            cursor: pointer;
            font-size: 20px;
            color: #881A30;
            text-decoration: none;
            transition: color 0.3s;
            justify-content:center;
            padding-right:10px;
            padding-bottom:10px;
        }

        /* Hover effect */
        .pen-icon:hover {
            color: orange;
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
                    <a href="Report.aspx">
                        <i class='bx bxs-flag-alt'></i>
                        <span class="text nav-text">Report</span>
                    </a>
                    <hr style="height:2px;border-width:0;color:#881A30;background-color:#881A30">
                    <asp:LinkButton runat="server" ID ="SignOut" OnClick="SignOut_Click" >
                       <i class='bx bx-log-out icon' ></i>
                        Sign-out
                    </asp:LinkButton>
                   
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="top"></div>
                <div class="bottom">
                    <center>
                    
                        <asp:Image ID="profileImage" CssClass="profile" Width="150px" Height="150px" runat="server" />
                    </center>
                    <div class="edit" style="text-align:right;">
                        <a href="EditAccount.aspx" class="pen-icon"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></a>
                    </div>
                </div>
                
                <div class="student-container">
                <div class="row">
                    <div class="col-6">
                        <div class="student-details">
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Full Name:
                                </div>
                                <div class="col-sm-8">
                                   <asp:Label ID="disp_name" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr class="line"/>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Student ID:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_studentID" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr class="line"/>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Student Status:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_studentStatus" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr class="line"/>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Course:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_course" runat="server" Text=""></asp:Label>  
                                </div>
                            </div>
                            <hr class="line"/>
                                <div class="row">
                                    <div class="col-sm-4" style="font-weight:bold;">
                                        Resume:
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:Label ID="lblResume" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            <br /><br />
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="student-details2">
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Contact Number:
                                </div>
                                <div class="col-sm-8">
                                   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr class="line"/>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Address:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr class="line"/>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Year Graduated:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            
                            <br /><br />
                        </div>
                    </div>
                </div>
                </div>
            </div>
           
        </div>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>