<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewIndustryProfile.aspx.cs" Inherits="ctuconnect.ViewIndustryProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css"/>
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha256-rqjJMwTqpcNs7L4lL7v5Et5Et4aBnaeUpK2cnFXa4UE=" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>

    <style>
        body{
            background-color:aqua;
        }
        .container {
            position:relative;
            margin: 10px auto;
            position:center;
        }

        .topnav {
          overflow: hidden;
  
        }

        .topnav a {
          float: left;
          display: block;
          color: black;
          text-align: center;
          padding: 14px 16px;
          text-decoration: none;
          font-size: 22px;
          border-bottom: 3px solid transparent;

        }

        .topnav a:hover {
          border-bottom: 3px solid #881A30;
        }

        .topnav a.active {
          border-bottom: 3px solid #881A30;
          color:#881A30;
        }
        

        

        .display-container{
            font-family: 'Poppins', sans-serif;
            font-size:16px;
            background-color:white; 
            width:800px;
            top:0;
            bottom:0;
            padding: 2% 2% 0% 2%;
            overflow: auto;
            /*background-color:white;*/
            height:300px;
            /*overflow: auto;
            float:left;
            margin-left:25%;
            position:relative;
            padding: 4% 0% 0% 6%;*/
            margin-left:500px;
        }


        .display-container .title{
            font-size:25px;
            font-weight:500;
            position:relative;
            margin-bottom:3%;
            padding-bottom:4px;
        }
        .display-container .title:before{
            content:'';
            position:absolute;
            height:2px;
            width:70px;
            bottom:0;
            background-color: #881A30;

        }

        .display-industry{
            font-family: 'Poppins', sans-serif;
            font-size:16px;
            background-color:white; 
            width:800px;
            top:0;
            bottom:0;
            padding: 2% 2% 0% 2%;
            overflow: visible;
            height:500px;
            
            margin-left:500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div class="container">
    <div class="row">
        <div class="display-container mx-auto">
            <div class="row">
                <div class="col-12">
                    <center>
                    <asp:Image ID="industryProfile" CssClass="profile-pic" Width="150px" Height="150px" runat="server" />
                    </center>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-12 industry-name">
                   <asp:Label ID="disp_name" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <br /><br />
            <div class="row">
                <div class="col-lg-12 order-1 order-lg-2 topnav">
                    <a class="active" href="#about">About</a>
                    <a href="#reviews">Reviews</a>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="display-industry mx-auto" id="about">
            <div class="row">
                <div class="col-sm-11">
                    <h3 style="font-weight:bold; color:#881A30;">Industry Details</h3>
                </div>
                <div class="col-sm-1" style="text-align:right;">  
                    
                        <asp:Button ID="addreviewindustry" runat="server" Text="Review" AutoPostBack="false" OnClick="addReview_Click" style="float:right;"/>
                    
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                    Name
                </div>
                <div class="col-sm-9" style="font-size:20px">
                   <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                    Location
                </div>
                <div class="col-sm-9" style="font-size:20px">
                   <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                    Email
                </div>
                <div class="col-sm-9" style="font-size:20px">
                   <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <hr class="line"/>
            <h3 style="font-weight:bold; color:#881A30;">Contact Person</h3><br />
            <div class="row">
                <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                    Name
                </div>
                <div class="col-sm-9" style="font-size:20px">
                   <asp:Label ID="contactName" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                    Position
                </div>
                <div class="col-sm-9" style="font-size:20px">
                   <asp:Label ID="contactPosition" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                    Contact Number
                </div>
                <div class="col-sm-9" style="font-size:20px">
                   <asp:Label ID="contactNumber" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3" style="font-weight:bold; font-size:20px;">
                    Email
                </div>
                <div class="col-sm-9" style="font-size:20px">
                   <asp:Label ID="contactEmail" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="display-review" id="reviews">
            <asp:Repeater runat="server" ID="rptfeedback">
                <ItemTemplate>
                    <div class="feedback-item">
                        <div class="row">
                            <div class="col-md-6">
                                <div style="display: flex; gap: 6px; padding-left: 1em;">
                                    <img src="images/defaultprofile.jpg" style="width:60px; height:auto; border-radius: 50%;" />
                                    <div>
                                        <p class="feedback-name"><asp:Label ID="lblFeedbackName" runat="server" Text='<%# Eval("sendfrom") %>'></asp:Label></p>
                                        <p class="feedback-date"><%# Eval("dateCreated", "{0:d}") %></p>
                                    </div>
                                </div>
                                <div class="feedback-rating">
                                    <div class="star-rating">
                                        <%# GetStarRating(Convert.ToInt32(Eval("rating"))) %>
                                    </div>
                                </div>
                                <div class="feedback-text">
                                    <p><%# Eval("feedback") %></p>
                                </div>
                            </div>
                            <%-- Add a clearfix to prevent layout issues --%>
                            <div class="clearfix visible-md visible-lg"></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <% if (rptfeedback.Items.Count == 0) { %>
                <div class="row">
                    <div class="empty-message">
                        <p>No Reviews Yet</p>
                    </div>
                </div>
            <% } %>
        </div>
    </div>
</div>
    <script>
        $(document).ready(function () {
            // Initially, show the "display-industry" content
            $(".display-industry").show();

            // Handle tab click events
            $(".topnav a").click(function () {
                // Hide all content sections
                $(".display-review, .display-industry").hide();

                // Remove the 'active' class from all tabs
                $(".topnav a").removeClass("active");

                // Add 'active' class to the clicked tab
                $(this).addClass("active");

                // Show the corresponding content based on the clicked tab
                var tabId = $(this).attr("href").substring(1);
                $("#" + tabId).show();

                return false; // Prevent default behavior of the anchor tag
            });
        });
    </script>

    <div class="modal" id="AddReviewlModal" tabindex="-1" role="dialog" >
    <div class="modal-dialog modal-dialog-centered" >
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="title">Feedback to Industry</h2>
            </div>
                <div class="modal-body">
                    


                                     <asp:Label ID="Label8" runat="server" Text="Send From" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                     <asp:TextBox ID="txtsendfrom" runat="server"  CssClass="txtbox"  ></asp:TextBox>
                                     <asp:Label ID="Label9" runat="server" Text="Send Tol" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                     <asp:TextBox ID="txtsendto" runat="server"  Readonly="true" CssClass="txtbox"  ></asp:TextBox>
                                     <asp:Label ID="Label3" runat="server" Text="Position" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                     <asp:TextBox ID="txtposition" runat="server" CssClass="txtbox"  ></asp:TextBox>


                                     <asp:Label ID="Label7" runat="server" Text="Rate" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                     <asp:RadioButtonList ID="companyRating" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Excellent" Value="5" />
                                        <asp:ListItem Text="Very Good" Value="4" />
                                        <asp:ListItem Text="Good" Value="3" />
                                        <asp:ListItem Text="Fair" Value="2" />
                                        <asp:ListItem Text="Poor" Value="1" />
                                    </asp:RadioButtonList>
                                       
                                     <asp:Label ID="Label13" runat="server" Text="Feedback" Style="font-size:18px;" ></asp:Label>
                                     <asp:TextBox ID="txtfeedback" runat="server" CssClass="txtbox"  ></asp:TextBox>
                     
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <asp:Button  class="buttonSubmit" runat="server" Text="Submit" OnCLick="Submit_ButtonClick" autopostback="false" />
            </div>
        </div>
    </div>
 </div>
        </form>
</body>
</html>
