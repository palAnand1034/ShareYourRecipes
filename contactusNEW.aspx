<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contactusNEW.aspx.cs" Inherits="OnlineRecipeSharing.contactusNEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content
================================================== -->

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
        <!-- Name -->
        <asp:Label runat="server" AssociatedControlID="TextBox1">Name:</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine" placeholder="Enter your name"></asp:TextBox>
    </div>
    <div>
        <!-- Email -->
        <asp:Label runat="server" AssociatedControlID="email">Email: <span>*</span></asp:Label>
        <asp:TextBox ID="email" runat="server" TextMode="Email" placeholder="Enter your email"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="email" ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$" ErrorMessage="Please enter a valid email address." Display="Dynamic" />
    </div>
    <div>
    <!-- Message -->
    <asp:Label runat="server" AssociatedControlID="TextBox2" Text="Message: "></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Columns="40" Rows="3" placeholder="Enter your message" spellcheck="true"></asp:TextBox>
</div>

</fieldset>

                    <%-- <div id="result"></div>--%>

                    <%--      <input type="submit" class="submit" id="submit" value="Send Message" />--%>
                    <div class="clearfix"></div>
                    <asp:Button ID="Submitbtn" runat="server" class="button color big" OnClick="BtnSubmit_Click" Text="SEND MESAGE" />
                    <%--   </form>--%>
                    <asp:Panel runat="server" ID="ResultPanel" Visible="false">
                        <!-- Content inside the panel goes here -->
                    </asp:Panel>


                </div>

                <asp:Label runat="server" ID="ErrorMessageLabel" Visible="false"></asp:Label>


            </section>
            <!-- Contact Form / End -->
            <div class="margin-bottom-50"></div>
        </div>
    </div>
</asp:Content>
