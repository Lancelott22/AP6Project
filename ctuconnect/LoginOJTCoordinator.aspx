<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginOJTCoordinator.aspx.cs" Inherits="ctuconnect.LoginOJTCoordinator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>

        <style>
            .bi-person-fill{
                color:#FFF5F5;
            }
            .connect{
                color:#FFF5F5;
                font-family: Arial;
                font-size: 15px;
                opacity: 0.9;
                
            }
            .btn-md{
                border: 1px #F7941F;
                background-color: #F7941F;
                position:center;
                border-radius: 25px;
                width: 120px;
            }
            .notice{
                color:#FFF5F5;
                font-size: 30px;
                font-family:Arial;
                opacity: 0.9;
                text-align:center;
            }
            .ask{
                color:#FFF5F5;
            }
            .link{
                color:#F7941F;
            }
            .txtbox{
                opacity: 0.6;
                border-radius: 10px;
                
            }
            .box{
                border: 1px solid grey;
                width:500px;
            }
            
            .topnav a {
              float:left;
              display: block;
              color: white;
              text-align: center;
              padding: 14px 16px;
              text-decoration: none;
              font-size: 14px;
              border-bottom: 3px solid transparent;
            }
            .topnav a:hover {
              border-bottom: 3px solid #F7941F;
              color:#F7941F;
            }
            .topnav a.active {
              border-bottom: 3px solid #F7941F;
              color:#F7941F;
            }
            
            
        </style>

            <br /><br />


            <div class="container px-4 px-lg-5 h-100 box">

                <div class="row align-items-center justify-content-center text-center" >
                    <div class="col-lg-12 order-1 order-lg-2 topnav">
                              <a href="LoginStudent.aspx">Student</a>
                              <a href="LoginIndustry.aspx">Industry</a>
                              <a class="active" href="#OJTCoordinator">Coordinator</a>
                    </div>
                </div>
                <br /><br />
                <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center text-center">
                    <div class="col-lg-8 align-self-end">

                        <svg xmlns="http://www.w3.org/2000/svg" width="63" height="65" fill="currentColor" class="bi bi-person-fill" viewBox="0 0 16 16">
                          <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z"/>
                        </svg>
                    </div>
                    <!-- Email -->
                    <div class="col-lg-12 align-self-end">       
                        <asp:TextBox ID="txtusername" CssClass="txtbox" runat="server" placeholder="username" Height="40px" Width="285px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter username" ControlToValidate="txtusername" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                     
                    <!-- Password -->
                    <div class="col-lg-12 align-self-end">
                        <asp:TextBox ID="txtpwd" CssClass="txtbox" runat="server" TextMode="Password" placeholder="Password" Height="40px" Width="285px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter password" ControlToValidate="txtpwd"  CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:Label ID="LoginErrorMessage" runat="server" Text="The password or email is incorrect!" CssClass="connect"></asp:Label>
                    </div>
                    <!-- Check Box for Hide Password -->
                    <div>
                        <asp:CheckBox ID="CheckBox1" style="color:#FFF5F5; font-family: Arial; font-size: 15px;opacity: 0.9;" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged"/>
                    </div>
                    <!-- Login Button -->
                    <div class="col-lg-12 align-self-end">
                        <p><asp:Button ID="btn" class="btn btn-primary btn-md" runat="server" Text="Login" OnClick="btn_Click"/></p>
                    </div> 

                </div>
                <br />
            </div>


        <br /><br /><br /><br /><br /><br />
        
        <br /><br />

    </main>
</asp:Content>
