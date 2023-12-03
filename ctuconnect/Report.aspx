<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ctuconnect.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>

    <!-- include summernote css/js -->
    <link href="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js"></script>

    <style>
        .nav {
            padding:10px 10px 10px 10px;
            width:200px;
            margin:auto;
            margin-top:20px;
            position: absolute;
            margin-left:70px;
        }

            .nav a {
                font-size: 18px;
                font-family: 'Arial Rounded MT';
                color: #000000;
                padding-left: 3px;
                text-decoration: none;
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



        .col {
            font-size: 15px;
        }

        .top {
            height: 200px;
            background-color: #F7941F;
            width: 80%;
        }


        .box {
            width: 85%;
            min-height: 300px;
            background-color: #ffffff;
            padding-left: 2em;
            border: 1px solid #FFFFFF;
            padding: 10px;
            border-radius: 5px;
        }

        .profile {
            border-radius: 50px;
            position: relative;
            top: -50px;
        }

        .line {
            height: 2px;
            width: 95%;
            background-color: #881A30;
            color: #881A30;
            position: center;
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

    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column align-self-start">
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">

                    <a href="MyAccount.aspx">
                        <i class='bx bx-user-circle icon'></i>
                        <span class="text nav-text">My Account</span>
                    </a>
                    <a href="Resume.aspx">
                        <i class='bx bx-file-blank icon'></i>
                        <span class="text nav-text">Resume</span>
                    </a>
                    <a href="MyJobApplication.aspx">
                        <i class='bx bx-layer icon'></i>
                        <span class="text nav-text">Application</span>
                    </a>
                    <a href="Student_AccountSetting.aspx">
                        <i class='bx bx-cog icon'></i>
                        <span class="text nav-text">Account Settings</span>
                    </a>
                    <a class="active" href="#">
                        <i class='bx bxs-flag-alt'></i>
                        <span class="text nav-text">Report</span>
                    </a>
                    <hr style="height: 2px; border-width: 0; color: #881A30; background-color: #881A30">
                    <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                        <i class='bx bx-log-out icon' ></i>
                        Sign-out
                    </asp:LinkButton>
                </div>
            </div>

            <div class="col-6 d-flex flex-column">
                 
                <div class="container-fluid p-5" style="background-color:white;">
                    <h3 class="title opacity-75 my-0 mb-5" >Report Industry</h3>
                     <div class="form-group row p-2">
                        <asp:Label ID="industryName" runat="server" Text="Industry Name" Style="font-size: 20px;"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="selectpicker form-control" ID="industry" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                     <div class="form-group row p-2">
                        <asp:Label ID="reasonLabel" runat="server" Text="Reason for reporting" Style="font-size: 20px;"></asp:Label>
                         <textarea class="form-control" cols="40" rows="5" id="reasonTxt" runat="server" placeholder="Input reason..."></textarea>
                    </div>
                    <div>
                        <asp:Button ID="SubmitReport" runat="server" CssClass="submitStyle" Text="Submit" OnClick="SubmitReport_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
