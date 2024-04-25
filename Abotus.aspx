<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Abotus.aspx.cs" Inherits="OnlineRecipeSharing.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>About Us - Flavour Fusion</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <style>
        /* Add your custom styles here */
        .jumbotron {
            background-image: url('background-image.jpg'); /* Add your background image */
            background-size: cover;
            color: #fff;
            text-align: center;
            padding: 100px 0;
        }
    </style>
</head>

<body>

    <!-- Navigation Bar -->
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#"></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          
        </div>
    </nav>

    <!-- Page Content -->
    <div class="container">
        <div class="jumbotron">
            <h1 class="display-4">Welcome to Flavour Fusion</h1>
            <p class="lead">Discover mouthwatering recipes, share culinary experiences, and connect with like-minded
                individuals from around the world.</p>
        </div>

        <!-- Our Story -->
        <section id="our-story" class="my-5">
            <div class="row">
                <div class="col-lg-6">
                    <h2 class="mb-4">Our Story</h2>
                    <p>Our website, Flavour Fusion, was born out of a shared love for food and a desire to connect with
                        fellow food enthusiasts. We started this platform to create a space where people can discover
                        mouthwatering recipes, share culinary experiences, and connect with like-minded individuals from
                        around the world. Our passion for cooking and exploring diverse cuisines drives us to
                        continuously innovate and inspire others in the kitchen.</p>
                </div>
                <div class="col-lg-6">
                    <!-- Insert an image related to your story here -->
                    <img src="images/bg/about.png" class="img-fluid" alt="Our Story">
                </div>
            </div>
        </section>

        <!-- Values -->
        <section id="values" class="my-5">
            <div class="row">
                <div class="col-lg-6">
                    <!-- Insert an image related to your values here -->
                    <img src="images/exp.png"" class="img-fluid" alt="Our Values">
                </div>
                <div class="col-lg-6">
                    <h2 class="mb-4">Our Values</h2>
                    <p>At Flavour Fusion, we believe in the power of food to bring people together, ignite creativity,
                        and evoke cherished memories. We are committed to fostering a vibrant community of food
                        enthusiasts, where everyone feels welcome to share their culinary journey and learn from one
                        another. What makes our website unique is our dedication to curating a diverse collection of
                        recipes, providing valuable resources, and fostering meaningful connections among our users.
                    </p>
                </div>
            </div>
        </section>

        <!-- Mission -->
        <section id="mission" class="my-5">
            <div class="row">
                <div class="col-lg-6">
                    <h2 class="mb-4">Our Mission</h2>
                    <p>Our mission is to revolutionize the way people experience food by providing a platform that
                        fosters creativity, community, and culinary exploration. We aim to inspire individuals of all
                        skill levels to unleash their creativity in the kitchen, explore new cuisines, and create
                        unforgettable dishes. Through Flavour Fusion, we hope to empower our users to discover their
                        passion for cooking and embark on a delicious culinary journey.</p>
                </div>
                <div class="col-lg-6">
                    <!-- Insert an image related to your mission here -->
                    <img src="images/blog-img/video-1.jpg" class="img-fluid" alt="Our Mission">
                </div>
            </div>
        </section>

       <!-- Connect with Audience -->
<section id="connect" class="my-5">
    <h2 class="text-center mb-5">Connect with Us</h2>
    <div class="row">
        <div class="col-lg-6">
            <!-- Insert an image related to connecting with your audience here -->
            <img src="images/blog-img/recipe-13.jpg" class="img-fluid" alt="Connect with Us">
        </div>
        <div class="col-lg-6">
            <p class="lead">Our readers are passionate about discovering new recipes, experimenting with
                ingredients, and learning cooking techniques from around the world. They seek inspiration for
                everyday meals, special occasions, and culinary adventures. Whether it's quick and easy
                weeknight dinners, indulgent desserts, or international cuisines, our audience is eager to
                explore and try new dishes.</p>
            <!-- Add your call-to-action button here -->
            <div class="text-center">
                <!-- Replace the "#" with the URLs of your social media profiles -->
                <a href="https://www.facebook.com/YourPage" target="_blank" class="btn btn-primary btn-lg mr-3">Facebook</a>
                <a href="https://www.instagram.com/YourPage" target="_blank" class="btn btn-primary btn-lg mr-3">Instagram</a>
                <a href="https://twitter.com/YourPage" target="_blank" class="btn btn-primary btn-lg mr-3">Twitter</a>
                <a href="https://www.pinterest.com/YourPage" target="_blank" class="btn btn-primary btn-lg">Pinterest</a>
            </div>
        </div>
    </div>
</section>

    </div>

    

    <!-- Bootstrap JS and jQuery -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>

</html>

</asp:Content>
