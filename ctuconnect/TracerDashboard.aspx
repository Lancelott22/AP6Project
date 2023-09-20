<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TracerDashboard.aspx.cs" Inherits="ctuconnect.TracerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        * {
          box-sizing: border-box;
        }

        body {
          margin: 0 0;
        } 

        /* Clear floats before the columns */
        .row::before {
          content: "";
          display: table;
          clear: both;
        }

        /* Responsive layout - makes the three columns stack on top of each other instead of next to each other */
        @media screen and (max-width: 500px) {
          .column.side{
            width: 100%;
            height: 100%;
          }
        }

        .column {
            float: left;
            padding: 10px;
            
        }

       .div {
           height: 100%;
           
       }

        .column.side {
            width: 100%;
            background-color: #f1f1f1;
            height: 100%;
        }


        .box1, .box2 {
            box-sizing: border-box;
            -moz-box-sizing:border-box;
            -webkit-box-sizing: border-box;
            width: 480px;
            height: 250px;
            border: 1px solid #000000;
            border-radius: 8px;

            margin: 95px;
            margin-left: 45%;
            box-shadow: 5px 5px 5px 5px #888888;
            background: #f1eae6;  
        }
    </style>

    <div class="row">
           
            <div class="column side">
                <div class="box1">

                </div>
                <div class="box2">

                </div>
            </div>
        </div>
</asp:Content>
