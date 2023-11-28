<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TraceIndustry.aspx.cs" Inherits="ctuconnect.TraceIndustry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        * {
            box-sizing: border-box;
        }

        body {
            margin: 0 0;
        }

        /* Clear floats before the columns */
        .row::before {
            content: "";
            display: table;
            clear: both;
        }

        /* Responsive layout - makes the three columns stack on top of each other instead of next to each other */
        @media screen and (max-width: 500px) {
            .column.side {
                width: 100%;
                height: 100%;
            }
        }
        /*
      .column {
          float: left;
          padding: 10px;
          
      }

     .div {
         height: 1000%;
         
     }

      .column.side {
          width: 100%;
          background-color: #f1f1f1;
          height: 100vh;
      }*/
    </style>
    <h2 class="opacity-75">Industry List</h2>
    <div class="container m-auto my-5 w-100 h-100 d-flex flex-column py-3">

        <div class="row" id="showIndustryList" runat="server">
            <div class="row">
                <div class="col-sm-4">
                    <div class="input-group mb-3">
                        <asp:TextBox ID="IndustryName" runat="server" class="form-control" Placeholder="Search Industry Name"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button class="btn btn-primary" runat="server" ID="SearchIndustry" OnClick="SearchIndustry_Click" Text="Search" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="input-group mb-3">
                        <asp:TextBox ID="Address" runat="server" class="form-control" Placeholder="Search Address"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button class="btn btn-primary" runat="server" ID="IndustryAdress" OnClick="IndustryAdress_Click" Text="Search" />
                        </div>
                    </div>
                </div>
            </div>

            <asp:ListView ID="IndustryListView" runat="server">
                <LayoutTemplate>
                    <table style="font-size: 18px; line-height: 30px;">
                        <tr style="background-color: #336699; color: White; padding: 10px;">
                            <th>Industry Name</th>
                            <th>Location</th>
                            <th>Total Job Posts</th>
                            <th>Current Employee</th>
                            <th>Actions</th>
                        </tr>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr style="border-bottom: solid 1px #336699">
                        <td><%#Eval("industryName")%></td>
                        <td><%#Eval("location")%></td>
                        <td><%#Eval("totalJobPosted")%></td>
                        <td><%#Eval("TotalEmployee")%></td>
                        <td>
                            <asp:LinkButton ID="ViewDetails" runat="server" OnCommand="ViewDetails_Command" CommandArgument='<%#Eval("industry_accID")%>'>View Details</asp:LinkButton>
                            | 
                            <asp:LinkButton ID="ViewJobPost" runat="server" CommandName='<%#Eval("industryName")%>' OnCommand="ViewJobPost_Command" CommandArgument='<%#Eval("industry_accID")%>'>View Job Post</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="row d-none" id="showJobPosted" runat="server" visible="false">
            <asp:ListView ID="JobPostListView" runat="server">
                <LayoutTemplate>
                    <table style="font-size: 18px; line-height: 30px;">
                        <tr style="background-color: #336699; color: White; padding: 10px;">
                            <th>Job Title</th>
                            <th>Job Type</th>
                            <th>Job Course</th>
                            <th>Job Posted Date</th>
                            <th>Job Status</th>
                            <th>Current Employee</th>
                            <%-- <th>Actions</th> --%>
                        </tr>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr style="border-bottom: solid 1px #336699">
                        <td><%#Eval("jobTitle")%></td>
                        <td><%#Eval("jobType")%></td>
                        <td><%#Eval("jobCourse")%></td>
                        <td><%#Eval("Job_PostedDate")%></td>
                        <td><%#Eval("JobStatus") %></td>
                        <td><%#Eval("TotalJobEmployee")%></td>
                        <%-- <td>
                            <asp:LinkButton ID="viewJob" runat="server">View Job</asp:LinkButton></td>--%>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="modal" id="showIndustryProfile" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">Industry Profile</h3>
                </div>
                <div class="modal-body">
                    <div class="container-fluid p-0">
                        <div class="row p-4 py-3" style="font-size: 15px;">
                            <h4>Industry Details</h4>
                            <div class="col-3">
                                <img id="IndustryLogo" runat="server" alt="industryLogo" style="height: 80px; width: 80px; border: 1px solid #747574;" />
                            </div>
                            <div class="col">
                                <div>
                                    <label>Industry Name: </label>
                                    <span id="Industry_Name" runat="server"></span>
                                </div>
                                <div>
                                    <label>Email: </label>
                                    <span id="IndustryEmail" runat="server"></span>
                                </div>
                                <div>
                                    <label>Address: </label>
                                    <span id="Location" runat="server"></span>
                                </div>
                            </div>
                        </div>
                        <hr style="margin: 10px 0 10px 0; border: 1px solid #a1a1a1;" />
                        <div class="row p-4 py-3" style="font-size: 15px;">
                            <h4>Contact Person Details</h4>
                            <div class="col">
                                <div>
                                    <label>Name: </label>
                                    <span id="ContactName" runat="server"></span>
                                </div>
                                <div>
                                    <label>Position: </label>
                                    <span id="jobPosition" runat="server"></span>
                                </div>
                                <div>
                                    <label>Contact Email: </label>
                                    <span id="contactEmail" runat="server"></span>
                                </div>
                                <div>
                                    <label>Contact Number: </label>
                                    <span id="contactNumber" runat="server"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function showIndustry() {
            $('#showIndustryProfile').modal('show');
        }
    </script>
</asp:Content>
