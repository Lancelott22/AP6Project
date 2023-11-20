<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="ctuconnect.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        .profile-container{
            background-color:white;
            margin-left:4%;
            padding-bottom:8px;
            border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }

        .profile-container img{
            display:block;
            width:50%;
            margin-left:auto;
            margin-right:auto;
            margin-top:auto;
            padding-top:10px;
        }

        .profile-container p{
            display:block;
            text-align:center;
            font-size: 19px;
            margin-top:7%;
        }

        .second{
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left:auto;
            margin-right:auto;
            margin-top:13%;
            margin-bottom:0%;
        }
             
        .horizontal-line {
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left:auto;
            margin-right:auto;
            margin-top:1%;
            margin-bottom:0%;
        }
                
        .nav{
            padding:10px 10px 10px 10px;
            width:350px;
            margin:auto;
            margin-top:20px;
            position: absolute;
            margin-left:25px;
        }

        .nav a{
            font-size:18px;
            font-family:'Arial Rounded MT';
            color:#000000;
            text-decoration:none;
            position:static;
            font-size: 19px;
            display: block;
            margin: 2px 15px 5px 15px ;
            padding: 0px 0px 0px 30px;
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

        .container {
            min-height: 100%;
            border-color: grey;
            width:200%;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
            padding-top:2em;
            padding-left:2em;
            padding-right:2em;                  
            margin-left:1px;
        }
       
        .card {
            background: rgb(121,101,55);
            background: linear-gradient(90deg, rgba(121,101,55,1) 0%, rgba(245,168,2,1) 40%);
            border-radius:10px;
        }
    
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column" >
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">
                    <div class="profile-container">
                        <img src="images/administratorpic.jpg" />
                        <p >Admin</p>
                        <hr class="horizontal-line" />
                        <a class="active" href="#">
                            <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Dashboard
                        </a>
                        <a href="#">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Create Partnership
                        </a>
                        <a href="#">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Industry Verification
                        </a>
                        <a href="#">
                            <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Referred Student
                        </a>
                        <hr class="horizontal-line" />
                        <a href="#">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            List of Industry
                        </a>
                        <a href="#">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            List of Interns
                        </a>
                        <a href="#">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            List of Alumni
                        </a>
                        <hr class="horizontal-line" />
                        <a href="#">
                            <i class="fa fa-exclamation-triangle" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Dispute
                        </a>
                        <a href="#">
                            <i class="fa fa-ban" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Blacklist
                        <br />
                        </a>
                        <hr class="second" />
                        <a href="#">
                            <i class="fa fa-user" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Profile
                        </a>
                        <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                            <i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Sign-out
                        </asp:LinkButton>
                    </div>
                    
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container">
                    <h2 class="title opacity-75" >Dashboard</h2>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col">
                            <div class="card text-white p-2" style="max-width: 20rem;">

                                <div class="card-body">
                                    <h4 class="card-title">Total Industry</h4>
                                    <h2 class="card-text" id="totalIndustry" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card text-white  p-2" style="max-width: 20rem;">

                                <div class="card-body">
                                    <h4 class="card-title">Total Interns</h4>
                                    <h2 class="card-text" id="totalInterns" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card text-white  p-2" style="max-width: 20rem;">

                                <div class="card-body">
                                    <h4 class="card-title">Total Alumni</h4>
                                    <h2 class="card-text" id="totalAlumni" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>    
       
        </div>
    </div>

</asp:Content>
