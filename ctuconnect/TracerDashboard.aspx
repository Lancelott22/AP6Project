<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TracerDashboard.aspx.cs" Inherits="ctuconnect.TracerDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
<script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
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
            padding: 10px;
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
                        <h3 class="card-title">Total Interns</h3>
                        <h2 class="card-text my-5" id="totalIntern" runat="server"></h2>

                    </div>
                </div>
            </div>
            <div class="col-sm ">
                <div class="card h-100">
                    <div class="card-body">
                        <h3 class="card-title">Total Industry</h3>
                        <h2 class="card-text my-5" id="totalIndustry" runat="server"></h2>

                    </div>
                </div>
            </div>
            <div class="col-sm ">
                <div class="card h-100">
                    <div class="card-body">
                        <h3 class="card-title">Total Job Posted</h3>
                        <h2 class="card-text my-5" id="totalJobPosted" runat="server"></h2>

                    </div>
                </div>
            </div>
        </div>
        <div class="row my-5">
            <div class="col">
                <asp:Chart ID="Chart1" runat="server" Width="500px" BorderlineDashStyle="Solid">
                    <Titles>
                        <asp:Title Name="ChartTitle" Text="Total Hired per Industry" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Internship" ChartType="StackedColumn" IsValueShownAsLabel="true" IsVisibleInLegend="true" Legend="Internship" XValueMember="industryName" YValueMembers="hiredCount">
                        </asp:Series>
                        <asp:Series Name="Fulltime" ChartType="StackedColumn" IsValueShownAsLabel="true" IsVisibleInLegend="true" Legend="Fulltime" XValueMember="industryName" YValueMembers="hiredCount">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Internship" Docking="Bottom"></asp:Legend>
                        <asp:Legend Name="Fulltime" Docking="Bottom"></asp:Legend>
                    </Legends>
                </asp:Chart>
            </div>
            <div class="col d-flex flex-column align-items-center">
                 <asp:DropDownList runat="server" CssClass="selectpicker" ID="IndustryJob" AutoPostBack="true" OnSelectedIndexChanged="IndustryJob_SelectedIndexChanged">
                    </asp:DropDownList>
                <asp:Label ID="NoData" Text="No data available" runat="server" Visible="false"></asp:Label>
                <asp:Chart ID="Chart2" runat="server" Width="500px" BorderlineDashStyle="Solid">
                    <Titles>
                        <asp:Title Name="ChartTitle" Text="Total Hired per Job by Industry" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Internship" ChartType="StackedColumn" IsValueShownAsLabel="true" IsVisibleInLegend="true" Legend="Internship" XValueMember="jobPosition" YValueMembers="HiredPerJob">
                        </asp:Series>
                        <asp:Series Name="Fulltime" ChartType="StackedColumn" IsValueShownAsLabel="true" IsVisibleInLegend="true" Legend="Fulltime" XValueMember="jobPosition" YValueMembers="HiredPerJob">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Internship" Docking="Bottom"></asp:Legend>
                        <asp:Legend Name="Fulltime" Docking="Bottom"></asp:Legend>
                    </Legends>
                </asp:Chart>
            </div>
        </div>
    </div>
</asp:Content>
