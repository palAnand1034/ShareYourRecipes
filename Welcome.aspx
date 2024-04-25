<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="OnlineRecipeSharing.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Welcome to Online Recipe Sharing!</h2>
        <p>Welcome,
            <asp:Label ID="lblUsername" runat="server" /></p>
        <asp:Button ID="btnSubmitRecipe" runat="server" Text="Submit Recipe" OnClick="btnSubmitRecipe_Click" />
    </div>
</asp:Content>

