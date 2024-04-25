<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineRecipeSharing.RegistrationAndSignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Titlebar -->
    <section id="titlebar">
        <div class="container">
            <div class="twelve columns">
                <h2>Registration and Sign In</h2>
            </div>
        </div>
    </section>

    <!-- Content -->
    <div class="container">

        <div class="eight columns">
            <!-- Sign In Form -->
            <div id="signInForm">
                <h3 class="headline">Log in</h3>
                <span class="line margin-bottom-25"></span>
                <div class="clearfix"></div>

                <asp:TextBox ID="signInUsername" runat="server" placeholder="Username" CssClass="input" /><br />
                <asp:TextBox ID="signInPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="input" /><br />
                <asp:Button ID="SignInButton" runat="server" Text="Sign In" OnClick="SignInButton_Click" CssClass="submit" />
                <div id="SignInResult" runat="server"></div>
            </div>
            <!-- Sign In Form / End -->
        </div>
        <div class="eight columns">
            <!-- Registration Form -->
            <div id="registrationForm">
                <h3 class="headline">Register </h3>
                <span class="line margin-bottom-25"></span>
                <div class="clearfix"></div>

                <asp:TextBox ID="firstName" runat="server" placeholder="First Name" CssClass="input" /><br />
                <asp:TextBox ID="lastName" runat="server" placeholder="Last Name" CssClass="input" /><br />
                <asp:TextBox ID="email" runat="server" placeholder="Email" CssClass="input" /><br />
                <asp:TextBox ID="contactNumber" runat="server" placeholder="Contact Number" CssClass="input" /><br />
                <asp:TextBox ID="username" runat="server" placeholder="Username" CssClass="input" /><br />
                <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="Password" CssClass="input" /><br />
                <asp:FileUpload ID="FL_img" runat="server" /><br />
                <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" CssClass="submit" />
                <div id="registrationResult" runat="server"></div>
            </div>
            <!-- Registration Form / End -->
        </div>
        

    </div>
    <!-- Container / End -->

</asp:Content>
