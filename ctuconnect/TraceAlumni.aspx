<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TraceAlumni.aspx.cs" Inherits="ctuconnect.TraceAlumni" %>

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

        /*  .column {
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

    <h2 class="opacity-75">Alumni List</h2>
    <div class="container m-auto my-5 w-100 h-100 d-flex flex-column py-3">
        <div class="row">
            <div class="col-sm-4">
                <div class="input-group mb-3">
                    <asp:TextBox ID="AlumniNameOrID" runat="server" class="form-control" Placeholder="Lastname or Firstname or StudentID"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button class="btn btn-primary" runat="server" ID="SearchAlumni" OnClick="SearchAlumni_Click" Text="Search" />
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="form-group">
                    <label for="department" class="col-sm-4 col-form-label">Department</label>
                    <div class="col-sm-8">
                        <asp:DropDownList runat="server" CssClass="selectpicker form-control" ID="department" AutoPostBack="true" OnSelectedIndexChanged="department_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="form-group">
                    <label for="department" class="col-sm-3 col-form-label">Course</label>
                    <div class="col-sm-8">
                        <asp:DropDownList runat="server" CssClass="selectpicker form-control" ID="course" AutoPostBack="true" OnSelectedIndexChanged="course_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <%-- <div class="col-sm-2">
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
            </div>--%>
        </div>
        <div class="row">
            <asp:ListView ID="AlumniListView" runat="server">
                <LayoutTemplate>
                    <table style="font-size: 18px; line-height: 30px;">
                        <tr style="background-color: #336699; color: White; padding: 10px;">
                            <th>Student ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Department</th>
                            <th>Course</th>
                            <th>Employment Status</th>
                            <th>Company Or Business</th>
                            <th>Position</th>
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
                        <td><%#Eval("departmentName")%></td>
                        <td><%#Eval("course")%></td>
                        <td><%#Eval("employmentStatus")%></td>
                        <td><%#Eval("CompanyOrBusinessName")%></td>
                        <td><%#Eval("position")%></td>
                        <td>
                            <asp:LinkButton ID="viewProfile" runat="server" OnCommand="viewProfile_Command" CommandArgument='<%#Eval("studentId")%>'>View Details</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <div class="modal" id="showAlumniProfile" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">Alumni Profile</h3>
                </div>
                <div class="modal-body">
                    <div class="container-fluid p-0">
                        <div class="row p-4 py-3" style="font-size: 15px;">
                            <h3>Personal Details</h3>
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
                            <h3>Employment Details</h3>
                            <div class="col">
                                <div>
                                    <label>Employment Status: </label>
                                    <span id="EmploymentStatus" runat="server"></span>
                                </div>
                                <div>
                                    <label>Company Or Business Name: </label>
                                    <span id="CompanyOrBusinessName" runat="server"></span>
                                </div>
                                <div>
                                    <label>Department: </label>
                                    <span id="DepartmentName" runat="server"></span>
                                </div>
                                <div>
                                    <label>Position: </label>
                                    <span id="Position" runat="server"></span>
                                </div>
                                <div>
                                    <label>Type of Employment: </label>
                                    <span id="typeOfEmployment" runat="server"></span>
                                </div>
                                <div>
                                    <label>Salary Range: </label>
                                    <span id="SalaryRange" runat="server"></span>
                                </div>
                                <div>
                                    <label>Date Hired: </label>
                                    <span id="dateHired" runat="server"></span>
                                </div>
                                <div>
                                    <label>Is Job Connected to your Course: </label>
                                    <span id="connectedToCourse" runat="server"></span>
                                </div>
                                <div>
                                    <label>Is Job Aligned to your skills: </label>
                                    <span id="alignedToSkills" runat="server"></span>
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
        function showAlumni() {
            $('#showAlumniProfile').modal('show');
        }
    </script>
</asp:Content>
