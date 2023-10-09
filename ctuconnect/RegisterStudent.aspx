<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="ctuconnect.RegisterStudent" %>
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
                  <a class="active" href="#student">Student</a>
                  <a href="RegisterIndustry.aspx">Industry</a>      
             </div>
          </div>
        </div>
    </section>

    <section class="form">
        <br /><br />
        <div class="container content">
            
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- First name -->
                <div class="col-sm-4 d-flex flex-column justify-content-center">      
                    Firstname*<br />
                    <asp:TextBox ID="txtfname" CssClass="txtbox" runat="server" Width="300px" Height="30px"></asp:TextBox>    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" forecolor="#F7941F" ControlToValidate="txtfname" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
                <!-- Middle name -->
                <div class="col-sm-4 d-flex flex-column justify-content-center ">
                    Middle Initial*<br />
                    <asp:TextBox ID="txtinitial" CssClass="txtbox" runat="server" Width="200px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" forecolor="#F7941F" ControlToValidate="txtinitial" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
                <!-- Last name -->
                <div class="col-sm-4 d-flex flex-column justify-content-center">
                    Lastname*<br />
                    <asp:TextBox ID="txtlname" CssClass="txtbox" runat="server" Width="300px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" forecolor="#F7941F" ControlToValidate="txtlname" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- Email -->
                <div class="col-sm-4 d-flex flex-column justify-content-center">      
                    Email*<br />
                    <asp:TextBox ID="txtemail" CssClass="txtbox" runat="server" Width="300px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" forecolor="#F7941F" ControlToValidate="txtemail" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
                <!-- Student ID -->
                <div class="col-sm-4 d-flex flex-column justify-content-center ">
                    Student ID*<br />
                    <asp:TextBox ID="txtid" CssClass="txtbox" runat="server" Width="200px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" forecolor="#F7941F" ControlToValidate="txtid" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
                <!-- Course -->
                <div class="col-sm-4 d-flex flex-column justify-content-center">
                    Course*<br />
                    <asp:DropDownList ID="drpcourse" CssClass="txtbox" runat="server" Width="200px" Height="30px">
                        <asp:ListItem Value="100000002">BSIT</asp:ListItem>
                        <asp:ListItem Value="100000002">BSIS</asp:ListItem>
                        <asp:ListItem Value="100000002">BIT</asp:ListItem>
                        
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" forecolor="#F7941F" ControlToValidate="drpcourse" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- Password -->
                <div class="col-sm-4 d-flex flex-column justify-content-center">      
                    Password*<br />
                    <asp:TextBox ID="txtpwd" CssClass="txtbox" runat="server" Width="300px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" forecolor="#F7941F" ControlToValidate="txtpwd" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revpwd" runat="server" ControlToValidate="txtpwd" ErrorMessage="Invalid Password" ForeColor="Black" ValidationExpression="(?=^.{8,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$"></asp:RegularExpressionValidator>
                </div>
                <!-- COR -->
                <div class="col-sm-8 d-flex flex-column justify-content-center ">
                    Attach Certificate of Registration*<br />
                    <asp:FileUpload ID="corUpload" runat="server" Width="300px"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" forecolor="#F7941F" ControlToValidate="corUpload" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>  
            </div>
            <br />
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <!-- Confirm Password -->
                <div class="col-sm-4 d-flex flex-column justify-content-center">      
                    Confirm Password*<br />
                    <asp:TextBox ID="txtcpwd" CssClass="txtbox" runat="server" Width="300px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" forecolor="#F7941F" ControlToValidate="txtcpwd" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvcpwd" runat="server" ErrorMessage="Password did not match!" ControlToCompare="txtpwd" ControlToValidate="txtcpwd"></asp:CompareValidator>
                </div>
                <!-- Profile Picture -->
                <div class="col-sm-8 d-flex flex-column justify-content-center ">
                    Attach Profile Picture*<br />
                    <asp:FileUpload ID="profileUpload" runat="server" Width="300px"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" forecolor="#F7941F" ControlToValidate="profileUpload" runat="server" ErrorMessage="this field is required!"></asp:RequiredFieldValidator>
                </div>  
            </div>
            <br />
            <!-- Sign Up -->
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <p><asp:Button ID="btn" class="btn btn-primary btn-md" runat="server" Text="Sign Up" OnClick="btn_Click"/></p>   
            </div>
            <!-- Login Link -->
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center">
                <p class="ask">Already have an account? <a href="Login.aspx" class="link">Login here</a></p> 
            </div>
            
        </div>

    </section>

</asp:Content>
