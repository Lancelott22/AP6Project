﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="PartneredIndustries.aspx.cs" Inherits="ctuconnect.PartneredIndustries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
 <style>
     @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
     
     .profile-container{
         font-family: 'Poppins', sans-serif;
         max-width:260px;
         min-height:660px;
         background-color:white;
         margin-left:4%;
         padding-bottom:8px;
          border: 2px ;
         box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
     }
     @media (max-width: 790px) {
         .profile-container, .sidemenu-container {
             max-width: 50%;
             max-height:100%;
             
              padding:5px 5px 5px 5px;
         }
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
     .sidemenu-container{
         font-family: 'Poppins', sans-serif;
         width:260px;
         height:200px;
         background-color:white;
         /*margin-top:22%;*/
         padding-top:4px;
         margin-bottom:10%;
         margin-left:4%;
         border-radius: 25px;
         border: 2px ;
         box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
         
     }
    
         .profile-container a {
             position:static;
             border-radius: 10px;
             color: black;
             text-decoration: none;
             font-size: 19px;
             display: block;
             margin: 2px 15px 5px 15px ;
             padding: 0px 0px 0px 8px;
         }
         .profile-container a.active{
              background-color:#F6B665;
             color:#606060;
         }
         .profile-container a:hover{
             background-color:#fcd49a;
             color:#606060;
             margin: 2px 15px 5px 15px ;
             padding: 0px 0px 0px 8px;
             text-decoration: none;
         }
         .display-container{
             font-family: 'Poppins', sans-serif;
             background-color:white; 
             width:1550px;
             top:0;
             bottom:0;
             padding: 2%;
             overflow: auto;
             /*background-color:white;*/
             height:800px;
         }
             .display-container {
                 max-width: 100%;
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
              height:100%; 
              width:97%; 
              margin-left:2%; 
              margin-right:2%;
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
.horizontal-line {
     border: none;
     border-top: 1.5px solid black;
     width: 90%;
     margin-left:auto;
     margin-right:auto;
     margin-top:1%;
     margin-bottom:0%;
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
 .full-time:active::before{
             content:'';
             position:absolute;
             height:10px;
             width:40px;
             bottom:0%;
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

    .fa {
        width:20px;
        margin-right: 19px; 
    }
 </style>
 <asp:Table ID="Table1" runat="server"  CssClass="content">
     <asp:TableRow>
         <asp:TableCell  style="vertical-align: top;">
             <div class="profile-container">
               <asp:Image ID="CoordinatorImage" runat="server"/>   
                   <p >OJT Coordinator</p>
                   <hr class="horizontal-line" />
                   <a href="CoordinatorProfile.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                   <a href="ListOfAlumni"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Alumni</a>
                   <a class="active" href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Partnered Industry</a>
                   <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px;"></i>Refer Student</a>
                   <a href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                   <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                   <a href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right:12px;"></i>Contact</a>
                   <a href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                   <a href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                   <a href="EditEvaluation.aspx"><i class="fa fa-file-text" aria-hidden="true" style="padding-right:12px;"></i>Evaluation Form</a>
                   <hr class="second" />
                   <a href="OJTCoordinator_Profile.aspx"><i class="fa fa-user" aria-hidden="true" style="padding-right:12px;"></i>Profile</a>
                   <a href="Coord_AccountSetting.aspx"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                   <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                       <i class="fa fa-sign-out" aria-hidden="true"></i>
                       Sign-out
                       </asp:LinkButton>
            </div>
         </asp:TableCell>
         <asp:TableCell Style="padding:0px 5px 0px 40px">
            <div class="display-container">
                <h1 class="title">Partnered Industries</h1>
                 
                <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>
                
                <asp:ListView ID="partneredIndustries" runat="server"> 
                     <LayoutTemplate>
                            <table  class="table-list">
                                 <tr>
                                     <th>No.</th>
                                     <th>Industry Name</th>
                                     <th>Location</th>
                                     <th>Contact Person</th>
                                     <th>Contact Number</th>
                                     <th>Contact Email</th>
                                 </tr>
                                <tbody>
                                     <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                 </tbody>
                                </table>
                    </LayoutTemplate>
                                 <Itemtemplate>
                                         <tr>
                                             <td class="datas"><%# Container.DataItemIndex + 1 %></td>
                                             <td class="datas">
                                                 <a href='<%# ResolveUrl("~/ViewIndustryProfile_Coord?industry_accID=" + Eval("industry_accID"))%>' style="text-decoration: underline;">
                                                 <asp:Label runat="server" Text='<%# Eval("industryName") %>'></asp:Label>

                                             </td>
                                             <td class="datas"><%# Eval("location") %></td>
                                             <td class="datas"><%# Eval("contactPerson") %></td>
                                             <td class="datas"><%# Eval("contactNumber") %></td>
                                             <td class="datas"><%# Eval("contactEmail") %></td>
                                         </tr>
                                </Itemtemplate>
                       </asp:ListView>
            </div>
         </asp:TableCell>
     </asp:TableRow>
       
 </asp:Table>
</asp:Content>
