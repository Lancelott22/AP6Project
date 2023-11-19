<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TraceStudent.aspx.cs" Inherits="ctuconnect.TraceStudent" %>

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
    <h2 class="opacity-75">Intern List</h2>
    <div class="container m-auto my-5 w-100 h-100 d-flex flex-column py-3">
        <div class="row">
            <div class="col-sm-4">
                <div class="input-group mb-3">
                    <asp:TextBox ID="StudentNameOrID" runat="server" class="form-control" Placeholder="Lastname or Firstname or StudentID"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button class="btn btn-primary" runat="server" ID="SearchStudent" OnClick="SearchStudent_Click" Text="Search" />
                    </div>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="selectpicker form-control" ID="department" AutoPostBack="true" OnSelectedIndexChanged="department_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="selectpicker form-control" ID="course" AutoPostBack="true" OnSelectedIndexChanged="course_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <div class="form-group">
                        <asp:DropDownList runat="server" CssClass="selectpicker form-control" ID="industry" AutoPostBack="true" OnSelectedIndexChanged="industry_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="selectpicker form-control" ID="position" AutoPostBack="true" OnSelectedIndexChanged="position_SelectedIndexChanged">
                    </asp:DropDownList>

                </div>
            </div>
        </div>
        <div class="row">
            <asp:ListView ID="InternListView" runat="server">
                <LayoutTemplate>
                    <table style="font-size: 18px; line-height: 30px;">
                        <tr style="background-color: #336699; color: White; padding: 10px;">
                            <th>Student ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Course</th>
                            <th>Industry Name</th>
                            <th>Position</th>
                            <th>Status</th>
                            <th>Actions</th>
                        </tr>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr style="border-bottom: solid 1px #336699">
                        <td><%#Eval("studentId")%></td>
                        <td><%#Eval("firstName")%></td>
                        <td><%#Eval("lastName")%></td>
                        <td><%#Eval("course")%></td>
                        <td><%#Eval("workedAt")%></td>
                        <td><%#Eval("position")%></td>
                        <td><%#Eval("internshipStatus")%></td>
                        <td>
                            <asp:LinkButton ID="viewProfile" runat="server" OnCommand="viewProfile_Command" CommandArgument='<%#Eval("id")%>'>View Details</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <div class="modal" id="showInternProfile" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">Intern Profile</h3>
                </div>
                <div class="modal-body">
                    <div class="container-fluid p-0">
                        <div class="row p-4 py-3" style="font-size: 15px;">
                            <h4>Personal Details</h4>
                            <div class="col-4">
                                <img id="studentPic" runat="server" alt="studentPic" style="height: 130px; width: 130px; border: 1px solid #747574;" />

                            </div>
                            <div class="col">
                                <div>
                                    <label>Name: </label>
                                    <span id="Name" runat="server"></span>
                                </div>
                                <div>
                                    <label>Course: </label>
                                    <span id="StudCourse" runat="server"></span>
                                </div>
                                <div>
                                    <label>Email: </label>
                                    <span id="Email" runat="server"></span>
                                </div>
                                <div>
                                    <label>Address: </label>
                                    <span id="Address" runat="server"></span>
                                </div>
                                <div>
                                    <label>Contact Number: </label>
                                    <span id="CNumber" runat="server"></span>
                                </div>
                            </div>
                        </div>
                        <hr style="margin: 10px 0 10px 0; border: 1px solid #a1a1a1;" />
                        <div class="row p-4 py-3" style="font-size: 15px;">
                            <h4>Job Details</h4>
                            <div class="col-4">
                                <img id="industryLogo" runat="server" alt="industryLogo" style="height: 130px; width: 130px; border: 1px solid #747574;" />
                            </div>
                            <div class="col">
                                <div>
                                    <label>Job Position: </label>
                                    <span id="JobPosition" runat="server"></span>
                                </div>
                                <div>
                                    <label>Job Type: </label>
                                    <span id="jobType" runat="server"></span>
                                </div>
                                <div>
                                    <label>Industry Name: </label>
                                    <span id="IndustryName" runat="server"></span>
                                </div>
                                <div>
                                    <label>Address: </label>
                                    <span id="IndustryAddress" runat="server"></span>
                                </div>
                                <div>
                                    <label>Internship Status: </label>
                                    <span id="InternshipStatus" runat="server"></span>
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
        function showIntern() {
            $('#showInternProfile').modal('show');
        }
    </script>
</asp:Content>
