<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Dispute.aspx.cs" Inherits="ctuconnect.Dispute" %>

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
            margin-top: 1%;
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
            width: 200%;
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

        body:not(.modal-open) {
            padding-right: 0px !important;
        }
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column">
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">
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
                        <a class="active" href="#">
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
                        <a href="Coordinator_CreateAccount.aspx">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Coordinator Account
                        </a>
                        <asp:LinkButton runat="server" ID ="LinkButton1">
                            <i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>
                            Sign-out
                        </asp:LinkButton>
                    </div>

                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container bg-light">
                    <h2 class="title opacity-75">Dispute</h2>
                    <br />
                    <br />
                    <br />
                    <div class="row" id="showDispute" runat="server">
                        <asp:ListView ID="disputeListView" runat="server" OnItemDataBound="disputeListView_ItemDataBound">
                            <LayoutTemplate>
                                <table style="font-size: 18px; line-height: 30px;">
                                    <tr style="background-color: #336699; color: White; padding: 10px;">
                                        <th>ID</th>
                                        <th>Industry Name</th>
                                        <th>Student Name</th>
                                        <th>Reason</th>
                                        <th>Date Added</th>
                                        <th>Status</th>
                                        <th>Is Resolved</th>
                                        <th>Date Decided</th>
                                        <th>Actions</th>
                                    </tr>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr style="border-bottom: solid 1px #336699">
                                   <asp:Label ID="disputeID" runat="server" Visible="false" Text='<%#Eval("disputeID")%>'></asp:Label>
                                    <td><%#Eval("disputeID")%></td>
                                    <td><%#Eval("industryName")%></td>
                                    <td><%#Eval("firstName")%> <%#Eval("lastName")%> </td>
                                    <td><%#Eval("reason")%></td>
                                    <td><%#Eval("date_Added")%> </td>
                                    <td><%#Eval("status")%> </td>
                                    <td><%#Eval("disputeResolveStatus")%> </td>
                                    <td><%#Eval("decision_Date")%> </td>
                                    <td>
                                    <asp:LinkButton ID="statusBtn" runat="server" OnCommand="statusBtn_Command" CommandArgument='<%#Eval("disputeID")%>'><i class="fa fa-pencil-square-o" aria-hidden="true" data-toggle="tooltip" title="change status"></i></asp:LinkButton>
                                        |
                                    <asp:LinkButton ID="blacklistBtn" runat="server" OnCommand="blacklistBtn_Command" CommandName='<%#Eval("industryName")%>' CommandArgument='<%#Eval("industry_accID")%>'><i class="fa fa-ban text-danger" aria-hidden="true" data-toggle="tooltip" title="blacklist"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <h3 style="position: relative;">
                                    <asp:Label CssClass="alert alert-light d-flex p-2 bg-light justify-content-sm-center" runat="server" Text="No Reports Yet!"></asp:Label></h3>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="modal" id="BlacklistModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <asp:Label ID="blacklist_ID" runat="server" Visible="false"></asp:Label>
                <div class="modal-header">
                    <h3><b>Blacklist Industry</b></h3>
                </div>
                <div class="modal-body" style="padding: 20px;">
                    <span class="fs-3">Are you sure you want to blacklist <span id="BlackList_IndustryName" runat="server"></span>?
                    </span>
                    <div class="container-fluid d-flex flex-column py-2">
                        <div class="form-group row">
                            <label for="BlacklistReason" class="fs-4">Reason</label><span id="errorText" runat="server" visible="false" class="text-danger">*Please fill this input</span>
                            <textarea class="form-control" cols="40" rows="5" id="BlacklistReason" runat="server" placeholder="Input reason..."></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div style="float: right;">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <asp:LinkButton ID="ConfirmBlacklist" class="btn btn-success" runat="server" OnCommand="ConfirmBlacklist_Command">Confirm Blacklist</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="ChangeStatusModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <asp:Label ID="disputeID" runat="server" Visible="false"></asp:Label>
                <div class="modal-header">
                    <h3><b>Change Status</b></h3>
                </div>
                <div class="modal-body" style="padding: 20px;">
                    
                    <span class="fs-3">What's your decision?
                    </span>
                    <span id="changeError" runat="server" visible="false" class="text-danger">*Please fill all fields</span>
                    <div class="container-fluid d-flex flex-column py-2">
                        <div class="form-group row">
                            <label for="StatusDDL">Status:</label>
                            <asp:DropDownList ID="StatusDDL" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Open" Value="Open" Disabled="true" Selected="true"></asp:ListItem>
                                <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group row">
                             <label for="IsResolvedDLL">Is it Resolve?</label>
                            <asp:DropDownList ID="IsResolvedDLL" runat="server" CssClass="form-control">
                                 <asp:ListItem Text="Select option" Value="-1" Disabled="true" Selected="true"></asp:ListItem>
                                <asp:ListItem Text="Resolved" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Unresolved" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group row">
                             <label for="DateDecided">Date Decided:</label>
                            <asp:TextBox ID="DateDecided" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div style="float: right;">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                        <asp:LinkButton ID="Save" class="btn btn-success" runat="server" OnCommand="Save_Command">Save Changes</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function showBlackList() {
            $('#BlacklistModal').modal('show');
        }
        function showChangeStatus() {
            $('#ChangeStatusModal').modal('show');
        }
    </script>
     <script type="text/javascript">
         // Get the date input element
         var dateInput = document.getElementById('<%= DateDecided.ClientID %>');

         // Set the minimum attribute to a minimum allowed date (e.g., project start date)
         var minDate = 'YYYY-MM-DD'; // Replace with your desired minimum date
         dateInput.setAttribute('min', minDate);

         // Set the maximum attribute to today's date
         var today = new Date();
         var dd = String(today.getDate()).padStart(2, '0');
         var mm = String(today.getMonth() + 1).padStart(2, '0'); // January is 0!
         var yyyy = today.getFullYear();

         today = yyyy + '-' + mm + '-' + dd;
         dateInput.setAttribute('max', today);

     </script>
</asp:Content>
