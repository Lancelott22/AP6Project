<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JobPortal.aspx.cs" Inherits="ctuconnect.JobPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .box{
            min-width:250px;
            height: 250px;
            border: 1px solid #FFFFFF;
            border-radius: 5px;
            padding: 5px;
            background: #FFFFFF;
            padding: 5px 5px;
            margin-left:20px;
        }

        .profile {
          border-radius: 50px;
          
          
             
        }

        .searchbox{
            min-width:90%;
            border-radius: 5px;
            padding: 5px;
            background: #F0EBEB;
            border: 1px solid grey;
        }

        .reco{
            width:90%;
            min-height:300px;
            background: #FFFFFF;
            border: 1px solid #FFFFFF;
            padding: 4px 4px 4px 4px;
            border-radius: 5px;
        }

        .jobs{
            width:90%;
            min-height:300px;
            background: #FFFFFF;
            border: 1px solid #FFFFFF;
            padding: 4px 4px 4px 4px;
            border-radius: 5px;
        }

        .name{
            font-size:16px;
            font-family:'Arial Rounded MT';
        }

        .accountid{
            font-size:12px;
            font-family:'Arial Rounded MT';
        }

        .btn-md{
            border: 1px #F7941F;
            border-radius: 15px;
            background-color: #F7941F;
            width: 95px;
        }

        .line{
            height:2px;
            width:90%;
            background-color:#881A30;
            color:#881A30;
            position:center;
        }
        
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column align-items-center text-center" >
                <br />
                <div class="box">
                    <img src="images/defaultprofile.jpg" alt="Bootstrap" class="profile" height="90" width="90">
                    <br />
                    <asp:Label ID="lblname" CssClass="name" runat="server" Text="Name of the Intern/Alumni"></asp:Label>
                    <br />
                    <asp:Label ID="lblacctid" CssClass="accountid" runat="server" Text="account id"></asp:Label>
                    <hr style="height:2px;border-width:0;color:gray;background-color:gray">
                    <a href="MyAccount.aspx" class="btn btn-primary btn-md">View Profile</a>
                </div>
            </div>
            <div class="col-9 d-flex flex-column">
                <br />
                <asp:TextBox ID="txtsearchOrder" CssClass="searchbox" runat="server" placeholder="Search job title or keyword"></asp:TextBox>
                <br />
                <div class="reco">
                    <p>Recommended for you</p>

                </div>
                <hr class="line"/>
                <div class="jobs">
                    

                </div>
            </div>
        </div>
    </div>
    <br /><br />
</asp:Content>
