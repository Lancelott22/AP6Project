﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterIndustry.aspx.cs" Inherits="ctuconnect.RegisterIndustry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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
          font-size: 17px;
          border-bottom: 3px solid transparent;
        }

        .topnav a:hover {
          border-bottom: 3px solid black;
        }

        .topnav a.active {
          border-bottom: 3px solid black;
          color:#881A30;
        }

        .txtbox{
            opacity: 0.6;
            border-radius: 10px;        
        }

        .content{
            width: 1000px;
        }

        .ask{
            color:black;
        }

        .link{
            color:#F7941F;
        }

        .btn-md{
            border: 1px #F7941F;
            border-radius: 5px;
            background-color: #F7941F;
            position:center;
            border-radius: 25px;
            width: 120px;
        }
        </style>

    <section>
        <div class="container">       
          <div class="row">
            <div class="col-lg-12 pt-5 pt-lg-0 order-2 order-lg-1 d-flex flex-column justify-content-center">
              <h2>Create Account</h2>
            </div>
          </div>
          <div class="row">
            <div class="col-lg-12 order-1 order-lg-2 topnav">
                  <a href="RegisterStudent.aspx" >Student</a>
                  <a class="active" href="#industry">Industry</a>      
             </div>
          </div>
        </div>
    </section>

    <section class="form">
        <br /><br />
        <div class="container content">
            
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- Industry Name -->
                <div class="col-sm-6 d-flex flex-column justify-content-center">      
                    Industry Name<span style="color:red;">*</span><br />
                    <asp:TextBox ID="txtindustry" CssClass="txtbox" runat="server" Width="500px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" forecolor="#F7941F" ControlToValidate="txtindustry" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
                <!-- Location -->
                <div class="col-sm-6 d-flex flex-column justify-content-center ">
                    Location<span style="color:red;">*</span><br />
                    <asp:TextBox ID="txtlocation" CssClass="txtbox" runat="server" Width="500px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" forecolor="#F7941F" ControlToValidate="txtlocation" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- Email -->
                <div class="col-sm-6 d-flex flex-column justify-content-center">      
                    Email<span style="color:red;">*</span><br />
                    <asp:TextBox ID="txtemail" CssClass="txtbox" runat="server" Width="500px" Height="30px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="chkemail" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid Email" Display="Dynamic" CssClass="text-danger" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" forecolor="#F7941F" ControlToValidate="txtemail" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
                <!-- MOA -->
                <div class="col-sm-6 d-flex flex-column justify-content-center ">
                    Attach Memorandum of Understanding<span style="color:red;">*</span><br />
                    <asp:FileUpload ID="mouUpload" runat="server" Width="300px"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" forecolor="#F7941F" ControlToValidate="mouUpload" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                    <asp:Label ID="StatusLabel" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- Password -->
                <div class="col-sm-6 d-flex flex-column justify-content-center">      
                    Password<span style="color:red;">*</span><br />
                    <asp:TextBox ID="txtpwd" CssClass="txtbox" runat="server" Width="500px" Height="30px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" forecolor="#F7941F" ControlToValidate="txtpwd" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="revpwd" runat="server" ControlToValidate="txtpwd" ErrorMessage="Invalid Password" Display="Dynamic" CssClass="text-danger" ValidationExpression="^(?=.*\d)(?=.*[A-Z])(?=.*\W)(?!.*\s).{8,}$"></asp:RegularExpressionValidator>
                </div>
                <!-- Profile Picture -->

                <div class="col-sm-6 d-flex flex-column justify-content-center ">
                    Attach Profile Picture<span style="color:red;">*</span><br />
                    <asp:FileUpload ID="profileUpload" runat="server" Width="300px"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" forecolor="#F7941F" ControlToValidate="profileUpload" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- Confirm Password -->
                <div class="col-sm-6 d-flex flex-column justify-content-center">
                    Confirm Password<span style="color:red;">*</span><br />
                    <asp:TextBox ID="txtcpwd" CssClass="txtbox" runat="server" Width="500px" Height="30px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" forecolor="#F7941F" ControlToValidate="txtcpwd" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvcpwd" runat="server" ErrorMessage="Password did not match!" ControlToCompare="txtpwd" ControlToValidate="txtcpwd"></asp:CompareValidator>
                </div>
                <div class="col-sm-6 d-flex flex-column justify-content-center">
                </div>
            </div>
            <br />
            <!-- Sign Up -->
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <p><asp:Button ID="btn" class="btn btn-primary btn-md" runat="server" Text="Sign Up" OnClick="btn_Click"/></p>   
            </div>
            <!-- Login link -->
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <p class="ask">Already have an account? <a href="LoginIndustry.aspx" class="link">Login here</a></p> 
            </div>
            
        </div>

    </section>
</asp:Content>
