<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineRecipeSharing.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <!-- Slider
================================================== -->

    <div id="homeSlider" class="royalSlider rsDefaultInv">
        <!-- Slide #1 - Greek Chicken Pasta -->
        <div class="rsContent">
            <a class="rsImg" href="Upload\greenchikecnpasta.jpg"></a>
            <i class="rsTmb">Greek Chicken Pasta</i>

            <!-- Slide Caption -->
            <div class="SlideTitleContainer rsABlock">
                <div class="CaptionAlignment">
                    <div class="rsSlideTitle tags">
                        <ul>
                            <li>Baking</li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>


                    <h2><a href="Recipie_details.aspx?recipeId=1234" class="rsSlideTitle title">Greek Chicken Pasta</a></h2>
                    <div class="rsSlideTitle details">
                        <ul>
                            <li><i class="fa fa-cutlery"></i>4 Servings</li>
                            <li><i class="fa fa-clock-o"></i>45 minutes</li>
                            <li><i class="fa fa-user"></i>by <a href="#">Chef Khan</a></li>
                        </ul>
                    </div>

                    <a href="Recipie_details.aspx?recipeId=1234" class="rsSlideTitle button">View Recipe</a>

                </div>
            </div>

        </div>

        <div class="rsContent">
            <a class="rsImg" href="Upload\popchoclatecakes.jpg"></a>
            <i class="rsTmb">Greek Chicken Pasta1</i>

            <!-- Slide Caption -->
            <div class="SlideTitleContainer rsABlock">
                <div class="CaptionAlignment">
                    <div class="rsSlideTitle tags">
                        <ul>
                            <li>Baking</li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>


                    <h2><a href="Recipie_details.aspx?recipeId=1234" class="rsSlideTitle title">Greek Chicken Pasta</a></h2>
                    <div class="rsSlideTitle details">
                        <ul>
                            <li><i class="fa fa-cutlery"></i>4 Servings</li>
                            <li><i class="fa fa-clock-o"></i>45 minutes</li>
                            <li><i class="fa fa-user"></i>by <a href="#">Chef Khan</a></li>
                        </ul>
                    </div>

                    <a href="Recipie_details.aspx?recipeId=1234" class="rsSlideTitle button">View Recipe</a>

                </div>
            </div>

        </div>

        <!-- Slide #2 - Chocolate Cake Pops -->
        <div class="rsContent">
            <a class="rsImg" href="Upload\popchoclatecakes.jpg"></a>
            <i class="rsTmb">Chocolate Cake Pops</i>

            <!-- Slide Caption -->
            <div class="SlideTitleContainer rsABlock">
                <div class="CaptionAlignment">
                    <div class="rsSlideTitle tags">
                        <ul>
                            <li>Desserts</li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>

                    <h2><a href='<%# "Recipie_details.aspx?recipeId=" + Eval("recipe_id") %>' class="rsSlideTitle title">Chocolate Cake Pops</a></h2>

                    <div class="rsSlideTitle details">
                        <ul>
                            <li><i class="fa fa-cutlery"></i>Serves 12</li>
                            <li><i class="fa fa-clock-o"></i>45 minutes</li>
                            <li><i class="fa fa-user"></i>by <a href="#">Chef Patel</a></li>
                        </ul>
                    </div>

                    <a href='<%# "Recipie_details.aspx?recipeId=" + Eval("recipe_id") %>' class="rsSlideTitle button">View Recipe</a>

                </div>
            </div>
        </div>

        <!-- Slide #3 - Masala Dosa -->
        <div class="rsContent">
            <a class="rsImg" href="Upload\masaladosa.jpg"></a>
            <i class="rsTmb">Masala Dosa</i>

            <!-- Slide Caption -->
            <div class="SlideTitleContainer rsABlock">
                <div class="CaptionAlignment">
                    <div class="rsSlideTitle tags">
                        <ul>
                            <li>Curry</li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>


                    <h2><a href='<%# "Recipie_details.aspx?recipeId=" + Eval("recipe_id") %>' class="rsSlideTitle title">Masala Dosa</a></h2>
                    <div class="rsSlideTitle details">
                        <ul>
                            <li><i class="fa fa-cutlery"></i>4 Servings</li>
                            <li><i class="fa fa-clock-o"></i>60 minutes</li>
                            <li><i class="fa fa-user"></i>by <a href="#">Chef Rao</a></li>
                        </ul>
                    </div>

                    <a href='<%# "Recipie_details.aspx?recipeId=" + Eval("recipe_id") %>' class="rsSlideTitle button">View Recipe</a>

                </div>
            </div>
        </div>

        <!-- Slide #4 - Veg Spring Rolls -->
        <div class="rsContent">
            <a class="rsImg" href="Upload\vegspringrolls.jpg"></a>
            <i class="rsTmb">Veg Spring Rolls</i>

            <!-- Slide Caption -->
            <div class="SlideTitleContainer rsABlock">
                <div class="CaptionAlignment">
                    <div class="rsSlideTitle tags">
                        <ul>
                            <li>Appetizers</li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>

                    <h2><a href='<%# "Recipie_details.aspx?recipeId=" + Eval("recipe_id") %>' class="rsSlideTitle title">Veg Spring Roll</a></h2>

                    <div class="rsSlideTitle details">
                        <ul>
                            <li><i class="fa fa-cutlery"></i>Makes 10 spring rolls</li>
                            <li><i class="fa fa-clock-o"></i>45 minutes</li>
                            <li><i class="fa fa-user"></i>by <a href="#">Chef Li</a></li>
                        </ul>
                    </div>

                    <a href="Recipie_details.aspx?recipeId=12345" class="rsSlideTitle button">View Recipe</a>
                    <a href="https://google.com" class="rsSlideTitle button">View Recipe2</a>

                </div>
            </div>
        </div>

        <!-- Slide #5 -->
        <div class="rsContent">
            <a class="rsImg" href="images/sliderA_05.jpg"></a>
            <i class="rsTmb">Farmhouse Vegetable
                <br>
                And Barley Soup</i>

            <!-- Slide Caption -->
            <div class="SlideTitleContainer rsABlock">
                <div class="CaptionAlignment">
                    <div class="rsSlideTitle tags">
                        <ul>
                            <li>Soups</li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>

                    <h2 class="rsSlideTitle title"><a href="recipe-page-1.html">Farmhouse Vegetable And Barley Soup</a></h2>

                    <div class="rsSlideTitle details">
                        <ul>
                            <li><i class="fa fa-cutlery"></i>4 Servings</li>
                            <li><i class="fa fa-clock-o"></i>1 Hr 30 Min</li>
                            <li><i class="fa fa-user"></i>by <a href="#">Sandra Fortin</a></li>
                        </ul>
                    </div>

                    <a href="recipe-page-1.html" class="rsSlideTitle button">View Recipe</a>
                </div>
            </div>

        </div>

    </div>


    <!-- Content
================================================== -->
    <div class="container">

        <!-- Masonry -->
        <div class="sixteen columns">

            <!-- Headline -->
            <h3 class="headline">Latest Recipes</h3>
            <span class="line rb margin-bottom-35"></span>
            <div class="clearfix"></div>

            <!-- Isotope -->
            <div class="isotope">



                <asp:ListView ID="Lv_Recipies" runat="server">
                    <%-- <LayoutTemplate>
                        <div>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </div>
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <p>No recipe found. Kindly search for another recipe or add a new one.</p>
                    </EmptyDataTemplate>--%>
                    <ItemTemplate>
                        <div class="four recipe-box columns">
                            <!-- Thumbnail -->
                            <div class="thumbnail-holder">
                                <img src='<%# Eval("image") %>' alt="" width="400" height="350" />
                                <!-- Set fixed width and height -->
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



        <!-- Container / End -->

        <div class="margin-top-5"></div>
    </div>


    <!-- Wrapper / End -->
</asp:Content>
