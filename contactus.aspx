<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="OnlineRecipeSharing.WebForm1" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <!-- Titlebar
================================================== -->
    <section id="titlebar">
        <!-- Container -->
        <div class="container">

            <div class="eight columns">
                <h2>Contact Us</h2>
            </div>

            <div class="eight columns">
                <nav id="breadcrumbs">
                    <ul>
                        <li>You are here:</li>
                        <li><a href="#">Home</a></li>

                        <li>Contact Us</li>
                    </ul>
                </nav>
            </div>
            <link href="Content/bootstrap-theme.css" rel="stylesheet" />
        </div>
        <!-- Container / End -->
    </section>

    <!-- Container -->
    <div class="container">
        <div class="sixteen columns">
            <div class="image-with-caption contact">
                <img class="rsImg" src="images/contact.jpg" alt="" />
                <span>Contact me with any questions</span>
            </div>
        </div>
    </div>
    <!-- Container / End -->


    <div class="margin-top-10"></div>


    <!-- Container -->
    <div class="container">

        <!-- Contact Form -->
        <div class="twelve columns">
            <h3 class="headline">Contact Form</h3>
            <span class="line margin-bottom-25"></span>
            <div class="clearfix"></div>

            <!-- Contact Form -->
            <section id="contact">

                <!-- Success Message -->
                <mark id="message"></mark>

                <!-- Form -->
                <div method="post" name="contactform" id="contactform">

                    <fieldset>

                        <div>
                            <asp:Label runat="server" ID="NameLabel" AssociatedControlID="NameTextBox">Name:</asp:Label>
                            <asp:TextBox runat="server" ID="NameTextBox" EnableViewState="true"></asp:TextBox>

                        </div>

                        <div>
                            <asp:Label runat="server" ID="EmailLabel" AssociatedControlID="EmailTextBox">Email: <span>*</span></asp:Label>
                            <asp:TextBox runat="server" ID="EmailTextBox" TextMode="Email" EnableViewState="true"></asp:TextBox>
                            <asp:RegularExpressionValidator runat="server" ID="EmailValidator" ControlToValidate="EmailTextBox" ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$" ErrorMessage="Please enter a valid email address." Display="Dynamic" />

                        </div>

                        <div>
                            <asp:Label runat="server" ID="MessageLabel" AssociatedControlID="MessageTextBox">Message: <span>*</span></asp:Label>
                            <asp:TextBox runat="server" ID="MessageTextBox" TextMode="MultiLine"  EnableViewState="true" Columns="40" Rows="3"></asp:TextBox>

                        </div>

                    </fieldset>
                    <asp:Panel runat="server" ID="ResultPanel">
                        <!-- Content inside the div goes here -->
                    </asp:Panel>
                    <asp:Button runat="server" ID="SubmitButton" CssClass="submit" Text="Send Message" OnClick="SubmitButton_Click" />
                    <div class="clearfix"></div>

                </div>

            </section>
            <asp:Label runat="server" ID="ErrorMessageLabel"></asp:Label>

            <!-- Contact Form / End -->
            <div class="margin-bottom-50"></div>
        </div>


        <div class="four columns">
        </div>

    </div>
    <!-- Container / End -->
</asp:Content>
