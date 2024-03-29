﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="ReferralList.aspx.cs" Inherits="ctuconnect.ReferralList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
        .profile-container{
            font-family: 'Poppins', sans-serif;
            max-width: 260px;
            height: auto;
            padding: 10px;
            background-color: white;
            margin-left: 4%;
        }
        @media (max-width: 790px) {
            .profile-container, .sidemenu-container {
                max-width: 50%;
                max-height:auto;
                padding:5px 5px 5px 5px;
            }
        }
        .profile-container img {
            display: block;
            width: 60%;
            margin-left: auto;
            margin-right: auto;
        }

        .profile-container p {
            display: block;
            text-align: center;
            font-size: 19px;
            margin-top: 7%;
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
                background-color:white; 
                width:1500px;
                top:0;
                bottom:0;
                padding: 2% 2% 0% 2%;
                overflow: auto;
                height:800px;
            }
                .display-container {
                    min-width: 100%;
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
                width:40px;
                bottom:0;
                background-color: #881A30;

            }
         .content{
                             height: auto;
            width: 97%;
            margin-left: 2%;
            margin-right: 2%;
            padding: 0px 0px 0px 0px;
             }
             .gridview-style{
                 margin-top:5%;
                 text-align:center;
             }
             .gridview-style .header-style{
                 width:20px;
                 text-align:center;
                 align-items:center;
             }
            .sort-dropdown{
                border-radius: 12px;
                width:100px;
                padding-left:8px;
                border-color:#c1beba;
            }
            .gridview-container {
        position: relative;
        min-height: 1px;
        height: auto;
        width: 100%;
    }

    .gridview {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        display: none;
    }
   /* .horizontal-line {
        border: none;
        border-top: 1px solid black;
        width: 100%;
        margin-top:1%;
        margin-bottom:0%;
    }*/
    
    .full-time:active::before{
                content:'';
                position:absolute;
                height:10px;
                width:40px;
                bottom:0%;
                background-color: #881A30;

    }
    .fa {
                width:20px;
                margin-right: 19px; 
    }
        .status-pending {
    background-color: #F9E9B7; 
    color: #F3C129; 
    margin-right:2px;
    border-radius: 25px; 
    padding: 1px 3px; 
    text-align: center;
    cursor: pointer;
}
        .status-approved {
    background-color: #d3ffd3; 
    color: #2c9a5d; 
    margin-right:2px;
    border-radius: 25px;
    padding: 1px 3px; 
    text-align: center;
    cursor: pointer;
}
    .status-column{
        padding:10px;
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
        font-size:13px; 
        height:auto; 
        width:100%;
        color:dimgray;
        padding-right:4px;
    }
    </style>
     <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; height:180px; ">
                <div class="profile-container">
                  <asp:Image ID="industryImage1" runat="server" />
                 <center>
                     <b>
                         <asp:Label ID="disp_industryName" CssClass="disp_industryName" runat="server" Text=""></asp:Label></b>
                     <span><i class="fa fa-check-circle" id="verifiedIcon" runat="server" aria-hidden="true" data-toggle="tooltip" data-placement="auto"></i></span></center>
                 <center>
                     <p style="font-size: 14px;">
                         Account ID: <b>
                             <asp:Label ID="disp_accID" runat="server" Text=""></asp:Label></b>
                     </p>
                 </center>
                </div>
            </asp:TableCell>
            <asp:TableCell  RowSpan="2" Style="padding:0px 5px 0px 25px">
               <div class="display-container">
                   <h1 class="title">Referral List</h1>
                   <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>
                   


                           <asp:ListView ID="dataRepeater" runat="server">
                                    <LayoutTemplate>
                                      <table  class="table-list">
                                        <tr>
                                        <th>referral id</th>
                                        <th>Last Name</th>
                                        <th>First Name</th>
                                        <th>Referred by</th>
                                        <th>Referral letter</th>
                                        <th>Date</th>
                                        <th>Status</th>
                                        <th></th>
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
                                        <th>referral id</th>
                                        <th>Last Name</th>
                                        <th>First Name</th>
                                        <th>Referred by</th>
                                        <th>Referral letter</th>
                                        <th>Date</th>
                                        <th>Status</th>
                                        <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td style="text-align:center; font-size:18px;" colspan="9">No data available</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                  <ItemTemplate>
                                        <tr>
                                        <td class="datas"><%# Eval("referralID") %></td>
                                        <td class="datas"><%# Eval("lastName") %></td>
                                        <td class="datas"><%# Eval("firstName") %></td>
                                        <td class="datas"><%# Eval("referredBy") %></td>
                                        <td class="datas">
                                            <asp:Button ID="btnreferralLetterButton" runat="server" Text="View Referral Letter" OnCommand="btnreferralLetterButton_Command"
                                                CommandName="Review" CommandArgument='<%# Eval("referralLetter") %>'/>
                                        </td>
                                        <td class="datas"><%# Eval("datereferred") %></td>
                                        <td class='<%# "datas " + GetStatusCssClass(Eval("ReferralStatus").ToString()) %>'>
                                            <%# Eval("ReferralStatus").ToString() == "Pending" ? "Pending" : Eval("ReferralStatus").ToString() == "Approved" ? "Hired" : "" %>
                                        </td>
                                        <td class="datas" style="width:50px;"><asp:Button ID="ViewApplicants" Text="View Applicant"  runat="server"  OnCommand="ViewApplicant_Command" CommandArgument='<%#Eval("student_accID")%>' /> </td>
                                    </tr>
                                            </ItemTemplate>
                            </asp:ListView>

               </div>
            </asp:TableCell>
        </asp:TableRow>
          <asp:TableRow>
            <asp:TableCell Style=" vertical-align:top; width:230px;">
                <div class="sidemenu-container">
                    <a  href="IndustryDashboard.aspx"><i class='bx bxs-dashboard' aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                     <a  href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                    <a href="IndustryJobPosted.aspx"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                     <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                     <a href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                     <a class="active" href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                    <a href="IndustryProfile.aspx"><i class="fa fa-user" aria-hidden="true"></i>Profile</a>
                    <a href="Industry_AccountSetting.aspx"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                    <a href="Industry_Contact.aspx"><i class="fa fa-comments" aria-hidden="true"></i>Contact</a>
                     <asp:LinkButton runat="server" ID ="SignOut" OnClick="SignOut_Click" >
   <i class="fa fa-sign-out" aria-hidden="true"></i>
    Sign-out
</asp:LinkButton>
               </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
