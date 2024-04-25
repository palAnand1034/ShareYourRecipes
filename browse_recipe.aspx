<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="browse_recipe.aspx.cs" Inherits="OnlineRecipeSharing.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Titlebar
================================================== -->
    <section id="titlebar" class="browse-all">
        <!-- Container -->
        <div class="container">

            <div class="eight columns">
                <h2>Browse Recipes</h2>
            </div>

        </div>
        <!-- Container / End -->
    </section>


    <!-- Container -->
    <div class="advanced-search-container">
        <div class="container">
            <div class="sixteen columns">
                <div id="advanced-search">
                    <div class=" ">
                       <%-- <div class="four columns ">
                            <asp:DropDownLi
                           st ID="ChooseCategory" class="chosen-select-no-single" runat="server"></asp:DropDownList>
                        </div>--%>
                        <div class="twenty columns ">
                            <asp:TextBox ID="SearchTextBox" runat="server" Width="450" />
                        </div>
                        <div class="four columns ">
                            <asp:Button ID="SearchButton" runat="server" Text="Search" Width="100%" placeholder="eg. lunch" OnClick="SearchButton_Click" />
                        </div>

                    </div>

                    <div class="clearfix"></div>

                    <!-- Search Input -->
                    <%--<nav class="search-by-keyword">
                    </nav>--%>
                    <div class="clearfix"></div>



                    <div class="clearfix"></div>
                </div>

            </div>
        </div>
    </div>


    <div class="margin-top-35"></div>


    <!-- Container -->
    <div class="container">

        <!-- Headline -->
        <div class="sixteen columns">
            <h3 class="headline">All Recipes</h3>
            <span class="line margin-bottom-35"></span>
            <div class="clearfix"></div>
        </div>
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
            <img src='<%# Eval("image") %>' alt="" width="200" height="150" /> <!-- Set fixed width and height -->
            <div class="hover-cover"></div>
            <div class="hover-icon"><a href='<%# "Recipie_details.aspx?recipeId=" + Eval("recipe_id") %>'>View Recipe</a></div>
        </div>
        <!-- Content -->
        <div class="recipe-box-content">
            <h3><%# Eval("RecipeTitle") %></h3>
            <div class="recipe-meta"><i class="fa fa-clock-o"></i><%# Eval("CookingTime") %></div>
            <div class="clearfix"></div>
        </div>
    </div>
</ItemTemplate>
     </asp:ListView>

        </div>
        <div class="clearfix"></div>
        <asp:Label ID="ErrorMessageLabel" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>



        <!-- Pagination -->
        <div class="sixteen columns">
            <div class="pagination-container">
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
        </div>

    </div>

    <!-- Wrapper / End -->
</asp:Content>
