﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IndustryHome.aspx.cs" Inherits="ctuconnect.IndustryHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
       
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        *{
            font-family: 'Poppins', sans-serif;
        }
        .profile-container{
            max-width:260px;
            max-height:300px;
            background-color:white;
            margin-left:4%;
        }
        @media (max-width: 790px) {
            .profile-container, .sidemenu-container {
                max-width: 50%;
                max-height:auto;
                
                 padding:5px 5px 5px 5px;
            }
        }
        .profile-container img{
            display:block;
            width:80%;
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
            width:253px;
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
                background-color:white; 
                width:1000px;
                top:0;
                bottom:0;
                padding: 2% 7% 4% 7%;
                overflow: auto;
                /*background-color:white;*/
                height:100vh;
                /*overflow: auto;
                float:left;
                margin-left:25%;
                position:relative;
                padding: 4% 0% 0% 6%;*/
            }
            }
            @media (max-width: 790px) {
                .display-container {
                    max-width: 50%;
                }
            }
            .display-container .title{
                font-size:25px;
                font-weight:500;
                position:relative;
                margin-bottom:3%;
            }
            .display-container .title:before{
                content:'';
                position:absolute;
                height:2px;
                width:40px;
                bottom:0;
                background-color: #881A30;

            }
           /* .details1{
                
               display:flex;
                flex-wrap:wrap;
            }*/
            .title{

            }
           /*.input-box{
               width:100%;
               background:red;
               margin-top:20px;
           }*/
          /* .input-box input{
               position:relative;
               height:40px;
               width:100%;
               outline: none;
           }*/

          
          /* .textbox{
               position:relative;
               display:inline-block;
               height:40px;
               width:100%;
               background:red;
               padding-right:0;
               justify-content:center;
           }*/
            /*.details{
                width:80%;
                position:relative;
                background:red;
            }*/
             .txtbox {
                 display:flex;
                 position:relative;
                 border-radius: 10px;
                 min-width: 100%;
                min-height:35px;
                margin-bottom:2%;
                padding-left:20px;
                border: 1px solid gray;
                justify-content: center; /* Add this property to include padding in the width calculation */
               
    }
             .txtbox-description{
                 padding-left:20px;
                  border-radius: 10px;
                  min-width: 100%;
                min-height:190px;
                margin-bottom:2%;
              border: 1px solid gray;
             }
             .content{
                 height:100%; 
                 width:97%; 
                 margin-left:2%; 
                 margin-right:2%;
                 padding: 0px 0px 0px 0px;
             }
            /* .profile{
                 max-width:25%;
                 height:200px;

             }*/
              @media (max-width: 790px) {
                .profile {
                    max-width: 20%;
                }
            }
             /*.label{
                 font-size:20px;
                 color:black;
              }*/
             label{
                 font-size:50px;
             }
            .dropdown1{
               
                display:flex;
                flex-wrap:wrap;
                justify-content:space-between;
            }
            .dropdown-bx{
                border-radius: 10px; 
                min-width: 40%;
                min-height:35px;

            }
            .fa {
                width:20px;
                margin-right: 19px; 
    }
    </style>
    <asp:Table ID="Table1" runat="server" CssClass="content" >
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; height:200px;" >
                <div class="profile-container">
                <img src="images/industrypic.png" />
                <p>Industry Name</p>
                </div>
            </asp:TableCell> 
            <asp:TableCell  RowSpan="2" Style="padding:0px 5px 0px 40px">
                <div class="display-container">
                    <h1 class="title">Post a Job</h1>
                   
                        <asp:Label ID="Label1" runat="server" Text="Job Title " Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="JobTitle" runat="server" CssClass="txtbox" Placeholder="e.g. Financial Planning Assistant" ></asp:TextBox>
                
                        <asp:Label ID="Label2" runat="server" Text="Industry Name " Style="font-size:18px;"></asp:Label><span style="color: red">*</span>
                        <asp:TextBox ID="IndName" runat="server" CssClass="txtbox" Placeholder="e.g. Gaus Electonics"></asp:TextBox>
                   

                        <asp:Label ID="Label3" runat="server" Text="Job Type " Style="font-size:18px;"></asp:Label><span style="color: red">*</span>
                    <asp:Label ID="Label4" runat="server" Text="Specified course " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>


                           <div class="dropdown1">
                            <select runat="server" name="jobtype" id="jobtype" Style="border-radius: 10px;  min-width: 47%; min-height:35px; margin-bottom:2%; padding-left:20px;">
                                <option value="fulltime">Full-time</option>
                                <option value="internship">Internship</option>
                            </select>
                            <select runat="server" name="course" id="course" Style="border-radius: 10px;  min-width: 47%; min-height:35px; margin-bottom:2%; padding-left:20px;" >
                                <option value="fulltime">Full-time</option>
                                <option value="internship">Internship</option>
                                <option value="fulltime">Full-time</option>
                                <option value="internship">Internship</option>
                                <option value="fulltime">Full-time</option>
                                <option value="internship">Internship</option>
                                <option value="fulltime">Full-time</option>
                                <option value="internship">Internship</option>
                            </select>
                       </div>
                   
                    <asp:Label ID="Label5" runat="server" Text="Job Location " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                     <asp:TextBox ID="jobLoc" runat="server" CssClass="txtbox" Style="padding-left:20px;" Placeholder="e.g. M.J. Cuenco Ave, Cor R. Palma Street, 6000 Cebu" ></asp:TextBox>

                     <asp:Label ID="Label6" runat="server" Text="Job Description " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                     <asp:TextBox ID="jobDescript" runat="server" CssClass="txtbox-description" Placeholder="job location" ></asp:TextBox>

                    <asp:Label ID="Label7" runat="server" Text="Job Qualifications " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                     <asp:TextBox ID="jobQuali" runat="server" CssClass="txtbox" Placeholder="Enter job qualifications" ></asp:TextBox>

                    <asp:Label ID="Label8" runat="server" Text="Instructions to apply " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                     <asp:TextBox ID="jobInstruct" runat="server" CssClass="txtbox" Style="height:70px;">job location</asp:TextBox>
                     <asp:Button ID="PostJob" runat="server" Style="background-color:white; min-width:25%; min-height:35px; float:right; color:white; background-color:orange;  border-radius: 10px; border: 1.5px solid orange; " Text="Post" OnClick="PostJob_Click"/>
            </div>
                    </asp:TableCell>
            </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top;" >
                <div class="sidemenu-container">
                    <a class="active" href="#"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                     <a href="#"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                     <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                     <a href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                     <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
               </div>
            </asp:TableCell> 
       </asp:TableRow>
      
    </asp:Table>

    
</asp:Content>