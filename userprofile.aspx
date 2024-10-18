<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="OnlineRecipeSharing.UserProfile" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">
        <!-- Centered Heading -->
        <div class="text-center">
            <h2>User Profile</h2>
        </div>

        <!-- Profile Image and User Info -->
        <div class="row justify-content-center align-items-center mb-4">
            <div class="col-md-4 text-center">
                <asp:Image ID="imgProfile" runat="server" CssClass="img-fluid rounded-circle" />
            </div>
            <div class="col-md-8">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="lblName">Name:</label>
                            <asp:Label ID="lblName" runat="server" CssClass="form-control" ReadOnly="true"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="lblEmail">Email:</label>
                            <asp:Label ID="lblEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="lblContactNo">Contact Number:</label>
                            <asp:Label ID="lblContactNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <hr />

        <!-- Shared Recipes -->
        <h3>Shared Recipes</h3>
        <div class="row">
            <asp:ListView ID="lvSharedRecipes" runat="server">
                <ItemTemplate>
                    <!-- Thumbnail -->
                    <div class="col-lg-4 col-md-6 col-sm-12 mb-4">
                        <div class="card">
                            <img src='<%# Eval("image") %>' class="card-img-top" alt="Recipe Image" style="max-width: 100%; height: auto;">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("RecipeTitle") %></h5>
                                <p class="card-text">Cooking Time: <%# Eval("CookingTime") %></p>
                                <!-- Link to view recipe -->
                                <a href='<%# "Recipie_details.aspx?recipeId=" + Eval("recipe_id") %>' class="btn btn-primary btn-block">View Recipe</a>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit Recipe" CssClass="btn btn-secondary btn-block" OnClick="EditRecipe_Click" CommandArgument='<%# Eval("recipe_id") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>

        <!-- Manage Links -->
        <div class="text-center mt-4">
            <a href="MealTypes.aspx" class="btn btn-info">Manage Meal Types</a>
        </div>
    </div>

    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">

    <!-- Bootstrap JavaScript -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
