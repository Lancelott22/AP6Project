<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TraceStudent.aspx.cs" Inherits="ctuconnect.TraceStudent" %>
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
           height: 1000%;
           
       }

        .column.side {
            width: 100%;
            background-color: #f1f1f1;
            height: 100%;
        }


        
    </style>

    <div class="row">
           
            <div class="column side">
                
            </div>
        </div>
</asp:Content>
