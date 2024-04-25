<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Registeration.aspx.cs" Inherits="OnlineRecipeSharing.Registeration" EnableViewState="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- Titlebar -->
    <section id="titlebar">
        <div class="container">
            <div class="eight columns">
                <h2>User Registration</h2>
            </div>
            <div class="eight columns">
                <nav id="breadcrumbs">
                    <ul>
                        <li>You are here:</li>
                        <li><a href="#">Home</a></li>
                        <li>User Registration</li>
                    </ul>
                </nav>
            </div>
        </div>
    </section>
    <!-- Titlebar / End -->

    <!-- Content -->
    <div class="container">
        <div class="sixteen columns">
            <div class="User Registration-form">
                <!--User Registration -->
                <h4>User Registration</h4>
                
                <!-- Registration Form -->
                <div class="container">
                    <div class="container">
                        <form>
                            <div class="form-group">
                                <label for="userid">Userid:</label>
                                <asp:TextBox ID="userid" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="username">Username:</label>
                                <asp:TextBox ID="username" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="email">Email:</label>
                                <asp:TextBox ID="email" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password">Password:</label>
                                <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                            </div>
                           
                            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" CssClass="btn btn-primary" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

