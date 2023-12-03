<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="IndustryJobPosted.aspx.cs" Inherits="ctuconnect.IndustryJobPosted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');

        
        a{

        }
        .profile-container {
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
                max-height: auto;
                padding: 5px 5px 5px 5px;
            }
        }

        .profile-container img {
            display: block;
            width: 80%;
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
            padding-bottom:4px;
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
            font-family: 'Poppins', sans-serif;
            background-color: white;
            width: 1000px;
            top: 0;
            bottom: 0;
            padding: 2% 7% 4% 7%;
            overflow: auto;
            /*background-color:white;*/
            height: auto;
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
            width: 95%;
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

        .imgStyle {
            border-radius: 50%;
            border: solid grey 1px;
            box-shadow: gray;
            width: 100px;
            height: 100px;
            box-shadow: 0px 0px 12px -3px grey;
        }

        .JobPostedListbox {
            width: 100%;
            min-height: 300px;
            background-color: #ffffff;           
            border: 1px solid #FFFFFF;
            padding: 10px;
            border-radius: 5px;
        }
        .jobPostedBox {
            border: 1px solid #881A30;
            padding: 10px;
            margin: auto;
            margin-bottom: 10px;
            width: contain;
            height: contain;
            box-shadow: 0px 0px 7px -3px #bd0606;
            border-radius: 7px;
            position:relative;
            
        }

            .jobPostedBox:hover {
                box-shadow: 3px 7px 18px #bd0606;
            }

        .NewBadge {
            border: solid 1px #15d455;
            border-radius: 5px;
            height: 20px;
            width: 30px;
            background: #15d455;
            padding: 2px;
            color: #ffffff;
            font-size: 10px;
            position: absolute;
            top: 10px;
            left: 15px;
            box-shadow: 0px 0px 9px -1px #15d455;
            text-align: center;
        }

        .buttonStyle {
            background-color: white;
            width: 85%;
            left: 15px;
            right: 15px;
            min-height: 35px;
            color: orange;
            border-radius: 20px;
            border: 1.5px solid orange;
            position: relative;
        }

            .buttonStyle:hover {
                background: orange;
                color: white;
                box-shadow: 3px 6px 7px -4px grey;
            }
             .buttonDetails {
     background-color: white;
     width: 85%;
     left: 15px;
     right: 15px;
     min-height: 35px;
     color: #881a30;
     border-radius: 20px;
     border: 1.5px solid #881a30;
     position: relative;
 }

     .buttonDetails:hover {
         background: #881a30;
         color: white;
         box-shadow: 3px 6px 7px -4px grey;
     }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ClientIDMode="AutoID">
        <ContentTemplate>
            <asp:Table ID="Table1" runat="server" CssClass="content">
                <asp:TableRow>
                    <asp:TableCell Style="vertical-align: top; height: 200px;">
                        <div class="profile-container">
                            <asp:Image ID="industryImage1" runat="server" />
                            <center>
                                <b>
                                    <asp:Label ID="disp_industryName" CssClass="disp_industryName" runat="server" Text=""></asp:Label></b></center>
                            <center>
                                <p style="font-size: 14px;">
                                    Account ID: <b>
                                        <asp:Label ID="disp_accID" runat="server" Text=""></asp:Label></b>
                                </p>
                            </center>
                        </div> 
                    </asp:TableCell>
                    <asp:TableCell RowSpan="2">
                        <div class="d-flex flex-column" style="margin-bottom: 30px;">                           
                            <div class="JobPostedListbox" style="padding: 30px;">
                                 <h3 class="title">My Job Posted</h3><br />
                                <asp:ListView ID="IndustryJobPostedList" runat="server" class="container-fluid" OnItemDataBound="IndustryJobPostedList_ItemDataBound" OnPagePropertiesChanged="IndustryJobPostedList_PagePropertiesChanged">
                                    <ItemTemplate>
                                        <div id="myJobPosted" runat="server" class="row d-flex align-items-center jobPostedBox">
                                            <span runat="server" id="badge" class="NewBadge" visible="false">New</span>
                                            <div class="col-sm-2" style="text-align: center">
                                                <img id="IndstryLogo" src='<%#String.Format("../images/IndustryProfile/{0}", Eval("industryPicture"))%>' runat="server" alt="Logo" class="imgStyle" />
                                            </div>
                                            <div class="col-sm-8">
                                                <div class="row" style="border-right: 1px solid #881A30;">
                                                    <label id="JobID" runat="server" hidden="hidden"><%#Eval("jobID")%></label>
                                                    <label id="JobPostedDate" runat="server" hidden="hidden"><%#Eval("jobPostedDate")%></label>

                                                    <div class="align-items-start">
                                                        <span>
                                                            <h3 style="color: #881A30; margin-bottom: 10px;"><b><%#Eval("jobTitle")%></b></h3>
                                                        </span>
                                                    </div>
                                                    <div class="col">
                                                        <label>
                                                            Job Course: 
                                                        </label>
                                                        <br />
                                                        <span id="jobCourse" runat="server"><%#Eval("jobCourse") %></span>
                                                    </div>
                                                    <div class="col">
                                                        <label>
                                                            Job Type: 
                                                        </label>
                                                        <br />
                                                        <span id="Span1" runat="server"><%#Eval("jobType")%></span>
                                                    </div>
                                                    <div class="col">
                                                        <label>Date Posted: </label>
                                                        <br />
                                                        <span><%#Eval("DatePosted") %></span>
                                                    </div>
                                                    <div class="col">
                                                        <label>Job Status: </label>
                                                        <br />
                                                        <span><%#Eval("JobStatus") %></span>
                                                    </div>
                                                    <div class="col">
                                                        <label>Total Applicants: </label>
                                                        <br />
                                                        <span><%#Eval("NumberOfApplicants") %></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2" style="position: relative; text-align: center; vertical-align: middle; margin: 0px;">
                                                <div class="row"  style="margin-bottom:10px;">
                                                    <asp:Button ID="ViewApplicants" Text="View Applicants" class="buttonStyle" runat="server" CommandName='<%#Eval("jobTitle")%>' OnCommand="ViewApplicants_Command" CommandArgument='<%#Eval("jobID")%>' AutoPostBack="false" CausesValidation="false" />                                        
                                                </div>
                                                
                                                <div class="row">
                                                    <asp:Button ID="UpdateJob" Text="Update Job" class="buttonDetails" runat="server" CommandName="UpdateJob" OnCommand="UpdateJob_Command" CommandArgument='<%#Eval("jobID")%>' AutoPostBack="false" CausesValidation="false" />
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <h3 style="position: relative; top: 100px;">
                                            <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoAppliedJob" Text="No Job Posted Yet!"></asp:Label></h3>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                                <asp:DataPager ID="ListViewPager" runat="server" PagedControlID="IndustryJobPostedList" PageSize="10" class="btn-group btn-group-sm float-end">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                                        <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="false" ButtonCount="5" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary disabled" NextPreviousButtonCssClass="btn btn-default" />
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell Style="vertical-align: top;">
                        <div class="sidemenu-container">
                             <a  href="IndustryDashboard.aspx"><i class='bx bxs-dashboard' aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                            <a href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                            <a class="active" href="#"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                            <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                            <a href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                            <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                            <a href="IndustryProfile.aspx"><i class="fa fa-user" aria-hidden="true"></i>Profile</a>
                            <a href="Industry_AccountSetting.aspx"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                            <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                       <i class="fa fa-sign-out" aria-hidden="true"></i>
                        Sign-out
                            </asp:LinkButton>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>