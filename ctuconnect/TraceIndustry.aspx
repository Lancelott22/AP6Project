<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TraceIndustry.aspx.cs" Inherits="ctuconnect.TraceIndustry" %>
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
          float: left;
          padding: 10px;
          
      }

     .div {
         height: 1000%;
         
     }

      .column.side {
          width: 100%;
          background-color: #f1f1f1;
          height: 100vh;
      }*/
  </style>
  <h2 class="opacity-75">Industry List</h2>
  <div class="container m-auto my-5 w-100 h-100 d-flex flex-column py-3">
      <div class="row"></div>
      <div class="row">
          <asp:ListView ID="IndustryListView" runat="server">
              <LayoutTemplate>
                  <table style="font-size:18px; line-height:30px;">
                      <tr style="background-color: #336699; color: White; padding:10px;">
                          <th>Industry Name</th>
                          <th>Location</th>
                          <th>Total Job Posts</th>
                          <th>Total Employees</th>
                          <th>Actions</th>
                      </tr>
                      <tbody>
                          <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                      </tbody>
                  </table>
              </LayoutTemplate>
              <ItemTemplate>
                  <tr style="border-bottom:solid 1px #336699">
                      <td><%#Eval("industryName")%></td>
                      <td><%#Eval("location")%></td>
                      <td><%#Eval("totalJobPosted")%></td>
                      <td><%#Eval("TotalEmployee")%></td>
                       <td><asp:LinkButton ID="viewProfile" runat="server">View Profile</asp:LinkButton></td>
                  </tr>
              </ItemTemplate>
          </asp:ListView>
      </div>
  </div>
</asp:Content>
