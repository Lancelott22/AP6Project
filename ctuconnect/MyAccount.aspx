<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="ctuconnect.MyAccount1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- include summernote css/js -->
    <link href="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js"></script>
    <style>
        
        .nav{
            padding:10px 10px 10px 10px;
            width:200px;
            margin:auto;
            margin-top:20px;
            position: absolute;
            margin-left:70px;
        }

        .nav a{
            font-size:18px;
            font-family:'Arial Rounded MT';
            color:#000000;
            padding-left:3px;
             text-decoration:none;
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

        .container2{
           margin: 15px 0 0 0;
        }

        .top {
          height: 150px;
          background-color: #F7941F;
          width:80%;
          
        }


        .bottom {
          height: 220px;
          width:80%;
          background-color: #ffffff;
          padding-left:2em;
          
        }

        .student-details{
            min-height: 180px;
            background-color: #ffffff;
            padding-left:2em;
            min-width:97%;
            float:left;
            margin-left:10px;
            padding-top:2em;
            font-family: 'Poppins', sans-serif;
        }

        .student-interest{
            min-height: 180px;
            background-color: #ffffff;
            padding-left:2em;
            min-width:97%;
            float:left;
            margin-left:10px;
            padding-top:2em;
            font-family: 'Poppins', sans-serif;
        }

        .student-details2{
            min-height: 180px;
            background-color: #ffffff;
            padding-left:2em;
            min-width:97%;
            float:left;
            margin-left:8px;
            padding-top:2em;
            font-family: 'Poppins', sans-serif;
        }

        .student-container{
            width:80%;
            margin-top:30px;
            font-size:18px;
        }

        .feedback-container{
            width:80%;
            margin-top:10px;
            font-family: 'Poppins', sans-serif;
            font-size:12px;
            background-color:white; 
            top:0;
            bottom:0;
            padding: 2% 2% 0% 2%;
            overflow: visible;
            min-height:500px;
            margin-top:30px;
            display:none;

        }

        .profile {
          
          border-radius: 100px;
          position: relative;
          top: -75px;
          
          
        }

        .line{
            height:2px;
            width:95%;
            background-color:#881A30;
            color:#881A30;
            position:center;
        }

        .btn-md{
            border: 1px #881A30;
            background-color: #881A30;
            position:center;
            width: 120px;
            height:45px;
        }

        .pen-icon {
            display: inline-block;
            cursor: pointer;
            font-size: 20px;
            color: #881A30;
            text-decoration: none;
            transition: color 0.3s;
            justify-content:center;
            padding-right:10px;
            padding-bottom:10px;
        }

        /* Hover effect */
        .pen-icon:hover {
            color: orange;
        }

        .profile-section{
            background-color:white;
            border-radius: 5px;
            font-size: 20px;
            text-align:center;
            min-width: 4%;
            min-height: 300px;
        }

        .details-section{
            background-color:#F7941F;
            border-radius: 5px;
            font-size: 20px;
            text-align:center;
            margin:auto;
            min-width: 20%;
            min-height:300px;
        }

        .section1{

        }

        .name{
            font-size:22px;
            color:#881A30;
            font-weight:bold;
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
            width: 50px;
            height: 50px;
            border-radius: 50%;
            object-fit: cover; /* Ensure the image covers the entire circle */
        }

        .feedback-name {
            font-weight: bold;
            margin-bottom: 5px;
            font-size:20px;
            padding-left:1em;
        }

        .feedback-date {
            font-size: 14px;
            color: #888;
            padding-left:1.5em;
        }

        .feedback-position {
            margin-left: 10px;
        }

        .feedback-rating {
            font-size: 15px;
            font-weight: bold;
            margin-top: 10px;
            padding-left:7em;
        }
        

        .feedback-text {
            margin-top: 10px;
            padding-left:6.5em;
            font-size:16px;
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

        .modal {
               display: none;
               width:600px;
               margin: 0 auto;
               margin-top:80px;
        }

        .modal-content{
            padding-left:1em;
            padding-right:1em;
        }
        .modal-body{
            font-family: 'Poppins', sans-serif;
            font-size:16px;
        }

        .btn1{

        }

        .btn2{

        }

        .txtbox-description{
           border-radius: 10px;
           width: 50%;
           min-height:80px;
           height:auto;
           margin-bottom:2%;
           border: 1px solid gray;
           padding:10px; 
           padding-left:20px;
           padding-top:20px;
        }

        .edit-resume{
            margin-left:100px;
        }

        
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column" >
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">

                    <a class="active" href="#myaccount">
                            <i class='bx bx-user-circle icon' ></i>
                            <span class="text nav-text">My Account</span>
                    </a>
                    <a href="Resume.aspx">
                            <i class='bx bx-file-blank icon' ></i>
                            <span class="text nav-text">Resume</span>
                    </a>
                    <a href="MyJobApplication.aspx">
                            <i class='bx bx-layer icon' ></i>
                            <span class="text nav-text">Application</span>
                    </a>
                    <a href="Student_AccountSetting.aspx">
                                <i class='bx bx-cog icon'></i>
                                <span class="text nav-text">Account Settings</span>
                            </a>
                    <a href="Report.aspx">
                        <i class='bx bxs-flag-alt'></i>
                        <span class="text nav-text">Report</span>
                    </a>
                    <hr style="height:2px;border-width:0;color:#881A30;background-color:#881A30">
                    <asp:LinkButton runat="server" ID ="SignOut" OnClick="SignOut_Click" >
                       <i class='bx bx-log-out icon' ></i>
                        Sign-out
                    </asp:LinkButton>
                   
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="top"></div>
                <div class="bottom">
                    <center>    
                        <asp:Image ID="profileImage" CssClass="profile" Width="150px" Height="150px" runat="server" />
                    </center>
                    <div class="row">
                        <div class="col-lg-12 order-1 order-lg-2 topnav">
                            <a class="active" href="#about">About</a>
                            <a href="#feedback">Feedback</a>
                        </div>
                    </div>
                </div>
                
                <div class="student-container" id="about">
                <div class="row">
                    <div class="col-6">
                        <div class="student-details">
                            <div class="row">
                                <div class="col-sm-12">
                                   <asp:Label ID="disp_name" runat="server" Text="" CssClass="name"></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="padding-top:1em;">
                                <div class="col-sm-1" style="font-weight:bold;">
                                    <i class="fa fa-map-marker" aria-hidden="true"></i>
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_address" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="padding-top:1em;">
                                <div class="col-sm-1" style="font-weight:bold;">
                                    <i class="fa fa-envelope" aria-hidden="true"></i>
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_email" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="padding-top:1em;">
                                <div class="col-sm-1" style="font-weight:bold;">
                                    <i class="fa fa-mobile" aria-hidden="true"></i>
                                </div>
                                <div class="col-sm-8">
                                    <asp:Label ID="disp_contact" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-12">
                                   <asp:Button ID="btnEdit" class="btn btn-primary btn-md" runat="server" Text="Edit" OnClick="btnEdit_Click"/>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-12">
                                   <asp:Label ID="Label4" runat="server" Text="Resume"></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="padding-top:1em;">
                                <div class="col-sm-1" style="font-weight:bold;">
                                    <i class="fa fa-file-text" aria-hidden="true"></i>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblResume" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-sm-7" style="float:right;">
                                    <asp:Button ID="btnViewResume" runat="server" class="btn btn-success" Text="View Resume" OnClick="btnViewResume_Click" Visible="false" />
                                    <asp:Button ID="UpdateResume" runat="server" class="btn btn-danger" Text="Update Resume" OnClick="UpdateResume_Click" />
                                  
                                </div>
                            </div>
                            <br />                          
                        </div>
                        
                    </div>
                    <div class="col-6">
                        <div class="student-details2">
                             <div class="row">
                                 <div class="col-sm-4">
                                     School
                                 </div>
                                 <div class="col-sm-8" style="font-weight:bold; color:#881A30;">
                                    <asp:Label ID="Label1" runat="server" Text="Cebu Technological University"></asp:Label>
                                 </div>
                             </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-4">
                                    Course
                                </div>
                                <div class="col-sm-8" style="font-weight:bold; color:#881A30;">
                                   <asp:Label ID="disp_course" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-4">
                                    Student Status
                                </div>
                                <div class="col-sm-8" style="font-weight:bold; color:#881A30;">
                                   <asp:Label ID="disp_status" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br /><br />
                            <div class="row">
                                <div class="col-sm-12">
                                   <asp:Button ID="btnEditStatus" class="btn btn-danger" runat="server" Text="Update" OnClick="btnEditStatus_Click"/>
                                </div>
                            </div>
                            <br />
                            
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-6">
                        <div class="student-interest">
                            <div class="row">
                                <div class="col-sm-12">
                                   <asp:Label ID="Label2" runat="server" Text="Interest/Hobby" CssClass="name"></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="padding-top:1em; padding-left:2em;">
                                <div class="col-sm-8">
                                    <asp:Label ID="lblinterestOrHobby" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-12">
                                   <asp:Button ID="btnEditInterest" class="btn btn-danger" runat="server" Text="Update" OnClick="btnEditInterest_Click"/>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
                </div>

                <div class="feedback-container" id="feedback">
                    <div class="row">
                        <div class="col-12">
                            <asp:ListView ID="listfeedback" runat="server">
                            <ItemTemplate>
                                <div class="feedback-item">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div style="display: flex; gap: 6px; padding-left: 1em;">
                                                <img src="images/defaultprofile.jpg" style="width:60px; height:auto; border-radius: 50%;" />
                                                <div>
                                                    <p class="feedback-name"><asp:Label ID="lblFeedbackName" runat="server" Text='<%# Eval("industryName") %>'></asp:Label></p>
                                                    <p class="feedback-date"><%# Eval("dateCreated", "{0:d}") %></p>
                                                </div>
                                            </div>
                                            <div class="feedback-text">
                                                <p><%# Eval("feedbackContent") %></p>
                                            </div>
                                        </div>
                                        <%-- Add a clearfix to prevent layout issues --%>
                                        <div class="clearfix visible-md visible-lg"></div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <h3 style="position: relative; top: 40%;">
                                    <asp:Label CssClass="alert alert-light d-flex p-2 bd-highlight justify-content-sm-center" runat="server" ID="lblNoPost" Text="No Feedback Yet!"></asp:Label></h3>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <asp:DataPager ID="ListViewPager" runat="server" PagedControlID="listfeedback" PageSize="2" class="btn-group btn-group-sm float-end">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                                <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="false" ButtonCount="5" NumericButtonCssClass="btn btn-default" CurrentPageLabelCssClass="btn btn-primary disabled" NextPreviousButtonCssClass="btn btn-default" />
                                <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="false" RenderNonBreakingSpacesBetweenControls="false" ButtonCssClass="btn btn-default" />
                            </Fields>
                        </asp:DataPager>
                        </div>
                    </div>
                </div>

            </div>
           
        </div>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br />
    <script>
        $(document).ready(function () {
            // Initially, show the "display-industry" content
            $(".student-container").show();

            // Handle tab click events
            $(".topnav a").click(function () {
                // Hide all content sections
                $(".feedback-container, .student-container").hide();

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

        function openModal2() {
            document.getElementById("myModal2").style.display = "block";
        }

        function closeEditModal2() {
            document.getElementById("myModal2").style.display = "none";
        }

        function openModal(interestHooby) {
            document.getElementById("myModal").style.display = "block";
            document.getElementById('<%=txtInterestHobby.ClientID%>').value = interestHooby;
        }

        function closeEditModal() {
            document.getElementById("myModal").style.display = "none";
        }

        function openModal4() {
            document.getElementById("myModal4").style.display = "block";
        }
        function closeEditModal4() {
            document.getElementById("myModal4").style.display = "none";
        }

        function openModal3() {
            document.getElementById("myModal3").style.display = "block";
        }

        function closeEditModal3() {
            document.getElementById("myModal3").style.display = "none";
        }

        $(document).ready(function () {
            $('.summernote1').summernote({
                height: 300,
                placeholder: 'Enter Interview Details...',
                toolbar: [
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['font'],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],

                    ['height', ['height']]

                ]
            });
        });
    </script>
    <!-- Modal dialog -->

    <div id="myModal2" class="modal">
    <div class="modal-content">
        <div class="modal-header">
            <h2 class="title">Edit Status</h2>
        </div>
        <div class="modal-body">
            <div class="row applicant-details">  
                <div class="col-sm-3">
                    Student Status
                </div>
                <div class="col-sm-9">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:DropDownList ID="drpStudentStatus" CssClass="txtbox" runat="server" Width="400px" Height="30px">
                        <asp:ListItem>Intern</asp:ListItem>
                        <asp:ListItem>Alumni</asp:ListItem>
                        <asp:ListItem>Withdraw</asp:ListItem>
                        </asp:DropDownList><br />
                        <asp:Label ID="lblstatus" runat="server" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>          
        </div>           
        <div class="modal-footer">
            <asp:Button ID="btnCloseStatus" runat="server" Text="Close" OnClick="btnCloseStatus_Click" class="btn btn-danger"/>
           <asp:Button ID="btnSaveStatus" class="btn btn-success" runat="server" Text="Save" OnClick="btnSaveStatus_Click"/>
        </div>
   
    </div>
</div>

    <div id="myModal" class="modal">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="title">Hobby/Interest</h2>
            </div>
            <div class="modal-body">
                <div class="row applicant-details"> 
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtInterestHobby" runat="server" Width="400px" Height="100px" ValidateRequestMode="Disabled" Rows="10" TextMode="MultiLine" CssClass="form-control txtbox-description summernote1" Placeholder="Add some interest/hobby"></asp:TextBox>
                    </div>
                </div>          
            </div>           
            <div class="modal-footer">
                <asp:Button ID="btnCloseHobby" runat="server" Text="Close" OnClick="btnCloseHobby_Click" class="btn btn-danger"/>
               <asp:Button ID="btnSaveHobby" class="btn btn-success" runat="server" Text="Save" OnClick="btnSaveHobby_Click"/>
            </div>
   
        </div>
    </div>


    <!-- Modal dialog -->
    <div id="myModal4" class="modal">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="title">Resume</h2>
            </div>
            <div class="modal-body">
                <div class="row edit-resume">  
                    <div class="col-sm-12">
                        <asp:Button ID="btnUploadResume" class="btn btn-success" runat="server" Text="Upload Resume"  OnClick="btnUploadResume_Click"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEditResume" runat="server" class="btn btn-success" Text="Build Resume" OnClick="btnEditResume_Click"/>
                    </div>
                </div>          
            </div>           
            <div class="modal-footer">
                <asp:Button ID="btnClose4" runat="server" Text="Close" OnClick="btnClose4_Click" class="btn btn-danger"/>
  
            </div>
   
        </div>
    </div>

    <!-- Modal dialog -->
    <div id="myModal3" class="modal">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="title">Edit Resume</h2>
            </div>
            <div class="modal-body">
                <div class="row applicant-details">  
                    <div class="col-sm-3">
                        Resume
                    </div>
                    <div class="col-sm-9">
                        <asp:FileUpload ID="resumeUpload" runat="server" Width="300px"/>
                        <asp:Label ID="lblResumeFileName" runat="server"></asp:Label>

                    </div>
                </div>          
            </div>           
            <div class="modal-footer">
                <asp:Button ID="btnCloseResume" runat="server" Text="Close" OnClick="btnCloseResume_Click" class="btn btn-danger"/>
               <asp:Button ID="btnSaveResumeback" class="btn btn-success" runat="server" Text="Save"  OnClick="btnSaveResumeback_Click"/>
            </div>
       
        </div>
    </div>

</asp:Content>