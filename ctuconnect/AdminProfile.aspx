<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="ctuconnect.AdminProfile" %>
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
        padding:10px 10px 0px 10px;
        width:300px;
        margin-top:5px;
        position: absolute;
        margin-left:10px;
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
        padding: 0px 0px 0px 8px;
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
   
    .profile-pic{
        width:150px;
        height:150px;
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
                    <a href="AdminDashboard.aspx">
                        <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                        Dashboard
                    </a>
                    <a href="#myaccount">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Create Partnership
                    </a>
                    <a  href="IndustryVerification.aspx">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Industry Verification
                    </a>
                    <a href="ReferralList_Admin.aspx">
                        <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Referred Student
                    </a>
                    <hr class="horizontal-line" />
                    <a href="ListOfIndustries_Alumni.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Industry
                    </a>
                    <a href="ListOfInterns_Alumni.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Interns
                    </a>
                    <a href="ListOfAlumni_Admin.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Alumni
                    </a>
                    <hr class="horizontal-line" />
                    <a href="Dispute.aspx">
                        <i class="fa fa-exclamation-triangle" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dispute
                    </a>
                    <a href="Blacklist_Admin.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Blacklist
                    </a>
                        <a href="SuggestionsAdmin.aspx">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                        Suggestions
                    </a>
                    <hr class="second" />
                    <a href="TracerDashboard.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Tracer
                    </a>
                    <a class="active" href="#">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                        Profile
                    </a>
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
                    <div class="row">
                      <div class="col-lg-4">
                        <div class="card shadow-sm profile-section">
                            <center>
                            <img src="images/administratorpic.jpg" class="profile-pic"/>
                            <h3><asp:Label ID="disp_name" runat="server" Text=""></asp:Label></h3>
                            </center>
                        </div>
                      </div>
                      <div class="col-lg-8">
                        <div class="card shadow-sm">
                          <div class="card-header bg-transparent border-0">
                              <div class="row">
                                  <div class="col-11" style="padding-left:1em;">
                                      <h3 class="mb-0">General Information</h3>
                                  </div>
                                  <div class="col-1" style="text-align:right;">
                                      <a href="#" class="pen-icon"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></a>
                                  </div>
                              </div>
        
          
                          </div>
                          <div class="card-body pt-0">
                            
                          </div>
                        </div>
                        <br />
                        <div class="card shadow-sm percentage">
      
                        </div>
      
                      </div>
                    </div>
            </div>   
        </div>    
   
    </div>
</div>
</asp:Content>
