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
            .column.side {
                width: 100%;
                height: 100%;
            }
        }
        /*
        .column {
            float: right;
            padding: 10px;
            left:300px;
            width:100%;
        }

        .column.side {
            background-color: #f1f1f1;
             height: 100vh;
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
        }*/
        .card {
            background: #ffc107;
            padding:10px;
        }
    </style>
    <h2 class="opacity-75">Dashboard</h2>
    <div class="container m-auto w-75 h-100 d-flex flex-column">
        <div class="row" style="height: 200px; margin-top: 10%;">
            <div class="col-sm">
                <div class="card h-100">
                    <div class="card-body">
                        <h3 class="card-title">Total Alumni</h3>
                        <h2 class="card-text my-5" id="totalAlumni" runat="server"></h2>
                    </div>
                </div>
            </div>
            <div class="col-sm">
                <div class="card h-100">
                    <div class="card-body">
                        <h3 class="card-title" >Total Interns</h3>
                        <h2 class="card-text my-5" id="totalIntern" runat="server"></h2>

                    </div>
                </div>
            </div>
            <div class="col-sm ">
                <div class="card h-100">
                    <div class="card-body">
                        <h3 class="card-title" >Total Industry</h3>
                        <h2 class="card-text my-5" id="totalIndustry" runat="server"></h2>

                    </div>
                </div>
            </div>
            <div class="col-sm ">
                <div class="card h-100">
                    <div class="card-body">
                        <h3 class="card-title" >Total Job Posted</h3>
                        <h2 class="card-text my-5" id="totalJobPosted" runat="server"></h2>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
