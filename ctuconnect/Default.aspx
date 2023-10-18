<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ctuconnect._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style>
            .school{
                color:#FFF5F5;
                font-family:Arial;
                font-size: 12px;
                opacity: 0.9;
            }

            .address{
                color:#FFF5F5;
                font-family:Arial;
                font-size: 10px;
                opacity: 0.9;
            }

            .connect{
                color:#FFF5F5;
                font-family: 'Arial Rounded MT';
                font-size: 60px;
                
            }

            .btn-md{
                border: 1px #F7941F;
                border-radius: 5px;
                background-color: #F7941F;
                position:center;
                border-radius: 25px;
                width: 120px;
            }


            .desc{
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

        </style>

        
            <div class="container px-4 px-lg-5 h-100">
                <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center text-center">
                    <div class="col-lg-8 align-self-end">
                        <img src="images/ctulogo.png" height="75" width="73">
                    </div>
                    <div class="col-lg-8">
                        <h3 class="school">CEBU TECHNOLOGICAL UNIVERSITY</h3>
                        <h6 class="address"><b>Main Campus:</b> M.J. Cuenco Avenue corner R. Palma St., Cebu City. </h6>
                    </div>
                    <div class="col-lg-8 align-self-end">
                        <p class="connect">CTU Connect</p>
                    </div>         

                </div>
            </div>

        <section class="row">
            <p class="desc">the system bridges the gap between university students and the Cebu Technological University 
                partnered industry through a job and internship. We believe that by facilitating university-industry
                collaboration, we can help students gain real world experience and to the Industry 
                to connect with potential employers.
            </p>
        </section>
        <br />
        <section class="row align-items-center justify-content-center text-center">
            <p><a href="LoginStudent.aspx" class="btn btn-primary btn-md">Login</a></p>
        </section>
        <section class="row align-items-center justify-content-center text-center">
            <p class="ask">Do not have an account yet? <a href="RegisterStudent.aspx" class="link">Register here</a></p>
        </section>
        <br /><br />
       
    </main>

</asp:Content>
