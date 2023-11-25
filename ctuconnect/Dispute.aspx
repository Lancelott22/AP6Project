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
            margin-top: 13%;
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
                        <a href="#myaccount">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                            Create Partnership
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
                            Blacklist
                        </a>
                        <a href="SuggestionsAdmin.aspx">
                            <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                            Suggestions
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
                        <asp:LinkButton runat="server" ID="LinkButton1">
                        <i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>
                        Sign-out
                        </asp:LinkButton>

                    </div>

                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container">
                    <h2 class="title opacity-75">Dispute</h2>
                    <br />
                    <br />
                    <br />
                    <div class="row" id="showDispute" runat="server">
                        <asp:ListView ID="disputeListView" runat="server">
                            <LayoutTemplate>
                                <table style="font-size: 18px; line-height: 30px;">
                                    <tr style="background-color: #336699; color: White; padding: 10px;">
                                        <th>ID</th>
                                        <th>Industry Name</th>
                                        <th>Student Name</th>
                                         <th>Reason</th>
                                        <th>Date Added</th> 
                                        <th>Status</th>
                                        <th>Date Resolved</th>
                                        <th>Actions</th>
                                    </tr>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr style="border-bottom: solid 1px #336699">
                                    <td><%#Eval("disputeID")%></td>
                                    <td><%#Eval("industryName")%></td>
                                    <td><%#Eval("firstName")%> <%#Eval("lastName")%> </td>      
                                    <td><%#Eval("reason")%></td>
                                    <td><%#Eval("date_Added")%> </td>
                                    <td><%#Eval("status")%> </td>
                                   <td><%#Eval("dateResolved")%> </td>
                                    <td>
                                        <asp:LinkButton ID="statusBtn" runat="server" OnCommand="statusBtn_Command">Change Status</asp:LinkButton>
                                        <asp:LinkButton ID="blacklistBtn" runat="server" OnCommand="blacklistBtn_Command">Blacklist</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
