﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="MyJobApplication.aspx.cs" Inherits="ctuconnect.WebForm1" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
<script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <style>
        .nav {
            padding: 10px 10px 10px 10px;
            width: 200px;
            margin: auto;
            margin-top: 20px;
            position: absolute;
            margin-left: 70px;
        }

            .nav a {
                font-size: 18px;
                font-family: 'Arial Rounded MT';
                color: #000000;
                padding-left: 3px;
                text-decoration: none;
            }

                .nav a.active {
                    background-color: rgb(255, 194, 102);
                    border-radius: 10px;
                    min-height: 10px;
                }

                .nav a:hover {
                    background-color: rgb(255, 194, 102);
                    border-radius: 10px;
                    min-height: 10px;
                }

        .buttonStyle {
            background-color: white;
            min-width: 100%;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
        }

            .buttonStyle:hover {
                background: orange;
                color: white;
                box-shadow: 3px 6px 7px -4px grey;
            }
    .buttonStyleDone {
    background-color: white;
    min-width: 100%;
    min-height: 35px;
    color: red;
    background-color: white;
    border-radius: 20px;
    border: 1.5px solid red;
}
        .imgStyle {
            border-radius: 50%;
            border: solid grey 1px;
            box-shadow: gray;
            width: 100px;
            height: 100px;
            box-shadow: 0px 0px 12px -3px grey;
        }

        .col {
            font-size: 15px;
        }

        h3 {
            font-size: 20px;
        }

        .top {
            height: 200px;
            background-color: #F7941F;
            width: 80%;
        }


        .box {
            width: 95%;
            min-height: 300px;
            background-color: #ffffff;
            padding-left: 2em;
            border: 1px solid #FFFFFF;
            padding: 10px;
            border-radius: 5px;
        }

        .profile {
            border-radius: 50px;
            position: relative;
            top: -50px;
        }

        .line {
            height: 2px;
            width: 95%;
            background-color: #881A30;
            color: #881A30;
            position: center;
        }

        .ContainerBox {
            border: solid 2px #881A30;
            box-shadow: 4px 6px 10px -4px grey;
            height: auto;
            margin: 10px;
            margin-bottom: 15px;
            vertical-align: bottom;
        }

        .statusStyle {
            border: solid 1px #06ba1b;
            background: #06ba1b;
            height: 50px;
            padding: 6px;
            color: white;
            box-shadow: 3px 6px 7px -4px grey;
        }

        .statusStyleReject {
            border: solid 1px #c90a0a;
            background: #c90a0a;
            height: 50px;
            padding: 6px;
            color: white;
            box-shadow: 3px 6px 7px -4px grey;
        }

        .statusStylePending {
            border: solid 1px #a8a8a8;
            background: #a8a8a8;
            height: 50px;
            padding: 6px;
            color: white;
            box-shadow: 3px 5px 10px -5px grey;
        }

        .applicationTimeline {
            position: relative;
            list-style: none;
        }

            .applicationTimeline > li {
                position: relative;
                margin-right: 10px;
                margin-bottom: 15px;
            }

            .applicationTimeline:before {
                content: '';
                position: absolute;
                top: 0;
                bottom: 0;
                width: 5px;
                background: rgb(255, 194, 102);
                left: 0;
                margin: 0;
                border-radius: 2px;
            }

            .applicationTimeline > li > .bx {
                width: 35px;
                height: 35px;
                font-size: 25px;
                line-height: 35px;
                position: absolute;
                color: #1c1c1b;
                background: rgb(255, 194, 102);
                border-radius: 50%;
                text-align: center;
                left: -35px;
                top: 0;
            }

        .jobAppliedBox {
            border: 1px solid #881A30;
            padding: 10px;
            margin: auto;
            margin-bottom: 10px;
            width: contain;
            height: contain;
            box-shadow: 0px 0px 7px -3px #bd0606;
            border-radius: 7px;
            position: relative;
        }

            .jobAppliedBox:hover {
                box-shadow: 3px 7px 18px #bd0606;
            }

        .row {
            margin-bottom: 10px;
        }

        .modal ::-webkit-scrollbar {
            display: none;
            width: 6px;
        }

        /* Track */
        .modal ::-webkit-scrollbar-track {
            box-shadow: inset 0 0 5px grey;
            border-radius: 5px;
        }

        /* Handle */
        .modal ::-webkit-scrollbar-thumb {
            background: rgb(255, 194, 102);
            border-radius: 10px;
        }

        .modal-content:hover ::-webkit-scrollbar {
            display: block;
        }
        /* Handle on hover */
        .modal ::-webkit-scrollbar-thumb:hover {
            background: #881A30;
        }
        .jobBoxSelected {
    box-shadow: 0px 0px 7px -3px orange;
    border: 1px solid orange;
    padding: 10px;
    margin: auto;
    margin-bottom: 10px;
    width: contain;
    height: contain;
    border-radius: 7px;
    position: relative;
}

    .jobBoxSelected:hover {
        box-shadow: 3px 7px 18px orange;
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
    </style>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ClientIDMode="AutoID">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-3 d-flex flex-column align-self-start">
                        <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">

                            <a href="MyAccount.aspx">
                                <i class='bx bx-user-circle icon'></i>
                                <span class="text nav-text">My Account</span>
                            </a>
                            <a href="Resume.aspx">
                                <i class='bx bx-file-blank icon'></i>
                                <span class="text nav-text">Resume</span>
                            </a>
                            <a class="active" href="#">
                                <i class='bx bx-layer icon'></i>
                                <span class="text nav-text">Application</span>
                            </a>
                            <a href="Student_AccountSetting.aspx">
                                <i class='bx bx-cog icon'></i>
                                <span class="text nav-text">Account Settings</span>
                            </a>
                            <a href="Report.aspx">
                                <i class='bx bxs-flag-alt'></i>
                                <span class="text nav-text">Report</span>
                            </a>
                            <hr style="height: 2px; border-width: 0; color: #881A30; background-color: #881A30">
                            <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                        <i class='bx bx-log-out icon' ></i>
                        Sign-out
                            </asp:LinkButton>
                        </div>
                    </div>

                    <div class="col-9 d-flex flex-column">
                        <br />
                        <div>
                            <asp:DropDownList runat="server"  ID="SwitchView" AutoPostBack="true" OnSelectedIndexChanged="SwitchView_SelectedIndexChanged">
                                <asp:ListItem Value="1" Selected="true">Job Application List</asp:ListItem>
                                <asp:ListItem Value="2">Hired Job List</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div class="box" id="MyJobHiredView" runat="server" visible="false">
                            <h3 class="my-5">My Hired Job</h3>
                            <asp:ListView ID="MyJobView" runat="server" class="container-fluid" OnItemDataBound="HiredView_ItemDataBound" OnPagePropertiesChanged="MyJobView_PagePropertiesChanged">
                                <ItemTemplate>
                                    <div id="MyHiredJob" runat="server" class="row d-flex align-items-center jobAppliedBox">
                                        <span runat="server" id="HiredBadge" class="NewBadge" visible="false">New</span>
                                        <div class="col-sm-1" style="text-align: center">
                                            <img id="IndstryLogo" src='<%#String.Format("images/IndustryProfile/{0}", Eval("industryPicture"))%>' runat="server" alt="Logo" style="width:80px; height:80px;" class="imgStyle" />
                                        </div>
                                        <div class="col-sm-9">
                                            <div class="row" style="border-right: 1px solid #881A30;">
                                                <label id="JobID" runat="server" hidden="hidden"><%#Eval("jobID")%></label>
                                                <label id="HiredID" runat="server" hidden="hidden"><%#Eval("id")%></label>
                                                <label id="DateHired" runat="server" hidden="hidden"><%#Eval("dateHired")%></label>
                                                <div class="align-items-start">
                                                    <span>
                                                        <h3 style="color: #881A30; margin-bottom: 10px;"><b><%#Eval("position")%></b></h3>
                                                    </span>
                                                </div>
                                                <div class="col">
                                                    <label>Industry Name: </label>
                                                    <br />
                                                    <a href='ViewIndustryProfile.aspx?industry_accID=<%#Eval("industry_accID")%>'>
                                                    <span>                                                        
                                                        <%#Eval("industryName")%>
                                                    </span>
                                                    </a>
                                                </div>
                                                <div class="col">
                                                    <label>Job Location: </label>
                                                    <br />
                                                    <span><%#Eval("location") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>Job Type: </label>
                                                    <br />
                                                    <span><%#Eval("jobType") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>Date Hired: </label>
                                                    <br />
                                                    <span><%#Eval("date_Hired") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>Date Started: </label>
                                                    <br />
                                                    <span><%#Eval("date_Started") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>Date Ended: </label>
                                                    <br />
                                                    <span><%#Eval("date_Ended") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>
                                                        Job Status: 
                                                    </label>
                                                    <br />
                                                    <span><%#Eval("internshipStatus") %></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-2 d-flex align-items-center">
                                            <div class="flex-fill">
                                                <asp:Button ID="RequestEval" Text="Request Evaluation" class="buttonStyle my-2" runat="server" OnCommand="RequestEval_Command" CommandArgument='<%#Eval("id")%>'/>
                                               <asp:Button ID="ViewEvaluation" Text="View Evaluation" class="buttonStyle my-2" runat="server"  OnCommand="ViewEvaluation_Command" CommandName='<%#Eval("id")%>' CommandArgument='<%#Eval("student_accID")%>' AutoPostBack="false" CausesValidation="false" />

                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <h3 style="position: relative; top: 100px;">
                                        <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoAppliedJob" Text="You're not hired yet!"></asp:Label></h3>
                                </EmptyDataTemplate>
                            </asp:ListView>
                            <asp:DataPager ID="ListViewPager1" runat="server" PagedControlID="MyJobView" PageSize="10" class="btn-group btn-group-sm float-end">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                                    <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="false" ButtonCount="5" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary disabled" NextPreviousButtonCssClass="btn btn-default" />
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                                </Fields>
                            </asp:DataPager>
                        </div>

                        <div class="box" id="MyJobApplicationView" runat="server">
                            <h3 class="my-5">My Job Application</h3>
                            <asp:ListView ID="MyApplication" runat="server" class="container-fluid" OnItemDataBound="MyApplication_ItemDataBound" OnPagePropertiesChanged="MyApplication_PagePropertiesChanged">
                                <ItemTemplate>
                                    <div id="myApplicationList" runat="server" class="row d-flex align-items-center jobAppliedBox">
                                        <span runat="server" id="badge" class="NewBadge" visible="false">New</span>
                                        <div class="col-sm-2" style="text-align: center">
                                            <img id="IndstryLogo" src='<%#String.Format("images/IndustryProfile/{0}", Eval("industryPicture"))%>' runat="server" alt="Logo" class="imgStyle" />
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="row" style="border-right: 1px solid #881A30;">
                                                <label id="ApplicantID" runat="server" hidden="hidden"><%#Eval("applicantID")%></label>
                                                <label id="JobID" runat="server" hidden="hidden"><%#Eval("jobID")%></label>
                                                <label id="DateApplied" runat="server" hidden="hidden"><%#Eval("dateApplied")%></label>
                                                <label runat="server" hidden="hidden"><%#Eval("jobType")%></label>
                                                <div class="align-items-start">
                                                    <span>
                                                        <h3 style="color: #881A30; margin-bottom: 10px;"><b><%#Eval("jobTitle")%></b></h3>

                                                    </span>
                                                </div>
                                                <div class="col">
                                                    <label>Industry Name: </label>
                                                    <br />
                                                    <a href='ViewIndustryProfile.aspx?industry_accID=<%#Eval("industry_accID")%>'>
                                                        <span>
                                                            <%#Eval("industryName")%>
                                                        </span>
                                                    </a>
                                                </div>
                                                <div class="col">
                                                    <label>
                                                        Job Course: 
                                                    </label>
                                                    <br />
                                                    <span id="jobCourse" runat="server"><%#Eval("jobCourse") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>Job Type: </label>
                                                    <br />
                                                    <span><%#Eval("jobType") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>Job Location: </label>
                                                    <br />
                                                    <span><%#Eval("jobLocation") %></span>
                                                </div>
                                                <div class="col">
                                                    <label>Date Applied: </label>
                                                    <br />
                                                    <span><%#Eval("date_Applied") %></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-2 d-flex align-items-center">
                                            <div class="flex-fill">
                                                <asp:Button ID="ViewApplication" Text="View" class="buttonStyle" runat="server" CommandName='<%#Eval("jobID")%>' OnCommand="ViewApplication_Command" CommandArgument='<%#Eval("applicantID")%>' AutoPostBack="false" CausesValidation="false" />

                                            </div>

                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <h3 style="position: relative; top: 100px;">
                                        <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoAppliedJob" Text="No Job Applied Yet!"></asp:Label></h3>
                                </EmptyDataTemplate>
                            </asp:ListView>
                            <asp:DataPager ID="ListViewPager" runat="server" PagedControlID="MyApplication" PageSize="10" class="btn-group btn-group-sm float-end">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                                    <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="false" ButtonCount="5" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary disabled" NextPreviousButtonCssClass="btn btn-default" />
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                                </Fields>
                            </asp:DataPager>

                        </div>

                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <!-- Modal -->
            <div class="modal fade" id="ViewApplication" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row text-center my-1">
                                <h2><b>Application Process</b></h2>
                                <h4 class="m-0" id="Job_Title" runat="server" style="color:#881A30"></h4>
                            </div>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <ul class="applicationTimeline">
                                    <li id="applicantStatus" runat="server">
                                        <i class='bx bxs-time'></i>
                                        <div class="ContainerBox">
                                            <div style="background: #881A30; color: white; padding: 10px; padding-left: 10px;">
                                                <label>Application Status</label>
                                                <i class='bx bx-envelope' style="float: right; font-size: 20px;"></i>
                                            </div>
                                            <div style="padding: 10px;">
                                                <br />
                                                <b><span>Status: </span></b>
                                                <asp:Label ID="applicationStatusCheck" runat="server" Text="Waiting for your application approval..."></asp:Label>
                                                <asp:Literal ID="requirementDetails" runat="server" Visible="false" Mode="PassThrough"></asp:Literal>
                                                <asp:Literal ID="dateStarted" runat="server" Visible="false" Mode="PassThrough"></asp:Literal>
                                                <br />
                                                <br />
                                                <span id="statusApplication" visible="false" runat="server"></span><span id="dateApproved" runat="server" visible="false"></span>
                                                <br />
                                                <br />
                                            </div>
                                        </div>
                                    </li>
                                    <li id="InterviewStatus" runat="server">
                                        <i class='bx bxs-time'></i>
                                        <div class="ContainerBox">
                                            <div style="background: #881A30; color: white; padding: 10px; padding-left: 10px;">
                                                <label>Interview Status</label>
                                                <i class='bx bx-calendar-check' style="float: right; font-size: 20px;"></i>

                                            </div>

                                            <div style="padding: 10px;">
                                                <br />
                                                <b><span id="StatusOrDetails" runat="server">Status: </span></b>
                                                <asp:Label ID="interviewStatusCheck" runat="server" Text="Waiting for your interview schedule..."></asp:Label>
                                                <asp:Literal ID="dateScheduled" runat="server" Visible="false" Mode="PassThrough"></asp:Literal>
                                                <br />
                                                <br />
                                                <span id="statusInterview" visible="false" runat="server"></span><span id="interviewDate" runat="server" visible="false"></span>
                                                <br />
                                                <br />
                                            </div>
                                        </div>
                                    </li>
                                    <li id="ResumeStatus" runat="server">
                                        <i class='bx bxs-time'></i>
                                        <div class="ContainerBox">
                                            <div style="background: #881A30; color: white; padding: 10px; padding-left: 10px;">
                                                <label>Resume Status</label>
                                                <i class='bx bx-notepad' style="float: right; font-size: 20px;"></i>
                                            </div>
                                            <div style="padding: 10px;">
                                                <br />
                                                <b><span>Status: </span></b>
                                                <asp:Label ID="resumeStatusCheck" runat="server" Text="Waiting for your resume review status..."></asp:Label>

                                                <br />
                                                <br />
                                                <span id="statusResume" visible="false" runat="server"></span><span id="dateReviewed" runat="server" visible="false"></span>
                                                <br />
                                                <br />
                                            </div>
                                        </div>
                                    </li>

                                </ul>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="SwitchView" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function viewApplication() {
            $('#ViewApplication').modal('show');
        }
    </script>
</asp:Content>
