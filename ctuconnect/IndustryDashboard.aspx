<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="IndustryDashboard.aspx.cs" Inherits="ctuconnect.IndustryDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>

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

        .card {
            background-color:white;
            border-radius:20px;
            min-height: 200px;
             box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
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

        .sidemenu-container {
            font-family: 'Poppins', sans-serif;
            width: 253px;
            min-height: 280px;
            background-color: white;
            /*margin-top:22%;*/
            padding-top: 4px;
            padding-bottom: 4px;
            margin-bottom: 10%;
            margin-left: 2%;
            border-radius: 20px;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }

            .sidemenu-container a {
                position: static;
                border-radius: 25px;
                color: black;
                text-decoration: none;
                font-size: 19px;
                display: flex;
                margin: 10px 15px 5px 15px;
                padding: 0px 0px 0px 20px;
                align-items: center;
            }

                .sidemenu-container a.active {
                    background-color: #F6B665;
                    color: #606060;
                }

                .sidemenu-container a:hover {
                    background-color: #fcd49a;
                    color: #606060;
                    margin: 10px 15px 5px 15px;
                    padding: 0px 0px 0px 20px;
                }

        .display-container {
            font-family: 'Poppins', sans-serif;
            width: 100%;
            top: 0;
            bottom: 0;
            padding: 2% 7% 4% 7%;
            overflow: auto;
            /*background-color:white;*/
            height: 100%;
            /*overflow: auto;
                float:left;
                margin-left:25%;
                position:relative;
                padding: 4% 0% 0% 6%;*/
            margin-bottom: 30px;
        }

        @media (max-width: 790px) {
            .display-container {
                max-width: 50%;
            }
        }

        .display-container .title {
            font-size: 25px;
            font-weight: 500;
            position: relative;
            margin-bottom: 3%;
        }

            .display-container .title:before {
                content: '';
                position: absolute;
                height: 2px;
                width: 40px;
                bottom: 0;
                background-color: #881A30;
            }
        /* .details1{
                
               display:flex;
                flex-wrap:wrap;
            }*/
        .title {
            
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
            display: flex;
            position: relative;
            border-radius: 10px;
            min-width: 100%;
            min-height: 35px;
            margin-bottom: 2%;
            padding: 10px;
            padding-left: 20px;
            border: 1px solid gray;
            justify-content: center; /* Add this property to include padding in the width calculation */
        }

        .txtbox-description {
            border-radius: 10px;
            min-width: 100%;
            min-height: 100px;
            height: auto;
            margin-bottom: 2%;
            border: 1px solid gray;
            padding: 10px;
            padding-left: 20px;
            padding-top: 20px;
        }

        .txtbox-instruction {
            border-radius: 10px;
            min-width: 100%;
            min-height: 100px;
            height: auto;
            margin-bottom: 2%;
            border: 1px solid gray;
            padding: 10px;
            padding-left: 20px;
            padding-top: 20px;
        }

        .content {
            height: auto;
            width: 97%;
            margin-left: 2%;
            margin-right: 2%;
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
        label {
            font-size: 50px;
        }

        .dropdown-bx {
            border-radius: 10px;
            min-width: 40%;
            min-height: 35px;
        }

        .fa {
            width: 20px;
            margin-right: 19px;
        }

        .postJobStyle {
            float: right;
            color: white;
            background-color: orange;
            border-radius: 15px;
            height: 40px;
            width: 20%;
            border: 1px solid orange;
        }

            .postJobStyle:hover {
                box-shadow: 3px 6px 7px -4px grey;
            }

        .txtsuggestion {
            background-color: white;
            border-radius: 20px;
            min-width: 100%;
            min-height: 200px;
            padding-top: 2px;
            padding: 20px;
            line-height: 60px;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }

        .btnSend {
            border: 1px #F7941F;
            border-radius: 5px;
            background-color: #F7941F;
            border-radius: 25px;
            width: 120px;
            color: #F0EBEB;
            float:right;
        }
    </style>

    <asp:Table ID="Table1" runat="server" CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align: top; height: 90px;">
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
            <asp:TableCell RowSpan="2" Style="padding: 0px 5px 0px 40px">
                
                <div class="display-container">
                    <h2 class="title opacity-75" style="font-size:30px;">Dashboard</h2>
                    <br />
                    <div class="row">
                        <div class="col">
                            <div class="card text-white p-2" style="max-width: 50rem;">

                                <div class="card-body">
                                    <img src="images/Icons/personIcon.png" style="float:left; width:70px; height:auto; border-radius:20px; margin-right:5%;"/>
                                    <h4 class="card-title" style="color:dimgray;">Total Hired</h4>
                                    <h2 class="card-text" style="color:black; font-size:80px;" id="totalHired" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card text-white  p-2" style="max-width: 50rem; padding-left:5%;">

                                <div class="card-body">
                                    <img src="images/Icons/hiredIcon.png" style="float:left; width:70px; height:auto; border-radius:20px; margin-right:5%;"/>
                                    <h4 class="card-title" style="color:dimgray;">Total Applicants</h4>
                                    <h2 class="card-text" style="color:black; font-size:80px;" id="totalApplicant" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card text-white  p-2" style="max-width: 50rem;">

                                <div class="card-body">
                                    <img src="images/Icons/jobsIcon.png" style="float:left; width:70px; height:auto; border-radius:20px; margin-right:5%;"/>
                                    <h4 class="card-title" style="color:dimgray;">Total Jobs</h4>
                                    <h2 class="card-text" style="color:black; font-size:80px;" id="totalJobs" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                        <div class="row gx-4 gx-lg-5 h-100">
                            <div class="col-lg-12 align-self-end">
                                <h1>Share us your Suggestions!</h1>
                                <p style="text-indent: 60px;">
                                    We value your insights and ideas! Your suggestions are crucial to us as we strive to improve and enhance our services. Whether you have 
                                    thoughts on how we can make things even better or ideas for new features, we want to hear from you. Help us shape the future by sharing 
                                    your suggestions — because together, we can create an even more exceptional experience for you! 🚀
                                </p>
                                <p style="float: right;">--From Admin</p>
                            </div>
                        </div>
                        <div class="row gx-4 gx-lg-5 h-100">
                            <div class="col-lg-12 align-self-end">
                                <asp:TextBox ID="txtsuggestion" runat="server" CssClass="txtsuggestion"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row gx-4 gx-lg-5 h-100">
                            <div class="col-lg-12 align-self-end">
                                <p>
                                    <br />
                                    <asp:Button ID="btn" class="btnSend" runat="server" Text="Submit" OnClick="Submit_Suggestions" /></p>
                            </div>
                        </div>
                    </div>
                </div>


            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Style="vertical-align: top;">
                <div class="sidemenu-container">
                    <a class="active" href="#"><i class='bx bxs-dashboard' aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                    <a href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                    <a href="IndustryJobPosted.aspx"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                    <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                    <a href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                    <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                    <a href="IndustryProfile.aspx"><i class="fa fa-user" aria-hidden="true"></i>Profile</a>
                    <a href="Industry_AccountSetting.aspx"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                    <a href="Industry_Contact.aspx"><i class="fa fa-comments" aria-hidden="true"></i>Contact</a>
                    <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                       <i class="fa fa-sign-out" aria-hidden="true"></i>
                        Sign-out
                    </asp:LinkButton>
                </div>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
    <%--SuccesPromptModal--%>
    <div class="modal fade" id="SuccessPrompt" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content rounded-0">
                <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                        <br />
                        <img src="images/check-mark.png" style="width: 100px; height: auto;" /><br />
                        <asp:Label ID="Label11" runat="server" Text="Submitted !" Style="font-size: 25px;"></asp:Label><br />
                        <asp:Label ID="Label12" runat="server" Text="Your suggestion was succesfully submitted." Style="font-size: 18px;"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnClick="Close_SuccessPrompt" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
