<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="IndustryVerification.aspx.cs" Inherits="ctuconnect.IndustryVerification" %>
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
            width:300px;
            margin:auto;
            margin-top:20px;
            position: absolute;
            margin-left:70px;
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
            min-height: 550px;
            background-color: #FFFFFF;
            width:90%;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
            padding-top:2em;
            padding-left:2em;
            padding-right:2em;                  
            margin-left:3px;
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
                        <a href="#">
                            <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Dashboard
                        </a>
                        <a class="active" href="#myaccount">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Create Partnership
                        </a>
                        <a href="#">
                            <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Referred Student
                        </a>
                        <a href="#">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            List of Industry
                        </a>
                        <a href="#">
                            <i class="fa fa-exclamation-triangle" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Dispute
                        </a>
                        <a href="#">
                            <i class="fa fa-ban" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Block List
                        </a>
                        <hr class="second" />
                        <asp:LinkButton runat="server" ID ="LinkButton1">
                            <i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>
                            Sign-out
                        </asp:LinkButton>
                    </div>
                    
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container">

                </div>
            </div>    
       
        </div>
    </div>

</asp:Content>
