<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Resume.aspx.cs" Inherits="ctuconnect.Resume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <style>
        
        .nav{
            padding:10px 10px 10px 10px;
            width:200px;
            margin:auto;
            margin-top:auto;
            
        }

        .nav a{
            font-size:18px;
            font-family:'Arial Rounded MT';
            color:#000000;
            padding-left:3px;
        }

        .nav a.active{
            background-color:rgb(255, 194, 102);
            border-radius:10px;
            min-height:10px;
            
        }

        .nav a:hover{
            background-color:rgb(255, 194, 102);
            border-radius:10px;
            min-height:10px;
            
        }

        .container {
            min-height: 550px;
            background-color: #FFFFFF;
            width:90%;
            border: 1px solid grey;
            padding-top:2em;
            padding-left:2em;
            padding-right:2em;
          
        }

        .container2{
            padding-left:4em;
            padding-right:2em;
        }

        .line{
            height:2px;
            width:100%;
            background-color:#000000;
            color:#000000;
            position:center;
        }

        .btn-md{
            border: 1px #881A30;
            background-color: #881A30;
            position:center;
            width: 120px;
            height:45px;
        }

        .btn-download{
            border: 1px solid #881A30;
            background-color: #F0EBEB;
            position:center;
            width: 120px;
            height:45px;
            color:  #881A30;
        }



    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column">
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">

                    <a href="MyAccount.aspx">
                            <i class='bx bx-user-circle icon' ></i>
                            <span class="text nav-text">My Account</span>
                    </a>
                    <a class="active" href="#resume">
                            <i class='bx bx-file-blank icon' ></i>
                            <span class="text nav-text">Resume</span>
                    </a>
                    <a href="#application">
                            <i class='bx bx-layer icon' ></i>
                            <span class="text nav-text">Application</span>
                    </a>
                    <a href="#settings">
                            <i class='bx bx-cog icon' ></i>
                            <span class="text nav-text">Account Settings</span>
                    </a>
                    <a href="#help">
                            <i class='bx bx-help-circle icon' ></i>
                            <span class="text nav-text">Help</span>
                    </a>
                    <hr style="height:2px;border-width:0;color:#881A30;background-color:#881A30">
                    <a href="#signout">
                            <i class='bx bx-log-out icon' ></i>
                            <span class="text nav-text">Sign-out</span>
                    </a>
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container">
                    <div class="row">
                        <div class="col-12 d-flex flex-column">
                            
                            <asp:Image ID="imgProfilePicture" runat="server" CssClass="profile-picture" height="90" Width="90"/>
                        </div>
                    </div>
                    <hr class="line"/>
                    <div class="row">
                        <div class="col-12 d-flex flex-column">
                            <b>PERSONAL INFORMATION</b>
                            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                            <asp:Label ID="lblContact" runat="server" Text="Contact Number:"></asp:Label>
                            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                            <asp:Label ID="lblBirthdate" runat="server" Text="Birthdate:"></asp:Label>
                            <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
                            <asp:Label ID="lblJobLevel" runat="server" Text="Job Level:"></asp:Label>
                        </div>
                    </div>
                    <hr class="line"/>
                    <div class="row">
                        <div class="col-12 d-flex flex-column">
                            <b>SKILLS</b>
                            <asp:Repeater ID="rptEducationalBackground" runat="server">
                                <ItemTemplate>
                                    <div class="resume-section">
                                        <asp:Label runat="server" Text='<%# Eval("Skills") %>'></asp:Label>
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <hr class="line"/>
                    <div class="row">
                        <div class="col-12 d-flex flex-column">
                            <b>EDUCATION</b>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div class="resume-section">
                                        <asp:Label runat="server" Text='<%# Eval("Degree") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" Text='<%# Eval("Institution") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" Text='<%# Eval("Year") %>'></asp:Label>
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <hr class="line"/>
                    <div class="row">
                        <div class="col-12 d-flex flex-column">
                            <b>CERTIFICATES OR AWARDS</b>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <div class="resume-section">
                                        <asp:Label runat="server" Text='<%# Eval("Certificates") %>'></asp:Label>
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <br />
                <div class="container2">
                    <div class="row">
                        <div class="col-2 d-flex flex-column">
                            <asp:Button ID="btn" class="btn btn-primary btn-md" runat="server" Text="Edit"/>
                        </div>
                        <div class="col-2 d-flex flex-column">
                            <asp:Button ID="btnDownload" class="btn btn-primary btn-md btn-download" runat="server" Text="Download"/>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <br /><br />
</asp:Content>
