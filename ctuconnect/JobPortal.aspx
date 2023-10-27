<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JobPortal.aspx.cs" Inherits="ctuconnect.JobPortal" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .box {
            min-width: 250px;
            width:contain;
            min-height: 260px;
            height:260px;
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
            min-width: 95%;
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
            width: 95%;
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
            width:85%;
            left:15px;
            right:15px;
            min-height: 35px;
            color: orange;
            
            border-radius: 20px;
            border: 1.5px solid orange;
            position:relative;
            
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
            width:35%;
            text-align: center;
            text-decoration: none;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
            padding:9px;
        }

            .buttonStyleSubmit:hover {
                background: orange;
                color: white;
                  text-decoration: none;
                   box-shadow: 3px 6px 7px -4px  grey;
            }
        .buttonStyleSubmitDisable {
            background-color: white;
            width:30%;
            text-align: center;
            text-decoration: none;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
            padding:9px;
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
            position:relative;
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
            .modal-footer {
               text-align:unset;
               justify-content:unset;
                display:block;
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
                min-width:250px;
                margin-bottom:20px;
                min-height:700px;
               
                
                top:20px;
                margin-top:15px;             
                border: 1px solid #881A30;
                border-radius:7px;
                box-shadow: 0px 0px 7px -3px  #bd0606;
                position:sticky;
                margin-top:20px;
                overflow:auto;
               
            }  
      
        }
    </style>

    <div class="container-fluid">
        <div class="row" style="padding-top:10px;">
            <div class="col-4 d-flex flex-column" >
              
                <div style="margin:10px; margin-left:10%; height: 100%; position:relative;padding:0px;">
                <div class="box text-center">
                    <br />
                    <asp:Image ID="profileImage" CssClass="profile" Width="100px" Height="100px" runat="server" />
                    <br />
                    <asp:Label ID="StudentName" CssClass="name" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="StudentID" CssClass="accountid" runat="server"></asp:Label>
                    <hr style="height: 2px; border-width: 0; margin-top: 10px; color: gray; background-color: gray">
                    <a href="MyAccount.aspx" class="btn btn-primary btn-md">View Profile</a>
                </div> 
                    <div class="detailsBox">
                    </div>
                </div>
            </div>


            <div class="col-8 d-flex flex-column ">
                <br />
                <asp:TextBox ID="txtsearchOrder" CssClass="searchbox" runat="server" placeholder="Search job title or keyword"></asp:TextBox>
                <br />
                <div class="jobs">
                    <asp:DataList ID="JobHiring" runat="server" class="container-fluid" OnItemDataBound="JobHiring_ItemDataBound">
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

                                        <asp:Button ID="ApplyJob" Text="Apply" class="buttonStyle" runat="server" CommandName="Apply" OnCommand="ApplyJob_Command" CommandArgument='<%#Eval("jobID")%>' CausesValidation="false" />
                                    </div>
                                    <div class="row">
                                        <asp:Button ID="JobDetails" Text="Details" class="buttonDetails" runat="server" CommandName="Apply" OnCommand="ApplyJob_Command" CommandArgument='<%#Eval("jobID")%>' CausesValidation="false" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <h3 style="position: relative; top: 40%;">
                        <asp:Label Visible="false" CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoPost" Text="No Job Posted Yet!"></asp:Label></h3>
                </div>
            </div>
        </div>
         
    </div>
    <br />
    <br />

    <!-- Modal -->
    <div class="modal fade" id="ApplyJobModal" tabindex="-1" role="dialog"  >
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
                    <div style="float:left; margin-left:15px; font-size:13px; ">
                      <span><label>Date Posted: </label>  <asp:Label ID="DatePosted" runat="server" /></span><br />
                    </div>
                    <div style="float:right;">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                     
                    <asp:LinkButton ID="SubmitApply"  class="buttonStyleSubmit" runat="server"  OnCommand="SubmitApply_Command" AutoPostBack="false">Submit Application</asp:LinkButton>
                    </div>
                     </div>
            </div>          
        </div>
    </div>
</asp:Content>
