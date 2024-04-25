<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="submitrecipe.aspx.cs" Inherits="OnlineRecipeSharing.WebForm2" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Titlebar
================================================== -->
    <section id="titlebar">
        <!-- Container -->
        <div class="container">

            <div class="eight columns">
                <h2>Submit Recipe</h2>
            </div>

            <div class="eight columns">
                <nav id="breadcrumbs">
                    <ul>
                        <li>You are here:</li>
                        <li><a href="#">Home</a></li>

                        <li>Submit Recipe</li>
                    </ul>
                </nav>
            </div>
            <link href="Content/bootstrap-theme.css" rel="stylesheet" />
        </div>
        <!-- Container / End -->
    </section>


    <!-- Content
================================================== -->
    <div class="container">
        <div class="sixteen columns">
            <div class="submit-recipe-form">


                <!-- Recipe Title -->
                <h4>Recipe Title</h4>




                <div class="title">
                    <%--<input class="search-field" type="text" placeholder="" value=""/>--%>
                    <asp:TextBox ID="RecipeTitle" runat="server"></asp:TextBox>
                </div>

                <div class="margin-top-25"></div>

                <!-- ChooseCategory -->
                <div class="select">
                    <h4>ChooseCategory</h4>

                    <%--<dropdownlist>Choose Category</dropdownlist>--%>
                    <asp:DropDownList ID="ChooseCategory" runat="server" Class="chosen-select-no-single">
                        <%--        <asp:ListItem Value="1">All</asp:ListItem>
                        <asp:ListItem Value="2">Vegetarian</asp:ListItem>
                        <asp:ListItem Value="3">non-veg</asp:ListItem>
                        <asp:ListItem Value="4">vegan</asp:ListItem>--%>
                    </asp:DropDownList>


                </div>
                <div class="select">
                    <h4>Select MealType</h4>

                    <%--<dropdownlist></dropdownlist>--%>
                    <asp:DropDownList ID="DDL_Meal" runat="server" Class="chosen-select-no-single">
                        <%--<asp:ListItem Value="1">All</asp:ListItem>
                        <asp:ListItem Value="2">Breakfast</asp:ListItem>
                        <asp:ListItem Value="3">Lunch</asp:ListItem>
                        <asp:ListItem Value="4">Appetizers</asp:ListItem>

                        <asp:ListItem Value="5">Desserts</asp:ListItem>
                        <asp:ListItem Value="6">Main Meal</asp:ListItem>--%>
                    </asp:DropDownList>

                </div>


                <div class="margin-top-25"></div>


                <!-- Short Summary -->
                <h4>ShortSummary</h4>
                <%--                <textarea class="WYSIWYG" name="summary" cols="40" rows="3" id="summary" spellcheck="true"></textarea>--%>
                <asp:TextBox ID="ShortSummary" class="WYSIWYG" TextMode="MultiLine" runat="server"></asp:TextBox>

                <div class="margin-top-25"></div>


                <!-- Upload Photos -->
                <h4>Upload your photos</h4>

                <ul class="recipe-gallery">
                    <li>No photos uploaded yet</li>
                </ul>
                <asp:FileUpload ID="FL_img" runat="server" />

                <%-- <label class="upload-btn">
                    <input type="file" multiple />
                    <i class="fa fa-upload"></i>Upload
                </label>--%>


                <div class="clearfxix"></div>
                <div class="margin-top-15"></div>


                <!-- Ingredients -->
                <fieldset class="addrecipe-cont" name="ingredients">
                    <h4>Ingredients:</h4>
                    <asp:TextBox ID="ingredients" TextMode="MultiLine" runat="server"></asp:TextBox>
                </fieldset>


                <div class="margin-top-25"></div>


                <!-- Directions -->
                <h4>Directions</h4>
                <%--<textarea class="WYSIWYG" name="directions" cols="40" rows="3" id="directions" spellcheck="true"></textarea>--%>
                <asp:TextBox ID="directions" TextMode="MultiLine" runat="server"></asp:TextBox>

            </div>

            <div class="margin-top-25 clearfix"></div>


            <!-- Additional Informations -->
            <h4>Additional Informations</h4>

            <fieldset class="additional-info">
                <table>

                    <tr class="ingredients-cont">
                        <td class="label">
                            <label for="4">Proportion</label>
                        </td>
                        <td>
                            <%--<input id="4" type="text" /></td>--%>
                            <asp:TextBox ID="Proportion" runat="server"></asp:TextBox>
                    </tr>

                    <tr class="ingredients-cont">
                        <td class="label">
                            <label for="1">Preparation Time</label></td>
                        <td>
                            <asp:TextBox ID="PreparationTime" runat="server"></asp:TextBox>
                        </td>

                    </tr>

                    <tr class="ingredients-cont">
                        <td class="label">
                            <label for="2">Cooking Time</label></td>
                        <td>
                            <%--<input id="2" type="text" /></td>--%>
                            <asp:TextBox ID="CookingTime" runat="server"></asp:TextBox>
                    </tr>


                </table>

            </fieldset>

            <div class="margin-top-25"></div>
            <label for="2">author</label>
            <asp:TextBox ID="author" runat="server"></asp:TextBox>
            <div class="margin-top-25"></div>
            <label for="2">tags</label>
            <asp:TextBox ID="tags" runat="server"></asp:TextBox>

            <div class="margin-top-25"></div>
            <label for="2">keywords</label>
            <asp:TextBox ID="keywords" runat="server"></asp:TextBox>


            <!-- Nutrition Facts -->
            <h4>Nutrition Facts</h4>

            <fieldset class="additional-info">
                <table>

                    <tr class="ingredients-cont">
                        <td class="label">
                            <label for="5">Calories</label></td>
                        <td>
                            <%-- <input id="5" type="text" /></td>--%>
                            <asp:TextBox ID="Calories" runat="server"></asp:TextBox>
                    </tr>

                    <tr class="ingredients-cont">
                        <td class="label">
                            <label for="6">TotalCarbohydrate</label></td>
                        <td>
                            <%--<input id="6" type="text" /></td>--%>
                            <asp:TextBox ID="TotalCarbohydrate" runat="server"></asp:TextBox>
                    </tr>



                    <tr class="ingredients-cont">
                        <td class="label">
                            <label for="8">Protein</label></td>
                        <td>
                            <%-- <input id="8" type="text" /></td>--%>
                            <asp:TextBox ID="Protein" runat="server"></asp:TextBox>
                    </tr>



                </table>
            </fieldset>

            <div class="margin-top-30"></div>
           


            <%--  <a href="#" class="button color big">Submit Recipe</a>--%>
            <asp:Button ID="SubmitRecipe" class="button color big" runat="server" OnClick="BtnSubmit_Click" Text="Submit" />
        </div>
         <asp:Literal ID="LitPageTitle" runat="server"></asp:Literal>
    </div>

    <!-- Container / End -->


    <div class="margin-top-50"></div>


    <!-- Wrapper / End -->

</asp:Content>
