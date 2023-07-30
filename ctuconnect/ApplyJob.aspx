<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ApplyJob.aspx.cs" Inherits="ctuconnect.ApplyJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container{
            background:#FFFFFF; 
            padding: 20px 20px 20px 20px;
            border-radius: 5px;
            width: 450px;
            margin:auto;
        }

        .txtbox{
            border-radius: 8px;
            display:block;
            min-width:420px;
        }

        .txtbox1{
            border-radius: 8px;
            display:block;
            min-width:150px;
        }

        .button{
            border: 1px #F7941F;
            border-radius: 5px;
            background-color: #F7941F;
            position:center;
            border-radius: 25px;
            width: 200px;
            color:#FFFFFF;
            height:30px;
        }

        
    </style>
    <br /><br />
    <div class="container">
                <div class="row">
                    <div class="col">
                        Email*<br />
                        <asp:TextBox ID="txtemail" CssClass="txtbox" runat="server" Height="30px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        Name*<br />
                        <asp:TextBox ID="txtname" CssClass="txtbox" runat="server" Height="30px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                        Date*<br />
                        <asp:TextBox ID="txtdate" CssClass="txtbox1" Height="30px" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgbtncldr" runat="server" Height="30px" Width="25px" ImageUrl="images/calendar.jpg" OnClick="imgbtncldr_Click"/>
                        <asp:Calendar ID="clndrdate" runat="server" OnDayRender="clndrbdate_DayRender" OnSelectionChanged="clndrbdate_SelectionChanged"></asp:Calendar>
                    </div>
                </div>
                <br /><br /><br />
                <div class="row">
                    <div class="col">
                        <asp:Label ID="Label1" runat="server" Text="*Personal requirements should be submitted personally to the company" ForeColor="Red"></asp:Label>           
                    </div>
                </div>
                <br />
                <div class="row align-items-center justify-content-center text-center">
                    <div class="col">
                        <p><asp:Button ID="btn" class="button" runat="server" Text="Submit"/></p>           
                    </div>
                </div>
                
    </div>
    <br /><br />
    <br /><br /><br />
</asp:Content>
