<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recipes_category.aspx.cs" Inherits="OnlineRecipeSharing.recipes_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content
================================================== -->
    <div class="container">

        <!-- Masonry -->
        <div class="sixteen columns">

            <!-- Headline -->
            <h3 class="headline">Recipes</h3>
            <span class="line rb margin-bottom-35"></span>
            <div class="clearfix"></div>

            <!-- Isotope -->
            <div class="isotope">

                <asp:ListView ID="Lv_Recipies" runat="server">
                    <LayoutTemplate>
                        <div>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </div>
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <p>No recipe found. Kindly search for another recipe or add a new one.</p>
                    </EmptyDataTemplate>
                    <ItemTemplate>

                        <div class="four recipe-box columns">
                            <!-- Thumbnail -->
                            <div class="thumbnail-holder">

                                <img src='<%# Eval("image") %>' alt="" class="recipe-image" /> <!-- Set fixed width and height -->
                                <div class="hover-cover"></div>
                                <div class="hover-icon">
                                    <asp:HyperLink ID="ViewRecipeLink" runat="server" Text="View Recipe" NavigateUrl='<%# "Recipie_details.aspx?recipeId=" + Eval("Id") %>'></asp:HyperLink>
                                </div>
                            </div>
                            <!-- Content -->
                            <div class="recipe-box-content">
                                <h3><%# Eval("Name") %></h3>
                                <div class="recipe-meta"><i class="fa fa-clock-o"></i><%# Eval("CookingTime1") %></div>
                                <div class="clearfix"></div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:ListView>

                <!-- Message Label -->
                <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>

            </div>

        </div>
        <div class="clearfix"></div>

        <!-- Pagination -->
        <div class="pagination-container masonry">
            <nav class="pagination">
                <ul>
                    <li><a href="#" class="current-page">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                </ul>
            </nav>

            <nav class="pagination-next-prev">
                <ul>
                    <li><a href="#" class="prev"></a></li>
                    <li><a href="#" class="next"></a></li>
                </ul>
            </nav>
        </div>

        <!-- CSS for setting fixed dimensions -->
        <style>
            .recipe-image {
                width: 300px; 
                height: 200px; 
            }
        </style>

        <!-- Container / End -->

        <div class="margin-top-5"></div>
    </div>

</asp:Content>
