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
               box-shadow: 3px 6px 7px -4px  grey;
            }
        .buttonStyleSubmit {
            background-color: white;
            width:20%;
            text-align: center;
            text-decoration: none;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
        padding:5px;
        }

            .buttonStyleSubmit:hover {
                background: orange;
                color: white;
                  text-decoration: none;
                   box-shadow: 3px 6px 7px -4px  grey;
            }
        .buttonStyleSubmitDisable {
            background-color: white;
            width:20%;
            text-align: center;
            text-decoration: none;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
        padding:5px;
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
            border:solid grey 1px;
            box-shadow: gray;
            width: 100px;
            height: 100px;
            box-shadow: 0px 0px 12px -3px  grey;
        }
        .row {
            margin-bottom:10px;
        }
        .jobBox {
            border: 1px solid #881A30; padding: 10px; margin: auto; margin-bottom: 10px; width: 100%; height: 100%;
            box-shadow: 0px 0px 7px -3px  #bd0606;
            border-radius: 7px;
        }
        .jobBox:hover {
            box-shadow: 3px 7px 18px #bd0606;
        }
        /* width */
         .modal ::-webkit-scrollbar {
            display:none;
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
        .modal-content:hover ::-webkit-scrollbar{
            display:block;
            
        }
            /* Handle on hover */
            .modal ::-webkit-scrollbar-thumb:hover {
                background: #881A30;
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
            
              
                <div class="jobs">
                    <asp:DataList ID="JobHiring" runat="server" class="container-fluid"  >
                        <ItemTemplate>
                            <div id="jobList" runat="server" class="row d-flex align-items-center jobBox">
                                <div class="col-sm-2">
                                    <img id="IndstryLogo" src='<%#String.Format("../images/IndustryProfile/{0}", Eval("industryPicture"))%>' runat="server" alt="Logo" class="imgStyle"/>
                                    
                                </div>
                                <div class="col-sm-7">
                                    <div class="row">
                                        <asp:Label ID="PostID" runat="server" Visible="false" Text='<%#Eval("jobID")%>'></asp:Label>
                                       <asp:Label ID="Industry_accID" runat="server" Visible="false" Text='<%#Eval("industry_accID")%>'></asp:Label>
                                        <label  runat="server" hidden="hidden"><%#Eval("jobType")%></label>
                                        <div class="align-items-start">                                         
                                            <span>
                                                <h3 style="color:#881A30; margin-bottom:10px;"><b><%#Eval("jobTitle")%></b></h3>

                                            </span>
                                        </div>
                                        <div class="col">
                                             <label>Industry Name: </label><br />
                                             <span>
                                                <%#Eval("industryName")%>
                                            </span>
                                            
                                        </div>
                                        <div class="col">
                                            <label>
                                                Job Course: 
                                            </label><br />
                                            <span ID="jobCourse" runat="server"><%#Eval("jobCourse") %></span>
                                        </div>
                                        <div class="col">
                                            <label>Job Location: </label><br />
                                            <span><%#Eval("jobLocation") %></span>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-1" style="border-right: 1px solid #881A30; height:100px;">
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
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" role="document">
            <asp:Label ID="IndustryID" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="Job_ID" runat="server" Visible="false"></asp:Label>
            <div class="modal-content">
                <div class="modal-header">
                    <div class="container row" style="margin-left: 5px;"></div>
                    <div class="col-3">
                        <div>
                            <img id="IndstryLogo" runat="server" alt="Logo" class="imgStyle" />
                        </div>
                    </div>
                    <div class="col-9" style="margin-left: 10px;">
                        <div class="row" style="margin: 0px; margin-bottom: 5px;">
                            <asp:Label ID="JobTitle" runat="server" Style="font-size: 23px; font-weight: bold; color: #881A30;" />
                        </div>

                        <div class="row" style="margin: 0px; margin-bottom: 2px;">
                            <a href="#" style="text-decoration: underline;">
                                <asp:Label ID="IndustryName" runat="server" Style="font-size: 17px;" /></a>
                        </div>
                       
                        <div class="row" style="margin: 0px;margin-bottom: 2px; font-size:15px;">
                            <asp:Label ID="JobLocation" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div style="padding: 10px;">
                        <div class="container-fluid row">
                            <h3><b>Job Details</b></h3>
                            <br /><br />
                            <span><label>Job Type: </label>  <asp:Label ID="JobType" runat="server"  /></span><br />

                            <span><label>Job Course: </label>  <asp:Label ID="JobCourse" runat="server" /></span><br />
                           
                            <span id="salaryData" runat="server"><label>Salary: </label>  <asp:Label ID="SalaryRange" runat="server" /> </span><br />
                        </div>
                        <hr style="border:1px solid #000000;"/>
                        <div class="container-fluid row" >
                        <label>Job Description</label><br />
                        <asp:Label ID="JobDescription" runat="server" /><br /><br />
                        <label>Job Qualification </label>  
                        
                        <asp:Label ID="JobQualification" runat="server" /><br /><br />
                        <label>Application Instruction </label>  <br />
                      
                        <asp:Label ID="ApplicationInstruction" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                     
                    <asp:LinkButton ID="SubmitApply"  class="buttonStyleSubmit" runat="server"  OnCommand="SubmitApply_Command" AutoPostBack="false">Submit Application</asp:LinkButton>
       
                     </div>
            </div>
            
        </div>
    </div>
</asp:Content>
