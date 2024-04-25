<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="OnlineRecipeSharing.WebForm8" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Include Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    
    <!-- Custom CSS -->
    <style>
        .text-bg {
            background-color: #f0f0f0; /* Light gray background */
            color: #333; /* Dark text color */
            padding: 10px; /* Add some padding for spacing */
        }

        .btn-remove {
            background-color: #74c69d; /* Light green color */
            border-color: #74c69d; /* Border color */
            color: #fff; /* White text color */
        }

        .btn-remove:hover {
            background-color: #5da78e; /* Darker green color on hover */
            border-color: #5da78e; /* Darker border color on hover */
        }

        /* Decrease the size of wishlist items and arrange 2 recipes in a row */
        .wishlist-item {
            width: 45%; /* Set width to arrange two items in a row */
            margin: 10px; /* Add some margin between items */
        }

        .wishlist-item img {
            max-width: 100%; /* Make images responsive */
            height: auto; /* Maintain aspect ratio */
        }
    </style>

      <!-- Titlebar
================================================== -->
    <section id="titlebar">
        <!-- Container -->
        <div class="container">

            <div class="eight columns">
                <h2>Wishlist</h2>
            </div>

            <div class="eight columns">
                <nav id="breadcrumbs">
                    <ul>
                        <li>You are here:</li>
                        <li><a href="#">Home</a></li>

                        <li>Wishlist</li>
                    </ul>
                </nav>
            </div>
            <link href="Content/bootstrap-theme.css" rel="stylesheet" />
        </div>
        <!-- Container / End -->
    </section>


    <!-- Content -->
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-12">
                <asp:ListView ID="WishlistListView" runat="server">
                    <ItemTemplate>
                        <div class="card wishlist-item">
                            <div class="card-body text-bg">
                                <h3 class="card-title"><%# Eval("RecipeTitle") %></h3>
                                <img src='<%# Eval("image") %>' alt="Recipe Image" class="img-fluid mb-3" />
                                <p class="card-text">Category: <%# Eval("category") %></p>
                                <!-- Add Remove Button -->
                                <asp:Button ID="RemoveButton" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Eval("RecipeID") %>' CssClass="btn btn-remove" OnClick="RemoveButton_Click" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
