<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ReferralList_Admin.aspx.cs" Inherits="ctuconnect.ReferralList_Admin" %>
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
        margin-top:1%;
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
        min-height: 550px;
        background-color: #FFFFFF;
        max-width:100%;
        width:1550px;
        border: 2px;
        box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        padding-top:2em;
        padding-left:2em;
        padding-right:2em;                  
        margin-left:3px;
    }
    .container .title{
    font-size:25px;
    font-weight:500;
    position:relative;
    margin-bottom:3%;
    padding-bottom:4px;
    }
    .container .title:before{
        content:'';
        position:absolute;
        height:2px;
        width:40px;
        bottom:0;
        background-color: #881A30;

    }
    th{
         border: 1px solid;
         border-color:#c4c4c4;
        background-color:#f4f4fb;
        padding:5px;

    }
/*    td{
        border: 1px solid;
        border-color:dimgray;
        padding-left:5px;
    }*/
    .datas{
        border: 1px solid;
        border-color:#c4c4c4;
        padding-left:5px;
         color:black;
         cursor:default;
    }

    .table-list{
        border-collapse: collapse;        
        font-size:14px; 
        height:auto; 
        width:100%;
        color:dimgray;
        padding-right:4px;
    }
    .topnav {
      overflow: hidden;
    }

    .topnav .linkbutton {
      float: left;
      display: block;
      color: black;
      text-align: center;
      padding: 2px 15px;
      text-decoration: none;
      font-size: 17px;
    }

    .topnav .linkbutton:hover {
      border-bottom: 2px solid black;
    }

    .topnav .linkbutton.active {
      border-bottom: 2px solid black;
      color:#881A30;
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
                        <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dashboard
                    </a>
                    <a  href="IndustryVerification.aspx">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Industry Verification
                    </a>
                    <a class="active" href="ReferralList_Admin.aspx">
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
                        Blacklisted
                    </a>
                    <a href="SuggestionsAdmin.aspx">
                            <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Suggestions
                        </a>
                        <a href="Admin_Contact.aspx">
                            <i class="fa fa-comments" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Contact
                        </a>
                    <hr class="second" />
                    <a href="TracerDashboard.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Tracer
                    </a>
                    <a href="#">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                        Profile
                    </a>
                     <a href="Coordinator_CreateAccount.aspx">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Coordinator Account
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
                <h1 class="title">List of Referred Students</h1>
                <div class="col-lg-5 order-1 order-lg-2 topnav">
                </div>
                 
                <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>
                     
                                            <asp:Listview ID="dataRepeater" runat="server">
                                      <LayoutTemplate>
                                          <table  class="table-list">
                                               <tr>
                                            <th>No.</th>
                                             <th>Last Name</th>
                                             <th>First Name</th>
                                             <th>Middle Initial</th>
                                             <th>Industry</th>
                                             <th>Referred by</th>
                                             <th>Referral Letter</th>
                                             <th>Date</th>
                                      </tr>
                                    <tbody>
                                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                               </tbody>
                              </table>
                              </LayoutTemplate> 
                               <EmptyDataTemplate>
                                <table class="table-list">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                             <th>Last Name</th>
                                             <th>First Name</th>
                                             <th>Middle Initial</th>
                                             <th>Industry</th>
                                             <th>Referred by</th>
                                             <th>Referral Letter</th>
                                             <th>Date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align:center; font-size:18px;" colspan="8">No data available</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                                      <ItemTemplate>
                                          <tr>
                                              <td class="datas"><%# Container.DataItemIndex + 1 %></td>
                                                <td class="datas"><%# Eval("lastName") %></td>
                                                <td class="datas"><%# Eval("firstName") %></td>
                                                <td class="datas"><%# Eval("midInitials") %></td>
                                                <td class="datas"><%# Eval("industryName") %></td>
                                                <td class="datas"><%# Eval("referredBy") %></td>
                                                <td class="datas">
                                                    <asp:Button ID="btnEndorsementLetterButton" runat="server" Text="View Referral Letter"
                                                    OnCommand="ReviewLetter_Command" CommandName="Review"  
                                                    CommandArgument='<%# Eval("referralLetter") %>'/>
                                                </td>
                                                <td class="datas"><%# Eval("dateReferred") %></td>
                                          </tr>
                                      </ItemTemplate>
                                  </asp:Listview>
</div>
            </div>
        </div>    
   
    </div>
</asp:Content>
