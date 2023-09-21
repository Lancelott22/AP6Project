<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Refer.aspx.cs" Inherits="UserInterface.Refer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <meta name='viewport' content='width=device-width, initial-scale=1'>
<script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        *{
            font-family: 'Poppins', sans-serif;
        }
        .profile-container{
            max-width:260px;
            max-height:630px;
            background-color:white;
            margin-left:4%;
            padding-bottom:8px;
             border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
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
            width:50%;
            margin-left:auto;
            margin-right:auto;
            margin-top:auto;
            padding-top:10px;

        }
        .profile-container p{
             display:block;
             text-align:center;
             font-size: 19px;
            margin-top:7%;
        }
        .sidemenu-container{
            width:260px;
            height:200px;
            background-color:white;
            /*margin-top:22%;*/
            padding-top:4px;
            margin-bottom:10%;
            margin-left:4%;
            border-radius: 25px;
            border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
            
        }
       
            a {
                position:static;
                border-radius: 10px;
                color: black;
                text-decoration: none;
                font-size: 19px;
                display: block;
                margin: 2px 15px 5px 15px ;
                padding: 0px 0px 0px 30px;
            }
            a.active{
                 background-color:#F6B665;
                color:#606060;
            }
            a:hover{
                background-color:#fcd49a;
                color:#606060;
                margin: 2px 15px 5px 15px ;
                padding: 0px 0px 0px 30px;
                text-decoration: none;
            }
            .display-container{
                background-color:white; 
                width:750px;
                top:0;
                bottom:0;
                padding: 2% 4% 4% 4%;
                overflow: auto;
                /*background-color:white;*/
                height:550px;
                /*overflow: auto;
                float:left;
                margin-left:25%;
                position:relative;
                padding: 4% 0% 0% 6%;*/
            }
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
                padding-bottom:4px;
            }
            .display-container .title:before{
                content:'';
                position:absolute;
                height:2px;
                width:40px;
                bottom:0;
                background-color: #881A30;

            }
             .content{
                 height:100%; 
                 width:97%; 
                 margin-left:2%; 
                 margin-right:2%;
                 padding: 0px 0px 0px 0px;
             }
             .gridview-style{
                 margin-top:5%;
                 text-align:center;
             }
             .gridview-style .header-style{
                 width:20px;
                 text-align:center;
                 align-items:center;
             }
            .sort-dropdown{
                border-radius: 12px;
                width:100px;
                padding-left:8px;
                border-color:#c1beba;
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
        border-top: 2px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:1%;
        margin-bottom:0%;
    }
    .second{
        border: none;
        border-top: 2px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:13%;
        margin-bottom:0%;
    }
    .full-time:active::before{
                content:'';
                position:absolute;
                height:10px;
                width:40px;
                bottom:0%;
                background-color: #881A30;

    }
    .txtbox {
                 display:flex;
                 position:relative;
                 border-radius: 10px;
                 min-width: 100%;
                min-height:35px;
                margin-bottom:2%;
                padding-left:20px;
                border: 1px solid gray;
                justify-content: center; /* Add this property to include padding in the width calculation */
               
    }
    .dropdown1{
               
                display:flex; 
                position:relative;
                 border-radius: 10px;
                min-height:35px;
                margin-bottom:2%;
                justify-content: center;
            }
    .button-submit {
        background-color: white;
        min-width: 100%;
        min-height: 35px;
        color: orange;
        border-radius: 10px;
        border: 1px solid orange;
        transition: background-color 0.3s, color 0.3s, border-color 0.3s;
    }

    .button-submit:hover {
        background-color: #F6B665;
        color: white;
        border-color: orange;
    }
    .fa {
                width:20px;
                margin-right: 19px; 
    }
    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell  style="vertical-align: top;">
                <div class="profile-container">
                <img src="images/industrypic.png" />
                <p >OJT Coordinator</p>
                    <hr class="horizontal-line" />
                    <a  href="Coordinator.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                     <a class="active" href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:20px;"></i>Refer Student</a>
                    <a  href="CourseList.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                     <a  href="Applicants.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                     <hr class="second" />
                     <a  href="ReferralLIst.aspx"><i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>Sign-out</a>
                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding:0px 5px 0px 40px">
               <div class="display-container">
                   <h1 class="title">Refer a Student</h1>
                   <asp:Label ID="Label1" runat="server" Text="Student ID" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Placeholder="e.g. 1202200" ></asp:TextBox>
                   <asp:Label ID="Label2" runat="server" Text="First Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox"  ></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Last Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="txtbox"  ></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="User ID" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="txtbox" Placeholder="Enter your ID" ></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Referred by" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="txtbox"  ></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Text="Industry" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <div class="dropdown1">
                            <select name="jobtype" id="jobtype" Style="border-radius: 10px;  min-width: 100%; min-height:35px; margin-bottom:2%; padding-left:20px;">
                                <option value="#">Accenture.Inc</option>
                                <option value="#">Concentrix</option>
                                 <option value="#">Accenture.Inc</option>
                                <option value="#">Concentrix</option>
                                </select>
                       </div>
                   <asp:Label ID="Label7" runat="server" Text="Resume" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="txtbox"  ></asp:TextBox><br />
                   <asp:Button runat="server"  Text="Submit" CssClass="button-submit" />
               </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
