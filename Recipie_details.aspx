<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recipie_details.aspx.cs" Inherits="OnlineRecipeSharing.Recipie_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Recipe Background -->
    <div class="recipeBackground">
        <img src="images/recipeBackground.jpg" alt="" />
    </div>


    <!-- Content
================================================== -->
    <div class="container" itemscope itemtype="http://schema.org/Recipe">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <!-- Recipe -->
        <div class="twelve columns">
            <div class="alignment">

                <asp:ListView ID="RecipesListView" runat="server">
                    <ItemTemplate>
                        <!-- Header -->
                        <section class="recipe-header">
                            <div class="title-alignment">
                                <h2><%# Eval("RecipeTitle") %> <span style="font-size: 14px; float: right; font-family: inherit;">Recipe by <%# Eval("Author") %></span></h2>

                            </div>
                        </section>


                        <!-- Slider -->
                        <div class="recipeSlider rsDefault">
                            <img itemprop="image" class="rsImg" src='<%# Eval("image") %>' alt="" />

                        </div>

                        <section class="recipe-details" itemprop="nutrition">
                            <ul>
                                <li>Serves: <strong itemprop="recipeYield"><%# Eval("Proportion") %> people</strong></li>
                                <li>Prep Time: <strong itemprop="prepTime"><%# Eval("PreparationTime") %> </strong></li>
                                <li>Cooking: <strong itemprop="cookTime"><%# Eval("CookingTime") %></strong></li>
                                <li>Calories: <strong itemprop="calories"><%# Eval("Calories") %></strong></li>
                                <li>Category: <strong itemprop="Category"><%# Eval("Category") %></strong></li>
                                <li>Carbohydrate: <strong itemprop="Carbohydrate"><%# Eval("Carbohydrate") %> gm</strong></li>
                                <li>Protein: <strong itemprop="Protein"><%# Eval("Protein") %> gm</strong></li>
                            </ul>
                            <!-- Add to Wishlist Button -->
                            
                            <!-- Message Label -->
                            <%--<asp:Button ID="Button1" runat="server" Text="Add to Wishlist" 
                                OnClick="BtnAddToWishlist_Click" CssClass="button"
                                RecipeTitle='<%# Eval("RecipeTitle") %>' image='<%# Eval("image") %>' Category='<%# Eval("Category") %>' />--%>

                            <%--<a href="#" class="print"><i class="fa fa-print"></i>Print</a>--%>
                            <div class="clearfix"></div>
                        </section>



                        <p itemprop="description"><%# Eval("ShortSummary") %></p>

                        <p><strong>Ingredients:</strong> <%# Eval("Ingredients") %></p>



                        <p>
                            <strong>Directions:</strong> <%# Eval("directions") %>
                        </p>

                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <asp:Button ID="BtnAddToWishlist" runat="server" Text="Save Recipe" OnClick="BtnAddToWishlist_Click" CssClass="button" />
            </div>
        </div>
    </div>

    <%--<div class="container" itemscope itemtype="http://schema.org/Recipe" style="background: #fff;">
        <div class="sixteen columns " style="background: #fff;">
            <div class="alignment">
                <asp:ListView ID="" runat="server">
                    <ItemTemplate>
                        <div>
                            <div>
                                <h2><%# Eval("RecipeTitle") %></h2>
                            </div>

                            <img src='<%# Eval("image") %>' alt="" />
                            <p><%# Eval("ShortSummary") %></p>
                            <p><strong>Cooking Time:</strong> <%# Eval("CookingTime") %></p>
                            <p><strong>Preparation Time:</strong> <%# Eval("PreparationTime") %></p>
                            <p><strong>Calories:</strong> <%# Eval("Calories") %></p>
                            <p><strong>Author:</strong> <%# Eval("Author") %></p>
                            <p><strong>Ingredients:</strong> <%# Eval("Ingredients") %></p>
                            <p><strong>Direction Proportion:</strong> <%# Eval("Proportion") %></p>
                            <p><strong>Category:</strong> <%# Eval("Category") %></p>
                            <p><strong>Carbohydrate:</strong> <%# Eval("Carbohydrate") %></p>
                            <p><strong>Protein:</strong> <%# Eval("Protein") %></p>
                            <!-- Add more columns as needed -->

                            <p>
                                <strong>Directions:</strong> <%# Eval("directions") %>
                            </
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>--%>
</asp:Content>
