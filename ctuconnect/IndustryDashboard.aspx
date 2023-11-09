<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IndustryDashboard.aspx.cs" Inherits="ctuconnect.IndustryDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>

    <style>
        /* *{
            font-family: 'Poppins', sans-serif;
        }*/
        .profile-container {
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
           background: rgb(121,101,55);
background: linear-gradient(90deg, rgba(121,101,55,1) 0%, rgba(245,168,2,1) 40%);
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
            width: 253px;
            height: 280px;
            background-color: white;
            /*margin-top:22%;*/
            padding-top: 4px;
            margin-bottom: 10%;
            margin-left: 4%;
            border-radius: 25px;
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
            width: 1000px;
            top: 0;
            bottom: 0;
            padding: 2% 7% 4% 7%;
            overflow: auto;
            /*background-color:white;*/
            height: 900px;
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
            <asp:TableCell RowSpan="2" Style="padding: 0px 5px 0px 40px">
                 <h2 class="title opacity-75" >Dashboard</h2>
                <div class="display-container">                  
                    <br />
                    <br />
                    <br />
                    <div class="row">
                        <div class="col">
                            <div class="card text-white p-2" style="max-width: 18rem;">

                                <div class="card-body">
                                    <h4 class="card-title">Total Hired</h4>
                                    <h2 class="card-text" id="totalHired" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card text-white  p-2" style="max-width: 18rem;">

                                <div class="card-body">
                                    <h4 class="card-title">Total Applicants</h4>
                                    <h2 class="card-text" id="totalApplicant" runat="server"></h2>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card text-white  p-2" style="max-width: 18rem;">

                                <div class="card-body">
                                    <h4 class="card-title">Total Jobs</h4>
                                    <h2 class="card-text" id="totalJobs" runat="server"></h2>
                                </div>
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
                    <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                       <i class="fa fa-sign-out" aria-hidden="true"></i>
                        Sign-out
                    </asp:LinkButton>
                </div>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Content>
