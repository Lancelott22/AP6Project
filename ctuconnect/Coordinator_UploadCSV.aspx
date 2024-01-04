<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="Coordinator_UploadCSV.aspx.cs" Inherits="ctuconnect.Coordinator_UploadCSV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <meta name='viewport' content='width=device-width, initial-scale=1'>
        <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');

        .profile-container {
            font-family: 'Poppins', sans-serif;
            max-width: 260px;
            min-height: 660px;
            background-color: white;
            margin-left: 4%;
            padding-bottom: 8px;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }

        @media (max-width: 790px) {
            .profile-container, .sidemenu-container {
                max-width: 50%;
                max-height: 100%;
                padding: 5px 5px 5px 5px;
            }
        }

        .profile-container img {
            display: block;
            width: 50%;
            margin-left: auto;
            margin-right: auto;
            margin-top: auto;
            padding-top: 10px;
        }

        .profile-container p {
            display: block;
            text-align: center;
            font-size: 19px;
            margin-top: 7%;
        }

        .sidemenu-container {
            font-family: 'Poppins', sans-serif;
            width: 260px;
            height: 200px;
            background-color: white;
            /*margin-top:22%;*/
            padding-top: 4px;
            margin-bottom: 10%;
            margin-left: 4%;
            border-radius: 25px;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }

        .profile-container a {
            position: static;
            border-radius: 10px;
            color: black;
            text-decoration: none;
            font-size: 19px;
            display: block;
            margin: 2px 15px 5px 15px;
            padding: 0px 0px 0px 8px;
        }

            .profile-container a.active {
                background-color: #F6B665;
                color: #606060;
            }

            .profile-container a:hover {
                background-color: #fcd49a;
                color: #606060;
                margin: 2px 15px 5px 15px;
                padding: 0px 0px 0px 8px;
                text-decoration: none;
            }

        .display-container {
            font-family: 'Poppins', sans-serif;
            background-color: white;
            width: 1550px;
            top: 0;
            bottom: 0;
            padding: 2%;
            overflow: auto;
            /*background-color:white;*/
            height: 550px;
            /*overflow: auto;
             float:left;
             margin-left:25%;
             position:relative;
             padding: 4% 0% 0% 6%;*/
        }

        .display-container {
            max-width: 100%;
        }

            .display-container .title {
                font-size: 25px;
                font-weight: 500;
                position: relative;
                margin-bottom: 3%;
                padding-bottom: 4px;
            }

                .display-container .title:before {
                    content: '';
                    position: absolute;
                    height: 2px;
                    width: 40px;
                    bottom: 0;
                    background-color: #881A30;
                }

        .content {
            height:100%; 
            width:97%; 
            margin-left:2%; 
            margin-right:2%;
            padding: 0px 0px 0px 0px;
        }

        .gridview-style {
            margin-top: 5%;
            text-align: center;
        }

            .gridview-style .header-style {
                width: 20px;
                text-align: center;
                align-items: center;
            }

        .sort-dropdown {
            border-radius: 12px;
            width: 100px;
            padding-left: 8px;
            border-color: #c1beba;
        }

        .gridview-container {
            position: relative;
            min-height: 1px;
            height: auto;
            width: 100%;
        }

        .gridview {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            display: none;
        }

        .horizontal-line {
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 1%;
            margin-bottom: 0%;
        }

        .second {
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 13%;
            margin-bottom: 0%;
        }

        .full-time:active::before {
            content: '';
            position: absolute;
            height: 10px;
            width: 40px;
            bottom: 0%;
            background-color: #881A30;
        }

        th {
            border-collapse: collapse;
            border-color: white;
            background-color: #f4f4fb;
            padding: 5px;
        }

        .datas {
            padding: 9px;
            border: 8px solid;
            border-color: white;
            font-weight: bold;
            color: black;
        }

        .table-list {
            border-collapse: collapse;
            font-size: 13px;
            height: auto;
            width: 100%;
            color: dimgray;
        }

        .overlay {
            display: none;
            justify-content: center;
            align-items: center;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(255, 255, 255, 0.7);
            z-index: 9999;
        }

        .spinner-container {
            text-align: center;
        }

        .fa {
            width:20px;
            margin-right: 19px; 
        }
    </style>
    <div class="overlay">
        <div class="spinner-container">
            <span class="fs-1" id="LoadAddIntern"></span>
            <div class="spinner-grow" style="width: 1rem; height: 1rem;" role="status">
                <span class="sr-only">Loading...</span>
            </div>
            <div class="spinner-grow" style="width: 1rem; height: 1rem;" role="status">
                <span class="sr-only">Loading...</span>
            </div>
            <div class="spinner-grow" style="width: 1rem; height: 1rem;" role="status">
                <span class="sr-only">Loading...</span>
            </div>
        </div>
    </div>
    <asp:Table ID="Table1" runat="server" CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align: top;">
                 <div class="profile-container">
                   <asp:Image ID="CoordinatorImage" runat="server"/>   
                       <p >OJT Coordinator</p>
                       <hr class="horizontal-line" />
                       <a href="CoordinatorProfile.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                       <a href="ListOfAlumni"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Alumni</a>
                       <a href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Partnered Industry</a>
                       <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px;"></i>Refer Student</a>
                       <a href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                       <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                       <a href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right:12px;"></i>Contact</a>
                       <a class="active" href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                       <a href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                       <a href="EditEvaluation.aspx"><i class="fa fa-file-text" aria-hidden="true" style="padding-right:12px;"></i>Evaluation Form</a>
                       <hr class="second" />
                       <a href="OJTCoordinator_Profile.aspx"><i class="fa fa-user" aria-hidden="true" style="padding-right:12px;"></i>Profile</a>
                       <a href="Coord_AccountSetting.aspx"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                       <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                           <i class="fa fa-sign-out" aria-hidden="true"></i>
                          Sign-out
                           </asp:LinkButton>
                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding: 0px 5px 0px 40px">
                <div class="display-container">
                    <h1 class="title">Upload CSV</h1>
                    <div>
                        <h3>Add Intern</h3>

                        <asp:Button Text="Add Intern Account" CssClass="btn btn-info" ID="AddIntern" OnClick="AddIntern_Click" runat="server" />
                        <h3 class="my-1 text-danger">or</h3>
                        <h3 class="my-2">Upload CSV for Intern</h3>
                        <asp:FileUpload ID="studentCSV" runat="server" />
                        <asp:Button Text="Upload Intern CSV" CssClass="btn btn-success" ID="UploadInternCSV" OnClientClick="showOverlay(this.id);" OnClick="UploadInternCSV_Click" runat="server" />
                    </div>
                    <div>
                        <h3>Upload CSV for Graduates</h3>
                        <asp:FileUpload ID="graduateCSV" runat="server" />
                        <asp:Button Text="Upload Graduate CSV" CssClass="btn btn-success" ID="UploadGraduate" OnClick="UploadGraduate_Click" runat="server" />
                    </div>
                </div>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
    <div class="modal" id="AddInternModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h3><b>Add Intern</b></h3>
                </div>
                <div class="modal-body" style="padding: 20px;">
                    <div class="row my-2">
                        <span id="addError" runat="server" visible="false" class="text-danger">*Please fill all the fields</span>
                    </div>
                    <div class="form-group row">
                        <label for="StudentID" class="col-sm-3 col-form-label">Student ID:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="StudentID" runat="server" placeholder="Student ID">
                            <span id="studentIdError" runat="server" visible="false" class="text-danger">Student ID already exists</span>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="FirstName" class="col-sm-3 col-form-label">First Name:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="FirstName" runat="server" placeholder="Student First Name">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="MidInitial" class="col-sm-3 col-form-label">Middle Initial:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="MidInitial" runat="server" placeholder="Student Middle Initial">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="LastName" class="col-sm-3 col-form-label">Last Name:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="LastName" runat="server" placeholder="Student Last Name">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="StudentStatus" class="col-sm-3 col-form-label">Student Status:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" value="Intern" id="StudentStatus" runat="server" placeholder="Student Status" disabled>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="StudEmail" class="col-sm-3 col-form-label">Email/Username:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="StudEmail" runat="server" placeholder="CTU Email/Username" onfocus="displayEmail()">
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="StudEmail"
                                ErrorMessage="Please enter a valid CTU email address." ValidationExpression="^[a-zA-Z0-9._%+-]+@ctu\.edu\.ph$"
                                Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="StudPassword" class="col-sm-3 col-form-label">Password:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="StudPassword" runat="server" placeholder="Password" readonly onfocus="displayPassword()">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="StudPersonalEmail" class="col-sm-3 col-form-label">Personal Email:</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="StudPersonalEmail" runat="server" placeholder="Personal Email">
                            <asp:RegularExpressionValidator runat="server" ID="EmailValidator" ControlToValidate="StudPersonalEmail"
                                ErrorMessage="Please enter a valid Gmail address." ValidationExpression="^[a-zA-Z0-9._%+-]+@gmail\.com$"
                                Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="Sem_Code" class="col-sm-3 col-form-label">Semester Code:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="Sem_Code" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="DepartmentID" class="col-sm-3 col-form-label">Department:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="DepartmentID" runat="server" CssClass="form-control" OnSelectedIndexChanged="DepartmentID_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="CourseID" class="col-sm-3 col-form-label">Student Course:</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="CourseID" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div style="float: right;">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <asp:LinkButton ID="Save" class="btn btn-success" runat="server" OnCommand="Save_Command" OnClientClick="showOverlay(this.id);">Save</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        jQuery.noConflict();
        function showAddIntern() {
            $('#AddInternModal').modal('show');
        }
        function displayPassword() {

            var inputBox = document.getElementById('<%= StudPassword.ClientID %>');
            var firstName = document.getElementById('<%= FirstName.ClientID %>').value.replace(/\s/g, '');
            var currentDate = new Date();
            var currentYear = currentDate.getFullYear();
            if (firstName != '') {
                inputBox.value = '@' + firstName + currentYear;
            }
        }
        function displayEmail() {

            var firstName = document.getElementById('<%= FirstName.ClientID %>').value.replace(/\s/g, '');
            var lastName = document.getElementById('<%= LastName.ClientID %>').value;
            var emailBox = document.getElementById('<%= StudEmail.ClientID %>');
            if (firstName != '' && lastName != '') {
                emailBox.value = firstName.toLowerCase() + '.' + lastName.toLowerCase() + '@ctu.edu.ph';
            }
        }

    </script>
    <script>
        function showOverlay(buttonId) {
            var SaveInternBtn = document.getElementById('<%= Save.ClientID %>').id;
            var UploadInternBtn = document.getElementById('<%= UploadInternCSV.ClientID %>').id;
            var textLoading = document.getElementById("LoadAddIntern");
            if (buttonId === UploadInternBtn) {
                textLoading.innerText = 'Uploading CSV';
            }
            else if (buttonId === SaveInternBtn) {
                var firstName = document.getElementById('<%= FirstName.ClientID %>').value;
                var lastName = document.getElementById('<%= LastName.ClientID %>').value;
                textLoading.innerText = 'Saving ' + firstName + ' ' + lastName + ' Data';
            }
            $(".overlay").css("display", "flex");
        }
    </script>
</asp:Content>
