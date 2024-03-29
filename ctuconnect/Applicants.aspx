﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="Applicants.aspx.cs" Inherits="ctuconnect.Applicants" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>

    <!-- include summernote css/js -->
    <link href="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js"></script>
    
    <style>
         @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
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
                width:70px;
                bottom:0;
                background-color: #881A30;

            }
             .content {
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
             .fa {
                width:20px;
                margin-right: 19px; 
             }

             .modal{
                 width:500px;
                 margin:auto;
                 margin-top:20px;
                
                 
             }
             .modal-content{
                 padding-left:2em;
             }

             .center-header {
                text-align: center;
            }

             .applicant-details{
                 padding-left:2em;
             }

             .txtbox{
                border-radius: 3px;
    
             }

             .btn1{
                border: 1px solid red;
                border-radius: 5px;
                background-color: red;
                font-size: 14px;
    
             }

            .btn2{
                border: 1px #00cc99;
                border-radius: 5px;
                background-color: #00cc99;
                font-size: 14px;
    
            }

            .applicant-buttons{
                padding-left:5em;
            }

            .applicantBox {
                border: 1px solid #881A30; padding: 10px; margin: auto; margin-bottom: 10px; width: 100%; max-height: 100%;
                box-shadow: 0px 0px 7px -3px  #bd0606;
                border-radius: 7px;
                padding-left:3em;
                position:relative;
            }

            .status-area{
                padding: 10px;
                padding-left:3em;
            }

            .modal{
                 width:1000px;
                 margin:auto;
                 margin-top:50px;
                
                 
             }
             .modal-content{
                 padding-left:1em;
                 padding-right:2em;
             }

             .applicant-details{
                 padding-left:2em;
                 font-size:20px;
             }

             .txtbox{
                border-radius: 3px;
    
             }

             .searchbox {
                width: 400px;
                border-radius: 5px;
                padding: 5px;
                height: 50px;

             }

             .btnApplicant {
                background-color: white;
                color: orange;
                border-radius: 15px;
                border: 1.5px solid orange;
                position:relative;
             }

             .btnApplicant:hover{
                background: orange;
                color: white;
             }

             .drpbox {
                

                border: 1px solid #ccc; /* Add a border */
                border-radius: 5px; /* Add rounded corners */
                padding: 5px; /* Add some padding */
                font-size: 14px; /* Set the font size */
                margin-top: 5px; /* Add some top margin */
                box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); /* Add a subtle box shadow */
             }

             .buttonSubmit {
                background-color: white;
                width: 80px;
                height: 35px;
                color: orange;
                border-radius: 10px;
                border: 1px solid orange;
                transition: background-color 0.3s, color 0.3s, border-color 0.3s;
             }

             .empty-message{
                display: flex;
                align-items: center;
                height: 500px;
                font-size:20px;
                font-weight:bold;
                padding-left:10em;
                
             }

             .applicant-info{
                 text-align:right;
                 font-weight:bold;
             }

             .btn-search{
                border-color:#F7941F ;
                background-color: #F7941F
             }

             .txtbox-description{
                border-radius: 10px;
                width: 70%;
                min-height:100px;
                height:auto;
                margin-bottom:2%;
                border: 1px solid gray;
                padding:10px; 
                padding-left:20px;
                padding-top:20px;
             }

             .txtDate{
                border: 1px solid #ccc; /* Add a border */
                border-radius: 5px; /* Add rounded corners */
                padding: 5px; /* Add some padding */
                font-size: 16px; /* Set the font size */
                margin-top: 5px; /* Add some top margin */
                box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); /* Add a subtle box shadow */
             }
             
             .MatchBadge {
                border: solid 1px #4287f5;
                border-radius: 5px;
                height: 20px;
                width: 80px;
                background: #4287f5;
                padding: 2px;
                color: #ffffff;
                font-size: 11px;
                position: absolute;
                top: 10px;
                left: 18px;
                box-shadow: 0px 0px 9px -1px #4287f5;
                text-align: center;
                z-index:1;
            }   
           
    </style>
    
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; height:180px;">
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
          
            <asp:TableCell RowSpan="2" Style="padding:0px 10px 0px 25px; vertical-align:top;">
                <div class="display-container">
                     <h1 class="title">Applicants List</h1>
                    <div class="input-group mb-3" style="float:left; padding:10px;">
                        <asp:TextBox ID="ApplicantsID" runat="server" class="form-control" Placeholder="Lastname or Firstname or Status"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button class="btn btn-primary btn-search" runat="server" ID="SearchApplicant" Text="Search" OnClick="SearchApplicant_Click"/>
                        </div>
                    </div>

                    <h3 id="Job_Title" runat="server" visible="false" style="float:left; padding:10px;"></h3>
                    
                    <asp:Repeater ID="rptApplicant" runat="server" OnItemDataBound="rptApplicant_ItemDataBound">
                        <ItemTemplate>
                            <div class="container-fluid">
                                <div class="row applicantBox">
                                    <asp:Label ID="ApplicantID" runat="server" Visible="false" Text='<%#Eval("applicantID")%>'></asp:Label>
                                    <asp:Label ID="JobPostID" runat="server" Visible="false" Text='<%#Eval("jobID")%>'></asp:Label>
                                    <asp:Label ID="studentAccID" runat="server" Visible="false" Text='<%#Eval("student_accID")%>'></asp:Label>
                                     <span runat="server" id="MatchedBadge" class="MatchBadge" visible="false">Matched Skill</span>
                                    <div class="col-5 d-flex flex-column">
                                        <div class="row">
                                            <div class="col-12 d-flex flex-column">
                                                <h4 Style="text-align:center; color:#881a30;"><b>Applicant Details</b></h4>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3 d-flex flex-column applicant-info">
                                                Name
                                            </div>
                                            <div class="col-5">
                                                <a href='<%# ResolveUrl("~/ViewApplicantProfile?student_accID=" + Eval("student_accID"))%>' style="text-decoration: underline;">
                                                <asp:Label ID="lblfname" runat="server" Text='<%# Eval("applicantFname") %>'></asp:Label>
                                                <asp:Label ID="lbllname" runat="server" Text='<%# Eval("applicantLname") %>'></asp:Label>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3 d-flex flex-column applicant-info">
                                                Position
                                            </div>
                                            <div class="col-5">
                                                <asp:Label ID="Lblposition" runat="server" Text='<%# Eval("appliedPosition") %>'></asp:Label>                                                
                                            </div>
                                        </div>
                                         <div class="row">
                                             <div class="col-3 d-flex flex-column applicant-info">
                                                 Job Type
                                             </div>
                                             <div class="col-5">
                                                 <asp:Label ID="lbljobType" runat="server" Text='<%# Eval("jobType") %>'></asp:Label>                                                
                                             </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3 d-flex flex-column applicant-info">
                                                Date Applied
                                            </div>
                                            <div class="col-5">
                                                <asp:Label ID="lbldateApplied" runat="server" Text='<%# Bind("dateApplied", "{0:d}") %>'></asp:Label>                                                
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3 d-flex flex-column applicant-info">
                                                Endorsement
                                                <asp:Label ID="lblEndorsement" runat="server" Visible="false" Text='<%# Eval("endorsementLetter") %>'></asp:Label>  
                                            </div>
                                            <div class="col-5">
                                                <asp:Button ID="btnEndorsement" runat="server" Text="View Endorsement Letter" Width="210px" Height="30px" CssClass="btnEndorsement" OnCommand="EndorsementButton_Command" CommandName="Endorsement" CommandArgument='<%# Eval("applicantID") %>' />
                                                <asp:Label ID="lblendorsementStatus" runat="server" Visible="false" Text="N/A"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row" runat="server" id="skillsMatch" visible="false">
                                            <div class="col-3 d-flex flex-column applicant-info">
                                                Matched Skills 
                                             </div>
                                            <div class="col-5">
                                                <asp:Label ID="matchSkillsLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-1" style="border-right: 1px solid #881A30; min-height:100px;">
                                    </div>
                                    <div class="col-6">
                                        <div class="row">
                                            <div class="col-12 d-flex flex-column">
                                                <h4 Style="text-align:center; color:#881a30;"><b>Status</b></h4>
                                            </div>
                                        </div>
                                        <div class="row status-area">
                                            <div class="col-3 d-flex flex-column">
                                                Resume Status:
                                            </div>
                                            <div class="col-5 d-flex flex-column">
                                                <asp:Label ID="lblresumeStatus" runat="server" Text='<%# Eval("resumeStatus") %>'></asp:Label>
                                            </div>
                                            <div class="col-4 d-flex flex-column">
                                                <asp:Button ID="btnReview" runat="server" Text="Review" Width="110px" Height="30px" CssClass="btnApplicant" OnCommand="ReviewButton_Command" CommandName="Review" CommandArgument='<%# Eval("applicantID") %>' />
                                            </div>
                                        </div>
                                        <div class="row status-area">
                                            <div class="col-3 d-flex flex-column">
                                                Interview Status:
                                            </div>
                                            <div class="col-5 d-flex flex-column">
                                                <asp:Label ID="lblinterviewStatus" runat="server" Text='<%# Eval("interviewStatus") %>'></asp:Label>
                                            </div>
                                            <div class="col-4 d-flex flex-column">
                                                <asp:Button ID="btnSchedule" runat="server" Text="Add Schedule" Width="110px" Height="30px" CssClass="btnApplicant" OnClick="btnSchedule_Click" CommandName="Add Schedule" CommandArgument='<%# Eval("applicantID") %>'/>
                                            </div>
                                        </div>
                                        <div class="row status-area">
                                            <div class="col-3 d-flex flex-column">
                                                Applicant Status:
                                            </div>
                                            <div class="col-5 d-flex flex-column">
                                                <asp:Label ID="lblapplicantStatus" runat="server" Text='<%# Eval("applicantStatus") %>'></asp:Label>
                                            </div>
                                            <div class="col-4 d-flex flex-column">
                                                <asp:Label ID="lblapplicantID" runat="server" Text='<%# Eval("applicantID") %>' Visible="false"></asp:Label>
                                                <asp:Button ID="btnApplication" runat="server" Text="Set Application" Width="140px" Height="30px" CssClass="btnApplicant" OnClick="btnApplication_Click" CommandName="Applicants" CommandArgument='<%# Eval("applicantID") %>'/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <Triggers>
                        </ItemTemplate>
                    </asp:Repeater>
                    <% if (rptApplicant.Items.Count == 0) { %>
                        <div class="empty-message">
                            <p>No Applicants Yet</p>
                        </div>
                    <% } %>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; width:230px; ">
                <div class="sidemenu-container">
                    <a href="IndustryDashboard.aspx"><i class="bx bxs-dashboard" aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                    <a href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                    <a href="IndustryJobPosted.aspx"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                    <a class="active" href="#"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
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
            
                    <!-- Modal dialog -->
                    <div id="myModal" class="modal">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h2 class="title">Interview Schedule</h2>
                            </div>
                            <div class="modal-body">
                                <div class="row applicant-details">                                   
                                    <div class="col-12 d-flex flex-column">
                                        <asp:Label ID="lblinterviewDetails" runat="server" Text="Interview Details" Style="font-size:20px;"></asp:Label>
                                        <asp:TextBox ID="txtInterviewDetails" runat="server" Width="400px" Height="100px" ValidateRequestMode="Disabled" Rows="10" TextMode="MultiLine" CssClass="form-control txtbox-description summernote1" Placeholder="Enter Interview Details"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row applicant-details">
                                    <div class="col-9 d-flex flex-column">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                            <asp:Label ID="lblDateinterview" runat="server" Text="Interview Date" Style="font-size:20px;"></asp:Label><br />
                                            <asp:TextBox ID="txtInterviewDate" runat="server" TextMode="Date" CssClass="txtDate" Width="250px" Height="40px" AutoPostBack="True" OnTextChanged="txtDate_TextChanged"></asp:TextBox><br />
                                            <asp:Label ID="lblinterviewdate" runat="server" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label><br />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    
                                    </div>
                                </div>
                            </div>           
                            <div class="modal-footer">
                                <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="closeEditModal" class="btn btn-secondary"/>
                               <asp:Button ID="btnSave" class="buttonSubmit" runat="server" Text="Save" OnClick="saveInterviewDetails"/>
                            </div>
                    
                           
                        </div>
                    </div>
                
                    
                    <script type="text/javascript">
                        function openModal(interviewDetails, interviewDate) {
                            document.getElementById("myModal").style.display = "block";

                            document.getElementById('<%=txtInterviewDetails.ClientID%>').value = interviewDetails;
                            document.getElementById('<%=txtInterviewDate.ClientID%>').value = interviewDate;

                        }

                        function closeEditModal() {
                            document.getElementById("myModal").style.display = "none";
                        }

                        function closeModal() {
                            document.getElementById("SetApplicationModal").style.display = "none";
                        }

                        function openModal2(requirements, dateStart) {
                            document.getElementById("SetApplicationModal").style.display = "block";

                            document.getElementById('<%=txtrequirements.ClientID%>').value = requirements;
                            document.getElementById('<%=txtDateStart.ClientID%>').value = dateStart;

                        }

                        $(document).ready(function () {
                            $('.summernote1').summernote({
                                height: 300,
                                placeholder: 'Enter Interview Details...',
                                toolbar: [
                                    ['style', ['bold', 'italic', 'underline', 'clear']],
                                    ['font'],
                                    ['fontsize', ['fontsize']],
                                    ['color', ['color']],
                                    ['para', ['ul', 'ol', 'paragraph']],

                                    ['height', ['height']]

                                ]
                            });

                            $('.summernote2').summernote({
                                height: 300,
                                placeholder: 'Enter Requirements...',
                                toolbar: [
                                    ['style', ['bold', 'italic', 'underline', 'clear']],
                                    ['font',],
                                    ['fontsize', ['fontsize']],
                                    ['color', ['color']],
                                    ['para', ['ul', 'ol', 'paragraph']],

                                    ['height', ['height']]
                                ]
                            });
                        });
                           
                    </script>
    
         
         <%--Modal--%>
                 <div class="modal" id="SetApplicationModal" tabindex="-1" role="dialog" >
                         <div class="modal-content">
                             <div class="modal-header">
                                 <h2 class="title">Set Application</h2>
                             </div>
                                 <div class="modal-body">
                                                <br />
                                                <div class="row">
                                                    <div class="col-12 d-flex flex-column">
                                                        <asp:Label ID="lblRequirements" runat="server" Text="Requirements" Style="font-size:20px;"></asp:Label>
                                                        <asp:TextBox ID="txtrequirements" runat="server" Width="400px" Height="100px" ValidateRequestMode="Disabled" Rows="10" TextMode="MultiLine" CssClass="form-control txtbox-description summernote2"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-8 d-flex flex-column">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                            <asp:Label ID="lbldatestart" runat="server" Text="Date Start" Style="font-size:20px;"></asp:Label><br />
                                                            <asp:TextBox ID="txtDateStart" runat="server" TextMode="Date" CssClass="txtDate" Width="250px" Height="40px" AutoPostBack="True" OnTextChanged="txtDateStart_TextChanged"></asp:TextBox><br />
                                                            <asp:Label ID="lblerrordate" runat="server" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label><br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
        
                                                    </div>
                                                    <div class="col-4 d-flex flex-column" style="float:right; padding-top:2em;">
                                                            <asp:DropDownList ID="drpApplicantStatus" runat="server" CssClass="drpbox" Width="250px" Height="40px">
                                                            <asp:ListItem Enabled="true" Text= "STATUS" Value= "-1"></asp:ListItem>
                                                            <asp:ListItem>Hire</asp:ListItem>
                                                            <asp:ListItem>Reject</asp:ListItem>
                                                            </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                
                      
                             </div>
                             <div class="modal-footer">
                                <asp:Button ID="btnClose2" runat="server" Text="Close" OnClick="closeModal" class="btn btn-secondary"/> 
                                <asp:Button ID="btnSubmit" class="buttonSubmit" runat="server" Text="Submit" OnCLick="Submit_ButtonClick"/>
                             </div>
                     </div>
                  </div>
    

                            
</asp:Content>