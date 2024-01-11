<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewIndustryProfile_Admin.aspx.cs" Inherits="ctuconnect.ViewIndustryProfile_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" integrity="sha256-rqjJMwTqpcNs7L4lL7v5Et5Et4aBnaeUpK2cnFXa4UE=" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <style>
        .display-container {
            height: 370px;
            width: 1210px;
            background-color: #ffffff;
            padding-left: 2em;
            padding: 2% 2% 0% 2%;
            margin-bottom:25px;
            border-radius:10px;
            font-family: 'Poppins', sans-serif;
            font-size:16px;
            top:0;
            bottom:0;
            padding: 2% 2% 0% 2%;
            overflow: auto;
            /*background-color:white;*/
            margin-left:12.5em;
        }

        .container-fluid {
            
        }

        .display-industry{
            min-height: 180px;
            background-color: #ffffff;
            padding-left:2em;
            min-width:90%;
            float:left;
            margin-left:55px;
            padding-top:2em;
            font-family: 'Poppins', sans-serif;
            border-radius: 10px;
        }

        .student-details2{
            min-height: 180px;
            background-color: #ffffff;
            padding-left:2em;
            min-width:75%;
            float:left;
            margin-left:3px;
            padding-top:2em;
            font-family: 'Poppins', sans-serif;
            border-radius:10px;
        }

        .student-container{
            width: 1310px;
            margin-top:200px;
            font-size:18px;
            margin: 0 auto; /* This centers the element horizontally */
            margin-left:8.5em;
        }

        .display-review{
            height: 450px;
            width: 1210px;
            background-color: #ffffff;
            padding-left: 2em;
            padding: 2% 2% 0% 2%;
            margin-bottom:25px;
            border-radius:10px;
            font-family: 'Poppins', sans-serif;
            font-size:16px;
            top:0;
            bottom:0;
            padding: 2% 2% 0% 2%;
            overflow: auto;
            /*background-color:white;*/
            margin-left:12.5em;
            margin-top:30px;
            display:none;
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

        .name{
            font-size:22px;
            color:#881A30;
            font-weight:bold;
            position:center;
        }

        .btn-md{
            border: 1px #881A30;
            background-color: #881A30;
            position:center;
            width: 120px;
            height:45px;
        }

        .feedback-item {
            border: 1px solid #e0e0e0;
            padding: 15px;
            margin-bottom: 15px;
            border-radius: 8px;
        }

        .profile-image {
            width: 20px;
            height: 20px;
            border-radius: 50%;
            object-fit: cover; /* Ensure the image covers the entire circle */
        }

        .feedback-name {
            font-weight: bold;
            margin-bottom: 5px;
            font-size:14px;
            padding-left:1em;
        }

        .feedback-date {
            font-size: 9px;
            color: #888;
            padding-left:2em;
        }

        .feedback-position {
            margin-left: 10px;
        }

        .feedback-rating {
            font-size: 12px;
            font-weight: bold;
            color: #ffc107; /* Yellow color for rating */
            margin-top: 10px;
        }

        .feedback-text {
            margin-top: 10px;
            padding-left:7em;
            font-size:14px;
        }

        .star-rating {
            display: inline-block;
            font-size: 18px; /* Adjust the font size as needed */
            padding-left:5.5em;
        }

        .star-rating i {
            color: #ffc107; /* Yellow color for filled stars */
        }

        /* Adjust the spacing between stars if needed */
        .star-rating i + i {
            margin-left: 4px;
        }

        .empty-message{
           display: flex;
           align-items: center;
           height: 500px;
           font-size:20px;
           font-weight:bold;
           text-align:center;
        }

        .btn-md {
            border: 1px #F7941F;
            border-radius: 15px;
            background-color: #F7941F;
            width: 120px;
        }

        .modal {
            display: none;
            width:600px;
            margin: 0 auto;
            margin-top:20px;
        }

        .modal-content{
         padding-left:1em;
         padding-right:1em;
     }

     .txtbox{
       border-radius: 5px;
    
    }
         .Rating {
        list-style: none; /* Remove default list styles */
        margin: 0;
            padding: 0;
        }

        /* Style for each ListItem */
        .Rating label {
            display: inline-block;
            padding: 5px 10px;
            margin-right: 5px;
            cursor: pointer;
        }

        /* Style for the selected ListItem */
        .Rating label.checked {
            background-color: #4CAF50; /* Change background color for selected item */
            color: #fff; /* Change text color for selected item */
        }

        .industry-name{
            font-weight:bold;
            font-size:20px;
            text-align:center;

        }


    </style>
    
            
                <div class="display-container">
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
                               <asp:Label ID="disp_name" runat="server" Text=""></asp:Label><br />
                                <span style="color: yellow;">
                                    <asp:Literal ID="lblOverallRating" runat="server"></asp:Literal>
                                </span>
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
                
                
                <div class="student-container" id="about">
                    <div class="row">
                        <div class="col-12">
                            <div class="display-industry">
                                <div class="row">
                                    <div class="col-sm-12">
                                       <asp:Label ID="Label1" runat="server" Text="Industry Details" CssClass="name"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="padding-top:1em;">
                                    <div class="col-3" style="padding-left:3em;">
                                        <b>Industry: </b> 
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="padding-top:1em;">
                                    <div class="col-3" style="padding-left:3em;">
                                        <b>Location: </b> 
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="padding-top:1em;">
                                    <div class="col-3" style="padding-left:3em;">
                                        <b>Email: </b> 
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-12">
                                       <asp:Label ID="Label2" runat="server" Text="Contact Person" CssClass="name"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="padding-top:1em;">
                                    <div class="col-3" style="padding-left:3em;">
                                        <b>Name: </b> 
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="contactName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="padding-top:1em;">
                                    <div class="col-3" style="padding-left:3em;" >
                                        <b>Position: </b>
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="contactPosition" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="padding-top:1em;">
                                    <div class="col-3" style="padding-left:3em;">
                                        <b>Number:</b>
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="contactNumber" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="padding-top:1em;">
                                    <div class="col-3" style="padding-left:3em;">
                                        <b>Email: </b>
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="contactEmail" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <br /><br />
                            </div>
                        </div>
                        
                    </div>
                    
                </div>

                
                <div class="display-review" id="reviews">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:ListView ID="listfeedback" runat="server">
                        <ItemTemplate>
                            <div class="feedback-item">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div style="display: flex; gap: 6px; padding-left: 1em;">
                                            <img src="images/defaultprofile.jpg" style="width:60px; height:auto; border-radius: 50%;" />
                                            <div>
                                                <p class="feedback-name"><asp:Label ID="lblFeedbackName" runat="server" Text='<%# Eval("firstName") + " " + Eval("lastName") %>'></asp:Label></p>
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
                        <EmptyDataTemplate>
                            <h3 style="position: relative; top: 40%;">
                                <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoPost" Text="No Reviews Yet!"></asp:Label></h3>
                        </EmptyDataTemplate>
                    </asp:ListView>
                
                    
                    <asp:DataPager ID="ListViewPager" runat="server" PagedControlID="listfeedback" PageSize="10" class="btn-group btn-group-sm float-end">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                            <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="false" ButtonCount="5" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary disabled" NextPreviousButtonCssClass="btn btn-default" />
                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                        </Fields>
                    </asp:DataPager>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>    
                
                <br /><br /><br />


            
   
        <script>         

            $(document).ready(function () {
                // Initially, show the "display-industry" content
                $(".student-container").show();

                // Handle tab click events
                $(".topnav a").click(function () {
                    // Hide all content sections
                    $(".display-review, .student-container").hide();

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

        
</asp:Content>        