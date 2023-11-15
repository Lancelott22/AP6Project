<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IndustryHome.aspx.cs" Inherits="ctuconnect.IndustryHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
<script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>

<!-- include summernote css/js -->
<link href="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.css" rel="stylesheet">
<script src="https://cdn.jsdelivr.net/npm/summernote@0.8.18/dist/summernote.min.js"></script>
    <style>
       
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        *{
            font-family: 'Poppins', sans-serif;
        }
        .profile-container{
            max-width:260px;
            height:auto;
            padding: 10px;
            background-color:white;
            margin-left:4%;
        }
        @media (max-width: 790px) {
            .profile-container, .sidemenu-container {
                max-width: 50%;
                max-height:auto;
                
                 padding:5px 5px 5px 5px;
            }
        }
        .profile-container img{
            display:block;
            width:80%;
            margin-left:auto;
            margin-right:auto;

        }
        .profile-container p{
             display:block;
             text-align:center;
             font-size: 19px;
            margin-top:7%;
        }
        .sidemenu-container{
            width:253px;
            height:280px;
            background-color:white;
            /*margin-top:22%;*/
            padding-top:4px;
            margin-bottom:10%;
            margin-left:4%;
            border-radius: 25px;
            border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
            
        }
       
            .sidemenu-container a {
                position:static;
                border-radius: 25px;
                color: black;
                text-decoration: none;
                font-size: 19px;
                display: flex;
                margin: 10px 15px 5px 15px ;
                padding: 0px 0px 0px 20px;
                align-items:center;
            }
            .sidemenu-container a.active{
                 background-color:#F6B665;
                color:#606060;
            }
            .sidemenu-container a:hover{
                background-color:#fcd49a;
                color:#606060;
                margin: 10px 15px 5px 15px ;
                padding: 0px 0px 0px 20px;
            }
            .display-container{
                background-color:white; 
                width:1000px;
                top:0;
                bottom:0;
                padding: 2% 7% 4% 7%;
                overflow: auto;
                /*background-color:white;*/
                height:auto;
                /*overflow: auto;
                float:left;
                margin-left:25%;
                position:relative;
                padding: 4% 0% 0% 6%;*/
                margin-bottom: 30px;
            }
            
            @media (max-width: 790px) {
                .display-container {
                    max-width: 50%;
                }
            }
            .display-container .title{
                font-size:25px;
                font-weight:500;
                position:relative;
                margin-bottom:3%;
            }
            .display-container .title:before{
                content:'';
                position:absolute;
                height:2px;
                width:40px;
                bottom:0;
                background-color: #881A30;

            }
           /* .details1{
                
               display:flex;
                flex-wrap:wrap;
            }*/
            .title{

            }
           /*.input-box{
               width:100%;
               background:red;
               margin-top:20px;
           }*/
          /* .input-box input{
               position:relative;
               height:40px;
               width:100%;
               outline: none;
           }*/

          
          /* .textbox{
               position:relative;
               display:inline-block;
               height:40px;
               width:100%;
               background:red;
               padding-right:0;
               justify-content:center;
           }*/
            /*.details{
                width:80%;
                position:relative;
                background:red;
            }*/
             .txtbox {
                 display:flex;
                 position:relative;
                 border-radius: 10px;
                 min-width: 100%;
                min-height:35px;
                margin-bottom:2%;
               
                padding: 10px;
                 padding-left:20px;
                border: 1px solid gray;
                justify-content: center; /* Add this property to include padding in the width calculation */
               
    }
             .txtbox-description{
            
                  border-radius: 10px;
                  min-width: 100%;
                  min-height:100px;
               height:auto;
                margin-bottom:2%;
              border: 1px solid gray;
              padding:10px; 
                   padding-left:20px;
                   padding-top:20px;
             }
             .txtbox-instruction {
                
                  border-radius: 10px;
                  min-width: 100%;
                  min-height:100px;
                height:auto;
                margin-bottom:2%;
              border: 1px solid gray;
              padding:10px;
                   padding-left:20px;
                     padding-top:20px;
             }
             .content{
                 height:auto; 
                 width:97%; 
                 margin-left:2%; 
                 margin-right:2%;
                 padding: 0px 0px 0px 0px;
             }
            /* .profile{
                 max-width:25%;
                 height:200px;

             }*/
              @media (max-width: 790px) {
                .profile {
                    max-width: 20%;
                }
            }
             /*.label{
                 font-size:20px;
                 color:black;
              }*/
             label{
                 font-size:50px;
             }
         
            .dropdown-bx{
                border-radius: 10px; 
                min-width: 40%;
                min-height:35px;

            }
            .fa {
                width:20px;
                margin-right: 19px; 
    }
            .postJobStyle {
                float:right;
                color:white;
                background-color: orange;
                border-radius: 15px;
                height:40px;
                width:20%;
                border:1px solid orange;
            }
            .postJobStyle:hover {
                box-shadow: 3px 6px 7px -4px  grey;
            }
    </style>
    
    <asp:Table ID="Table1" runat="server" CssClass="content" >
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; height:200px;" >
                <div class="profile-container">
                <asp:Image ID="industryImage1" runat="server" />
                    <center><b><asp:Label ID="disp_industryName" CssClass="disp_industryName"  runat="server" Text=""></asp:Label></b></center>
                    <center><p style="font-size: 14px;">Account ID: <b><asp:Label ID="disp_accID" runat="server" Text=""></asp:Label></b></p></center>
                </div>
            </asp:TableCell> 
            <asp:TableCell  RowSpan="2" Style="padding:0px 5px 0px 40px">
                <div class="display-container container-fluid">
                    <h1 class="title">Post a Job</h1>
                   
                        <asp:Label ID="Label1" runat="server" Text="Job Title " Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="JobTitle" runat="server" CssClass="form-control txtbox" Placeholder="e.g. Financial Planning Assistant" ></asp:TextBox>
                        <div class="d-none">
                        <asp:Label ID="Label2" runat="server" Text="Industry Name " Style="font-size:18px;"></asp:Label><span style="color: red">*</span>
                        <asp:TextBox ID="IndName" runat="server" CssClass="form-control txtbox" Placeholder="e.g. Gaus Electonics"></asp:TextBox>
                   
                        <asp:Label ID="Label5" runat="server" Text="Job Location " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                        <asp:TextBox ID="jobLoc" runat="server" CssClass="form-control txtbox" Placeholder="e.g. M.J. Cuenco Ave, Cor R. Palma Street, 6000 Cebu" ></asp:TextBox>
                        </div>
                        <asp:Label ID="Label3" runat="server" Text="Job Type " Style="font-size:18px;"></asp:Label><span style="color: red">*</span>
                        <asp:Label ID="Label4" runat="server" Text="Specified course " Style="font-size:20px; margin-left:42%;"></asp:Label><span style="color: red">*</span>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <select runat="server" title="Select Job Type" class="selectpicker form-control" data-actions-box="true" multiple="true" name="jobtype" id="jobtype">
                                    <option value="fulltime">Full-time</option>
                                    <option value="internship">Internship</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <select runat="server" title="Choose Job Course" class="selectpicker form-control" data-actions-box="true" multiple="true" name="course" id="course">
                                    <option value="BSIT">BSIT</option>
                                    <option value="BIT-CT">BIT-CT</option>
                                    <option value="BSIS">BSIS</option>
                                </select>
                            </div>
                        </div>
                    </div>


                    <asp:Label ID="Label6" runat="server" Text="Job Description " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                    <asp:TextBox ID="jobDescript" runat="server" ValidateRequestMode="Disabled" Rows="10" TextMode="MultiLine" CssClass="form-control txtbox-description summernote1" Placeholder="Enter Job Description" ></asp:TextBox>

                    <asp:Label ID="Label7" runat="server" Text="Job Qualifications" Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                    <asp:TextBox ID="jobQuali" runat="server" Rows="10" ValidateRequestMode="Disabled" CssClass="form-control txtbox-description summernote2" TextMode="MultiLine" Placeholder="Enter Job Qualifications" ></asp:TextBox>

                    <asp:Label ID="Label8" runat="server" Text="Instructions to apply " Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                     <asp:TextBox ID="jobInstruct" runat="server" TextMode="MultiLine" CssClass="form-control txtbox-instruction" Placeholder="How to apply?"></asp:TextBox>
                     
                    <asp:Label ID="Label9" runat="server" Text="Salary Range" Style="font-size:20px;"></asp:Label><span style="color: red">*</span>
                    <asp:TextBox ID="salary" runat="server" CssClass="form-control txtbox" Placeholder="PHP XXX,XXX - PHP XXX,XXX"></asp:TextBox>

                    <asp:CheckBox ID="checkActivateJob" runat="server"/> <span Style="font-size:18px;">Activate Job</span> <span style="color: red">*</span><br />
                    <asp:Button ID="PostJob" runat="server" CssClass="postJobStyle"  Text="Post" OnClick="PostJob_Click"/>
            </div>
                    </asp:TableCell>
            </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top;" >
                <div class="sidemenu-container">
                     <a  href="IndustryDashboard.aspx"><i class='bx bxs-dashboard' aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                    <a class="active" href="#"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                    <a href="IndustryJobPosted.aspx" ><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                    <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                    <a href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                    <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                    <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
<i class="fa fa-sign-out" aria-hidden="true"></i>
 Sign-out
                    </asp:LinkButton>
               </div>
            </asp:TableCell> 
       </asp:TableRow>
      
    </asp:Table>
    <script>
    $(document).ready(function () {
        $('.summernote1').summernote({
            height: 300,
            placeholder: 'Enter Job Description...',
            toolbar: [
                ['style', ['bold', 'italic', 'underline', 'clear']],
                ['font'],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
               
                ['height', ['height']]

            ]
        });
        $('.summernote2').summernote({
            height: 300,
            placeholder: 'Enter Job Qualifications...',
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
</asp:Content>