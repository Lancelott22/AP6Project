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
    </style>
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
                    <h2 class="title opacity-75">Coordinator Account</h2>
                    <br />
                        <div>
                            <h4>Upload CSV for Coordinator</h4>
                            <asp:FileUpload ID="coordinatorCSV" runat="server" />
                            <asp:Button Text="Upload Coordinator CSV" ID="UploadCoordinatorCSV" OnClick="UploadCoordinatorCSV_Click" runat="server" />
                        </div>
                        <div class="row m-5">
                            <asp:ListView ID="CoordinatorListView" runat="server">
                                <LayoutTemplate>
                                    <table style="font-size: 18px; line-height: 30px;">
                                        <tr style="background-color: #336699; color: White; padding: 10px;">
                                            <th>Name</th>
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
                                        <td><%#Eval("Name")%></td>
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
                    </div>
              
            </div>

        </div>
    </div>

</asp:Content>
