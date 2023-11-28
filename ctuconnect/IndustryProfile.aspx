<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="IndustryProfile.aspx.cs" Inherits="ctuconnect.IndustryProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha256-rqjJMwTqpcNs7L4lL7v5Et5Et4aBnaeUpK2cnFXa4UE=" crossorigin="anonymous" />

    <style>
     @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
    .profile-container {
        font-family: 'Poppins', sans-serif;
        max-width: 260px;
        height: auto;
        padding: 10px;
        background-color: white;
        margin-left: 4%;
        margin-bottom: 20px;
    }

    @media (max-width: 790px) {
        .profile-container, .sidemenu-container {
            max-width: 50%;
            max-height: auto;
            padding: 5px 5px 5px 5px;
        }
    }

    .profile-container img{
        display:block;
        width:60%;
        margin-left:auto;
        margin-right:auto;

    }
    .profile-container p{
         display:block;
         text-align:center;
         font-size: 19px;
        margin-top:7%;
    }
    .sidemenu-container{
        font-family: 'Poppins', sans-serif;
        width:253px;
        min-height:280px;
        background-color:white;
        /*margin-top:22%;*/
        padding-top:4px;
        padding-bottom:4px;
        margin-bottom:10%;
        margin-left:2%;
        border-radius: 20px;
        border: 2px ;
        box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        
    }
   
        .sidemenu-container a {
            position:static;
            border-radius: 25px;
            color: black;
            text-decoration: none;
            font-size: 19px;
            display: flex;
            margin: 10px 15px 5px 15px ;
            padding: 0px 0px 0px 20px;
            align-items:center;
        }
        .sidemenu-container a.active{
             background-color:#F6B665;
            color:#606060;
        }
        .sidemenu-container a:hover{
            background-color:#fcd49a;
            color:#606060;
            margin: 10px 15px 5px 15px ;
            padding: 0px 0px 0px 20px;
        }
        .display-container{
            font-family: 'Poppins', sans-serif;
            font-size:16px;
            background-color:white; 
            width:1000px;
            top:0;
            bottom:0;
            padding: 2% 2% 0% 2%;
            overflow: auto;
            /*background-color:white;*/
            height:350px;
            /*overflow: auto;
            float:left;
            margin-left:25%;
            position:relative;
            padding: 4% 0% 0% 6%;*/
        }
        
        .display-container {
            min-width: 70%;
        }
        
        .display-container .title{
            font-size:25px;
            font-weight:500;
            position:relative;
            margin-bottom:3%;
            padding-bottom:4px;
        }
        .display-container .title:before{
            content:'';
            position:absolute;
            height:2px;
            width:70px;
            bottom:0;
            background-color: #881A30;

        }

        .content {
            height: auto;
            width: 97%;
            margin-left: 2%;
            margin-right: 2%;
            padding: 0px 0px 0px 0px;
        }

        .fa {
           width:20px;
           margin-right: 19px; 
        }

        @media (max-width: 790px) {
            .profile {
                max-width: 20%;
            }
        }
         
        .profile-pic {
            border-radius: 100px;
            position: center;
        }

        .industry-name{
            font-weight:bold;
            font-size:20px;
            text-align:center;

        }

        .industry-profile{
            position:center;
        }

        .topnav {
          overflow: hidden;
  
        }

        .topnav a {
          float: left;
          display: block;
          color: black;
          text-align: center;
          padding: 14px 16px;
          text-decoration: none;
          font-size: 22px;
          border-bottom: 3px solid transparent;

        }

        .topnav a:hover {
          border-bottom: 3px solid #881A30;
        }

        .topnav a.active {
          border-bottom: 3px solid #881A30;
          color:#881A30;
        }

        .display-industry{
            font-family: 'Poppins', sans-serif;
            font-size:16px;
            background-color:white; 
            width:1000px;
            top:0;
            bottom:0;
            padding: 2% 2% 0% 2%;
            overflow: visible;
            height:500px;
            min-width:70%;
        }

        .line{
            height:2px;
            width:100%;
            background-color:#881A30;
            color:#881A30;
            position:center;
        }
        
        .dropdown-item {
            padding: 8px;
            text-decoration: none;
            color: #333;
            display: block;
        }

        .dropdown-item:hover{
            background-color:rgb(255, 194, 102);
            border-radius:10px;
            min-height:5px;
            text-decoration:none;
        }


        .pen-icon {
            display: inline-block;
            cursor: pointer;
            font-size: 20px;
            color: #881A30;
            text-decoration: none;
            transition: color 0.3s;
        }

        /* Hover effect */
        .pen-icon:hover {
            color: orange;
        }
         
       
