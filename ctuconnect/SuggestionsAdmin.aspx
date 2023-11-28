<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="SuggestionsAdmin.aspx.cs" Inherits="ctuconnect.SuggestionsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        .profile-container{
            background-color:white;
            margin-left:4%;
            padding-bottom:8px;
            border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
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

        .second{
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left:auto;
            margin-right:auto;
            margin-top:13%;
            margin-bottom:0%;
        }
             
        .horizontal-line {
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left:auto;
            margin-right:auto;
            margin-top:1%;
            margin-bottom:0%;
        }
                
        .nav{
            padding:10px 10px 10px 10px;
            width:350px;
            margin:auto;
            margin-top:20px;
            position: absolute;
            margin-left:25px;
        }

        .nav a{
            font-size:18px;
            font-family:'Arial Rounded MT';
            color:#000000;
            text-decoration:none;
            position:static;
            font-size: 19px;
            display: block;
            margin: 2px 15px 5px 15px ;
            padding: 0px 0px 0px 30px;
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
        max-width:100%;
        width:1550px;
        border: 2px;
        box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        padding-top:2em;
        padding-left:2em;
        padding-right:2em;                  
        margin-left:3px;
    }
    .container .title{
    font-size:25px;
    font-weight:500;
    position:relative;
    margin-bottom:3%;
    padding-bottom:4px;
    }
    .container .title:before{
        content:'';
        position:absolute;
        height:2px;
        width:60px;
        bottom:0;
        background-color: #881A30;

    }
       
        .card {
            background: rgb(121,101,55);
            background: linear-gradient(90deg, rgba(121,101,55,1) 0%, rgba(245,168,2,1) 40%);
            border-radius:10px;
        }
                .txtsuggestion{
           background-color: #F0EBEB;
           border: 1px solid grey;
           border-radius: 5px;
           min-width:100%;
           min-height:200px;
           padding-top:2px;
           padding:20px;
           line-height: 60px;
        }
        .suggestion-container{
    max-height: 500px; 
    overflow-y: auto;
    background-color:plum;
    margin-left:20%;
    margin-right:20%;
    padding:20px;
}
.suggestion-item{
    background-color:whitesmoke;
    padding:10px;
    margin-bottom:1%;
}
.suggestion-text{
    padding-top:5px;
    text-indent: 29px;
}
    
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column" >
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">
                    <div class="profile-container">
                        <img src="images/administratorpic.jpg" />
                        <p >Admin</p>
                        <hr class="horizontal-line" />
                        <a class="active" href="AdminDashboard.aspx">
                            <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                            Dashboard
                        </a>
                    <a href="#myaccount">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Create Partnership
                    </a>
                    <a  href="IndustryVerification.aspx">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Industry Verification
                    </a>
                    <a href="ReferralList_Admin.aspx">
                        <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Referred Student
                    </a>
                    <hr class="horizontal-line" />
                    <a href="ListOfIndustries_Alumni.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Industry
                    </a>
                    <a href="ListOfInterns_Alumni.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Interns
                    </a>
                    <a href="ListOfAlumni_Admin.apsx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Alumni
                    </a>
                    <hr class="horizontal-line" />
                    <a href="#">
                        <i class="fa fa-exclamation-triangle" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dispute
                    </a>
                    <a href="Blacklist_Admin.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Blacklist
                    </a>
                        <a href="SuggestionsAdmin.aspx">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                        Suggestions
                    </a>
                    <hr class="second" />
                    <a href="TracerDashboard.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Tracer
                    </a>
                    <a href="#">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                        Profile
                    </a>
                    <asp:LinkButton runat="server" ID ="LinkButton1">
                        <i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>
                        Sign-out
                    </asp:LinkButton>

                    </div>
                    
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
            <div class="container">
                <h1 class="title">List of Suggestions</h1>
                 
                <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p><br />
         <div class="suggestion-container ">
    <div class="suggestion-list">
        <%-- Display suggestions here --%>
        <asp:Repeater ID="rptSuggestions" runat="server">
            <ItemTemplate>
                <div class="suggestion-item">
                    <div style="display: flex; gap:6px;">
                    <img src="images/defaultprofile.jpg" style="width:40px; height:auto; border-radius: 50%;"/>
                    <div>
                        <b>Anonymous:</b> <br />
                        <span style="font-size: 11px; color: #888;">Date Posted: <%# Eval("dateCreated") %></span>
                    </div>
                </div>
                    <p class="suggestion-text"> <%# Eval("Suggestion") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</div>
            </div>    
       
        </div>
    </div>

</asp:Content>
