<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyJobApplication.aspx.cs" Inherits="ctuconnect.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <style>
        
        .nav{
            padding:10px 10px 10px 10px;
            width:200px;
            margin:auto;
            margin-top:auto;
            
        }

        .nav a{
            font-size:18px;
            font-family:'Arial Rounded MT';
            color:#000000;
            padding-left:3px;
        }

        .nav a.active{
            background-color:rgb(255, 194, 102);
            border-radius:10px;
            min-height:10px;
            
        }

        .nav a:hover{
            background-color:rgb(255, 194, 102);
            border-radius:10px;
            min-height:10px;
            
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
            }
 .imgStyle {
     border-radius: 50%;
     border:solid black 1px;
     box-shadow: gray;
     width: 100px;
     height: 100px;
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
          width:80%;
          
        }


        .box {
          min-height: 100%;
          width:80%;
          background-color: #ffffff;
          padding-left:2em;
          
        }

        .profile {
          
          border-radius: 50px;
          position: relative;
          top: -50px;
          
          
        }

        .line{
            height:2px;
            width:95%;
            background-color:#881A30;
            color:#881A30;
            position:center;
        }

        .ContainerBox {
            border: solid 2px #c3c7c4;
            height:auto;
            margin: 10px;
             margin-bottom: 15px;
           vertical-align: bottom;
        }
        .statusStyle {
            border: solid 1px #06ba1b;
            background:#06ba1b;
            height:50px;
            padding: 6px;
            color:white;
        }
        .statusStyleReject {
            border: solid 1px #e30510;
            background:#e30510;
            height:50px;
            padding: 6px;
            color:white;
        }
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column" >
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">

                    <a  href="#myaccount">
                            <i class='bx bx-user-circle icon' ></i>
                            <span class="text nav-text">My Account</span>
                    </a>
                    <a href="Resume.aspx">
                            <i class='bx bx-file-blank icon' ></i>
                            <span class="text nav-text">Resume</span>
                    </a>
                    <a class="active" href="#application">
                            <i class='bx bx-layer icon' ></i>
                            <span class="text nav-text">Application</span>
                    </a>
                    <a href="#settings">
                            <i class='bx bx-cog icon' ></i>
                            <span class="text nav-text">Account Settings</span>
                    </a>
                    <a href="#help">
                            <i class='bx bx-help-circle icon' ></i>
                            <span class="text nav-text">Help</span>
                    </a>
                    <hr style="height:2px;border-width:0;color:#881A30;background-color:#881A30">
                    <a href="#signout">
                            <i class='bx bx-log-out icon' ></i>
                            <span class="text nav-text">Sign-out</span>
                    </a>
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="box">
                    <asp:DataList ID="MyApplication" runat="server" class="container-fluid">
                        <ItemTemplate>
                            <div id="myApplicationList" runat="server" style="border: 3px solid #a2a3a2; padding: 10px; margin: auto; margin-bottom: 10px; width: 100%; height: 100%" class="row d-flex align-items-center">
                                <div class="col-sm-2">
                                    <img id="IndstryLogo" src='<%#String.Format("images/{0}", Eval("industryPicture"))%>' runat="server" alt="Logo" class="imgStyle" />
                                </div>
                                <div class="col-sm-7">
                                    <div class="row">
                                        <label id="JobID" runat="server" hidden="hidden"><%#Eval("applicantID")%></label>
                                         <label id="Label1" runat="server" hidden="hidden"><%#Eval("jobID")%></label>
                                        <label runat="server" hidden="hidden"><%#Eval("jobType")%></label>
                                        <div class="align-items-start">
                                            <span>
                                                <h3><%#Eval("industryName")%></h3>
                                            </span>
                                        </div>
                                        <div class="col">
                                            <label>Job Title: </label>
                                            <span><%#Eval("jobTitle")%></span>
                                        </div>
                                        <div class="col">
                                            <label>
                                                Job Course: 
                                            </label>
                                            <span><%#Eval("jobCourse") %></span>
                                        </div>
                                        <div class="col">
                                            <label>Job Location: </label>
                                            <span><%#Eval("jobLocation") %></span>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-1" style="border-right: 2px solid #bdbdbd; height: 60px;">
                                </div>
                                <div class="col-sm-2 d-flex align-items-center">
                                    <div class="flex-fill">
                                        <asp:Button ID="ViewApplication" Text="View" class="buttonStyle" runat="server" CommandName='<%#Eval("jobID")%>' OnCommand="ViewApplication_Command"  CommandArgument='<%#Eval("applicantID")%>' AutoPostBack="false" CausesValidation="false" />
                                    </div>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>

                </div>
            </div>
        </div>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br />
     <!-- Modal -->
    <div class="modal fade" id="ViewApplication" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <h2>Application Process</h2>
                    </div>
                </div>
                <div class="modal-body">
                    <div id="ResumeStatus" runat="server" class="ContainerBox">
                        <div style="background: #881A30; color:white; padding:10px; padding-left:10px;">
                            <label>Resume Status</label>
                        </div>
                        <div style ="padding:10px;">
                        <br /> 
                         <b><span>Status: </span></b><asp:Label ID="resumeStatusCheck" runat="server" Text="Waiting for your resume review status..."></asp:Label>
                           <br />  <br /> 
                           <span id="statusResume" visible="false" runat="server" class="statusStyle">Reviewed</span>
                             <br />
                             <br />
                        </div>
                    </div>
                    <div id="InterviewStatus" runat="server" class="ContainerBox">
                        <div style="background: #881A30; color: white; padding: 10px; padding-left: 10px;">
                            <label>Interview Status</label>
                        </div>
                        <div style="padding: 10px;">
                            <br />
                            <b><span id="StatusOrDetails" runat="server">Status: </span></b>
                            <asp:Label ID="interviewStatusCheck" runat="server" Text="Waiting for your interview schedule..."></asp:Label>
                            <br />
                            <br />
                            <span id="statusInterview" visible="false" runat="server" class="statusStyle">Scheduled</span>
                             <br />
                             <br />
                        </div>
                    </div>
                    <div id="applicantStatus" runat="server" class="ContainerBox">
                        <div style="background: #881A30; color:white; padding:10px; padding-left:10px;">
                        <label>Applicantion Status</label>
                    </div>
                         <div style="padding: 10px;">
                            <br />
                            <b><span>Status: </span></b>
                            <asp:Label ID="applicationStatusCheck" runat="server" Text="Waiting for your application approval..."></asp:Label>
                            <br />
                            <br />
                            <span id="statusApplication" visible="false" runat="server" class="statusStyle"></span>
                             <br />
                             <br />
                        </div>
                        </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                </div>
            </div>
           </div>
    </div>
    </div>
</asp:Content>
