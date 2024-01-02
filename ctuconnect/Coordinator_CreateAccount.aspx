<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Coordinator_CreateAccount.aspx.cs" Inherits="ctuconnect.Coordinator_CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        .profile-container {
            background-color: white;
            margin-left: 4%;
            padding-bottom: 8px;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
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

        .second {
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 2%;
            margin-bottom: 0%;
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

        .nav {
            padding: 10px 10px 10px 10px;
            width: 350px;
            margin: auto;
            margin-top: 20px;
            position: absolute;
            margin-left: 25px;
        }

            .nav a {
                font-size: 18px;
                font-family: 'Arial Rounded MT';
                color: #000000;
                text-decoration: none;
                position: static;
                font-size: 19px;
                display: block;
                margin: 2px 15px 5px 15px;
                padding: 0px 0px 0px 30px;
            }

                .nav a.active {
                    background-color: rgb(255, 194, 102);
                    border-radius: 10px;
                    min-height: 10px;
                }

                .nav a:hover {
                    background-color: rgb(255, 194, 102);
                    border-radius: 10px;
                    min-height: 10px;
                }

        .container {
            min-height: 100%;
            border-color: grey;
            width: 100%;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
            padding-top: 2em;
            padding-left: 2em;
            padding-right: 2em;
            margin-left: 1px;
        }

        .card {
            background: rgb(121,101,55);
            background: linear-gradient(90deg, rgba(121,101,55,1) 0%, rgba(245,168,2,1) 40%);
            border-radius: 10px;
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
    </style>
    <div class="overlay">
        <div class="spinner-container">
            <span class="fs-1" id="LoadAddCoordinator"></span>
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
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column">
                <div class="nav flex-column flex-nowrap overflow-auto p-2">
                    <div class="profile-container">
                        <img src="images/administratorpic.jpg" />
                        <p>Admin</p>
                        <hr class="horizontal-line" />
                        <a href="AdminDashboard.aspx">
                            <i class="fa fa-tachometer" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Dashboard
                        </a>
                        <a href="IndustryVerification.aspx">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            Industry Verification
                        </a>
                        <a href="ReferralList_Admin.aspx">
                            <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            Referred Student
                        </a>
                        <hr class="horizontal-line" />
                        <a href="ListOfIndustries_Alumni.aspx">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            List of Industry
                        </a>
                        <a href="ListOfInterns_Alumni.aspx">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            List of Interns
                        </a>
                        <a href="ListOfAlumni_Admin.aspx">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            List of Alumni
                        </a>
                        <hr class="horizontal-line" />
                        <a href="Dispute.aspx">
                            <i class="fa fa-exclamation-triangle" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            Dispute
                        </a>
                        <a href="Blacklist_Admin.aspx">
                            <i class="fa fa-ban" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            Blacklisted
                        </a>
                        <a href="SuggestionsAdmin.aspx">
                            <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Suggestions
                        </a>
                        <a href="Admin_Contact.aspx">
                            <i class="fa fa-comments" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Contact
                        </a>
                        <hr class="second" />
                        <a href="TracerDashboard.aspx">
                            <i class="fa fa-ban" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            Tracer
                        </a>
                        <a href="#">
                            <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Profile
                        </a>
                        <a class="active" href="Coordinator_CreateAccount.aspx">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Coordinator Account
                        </a>
                    </div>

                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container bg-light">
                    <h2 class="title opacity-75">Coordinator Account</h2>
                    <br />
                        <div>
                            <h3>Add Coordinator</h3>
                            <asp:Button Text="Add Coordinator Account" CssClass="btn btn-info" ID="AddCoordinator" OnClick="AddCoordinator_Click" runat="server" />
                            <h3 class="my-1 text-danger">or</h3>
                            <h4>Upload CSV for Coordinator</h4>
                            <asp:FileUpload ID="coordinatorCSV" runat="server" />
                            <asp:Button Text="Upload Coordinator CSV" ID="UploadCoordinatorCSV" CssClass="btn btn-success" OnClientClick="showOverlay(this.id);" OnClick="UploadCoordinatorCSV_Click" runat="server" />
                        </div>
                        <br /><br /><br />
                        <div class="row">
                            <div class="col-sm-6">
                                <label>Coordinator Name</label>
                                <div class="input-group mb-3">                    
                                    <asp:TextBox ID="CoordinatorName" runat="server" class="form-control" Placeholder="Firstname or Lastname" Width="200px"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:LinkButton runat="server" ID="SearchCoordinator" OnClick="SearchCoordinator_Click" CssClass="btn btn-primary"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>      
    
                            <div class="col-sm-6">
                                <label>Date</label>
                                <div class="input-group mb-3">  
                                    <asp:TextBox ID="txtdate" runat="server" TextMode="Date" class="form-control" Width="200px"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:LinkButton runat="server" ID="SearchByDate" OnClick="SearchByDate_Click" CssClass="btn btn-primary"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                                    </div>
            
                                </div>
                            </div>

                        </div>

                        <div class="row m-2 my-4 mb-5">
                            <asp:ListView ID="CoordinatorListView" runat="server" OnPagePropertiesChanged="CoordinatorListView_PagePropertiesChanged">
                                <LayoutTemplate>
                                    <table style="font-size: 18px; line-height: 30px;">
                                        <tr style="background-color: #336699; color: White; padding: 10px;">
                                            <th>Account ID</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Email</th>
                                            <th>Deparment</th>
                                            <th>Date Registered</th>
                                        </tr>
                                        <tbody>
                                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr style="border-bottom: solid 1px #336699">
                                        <span visible="false" runat="server" id="coordinatorID"><%#Eval("coordinator_accID")%></span>
                                         <td><%#Eval("coordinator_accID")%></td>
                                        <td><%#Eval("firstName")%></td>
                                        <td><%#Eval("lastName")%></td>
                                        <td><%#Eval("username")%></td>
                                        <td><%#Eval("departmentName")%></td>
                                         <td><%#Eval("dateReg")%></td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <h3 style="position: relative; top: 40%;">
                                        <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" Text="No Account Listed!"></asp:Label></h3>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </div>
                    <asp:DataPager ID="ListViewPager" runat="server" PagedControlID="CoordinatorListView" PageSize="15" class="btn-group btn-group-sm float-end">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                            <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="false" ButtonCount="5" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary disabled" NextPreviousButtonCssClass="btn btn-default" />
                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                        </Fields>
                    </asp:DataPager>
                </div>

            </div>

        </div>
    </div>
    <div class="modal" id="AddCoordinatorModal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
        <div class="modal-content">
            <div class="modal-header">
                <h3><b>Add Coordinator</b></h3>
            </div>
            <div class="modal-body" style="padding: 20px;">
                <div class="row my-2">
                    <span id="addError" runat="server" visible="false" class="text-danger">*Please fill all the fields</span>
                </div>
                <div class="form-group row">
                    <label for="CoordFirstName" class="col-sm-3 col-form-label">First Name:</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" id="CoordFirstName" runat="server" placeholder="Coordinator First Name">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CoordMidInitial" class="col-sm-3 col-form-label">Middle Initial:</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" id="CoordMidInitial" runat="server" placeholder="Coordinator Middle Initial">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CoordLastName" class="col-sm-3 col-form-label">Last Name:</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" id="CoordLastName" runat="server" placeholder="Coordinator Last Name">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CoordEmail" class="col-sm-3 col-form-label">Email/Username:</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" id="CoordEmail" runat="server" placeholder="Email Address">
                        <span id="EmailError" runat="server" visible="false" class="text-danger">*Email is already taken</span>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="CoordEmail"
                            ErrorMessage="Please enter a valid email address." ValidationExpression="^[a-zA-Z0-9._%+-]+@gmail\.com$"
                            Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CoordPassword" class="col-sm-3 col-form-label">Password:</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" id="CoordPassword" runat="server" placeholder="Password" readonly onfocus="displayPassword()">
                    </div>
                </div>
                <div class="form-group row">
                    <label for="DepartmentID" class="col-sm-3 col-form-label">Department:</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="DepartmentID" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <div style="float: right;">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                    <asp:LinkButton ID="Save" class="btn btn-success" runat="server" OnClientClick="showOverlay(this.id);" OnCommand="Save_Command">Save</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</div>
    <script type="text/javascript">
        jQuery.noConflict();
        function showAddCoordinator() {
            $('#AddCoordinatorModal').modal('show');
        }
        function displayPassword() {

            var inputBox = document.getElementById('<%= CoordPassword.ClientID %>');
            var firstName = document.getElementById('<%= CoordFirstName.ClientID %>').value.replace(/\s/g, '');
            var currentDate = new Date();
            var currentYear = currentDate.getFullYear();
            if (firstName != '') {
                inputBox.value = '@' + firstName + currentYear;
            }
        }
    </script>
    <script>
        function showOverlay(buttonId) {
            var SaveCoordinatorBtn = document.getElementById('<%= Save.ClientID %>').id;
        var UploadCoordinatorBtn = document.getElementById('<%= UploadCoordinatorCSV.ClientID %>').id;
            var textLoading = document.getElementById("LoadAddCoordinator");
            if (buttonId === UploadCoordinatorBtn) {
            textLoading.innerText = 'Uploading CSV';
        }
            else if (buttonId === SaveCoordinatorBtn) {
            var firstName = document.getElementById('<%= CoordFirstName.ClientID %>').value;
            var lastName = document.getElementById('<%= CoordLastName.ClientID %>').value;
                textLoading.innerText = 'Saving ' + firstName + ' ' + lastName + ' Data';
            }
            $(".overlay").css("display", "flex");
        }
    </script>
</asp:Content>