</style>

    <asp:Table ID="Table1" runat="server" CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align: top; height: 200px;">
                <div class="profile-container">
                    <asp:Image ID="industryImage1" runat="server" />
                    <center><b>
                        <asp:Label ID="disp_industryName" CssClass="disp_industryName" runat="server" Text=""></asp:Label></b></center>
                    <center>
                        <p style="font-size: 14px;">Account ID: <b>
                            <asp:Label ID="disp_accID" runat="server" Text=""></asp:Label></b></p>
                    </center>
                </div>
            </asp:TableCell>
            <asp:TableCell RowSpan="2" Style="padding:0px 10px 0px 25px; vertical-align:top;">
                <div class="display-container">

                    <div class="row">
                        <div class="col-12">
                            <center>
                            <asp:Image ID="industryProfile" CssClass="profile-pic" Width="150px" Height="150px" runat="server" />
                            </center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-12 industry-name">
                           <asp:Label ID="disp_name" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br /><br />
                    <div class="row">
                        <div class="col-lg-12 order-1 order-lg-2 topnav">
                            <a class="active" href="#about">About</a>
                            <a href="#">Jobs</a>
                            <a href="#">Reviews</a>
                        </div>
                    </div>
                </div>
                <br />
                <div class="display-industry">
                    <div class="row">
                        <div class="col-sm-11">
                            <h3 style="font-weight:bold; color:#881A30;">Industry Details</h3>
                        </div>
                        <div class="col-sm-1" style="text-align:right;">  
                            <a href="EditIndustryProfile.aspx" class="pen-icon"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></a>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                            Name
                        </div>
                        <div class="col-sm-9" style="font-size:20px">
                           <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                            Location
                        </div>
                        <div class="col-sm-9" style="font-size:20px">
                           <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                            Email
                        </div>
                        <div class="col-sm-9" style="font-size:20px">
                           <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <hr class="line"/>
                    <h3 style="font-weight:bold; color:#881A30;">Contact Person</h3><br />
                    <div class="row">
                        <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                            Name
                        </div>
                        <div class="col-sm-9" style="font-size:20px">
                           <asp:Label ID="contactName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                            Position
                        </div>
                        <div class="col-sm-9" style="font-size:20px">
                           <asp:Label ID="contactPosition" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                            Contact Number
                        </div>
                        <div class="col-sm-9" style="font-size:20px">
                           <asp:Label ID="contactNumber" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                            Email
                        </div>
                        <div class="col-sm-9" style="font-size:20px">
                           <asp:Label ID="contactEmail" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <br /><br />
   
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Style="vertical-align: top;">
                <div class="sidemenu-container">
                    <a href="IndustryDashboard.aspx"><i class="bx bxs-dashboard" aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                    <a href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                    <a href="IndustryJobPosted.aspx"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                    <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                    <a href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                    <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                    <a class="active" href="#"><i class="fa fa-user" aria-hidden="true"></i>Profile</a>
                    <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                    <i class="fa fa-sign-out" aria-hidden="true"></i>
                     Sign-out
                    </asp:LinkButton>
                </div>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
       
</asp:Content>
