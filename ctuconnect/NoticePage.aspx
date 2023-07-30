<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoticePage.aspx.cs" Inherits="ctuconnect.NoticePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
 
        <style>
            .bi-person-fill{
                color:#FFF5F5;
            }

            .connect{
                color:#FFF5F5;
                font-family: 'Arial Rounded MT';
                font-size: 40px;
                opacity: 0.9;
                
            }

            .btn-md{
                border: 1px #F7941F;
                border-radius: 5px;
                background-color: #F7941F;
                position:center;
                border-radius: 25px;
                width: 120px;
            }


            .notice{
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

            <br />
            <div class="container px-4 px-lg-5 h-100">
                <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center text-center">
                    <div class="col-lg-8 align-self-end">
                        
                        <svg xmlns="http://www.w3.org/2000/svg" width="63" height="65" fill="currentColor" class="bi bi-person-fill" viewBox="0 0 16 16">
                          <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z"/>
                        </svg>
                    </div>
                    <div class="col-lg-12 align-self-end">
                        <p class="connect">Your account is currently on hold</p>
                    </div>         

                </div>
            </div>

        <section class="row">
            <p class="notice">Please wait for the confirmation via email when the verification process is done.<br />
                We hope you understand, this is to ensure the identity or authentication of the account holder.
            </p>
        </section>
        
        <br /><br /><br /><br /><br /><br />
        <section class="row align-items-center justify-content-center text-center">
            <p><a href="Login.aspx" class="btn btn-primary btn-md">Login</a></p>
        </section>
        <section class="row align-items-center justify-content-center text-center">
            <p class="ask">Do not have an account yet? <a href="RegisterStudent.aspx" class="link">Register here</a></p>
        </section>
        <br /><br />
       
    </main>
</asp:Content>
