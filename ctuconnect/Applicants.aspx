<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Applicants.aspx.cs" Inherits="ctuconnect.Applicants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
        .profile-container{
            max-width:200px;
            max-height:300px;
            background-color:white;
            margin-left:2%;
            border-radius: 20px;
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
            width:200px;
            height:200px;
            background-color:white;
            /*margin-top:22%;*/
            padding-top:4px;
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
                font-size:16px;
                background-color:white; 
                width:1000px;
                top:0;
                bottom:0;
                padding: 2% 2% 0% 2%;
                overflow: auto;
                /*background-color:white;*/
                min-height:200%;
                /*overflow: auto;
                float:left;
                margin-left:25%;
                position:relative;
                padding: 4% 0% 0% 6%;*/
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
                border: 1px solid #881A30; padding: 10px; margin: auto; margin-bottom: 10px; width: 100%; height: 100%;
                box-shadow: 0px 0px 7px -3px  #bd0606;
                border-radius: 7px;
            }

            .status-area{
                padding: 10px;
            }

            .modal{
                 width:600px;
                 margin:auto;
                 margin-top:100px;
                
                 
             }
             .modal-content{
                 padding-left:2em;
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
                background-color: white;
                color: #881a30;
                border-radius: 15px;
                border: 1.5px solid #881a30;
                position:relative;
             }

             


             
    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; height:200px;">
                <div class="profile-container">
                <img src="images/industrypic.png" />
                <p >Industry Name</p>
                </div>
            </asp:TableCell>
            <asp:TableCell RowSpan="2" Style="padding:0px 10px 0px 25px; vertical-align:top;">
                <div class="display-container">
                     <h1 class="title">Applicants List</h1>
                    <p style="float:left; padding:10px;">
                        <asp:DropDownList ID="drpStatus" runat="server" CssClass="searchbox">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Rejected</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    
                    <h3 id="Job_Title" runat="server" visible="false" style="float:left; padding:10px;"></h3>
                    <!-- Repeater for Applicant -->
                    <asp:Repeater ID="rptApplicant" runat="server" OnItemDataBound="rptApplicant_ItemDataBound">
                        <ItemTemplate>
                            <div class="container-fluid">
                                <div class="row applicantBox">                                        
                                    <div class="col-5 d-flex flex-column">
                                        <div class="row">
                                            <div class="col-12 d-flex flex-column">
                                                <h4 Style="text-align:center; color:#881a30;"><b>Applicant Details</b></h4>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3 d-flex flex-column">
                                                Applicant Name:
                                            </div>
                                            <div class="col-5">
                                                <asp:Label ID="lblfname" runat="server" Text='<%# Eval("applicantFname") %>'></asp:Label>
                                                <asp:Label ID="lbllname" runat="server" Text='<%# Eval("applicantLname") %>'></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3 d-flex flex-column">
                                                Position:
                                            </div>
                                            <div class="col-5">
                                                <asp:Label ID="Lblposition" runat="server" Text='<%# Eval("appliedPosition") %>'></asp:Label>                                                
                                            </div>
                                        </div>
                                         <div class="row">
                                             <div class="col-3 d-flex flex-column">
                                                 Job Type:
                                             </div>
                                             <div class="col-5">
                                                 <asp:Label ID="lbljobType" runat="server" Text='<%# Eval("jobType") %>'></asp:Label>                                                
                                             </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-3 d-flex flex-column">
                                                Date Applied:
                                            </div>
                                            <div class="col-5">
                                                <asp:Label ID="lbldateApplied" runat="server" Text='<%# Bind("dateApplied", "{0:d}") %>'></asp:Label>                                                
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
                                                <asp:DropDownList ID="drpApplicantStatus" runat="server" CssClass="drpbox" Width="110px" Height="30px" onchange="confirmStatusUpdate(this);" AutoPostBack="false" OnSelectedIndexChanged="drpApplicantStatus_SelectedIndexChanged">
                                                <asp:ListItem Enabled="true" Text= "STATUS" Value= "-1"></asp:ListItem>
                                                <asp:ListItem>Approved</asp:ListItem>
                                                <asp:ListItem>Rejected</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <Triggers>
                        </ItemTemplate>                       
                    </asp:Repeater>
                
                </div>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; ">
                <div class="sidemenu-container">
                    <a  href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                     <a href="#"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                     <a class="active" href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                     <a  href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                     <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

                    <!-- Modal dialog -->
                    <div id="myModal" class="modal">
                        <div class="modal-content">
                            <!--<span class="close" onclick="closeModal()">&times;</span>-->
                            <br />
                            <h3 style="text-align:center">Interview Schedule</h3> 
                            <br />
                            <div class="row applicant-details">
                                <div class="col-3 d-flex flex-column">
                                    Interview Details:
                                </div>
                                <div class="col-9 d-flex flex-column">
                                    <asp:TextBox ID="txtInterviewDetails" runat="server" CssClass="txtbox" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row applicant-details">
                                <div class="col-3 d-flex flex-column">
                                    Interview Date:
                                </div>
                                <div class="col-9 d-flex flex-column">
                                    <asp:TextBox ID="txtInterviewDate" runat="server" TextMode="Date" CssClass="txtbox" Width="200px" Height="25px"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row applicant-buttons">
                                <div class="col-4 d-flex flex-column">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="saveInterviewDetails" CssClass="btn2" Height="28px" Width="100px"/>
                                </div>
                                <div class="col-2 d-flex flex-column">
                
                                </div>
                                <div class="col-4 d-flex flex-column">
                                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="closeEditModal" CssClass="btn1" Height="28px" Width="100px"/>
                                </div>
                            </div>
                            <br /><br />

                           
                        </div>
                    </div>
                    
                    <script>
                        function openModal(interviewDetails, interviewDate) {
                            document.getElementById("myModal").style.display = "block";
                                 
                            document.getElementById('<%=txtInterviewDetails.ClientID%>').value = interviewDetails;
                            document.getElementById('<%=txtInterviewDate.ClientID%>').value = interviewDate;

                        }

                        function closeModal() {
                            document.getElementById("myModal").style.display = "none";
                        }

                        function confirmStatusUpdate(dropdown) {
                            var selectedValue = dropdown.value;
                            var applicantID = dropdown.getAttribute('applicant-id');
                            var confirmationMessage = "Are you sure you want to '" + selectedValue + "' the applicant?";
                            if (confirm(confirmationMessage)) {
                                // If user clicks OK in the confirmation dialog, trigger the server-side postback
                                __doPostBack(dropdown.id, ''); // This will cause a postback and trigger the server-side event
                            } else {
                                // If user clicks Cancel, reset the dropdown to its initial value (optional)
                                dropdown.selectedIndex = 0;
                            }
                        }

                    </script>
                            
</asp:Content>
