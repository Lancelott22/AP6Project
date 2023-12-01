<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewApplicantProfile.aspx.cs" Inherits="ctuconnect.ViewApplicantProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet' />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
        body{
            background-color:antiquewhite;
        }

        .container {
            position:relative;
            margin: 10px auto;
            position:center;
        }

        .top {
          height: 200px;
          background-color: #F7941F;
          width:1000px;
          margin-left:400px;
        }


        .bottom {
          min-height: 180px;
          width:1000px;
          background-color: #ffffff;
          margin-left:400px;
  
        }

        .details-container{
            width:1000px;
            margin-left:400px;
            background-color: #ffffff;
            height:400px;
            padding:3px 3px 3px 3px;
            font-family: 'Poppins', sans-serif;
        }

        .profile {
          border-radius: 100px;
          position: relative;
          top: -75px;
  
        }
    </style>
</head>
<body>
<div class="container">
    <div class="row">
        <br />
        <div class="top"></div>
        <div class="bottom">
            <center>
   
                <asp:Image ID="profileImage" CssClass="profile" Width="150px" Height="150px" runat="server" />
            </center>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="student-container">
            <div class="row">
                <div class="col-12">
                    <div class="details-container">
                        <div class="row">
                            <div class="col-sm-4" style="font-weight:bold;">
                                Full Name:
                            </div>
                            <div class="col-sm-8">
                               <asp:Label ID="disp_name" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Student ID:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_studentID" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Student Status:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_studentStatus" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4" style="font-weight:bold;">
                                    Course:
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_course" runat="server" Text=""></asp:Label>  
                                </div>
                            </div>
                            <div class="row">
                            <div class="col-sm-4" style="font-weight:bold;">
                                Contact Number:
                            </div>
                            <div class="col-sm-8">
                               <asp:Label ID="disp_contactNumber" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4" style="font-weight:bold;">
                                Address:
                            </div>
                            <div class="col-sm-8">
                                <asp:Label ID="disp_address" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4" style="font-weight:bold;">
                                Year Graduated:
                            </div>
                            <div class="col-sm-8">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
