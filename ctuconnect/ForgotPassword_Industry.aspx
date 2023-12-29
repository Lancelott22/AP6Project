<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword_Industry.aspx.cs" Inherits="ctuconnect.ForgotPassword_Industry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .box{
        border: 1px solid grey;
        width:500px;
        background: #F0EBEB;
        margin-top:50px;
        border-radius: 15px;
        min-height:200px;
    }

    .btn-md{
        border: 1px #F7941F;
        background-color: #F7941F;
        position:center;
        border-radius: 25px;
        width: 120px;
    }

    .txtbox{
        opacity: 0.6;
        border-radius: 10px;
        min-width:440px;

    }
</style>

<br /><br /><br /><br />


    <div class="container box">

        
        <div class="row">
            <div class="col-lg-12 align-self-end text-center" style="color:#881a30; font-weight:bold;">       
                <h3>Forgot Password</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 align-self-end">
                <br /><br />
            </div> 
        </div>
        <div class="row">
            <div class="col-12" style="font-size:20px; padding-left:1em;">
                Enter Your Email:<br />
                <asp:TextBox ID="txtemail" CssClass="txtbox" runat="server" Height="40px" AutoPostBack="true" OnTextChanged="txtemail_TextChanged"></asp:TextBox><br />
                <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            </div>
        </div>
        <div class="row">     
            <div class="col-lg-12 align-self-end">
                <br /><br /><br />
                <p><asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="btn btn-danger"/>
                </p>
            </div> 
    
        </div>
        <br />
    </div>
</asp:Content>
