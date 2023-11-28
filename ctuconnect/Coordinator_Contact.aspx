<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="Coordinator_Contact.aspx.cs" Inherits="ctuconnect.Coordinator_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
 <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
 <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
 <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
 <!-- include summernote css/js -->
 <link href="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css" rel="stylesheet">
 <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js"></script>

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');

        .profile-container {
            font-family: 'Poppins', sans-serif;
            max-width: 260px;
            max-height: 630px;
            background-color: white;
            margin-left: 4%;
            padding-bottom: 8px;
            border: 2px;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }

        @media (max-width: 790px) {
            .profile-container, .sidemenu-container {
                max-width: 50%;
                max-height: auto;
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

        a {
            position: static;
            border-radius: 10px;
            color: black;
            text-decoration: none;
            font-size: 19px;
            display: block;
            margin: 2px 15px 5px 15px;
            padding: 0px 0px 0px 8px;
        }

            a.active {
                background-color: #F6B665;
                color: #606060;
            }

            a:hover {
                background-color: #fcd49a;
                color: #606060;
                margin: 2px 15px 5px 15px;
                padding: 0px 0px 0px 8px;
                text-decoration: none;
            }

        .display-container {
            font-family: 'Poppins', sans-serif;
            background-color: white;
            width: 1500px;
            top: 0;
            bottom:0;
            padding: 2%;
            /*background-color:white;*/
            height: 100%;
            margin-bottom:20px;
            /*overflow: auto;
             float:left;
             margin-left:25%;
             position:relative;
             padding: 4% 0% 0% 6%;*/
        }

        .display-container {
            max-width: 100%;
        }

            .display-container .titles {
                font-size: 25px;
                font-weight: 500;
                position: relative;
                margin-bottom: 3%;
                padding-bottom: 4px;
            }

                .display-container .titles:before {
                    content: '';
                    position: absolute;
                    height: 2px;
                    width: 40px;
                    bottom: 0;
                    background-color: #881A30;
                }

        .content {
            height: 100%;
            width: 97%;
            margin-left: 2%;
            margin-right: 2%;
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
    </style>
    <asp:Table ID="Table1" runat="server" CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align: top;">
                <div class="profile-container">
                    <img src="images/industrypic.png" />
                    <p>OJT Coordinator</p>
                    <hr class="horizontal-line" />
                    <a href="Coordinator.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right: 12px;"></i>List of Interns</a>
                    <a href="ListOfAlumni.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right: 12px;"></i>List of Alumni</a>
                    <a href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right: 12px;"></i>Partnered Industry</a>
                    <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>Refer Student</a>
                    <a href="CourseLists.aspx"><i class="fa fa-book" aria-hidden="true" style="padding-right: 12px;"></i>Course List</a>
                    <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right: 12px;"></i>Blacklist Industry</a>
                    <a class="active" href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right: 12px;"></i>Contact</a>
                    <a href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right: 12px;"></i>Tracer</a>
                    <hr class="second" />
                    <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
    <i class="fa fa-sign-out" aria-hidden="true"></i>
     Sign-out
                    </asp:LinkButton>

                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding: 0px 5px 0px 40px">
                 <div class="display-container">
                     <h2 class="titles">Contact</h2>

                    <div class="container-fluid">
                        
                        <br />
                        <div class="form-group row p-2">
                            <label class="fs-3 fw-normal">Send to:</label>

                            <asp:DropDownList runat="server" title="Select User" CssClass="selectpicker form-control" ID="SendToUser" AutoPostBack="true" OnSelectedIndexChanged="SendToUser_SelectedIndexChanged">
                                <asp:ListItem Value="" Enabled="false" Selected="true">Select User</asp:ListItem>
                                <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                <asp:ListItem Value="OJTCoordinator">OJT Coordinator</asp:ListItem>
                                <asp:ListItem Value="Industry">Industry</asp:ListItem>
                                <asp:ListItem Value="Student">Student</asp:ListItem>
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
                            <asp:Button ID="SendMessage" runat="server" CssClass="submitStyle" Text="Send Message" OnClick="SendMessage_Click" />
                        </div>
                    </div>
               </div>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
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
</asp:Content>

