<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_JobPosted.aspx.cs" Inherits="ctuconnect.Admin_JobPosted" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .jobs {
            width: 100%;
            min-height: 500px;
            background: #FFFFFF;
            border: 1px solid #FFFFFF;
            padding: 10px;
            border-radius: 5px;
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
            margin: 5px;
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
            margin: 5px;
        }

            .buttonDetails:hover {
                background: #881a30;
                color: white;
                box-shadow: 3px 6px 7px -4px grey;
            }

        .imgStyle {
            border-radius: 50%;
            border: solid grey 1px;
            box-shadow: gray;
            width: 95px;
            height: 95px;
            box-shadow: 0px 0px 12px -3px grey;
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

        body:not(.modal-open) {
            padding-right: 0px !important;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ClientIDMode="AutoID">
        <ContentTemplate>
            <div class="container d-flex flex-column my-5">
                <br />
                <div class="col input-group mb-3">
                    <asp:TextBox ID="txtsearchJob" CssClass="form-control searchbox" runat="server" placeholder="Search job title"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button class="btn btn-primary" runat="server" ID="SearchJob" OnClick="SearchJob_Click" Text="Search" />
                    </div>
                </div>
                <br />
                <label id="totalJob" runat="server"></label>
                <div class="jobs">
                    <asp:ListView ID="JobPosted" runat="server" class="container-fluid" OnItemDataBound="JobPosted_ItemDataBound" OnPagePropertiesChanged="JobPosted_PagePropertiesChanged">
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
                                            <a href='ViewIndustryProfile_Admin.aspx?industry_accID=<%#Eval("industry_accID")%>'>
                                                <span>
                                                    <%#Eval("industryName")%>
                                                </span>
                                            </a>

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
                                        <asp:Button ID="ViewReport" Text="View Reports" class="buttonStyle" runat="server" OnCommand="ViewReport_Command" CommandArgument='<%#Eval("jobID")%>' />
                                    </div>

                                    <div class="row">
                                        <asp:Button ID="DeleteJob" Text="Delete Job" class="buttonDetails" runat="server" OnCommand="DeleteJob_Command" CommandArgument='<%#Eval("jobID")%>' />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <h3 style="position: relative; top: 40%;">
                                <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoPost" Text="No Job Posted Yet!"></asp:Label></h3>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <asp:DataPager ID="ListViewPager" runat="server" PagedControlID="JobPosted" PageSize="15" class="btn-group btn-group-sm float-end">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                            <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="false" ButtonCount="5" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary disabled" NextPreviousButtonCssClass="btn btn-default" />
                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </div>

            <div class="modal" id="ReportListModal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-lg modal-dialog-scrollable">
                    <div class="modal-content">
                        <asp:Label ID="reported_jobID" runat="server" Visible="false"></asp:Label>
                        <div class="modal-header">
                            <h3><b>Job Report List</b></h3>
                        </div>
                        <div class="modal-body" style="padding: 20px;">
                            <div class="container-fluid d-flex flex-column">
                                <span>
                                    <h4 id="Reported_JobTitle" runat="server" class="fw-bold"></h4>
                                    <h5 id="Reported_IndustryName" runat="server"></h5>
                                </span>
                                <asp:ListView ID="ReportListView" runat="server">
                                    <LayoutTemplate>
                                        <table style="font-size: 18px; line-height: 30px;">
                                            <tr style="background-color: #336699; color: White; padding: 10px;">
                                                <th>Problem Type</th>
                                                <th>Report Details</th>
                                                <th>Report Date</th>
                                            </tr>
                                            <tbody>
                                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr style="border-bottom: solid 1px #336699">
                                            <td><%#Eval("problemType")%></td>
                                            <td><%#Eval("reportDetails")%></td>
                                            <td><%#Eval("reportDate")%></td>
                                            <td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <h3 style="position: relative; top: 40%;">
                                            <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoReport" Text="No Job Report!"></asp:Label></h3>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div style="float: right;">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal" id="DeleteJobModal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                    <div class="modal-content">
                        <asp:Label ID="delete_jobID" runat="server" Visible="false"></asp:Label>
                        <div class="modal-header">
                            <h3><b>Delete Job</b></h3>
                        </div>
                        <div class="modal-body" style="padding: 20px;">
                            <span id="deleteErrorMsg" runat="server" visible="false" class="text-danger">*Please fill all fields</span>
                            <span>
                                <h5 id="Delete_JobTitle" runat="server" class="fw-bold opacity-75"></h5>
                                <h5 id="Delete_IndustryName" runat="server" class="opacity-75"></h5>
                            </span>
                            <div class="container-fluid d-flex flex-column">
                                <div class="form-group row">
                                    <label for="deleteReason" class="fs-4">Reason for job deletion</label><span id="errorText" runat="server" visible="false" class="text-danger">*Please fill this input</span>
                                    <textarea class="form-control" cols="40" rows="5" id="deleteReason" runat="server" placeholder="Input reason..."></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div style="float: right;">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                <asp:LinkButton ID="ConfirmDeletion" class="btn btn-success" runat="server" OnCommand="ConfirmDeletion_Command">Confirm Deletion</asp:LinkButton>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function showReportList() {
            $('#ReportListModal').modal('show');
        }
        function showDeleteJob() {
            $('#DeleteJobModal').modal('show');
        }
    </script>
</asp:Content>
