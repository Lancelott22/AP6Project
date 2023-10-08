<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JobPortal.aspx.cs" Inherits="ctuconnect.JobPortal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .box {
            min-width: 250px;
            height: 250px;
            border: 1px solid #FFFFFF;
            border-radius: 5px;
            padding: 5px;
            background: #FFFFFF;
            padding: 5px 5px;
            margin-left: 20px;
        }

        .profile {
            border-radius: 50px;
        }

        .searchbox {
            min-width: 90%;
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
            width: 90%;
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

        .col {
            font-size: 15px;
        }

        h3 {
            font-size: 20px;
        }
        .imgStyle {
            border-radius: 50%;
            border:solid black 1px;
            box-shadow: gray;
            width: 100px;
            height: 100px;
        }
    </style>

    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column align-items-center text-center">
                <br />
                <div class="box">
                    <img src="images/defaultprofile.jpg" alt="Bootstrap" class="profile" height="90" width="90">
                    <br />
                    <asp:Label ID="lblname" CssClass="name" runat="server" Text="Name of the Intern/Alumni"></asp:Label>
                    <br />
                    <asp:Label ID="lblacctid" CssClass="accountid" runat="server" Text="account id"></asp:Label>
                    <hr style="height: 2px; border-width: 0; color: gray; background-color: gray">
                    <a href="MyAccount.aspx" class="btn btn-primary btn-md">View Profile</a>
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <asp:TextBox ID="txtsearchOrder" CssClass="searchbox" runat="server" placeholder="Search job title or keyword"></asp:TextBox>
                <br />
            
                <hr class="line" />
                <div class="jobs">
                    <asp:DataList ID="JobHiring" runat="server" class="container-fluid">
                        <ItemTemplate>
                            <div id="jobList" runat="server" style="border: 3px solid #a2a3a2; padding: 10px; margin: auto; margin-bottom: 10px; width: 100%; height: 100%" class="row d-flex align-items-center">
                                <div class="col-sm-2">
                                    <img id="IndstryLogo" src='<%#String.Format("images/{0}", Eval("IndustryLogo"))%>' runat="server" alt="Logo" class="imgStyle"/>
                                   
                                </div>
                                <div class="col-sm-7">
                                    <div class="row">
                                        <label ID="JobID" runat="server" hidden="hidden"><%#Eval("jobID")%></label>
                                        <label  runat="server" hidden="hidden"><%#Eval("jobType")%></label>
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
                                        <asp:Button ID="ApplyJob" Text="Apply" class="buttonStyle" runat="server" CommandName="Apply" OnCommand="ApplyJob_Command" CommandArgument='<%#Eval("jobID")%>' AutoPostBack="false" CausesValidation="false"/>
                                    </div>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>

                </div>
            </div>
        </div>
    </div>
    <br />
    <br />

    <!-- Modal -->
    <div class="modal fade" id="ApplyJobModal" tabindex="-1" role="dialog"  aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-1">
                            <img id="IndstryLogo" runat="server" alt="Logo" class="imgStyle" />
                        </div>
                        <div class="col-4">
                            <asp:Label ID="JobTitle" runat="server" />
                        </div>
                        <div class="col-6">
                            <asp:Label ID="IndustryName" runat="server" /><br />
                            <br />
                        </div>

                    </div>
                </div>
                <div class="modal-body">
                    <asp:Label ID="JobId" runat="server" visible="false"/>
                    <label>JobDetail </label>
                    <asp:Label ID="JobDetail" runat="server" /><br />
                     <label>JobType </label>
                    <asp:Label ID="JobType" runat="server" /><br />
                      <label>JobLocation </label>
                    <asp:Label ID="JobLocation" runat="server" /><br />
                        <label>JobCourse </label>
                    <asp:Label ID="JobCourse" runat="server" /><br />
                    <label>JobQualification </label>
                    <asp:Label ID="JobQualification" runat="server" /><br />
                     <label>ApplicationInstruction </label>
                    <asp:Label ID="ApplicationInstruction" runat="server" /><br />
                        <label>SalaryRange </label>
                    <asp:Label ID="SalaryRange" runat="server" /><br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton ID="SubmitApply"  class="buttonStyle" runat="server"  OnCommand="SubmitApply_Command" AutoPostBack="false">Submit Application</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
