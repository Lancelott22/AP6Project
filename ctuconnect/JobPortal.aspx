<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="JobPortal.aspx.cs" Inherits="ctuconnect.JobPortal" MaintainScrollPositionOnPostback="true" ClientIDMode="AutoID" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        .box {
            min-width: 250px;
            width: contain;
            min-height: 200px;
            height: 200px;
            border: 1px solid #FFFFFF;
            border-radius: 5px;
            padding: 10px;
            background: #FFFFFF;
            padding: 5px 5px;
        }

        .profile {
            border-radius: 50px;
        }

        .searchbox {
            min-width: 97%;
            border-radius: 5px;
            padding: 5px;
            background: #F0EBEB;
            border: 1px solid grey;
        }

        .reco {
            width: 90%;
            min-height: 300px;
            background: #FFFFFF;
            border: 1px solid #FFFFFF;
            padding: 4px 4px 4px 4px;
            border-radius: 5px;
        }

        .jobs {
            width: 97%;
            min-height: 300px;
            background: #FFFFFF;
            border: 1px solid #FFFFFF;
            padding: 10px;
            border-radius: 5px;
        }

        .name {
            font-size: 16px;
            font-family: 'Arial Rounded MT';
        }

        .accountid {
            font-size: 12px;
            font-family: 'Arial Rounded MT';
        }

        .btn-md {
            border: 1px #F7941F;
            border-radius: 15px;
            background-color: #F7941F;
            width: 95px;
        }

        .line {
            height: 2px;
            width: 90%;
            background-color: #881A30;
            color: #881A30;
            position: center;
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

        .buttonStyleSubmit {
            background-color: white;
            width: 35%;
            text-align: center;
            text-decoration: none;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
            padding: 9px;
        }

            .buttonStyleSubmit:hover {
                background: orange;
                color: white;
                text-decoration: none;
                box-shadow: 3px 6px 7px -4px grey;
            }

        .buttonStyleSubmitDisable {
            background-color: white;
            width: 30%;
            text-align: center;
            text-decoration: none;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
            padding: 9px;
        }

            .buttonStyleSubmitDisable:hover {
                text-decoration: none;
                color: orange;
            }

        .col {
            font-size: 15px;
        }

        h3 {
            font-size: 20px;
        }

        .imgStyle {
            border-radius: 50%;
            border: solid grey 1px;
            box-shadow: gray;
            width: 95px;
            height: 95px;
            box-shadow: 0px 0px 12px -3px grey;
        }

        .row {
            margin-bottom: 10px;
        }

        .jobBox {
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

            .jobBox:hover {
                box-shadow: 3px 7px 18px #bd0606;
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
        /* width */
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

        .modal-footer {
            text-align: unset;
            justify-content: unset;
            display: block;
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
            left: 18px;
            box-shadow: 0px 0px 9px -1px #15d455;
            text-align: center;
        }

        .detailsBox {
            width: contain;
            min-width: 250px;
            margin-bottom: 20px;
            min-height: 660px;
            height: 660px;
            top: 20px;
            border: 1px solid #881A30;
            border-radius: 7px;
            box-shadow: 0px 0px 7px -3px #bd0606;
            position: sticky;
            margin-top: 20px;
            padding: 0px;
            background: white;
            transition: all 1s;
        }

        .detailsContent {
            padding: 0px;
            margin: 0px;
        }

        .detailsHeader {
            border-bottom: 1px solid transparent;
            box-shadow: 0 2px 4px #bd0606;
            height: 130px;
            margin: 0px;
            padding: 20px;
            padding-left: 30px;
        }

        .detailsBody {
            height: 450px;
            overflow-y: auto;
        }

        .detailsFooter {
            font-size: 14px;
            padding-left: 20px;
            padding-right: 20px;
            height: 50px;
            padding-top: 0px;
        }

        .detailsBody::-webkit-scrollbar {
            display: block;
            width: 5px;
        }

        /* Handle */
        .detailsBody::-webkit-scrollbar-thumb {
            background: #ba7373;
            border-radius: 10px;
        }
            /* Handle on hover */
            .detailsBody::-webkit-scrollbar-thumb:hover {
                background: #881A30;
            }

        body:not(.modal-open) {
            padding-right: 0px !important;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ClientIDMode="AutoID">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row" style="padding-top: 10px;">
                    <div class="col-5 d-flex flex-column">

                        <div style="margin: 10px; margin-left: 5%; height: 100%; position: relative; padding: 0px;">
                            <div class="box text-center">
                                <br />
                                <asp:Image ID="profileImage" CssClass="profile" Width="100px" Height="100px" runat="server" />
                                <br />
                                <asp:Label ID="StudentName" CssClass="name" runat="server"></asp:Label>
                                <span><i class="fa fa-address-card-o m-1" id="resumeIcon" runat="server" aria-hidden="true" data-toggle="tooltip" data-placement="auto"></i></span>

                                <br />
                                <asp:Label ID="StudentID" CssClass="accountid" runat="server"></asp:Label>
                            </div>
                            <div class="detailsBox" id="JobDetailBox" runat="server" visible="false">
                                <asp:UpdateProgress ID="LoadDetails" class="align-items-center h-100" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="true">
                                    <ProgressTemplate>
                                        <div class="d-flex justify-content-center align-items-center h-100">
                                            <div class="spinner-border" role="status">
                                                <span class="visually-hidden">Loading...</span>
                                            </div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="detailsContent" id="JobDetailContent" runat="server">
                                    <asp:Label ID="IndustryID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="Job_ID" runat="server" Visible="false"></asp:Label>

                                    <div class="detailsHeader">
                                        <div class="row">
                                            <div class="col-3">

                                                <img id="IndstryLogo" runat="server" alt="Logo" class="imgStyle" />

                                            </div>
                                            <div class="col-9">
                                                <div class="row" style="margin: 0px; margin-bottom: 5px;">
                                                    <asp:Label ID="JobTitle" runat="server" Style="font-size: 23px; font-weight: bold; color: #881A30;" />

                                                </div>
                                                <div class="row" style="margin: 0px; margin-bottom: 2px;">
                                                    <a href="#" style="text-decoration: underline;">
                                                        <asp:Label ID="IndustryName" runat="server" Style="font-size: 17px;" /></a>
                                                </div>

                                                <div class="row" style="margin: 0px; margin-bottom: 2px; font-size: 15px;">
                                                    <asp:Label ID="JobLocation" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="detailsBody">
                                        <div style="padding: 15px; padding-top: 20px;">
                                            <div class="container-fluid row lh-lg">
                                                <h3><b>Job Details</b></h3>
                                                <br />
                                                <span>
                                                    <label>Job Type: </label>
                                                    <asp:Label ID="JobType" runat="server" />
                                                    <br />
                                                </span>
                                                <span>
                                                    <label>Job Course: </label>
                                                    <asp:Label ID="JobCourse" runat="server" />
                                                    <br />
                                                </span>
                                                <span id="salaryData" runat="server">
                                                    <label>Salary: </label>
                                                    <asp:Label ID="SalaryRange" runat="server" />
                                                    <br />
                                                </span>
                                            </div>
                                            <hr style="border: 1px solid #000000;" />
                                            <div class="container-fluid row">
                                                <h4>
                                                    <label>Job Description</label></h4>
                                                <asp:Label ID="JobDescription" runat="server" Style="margin-bottom: 10px;" /><br />

                                                <h4>
                                                    <label>Job Qualification </label>
                                                </h4>
                                                <asp:Label ID="JobQualification" runat="server" Style="margin-bottom: 10px;" /><br />

                                                <h4>
                                                    <label>Application Instruction </label>
                                                </h4>

                                                <asp:Label ID="ApplicationInstruction" runat="server" Style="margin-bottom: 5px;" />
                                            </div>
                                        </div>

                                    </div>
                                    <hr style="border: 1px solid #bd0606; margin-top: 15px; margin-bottom: 15px;" />
                                    <div class="detailsFooter">
                                        <div style="float: left;">
                                            <span>
                                                <label>Date Posted: </label>
                                                <asp:Label ID="DatePosted" runat="server" /></span>
                                        </div>
                                        <div style="float: right;">
                                            <span>
                                                <asp:LinkButton ID="ReportJob" runat="server" CssClass="btn btn-default" OnCommand="ReportJob_Command"><i class="fa fa-flag" aria-hidden="true"></i> Report Job</asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="col-7 d-flex flex-column ">
                        <br />
                        <asp:TextBox ID="txtsearchOrder" CssClass="form-control searchbox" runat="server" placeholder="Search job title or keyword"></asp:TextBox>
                        <br />
                        <label id="totalJob" runat="server"></label>
                        <div class="jobs">


                            <asp:ListView ID="JobHiring" runat="server" class="container-fluid" OnItemDataBound="JobHiring_ItemDataBound" ClientIDMode="AutoID" OnPagePropertiesChanged="JobHiring_PagePropertiesChanged">
                                <ItemTemplate>
                                    <div id="jobList" runat="server" class="row d-flex align-items-center jobBox">
                                        <span runat="server" id="badge" class="NewBadge" visible="false">New</span>
                                        <div class="col-sm-2" style="text-align: center">
                                            <img id="IndstryLogo" src='<%#String.Format("../images/IndustryProfile/{0}", Eval("industryPicture"))%>' runat="server" alt="Logo" class="imgStyle" />
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="row" style="border-right: 1px solid #881A30;">
                                                <asp:Label ID="JobPostID" runat="server" Visible="false" Text='<%#Eval("jobID")%>'></asp:Label>
                                                <asp:Label ID="Industry_accID" runat="server" Visible="false" Text='<%#Eval("industry_accID")%>'></asp:Label>
                                                <asp:Label ID="JobPostedDate" runat="server" Visible="false" Text='<%#Eval("jobPostedDate")%>'></asp:Label>
                                                <label runat="server" hidden="hidden"><%#Eval("jobType")%></label>
                                                <div class="align-items-start">
                                                    <span>
                                                        <h3 style="color: #881A30; margin-bottom: 10px;"><b><%#Eval("jobTitle")%></b></h3>

                                                    </span>
                                                </div>
                                                <div class="col-3">
                                                    <label>Industry Name: </label>
                                                    <br />
                                                    <span>
                                                        <%#Eval("industryName")%>
                                                    </span>

                                                </div>
                                                <div class="col-3">
                                                    <label>
                                                        Job Course: 
                                                    </label>
                                                    <br />
                                                    <span id="jobCourse" runat="server"><%#Eval("jobCourse") %></span>
                                                </div>
                                                <div class="col-3">
                                                    <label>Job Location: </label>
                                                    <br />
                                                    <span><%#Eval("jobLocation") %></span>
                                                </div>
                                                <div class="col-3">
                                                    <label>Date: </label>
                                                    <br />
                                                    <span>
                                                        <asp:Label ID="timeAgoMsg" runat="server" Text=""></asp:Label></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-2" style="position: relative; text-align: center; vertical-align: middle; margin: 0px;">

                                            <div class="row">
                                                <asp:Button ID="ApplyJob" Text="Apply" class="buttonStyle" runat="server" CommandName='<%#Eval("jobTitle")%>' OnCommand="ApplyJob_Command" CommandArgument='<%#Eval("jobID")%>' CausesValidation="false" />
                                            </div>

                                            <div class="row">
                                                <asp:Button ID="JobDetails" Text="Details" class="buttonDetails" runat="server" OnClientClick="showDiv();" CommandName="Detail" OnCommand="JobDetails_Command" CommandArgument='<%#Eval("jobID")%>' CausesValidation="false" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <h3 style="position: relative; top: 40%;">
                                        <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoPost" Text="No Job Posted Yet!"></asp:Label></h3>
                                </EmptyDataTemplate>
                            </asp:ListView>
                            <asp:DataPager ID="ListViewPager" runat="server" PagedControlID="JobHiring" PageSize="15" class="btn-group btn-group-sm float-end">
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

            <!-- Modal -->

            <div class="modal" id="ApplyJobModal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                    <div class="modal-content">
                        <asp:Label ID="applyJobId" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="applyIndustryId" runat="server" Visible="false"></asp:Label>
                        <div class="modal-header">
                            <h2><b>Job Application</b></h2>
                        </div>

                        <div class="modal-body" style="padding: 20px;">
                            <div runat="server" id="JobApply">
                                <div class="form-group row">
                                    <label for="ApplyForJob" class="col-sm-3 col-form-label">Job Title</label>
                                    <div class="col-sm-9">
                                        <input type="text" class="form-control" id="ApplyForJob" runat="server" placeholder="Job Title" disabled>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="job_Type" class="col-sm-3 col-form-label">Job Type</label>
                                    <div class="col-sm-9">
                                        <select runat="server" class="form-control" id="job_Type">
                                            <option value="" disabled selected hidden>Select Job Type</option>
                                            <option value="internship">Internship</option>
                                            <option value="fulltime">Full-time</option>
                                        </select>
                                        <span runat="server" id="requiredError" class="text-danger" visible="false" style="position: absolute; right: 15%; top: 0;">*</span>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="Name" class="col-sm-3 col-form-label">Name</label>
                                    <div class="col-sm-9">
                                        <input type="text" class="form-control" id="Name" runat="server" placeholder="Your Name" disabled>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="Resume" class="col-sm-3 col-form-label">Resume</label>
                                    <div class="col-sm-9">
                                        <input type="text" class="form-control" id="Resume" runat="server" placeholder="Your Resume" disabled>
                                    </div>
                                </div>

                                <div class="form-group row" id="Endorsement_LetterBox" runat="server">
                                    <label for="EndorsementLetter" class="col-sm-3 col-form-label">Endorsement Letter</label>
                                    <div class="col-sm-9">
                                        <asp:FileUpload ID="EndorsementLetter" class="form-control" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div runat="server" id="AlreadyApplied">
                                <h3 style="position: relative; top: 40%;">
                                    <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="Label1" Text="You already applied to this job!"></asp:Label></h3>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div style="float: right;">
                                <button type="button" id="CancelorClose" runat="server" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                <asp:LinkButton ID="SubmitApply" class="buttonStyleSubmit" runat="server" OnCommand="SubmitApply_Command" AutoPostBack="false" ValidationGroup="SubmitApply">Submit Application</asp:LinkButton>
                            </div>
                        </div>


                    </div>
                </div>
            </div>

            <div class="modal" id="ReportJobModal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                    <div class="modal-content">
                        <asp:Label ID="report_jobID" runat="server" Visible="false"></asp:Label>
                        <div class="modal-header">
                            <h3><b>Report Job Problem</b></h3>
                        </div>
                        <div class="modal-body" style="padding: 20px;">
                            <span id="submitErrorMsg" runat="server" visible="false" class="text-danger">*Please fill all fields</span>
                            <span>
                                <h5 id="Report_JobTitle" runat="server" class="fw-bold opacity-75"></h5>
                                <h5 id="Report_IndustryName" runat="server" class="opacity-75"></h5>
                            </span>
                            <div class="container-fluid d-flex flex-column">
                                <div class="form-group row">
                                    <label for="problemType" class="fs-4">Problem Type</label>
                                    <input type="text" class="form-control" id="problemType" runat="server" placeholder="Input problem type">
                                </div>
                                <div class="form-group row">
                                    <label for="reportDetails" class="fs-4">Describe your problem</label>
                                    <textarea class="form-control" cols="40" rows="5" id="reportDetails" runat="server" placeholder="Problem Details"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div style="float: right;">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                <asp:LinkButton ID="SubmitReport" class="buttonStyleSubmit" runat="server" OnCommand="SubmitReport_Command">Submit Report</asp:LinkButton>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="SubmitApply" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function showModalFunction() {
            $('#ApplyJobModal').modal('show');
        }
    </script>
    <script type="text/javascript">
        function showReportModal() {
            $('#ReportJobModal').modal('show');
        }
    </script>
    <script type="text/javascript">
        function showDiv() {
            var details = document.getElementById('<%= JobDetailContent.ClientID %>');
            if (details.style.display === 'none') {
                details.style.display = 'block';
            } else {
                details.style.display = 'none';
            }
        }
    </script>
</asp:Content>
