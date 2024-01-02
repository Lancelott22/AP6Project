<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Contact.aspx.cs" Inherits="ctuconnect.Admin_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <!-- include summernote css/js -->
    <link href="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js"></script>
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


        .submitStyle {
            float: right;
            color: white;
            background-color: orange;
            border-radius: 15px;
            height: 40px;
            width: 20%;
            border: 1px solid orange;
        }

            .submitStyle:hover {
                box-shadow: 3px 6px 7px -4px grey;
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
            <span class="fs-1" id="Load">Sending Message</span>
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
                        <a class="active" href="Admin_Contact.aspx">
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

                    </div>

                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container" style="background-color: white;">
                    <h2 class="titles">Contact</h2>
                    <br />
                    <div class="form-group row p-2">
                        <label class="fs-3 fw-normal">Send to:</label>

                        <asp:DropDownList runat="server" title="Select User" CssClass="selectpicker form-control" ID="SendToUser" AutoPostBack="true" OnSelectedIndexChanged="SendToUser_SelectedIndexChanged">
                            <asp:ListItem Value="" Enabled="false" Selected="true">Select User</asp:ListItem>
                            <asp:ListItem Value="OJTCoordinator">OJT Coordinator</asp:ListItem>
                            <asp:ListItem Value="Industry">Industry</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <select runat="server" title="Select Account" class="selectpicker form-control" data-actions-box="true" multiple="true" name="SendToEmail" id="SendToEmail">
                        </select>

                    </div>
                    <div class="form-group row p-2">
                        <label class="fs-3 fw-normal">Subject:</label>
                        <input class="form-control" id="Subject" runat="server" placeholder="Input subject...">
                    </div>
                    <div class="form-group row p-2">
                        <label class="fs-3 fw-normal">Message:</label>
                        <asp:TextBox class="form-control summernote" Rows="5" TextMode="MultiLine" ID="message" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="SendMessage" runat="server" CssClass="submitStyle" Text="Send Message" OnClientClick="showOverlay();" OnClick="SendMessage_Click" />
                    </div>
                </div>

            </div>

        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('.summernote').summernote({
                height: 300,
                placeholder: 'Input message...',
                toolbar: [
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['font',],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],

                    ['height', ['height']]
                ]
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('.selectpicker').selectpicker();
        });
    </script>
    <script>
        function showOverlay() {
            $(".overlay").css("display", "flex");
        }
    </script>
</asp:Content>
