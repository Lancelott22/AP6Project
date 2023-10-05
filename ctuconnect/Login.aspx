<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ctuconnect.Login" %>
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

            


        </style>

            <br /><br /><br /><br />
            <div class="container px-4 px-lg-5 h-100">
                <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center text-center">
                    <div class="col-lg-8 align-self-end">
                        
                        <svg xmlns="http://www.w3.org/2000/svg" width="63" height="65" fill="currentColor" class="bi bi-person-fill" viewBox="0 0 16 16">
                          <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z"/>
                        </svg>
                    </div>
                    <div class="col-lg-12 align-self-end">
                        <p class="connect">Please Signin to continue</p>
                    </div>
                    <!-- Email -->
                    <div class="col-lg-12 align-self-end">       
                        <asp:TextBox ID="txtemail" CssClass="txtbox" runat="server" placeholder="Email address" Height="40px" Width="285px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter email" ControlToValidate="txtemail" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-12 align-self-end">
                        <br />
                    </div> 
                    <!-- Password -->
                    <div class="col-lg-12 align-self-end">
                        <asp:TextBox ID="txtpwd" CssClass="txtbox" runat="server" TextMode="Password" placeholder="Password" Height="40px" Width="285px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter password" ControlToValidate="txtpwd" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator><br />
                        <asp:Label ID="LoginErrorMessage" runat="server" Text="The password or email is incorrect!" CssClass="connect"></asp:Label>
                    </div>
                    <div>
                        <asp:CheckBox ID="CheckBox1" style="color:#FFF5F5; font-family: Arial; font-size: 15px;opacity: 0.9;" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged"/>
                    </div>
                    <div class="col-lg-12 align-self-end">
                        <p><asp:Button ID="btn" class="btn btn-primary btn-md" runat="server" Text="Login" OnClick="LogIn_Click"/></p>
                    </div> 

                </div>
            </div>

       
        <br /><br /><br /><br /><br /><br />
        <section class="row align-items-center justify-content-center text-center">
            <p class="ask">Do not have an account yet? <a href="RegisterStudent.aspx" class="link">Register here</a></p>
        </section>
        <br /><br />
       
    </main>
    
</asp:Content>
