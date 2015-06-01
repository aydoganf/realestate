<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>



<!--[if IE 7]>
<html class="ie ie7" lang="en-US">
<![endif]-->
<!--[if IE 8]>
<html class="ie ie8" lang="en-US">
<![endif]-->
<!--[if !(IE 7) | !(IE 8)  ]><!-->
<html lang="en-US">
<!--<![endif]-->

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="author" content="Aviators, http://themes.byaviators.com">

    <link rel="shortcut icon" href="/assets/img/favicon.png" type="image/png">

    <!--[if lt IE 9]>
    <script src="/assets/js/html5.js" type="text/javascript"></script>
    <![endif]-->

    <meta name='robots' content='noindex,nofollow' />

    <link rel='stylesheet' id='font-css'
        href='http://fonts.googleapis.com/css?family=Open+Sans%3A400%2C700%2C300&#038;subset=latin%2Clatin-ext&#038;ver=3.6'
        type='text/css' media='all' />



    <link rel='stylesheet' id='revolution-fullwidth' href='/assets/libraries/rs-plugin/css/fullwidth.css' type='text/css' media='all' />
    <link rel='stylesheet' id='revolution-settings' href='/assets/libraries/rs-plugin/css/settings.css' type='text/css' media='all' />
    <link rel='stylesheet' id='bootstrap-css' href='/assets/libraries/bootstrap/css/bootstrap.min.css' type='text/css' media='all' />
    <link rel='stylesheet' id='bootstrap-responsive-css' href='/assets/libraries/bootstrap/css/bootstrap-responsive.min.css' type='text/css' media='all' />

    <link rel='stylesheet' id='pictopro-normal-css' href='/assets/icons/pictopro-normal/style.css' type='text/css' media='all' />
    <link rel='stylesheet' id='justvector-web-font-css' href='/assets/icons/justvector-web-font/stylesheet.css' type='text/css' media='all' />
    <link rel='stylesheet' id='chosen-css' href='/assets/libraries/chosen/chosen.css' type='text/css' media='all' />

    <link rel='stylesheet' id='aviators-css' href='/assets/css/jquery.bxslider.css' type='text/css' media='all' />
    <link rel='stylesheet' id='properta-css' href='/assets/css/properta.css' type='text/css' media='all' />

    <script type='text/javascript' src='http://code.jquery.com/jquery-1.7.2.min.js'></script>
    <script type='text/javascript' src='/assets/js/aviators-settings.js'></script>
    <script type='text/javascript' src='/assets/libraries/chosen/chosen.jquery.min.js'></script>
    <script type='text/javascript' src='/assets/libraries/rs-plugin/js/jquery.themepunch.revolution.min.js'></script>
    <script type='text/javascript' src='/assets/libraries/rs-plugin/js/jquery.themepunch.plugins.min.js'></script>

    <title>Properta | Real Estate Template</title>
</head>

<body class="home page page-template">

    <div class="top">
        <div class="container">
            <div class="top-inner inverted">
                <div class="header clearfix">


                    <div class="branding pull-left">
                        <div class="logo">
                            <a href="../default.htm" title="Home">
                                <img src="/assets/img/logo.png" alt="Home">
                            </a>
                        </div>
                        <!-- /.logo -->

                        <div class="site-name">
                            <a href="../default.htm" title="Home" class="brand">Properta
                            </a>
                        </div>
                        <!-- /.site-name -->
                    </div>

                    <div class="contact-top">
                        <ul class="menu nav">
                            <li class="first leaf facebook">
                                <a href="http://www.facebook.com" class="facebook"><i>F</i></a>
                            </li>

                            <li class="leaf flickr"><a href="http://www.flickr.com" class="flickr"><i>n</i></a></li>

                            <li class="leaf google-plus"><a href="http://plus.google.com" class="google"><i>g</i></a></li>

                            <li class="leaf linkedin"><a href="htp://linkedin.com" class="linkedin"><i>l</i></a></li>

                            <li class="leaf twitter"><a href="http://www.twitter.com" class="twitter"><i>T</i></a></li>

                            <li class="last leaf vimeo"><a href="http://vimeo.com" class="vimeo"><i>v</i></a></li>
                        </ul>
                    </div>

                    <div class="user-area pull-right">
                        <div class="menu-anonymous-container">
                            <ul id="menu-anonymous" class="nav nav-pills">
                                <li class="menu-item"><a href="../register.html">Register</a></li>
                                <li class="menu-item"><a href="../login.html">Login</a></li>
                            </ul>
                        </div>
                    </div>
                    <!-- /.user-area -->
                </div>
                <!-- /.header -->
                <div class="navigation navbar clearfix">
                    <div class="pull-left">
                        <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>

                        <div class="nav-collapse collapse">
                            <ul id="menu-main" class="nav">
                                <li class="menu-item active-menu-item menu-item-parent">
                                    <a href="../default.htm">Homepage</a>
                                    <ul class="sub-menu">
                                        <li class="menu-item"><a href="../frontpage-slider.html">Revolution slider</a></li>
                                        <li class="menu-item"><a href="../frontpage-map-vertical.html.html">Homepage - Vertical filter</a></li>
                                        <li class="menu-item"><a href="../default.htm">Homepage - Horizontal filter</a></li>
                                    </ul>
                                </li>

                                <li class="menu-item menu-item-parent">
                                    <a href="#">Listings</a>

                                    <ul class="sub-menu">
                                        <li class="menu-item"><a href="../properties/default.htm">Properties listing</a></li>
                                        <li class="menu-item"><a href="property-detail.html">Property detail</a></li>

                                        <li class="menu-item"><a href="../agencies/default.htm">Agencies listing</a></li>
                                        <li class="menu-item"><a href="../agencies/agency-detail.html">Agencies detail</a></li>

                                        <li class="menu-item"><a href="../agents/default.htm">Agents listing</a></li>
                                        <li class="menu-item"><a href="../agents/agent-detail.html">Agent detail</a></li>

                                        <li class="menu-item"><a href="../register.html">Register</a></li>
                                        <li class="menu-item"><a href="../login.html">Login</a></li>
                                    </ul>
                                </li>

                                <li class="menu-item menu-item-parent">
                                    <a href="#">Pages</a>
                                    <ul class="sub-menu">
                                        <li class="menu-item"><a href="../404.html">404 page</a></li>
                                        <li class="menu-item"><a href="../faq.html">FAQ page</a></li>
                                        <li class="menu-item"><a href="../pricing.html">Pricing</a></li>
                                    </ul>
                                </li>

                                <li class="menu-item menu-item-parent">
                                    <a href="#">Submissions</a>
                                    <ul class="sub-menu">
                                        <li class="menu-item"><a href="../submissions/default.htm">List submissions</a></li>
                                        <li class="menu-item"><a href="../submissions/add.html">Add submission</a></li>
                                        <li class="menu-item"><a href="../submissions/edit.html">Edit submission</a></li>
                                    </ul>
                                </li>

                                <li class="menu-item menu-item-parent">
                                    <a href="#">Templates</a>
                                    <ul class="sub-menu">
                                        <li class="menu-item"><a href="../templates/default-left.html">Left sidebar</a></li>
                                        <li class="menu-item"><a href="../templates/default-right.html">Right sidebar</a></li>
                                        <li class="menu-item"><a href="../templates/default-full.html">Full width</a></li>
                                    </ul>
                                </li>

                                <li class="menu-item">
                                    <a href="../contact.html">Contact</a>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <!-- /.pull-right -->

                </div>

                <div class="breadcrumb pull-left">
                    <!-- Breadcrumb NavXT 4.4.0 -->
                    <a title="Go to Properta." href="../default.htm" class="home">Properta</a> &gt; Page
                </div>

                <!-- /.breadcrumb -->
            </div>
        </div>
    </div>

    <div id="content" class="clearfix">
        <!-- /.map-wrapper -->
        <div class="container">
            <div class="row">

                <div class="sidebar span3">
                    <h2>Search Properties</h2>

                    <div class="property-filter widget">
                        <div class="content">
                            <form method="get" action="javascript:void(0);">
                                <div class="location control-group">
                                    <label class="control-label">
                                        Location
                                    </label>

                                    <div class="controls">
                                        <select name="filter_location">
                                            <option>-</option>
                                            <option>Barney Circle</option>
                                            <option>Benning</option>
                                            <option>Benning Heights</option>
                                            <option>Benning Ridge</option>
                                            <option>Burrville</option>
                                            <option>Capitol Hill</option>
                                            <option>Capitol View</option>
                                            <option>Central Northeast</option>
                                            <option>Civic Betterment</option>
                                            <option>Judiciary Square</option>
                                            <option>Kingman Park</option>
                                            <option>Navy Yard</option>
                                            <option>Near Northeast</option>
                                            <option>Spring Valley</option>
                                            <option>Sursum Corda</option>
                                            <option>Swampoodle</option>
                                        </select>
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->

                                <div class="type control-group">
                                    <label class="control-label">
                                        Type
                                    </label>

                                    <div class="controls">
                                        <select name="filter_type">
                                            <option>-</option>
                                            <option>Apartment</option>
                                            <option>Building Area</option>
                                            <option>Condo</option>
                                            <option>Cottage</option>
                                            <option>Family House</option>
                                            <option>Single Home</option>
                                            <option>Villa</option>
                                        </select>
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->


                                <div class="rent control-group">
                                    <div class="controls">
                                        <label class="checkbox">
                                            <input type="checkbox" value="rent">
                                            Rent
                                        </label>
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->

                                <div class="sale control-group">
                                    <div class="controls">
                                        <label class="checkbox">
                                            <input type="checkbox" value="sale">
                                            Sale
                                        </label>
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->

                                <div class="price-from control-group">
                                    <label class="control-label">
                                        Price From
                                    </label>

                                    <div class="controls">
                                        <select name="filter_price_from">
                                            <option value="">-</option>
                                            <option value="1000">1,000 €</option>
                                            <option value="20000">20,000 €</option>
                                            <option value="50000">50,000 €</option>
                                            <option value="100000">100,000 €</option>
                                        </select>
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->

                                <div class="price-to control-group">
                                    <label class="control-label">
                                        Price To
                                    </label>

                                    <div class="controls">
                                        <select name="filter_price_to">
                                            <option value="">-</option>
                                            <option value="1000">1,000 €</option>
                                            <option value="20000">20,000 €</option>
                                            <option value="50000">50,000 €</option>
                                            <option value="100000">100,000 €</option>
                                        </select>
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->

                                <div class="area-from control-group">
                                    <label class="control-label">
                                        Area From
                                    </label>

                                    <div class="controls">
                                        <input type="text" value="" name="filter_area_from">
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->

                                <div class="area-to control-group">
                                    <label class="control-label">
                                        Area To
                                    </label>

                                    <div class="controls">
                                        <input type="text" value="" name="filter_area_to">
                                    </div>
                                    <!-- /.controls -->
                                </div>
                                <!-- /.control-group -->

                                <div class="form-actions">
                                    <button class="btn btn-primary btn-large">Filter now!</button>
                                </div>
                                <!-- /.form-actions -->
                            </form>
                        </div>
                        <!-- /.content -->
                    </div>
                    <!-- /.property-filter -->                    
                </div>
                <!-- /#sidebar -->

                <div id="main" class="span9 property-listing">

                    <h1 class="page-header">Properties</h1>

                    <div class="clearfix">

                        <div class="properties-rows">
                            <div class="row">
                                <div class="property span9">
                                    <div class="row">
                                        <div class="span3">
                                            <div class="image">
                                                <div class="content">
                                                    <a href="property-detail.html">
                                                        <img width="570" height="425" src="/assets/img/property/19.jpg" class="thumbnail-image" alt="19">
                                                    </a>
                                                </div>
                                                <!-- /.content -->
                                            </div>
                                            <!-- /.image -->
                                        </div>

                                        <div class="body span6">
                                            <div class="title-price row">
                                                <div class="title span4">
                                                    <h2><a href="property-detail.html">643 37th Ave</a>
                                                    </h2>
                                                </div>
                                                <!-- /.title -->

                                                <div class="price">
                                                    Contact us
                                                </div>
                                                <!-- /.price -->
                                            </div>
                                            <!-- /.title -->

                                            <div class="location">Burrville</div>
                                            <!-- /.location -->

                                            <div class="body">
                                                <p>
                                                    Quisque non dictum eros. Praesent porta vehicula arcu eu ornare. Donec id egestas arcu. Suspendisse
                    auctor condimentum ligula ultricies cursus. Vestibulum vel orci vel lacus rhoncus sagittis sed vitae
                    ...
                                                </p>
                                            </div>
                                            <!-- /.body -->

                                            <div class="property-info clearfix">
                                                <div class="area">
                                                    <i class="icon icon-normal-cursor-scale-up"></i>
                                                    800m<sup>2</sup>
                                                </div>
                                                <!-- /.area -->

                                                <div class="bedrooms">
                                                    <i class="icon icon-normal-bed"></i>
                                                    2
                                                </div>
                                                <!-- /.bedrooms -->


                                                <div class="more-info">
                                                    <a href="property-detail.html">More Info<i
                                                        class="icon icon-normal-right-arrow-circle"></i></a>
                                                </div>
                                            </div>
                                            <!-- /.info -->
                                        </div>
                                        <!-- /.body -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.property -->
                                <div class="property span9">
                                    <div class="row">
                                        <div class="span3">
                                            <div class="image">
                                                <div class="content">
                                                    <a href="property-detail.html">
                                                        <img width="570" height="425"
                                                            src="/assets/img/property/20.jpg"
                                                            class="thumbnail-image" alt="20">
                                                    </a>
                                                </div>
                                                <!-- /.content -->
                                            </div>
                                            <!-- /.image -->
                                        </div>

                                        <div class="body span6">
                                            <div class="title-price row">
                                                <div class="title span4">
                                                    <h2><a href="property-detail.html">2459
                            Tilden St</a></h2>
                                                </div>
                                                <!-- /.title -->

                                                <div class="price">
                                                    500 € <span class="suffix">/ per month</span>
                                                </div>
                                                <!-- /.price -->
                                            </div>
                                            <!-- /.title -->

                                            <div class="location">Judiciary Square</div>
                                            <!-- /.location -->

                                            <div class="body">
                                                <p>
                                                    Nam convallis consequat dui. Suspendisse sit amet augue nunc. Quisque eget ligula quis diam viverra
                    volutpat. Aliquam nec neque a metus blandit lobortis vitae vitae quam. Fusce ultricies molestie veli
                    ...
                                                </p>
                                            </div>
                                            <!-- /.body -->

                                            <div class="property-info clearfix">
                                                <div class="area">
                                                    <i class="icon icon-normal-cursor-scale-up"></i>
                                                    1030m<sup>2</sup>
                                                </div>
                                                <!-- /.area -->

                                                <div class="bedrooms">
                                                    <i class="icon icon-normal-bed"></i>
                                                    12
                                                </div>
                                                <!-- /.bedrooms -->

                                                <div class="bathrooms">
                                                    <i class="icon icon-normal-shower"></i>
                                                    6
                                                </div>
                                                <!-- /.bathrooms -->

                                                <div class="more-info">
                                                    <a href="property-detail.html">More Info<i
                                                        class="icon icon-normal-right-arrow-circle"></i></a>
                                                </div>
                                            </div>
                                            <!-- /.info -->
                                        </div>
                                        <!-- /.body -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.property -->
                                <div class="property span9">
                                    <div class="row">
                                        <div class="span3">
                                            <div class="image">
                                                <div class="content">
                                                    <a href="property-detail.html">
                                                        <img width="570" height="425"
                                                            src="/assets/img/property/17.jpg"
                                                            class="thumbnail-image" alt="17">
                                                    </a>
                                                </div>
                                                <!-- /.content -->
                                            </div>
                                            <!-- /.image -->
                                        </div>

                                        <div class="body span6">
                                            <div class="title-price row">
                                                <div class="title span4">
                                                    <h2><a href="property-detail.html">677
                            Cottage Terrace</a></h2>
                                                </div>
                                                <!-- /.title -->

                                                <div class="price">
                                                    59,600 €
                                                </div>
                                                <!-- /.price -->
                                            </div>
                                            <!-- /.title -->

                                            <div class="location">Spring Valley</div>
                                            <!-- /.location -->

                                            <div class="body">
                                                <p>
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur et risus vitae lectus dapibus
                    sagittis sit amet eu eros. Pellentesque accumsan mi nec tristique vehicula. Suspendisse potenti.
                    Cras f ...
                                                </p>
                                            </div>
                                            <!-- /.body -->

                                            <div class="property-info clearfix">
                                                <div class="area">
                                                    <i class="icon icon-normal-cursor-scale-up"></i>
                                                    650m<sup>2</sup>
                                                </div>
                                                <!-- /.area -->

                                                <div class="bedrooms">
                                                    <i class="icon icon-normal-bed"></i>
                                                    1
                                                </div>
                                                <!-- /.bedrooms -->

                                                <div class="bathrooms">
                                                    <i class="icon icon-normal-shower"></i>
                                                    1
                                                </div>
                                                <!-- /.bathrooms -->

                                                <div class="more-info">
                                                    <a href="property-detail.html">More
                        Info<i class="icon icon-normal-right-arrow-circle"></i></a>
                                                </div>
                                            </div>
                                            <!-- /.info -->
                                        </div>
                                        <!-- /.body -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.property -->
                                <div class="property span9">
                                    <div class="row">
                                        <div class="span3">
                                            <div class="image">
                                                <div class="content">
                                                    <a href="property-detail.html">
                                                        <img width="570" height="425"
                                                            src="/assets/img/property/21.jpg"
                                                            class="thumbnail-image" alt="21">
                                                    </a>
                                                </div>
                                                <!-- /.content -->
                                            </div>
                                            <!-- /.image -->
                                        </div>

                                        <div class="body span6">
                                            <div class="title-price row">
                                                <div class="title span4">
                                                    <h2><a href="property-detail.html">126 31st
                            Pl NE</a></h2>
                                                </div>
                                                <!-- /.title -->

                                                <div class="price">
                                                    48,000 €
                                                </div>
                                                <!-- /.price -->
                                            </div>
                                            <!-- /.title -->

                                            <div class="location">Civic Betterment</div>
                                            <!-- /.location -->

                                            <div class="body">
                                                <p>
                                                    Etiam ut est in odio tempor tincidunt vitae sed sem. Nullam dignissim lorem et erat dictum, cursus
                    posuere lorem pretium. In leo elit, luctus vel vehicula vel, accumsan quis velit. Ut sagittis
                    commodo ...
                                                </p>
                                            </div>
                                            <!-- /.body -->

                                            <div class="property-info clearfix">
                                                <div class="area">
                                                    <i class="icon icon-normal-cursor-scale-up"></i>
                                                    950m<sup>2</sup>
                                                </div>
                                                <!-- /.area -->

                                                <div class="bedrooms">
                                                    <i class="icon icon-normal-bed"></i>
                                                    2
                                                </div>
                                                <!-- /.bedrooms -->

                                                <div class="bathrooms">
                                                    <i class="icon icon-normal-shower"></i>
                                                    3
                                                </div>
                                                <!-- /.bathrooms -->

                                                <div class="more-info">
                                                    <a href="property-detail.html">More Info<i
                                                        class="icon icon-normal-right-arrow-circle"></i></a>
                                                </div>
                                            </div>
                                            <!-- /.info -->
                                        </div>
                                        <!-- /.body -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.property -->
                                <div class="property span9">
                                    <div class="row">
                                        <div class="span3">
                                            <div class="image">
                                                <div class="content">
                                                    <a href="property-detail.html">
                                                        <img width="570" height="425"
                                                            src="/assets/img/property/15.jpg"
                                                            class="thumbnail-image" alt="15">
                                                    </a>
                                                </div>
                                                <!-- /.content -->
                                            </div>
                                            <!-- /.image -->
                                        </div>

                                        <div class="body span6">
                                            <div class="title-price row">
                                                <div class="title span4">
                                                    <h2><a href="property-detail.html">Carlton Ave
                            NE</a></h2>
                                                </div>
                                                <!-- /.title -->

                                                <div class="price">
                                                    87,000 €
                                                </div>
                                                <!-- /.price -->
                                            </div>
                                            <!-- /.title -->

                                            <div class="location">Capitol Hill</div>
                                            <!-- /.location -->

                                            <div class="body">
                                                <p>
                                                    Quisque non dictum eros. Praesent porta vehicula arcu eu ornare. Donec id egestas arcu. Suspendisse
                    auctor condimentum ligula ultricies cursus. Vestibulum vel orci vel lacus rhoncus sagittis sed vitae
                    ...
                                                </p>
                                            </div>
                                            <!-- /.body -->

                                            <div class="property-info clearfix">
                                                <div class="area">
                                                    <i class="icon icon-normal-cursor-scale-up"></i>
                                                    800m<sup>2</sup>
                                                </div>
                                                <!-- /.area -->

                                                <div class="bedrooms">
                                                    <i class="icon icon-normal-bed"></i>
                                                    2
                                                </div>
                                                <!-- /.bedrooms -->

                                                <div class="bathrooms">
                                                    <i class="icon icon-normal-shower"></i>
                                                    3
                                                </div>
                                                <!-- /.bathrooms -->

                                                <div class="more-info">
                                                    <a href="property-detail.html">More Info<i
                                                        class="icon icon-normal-right-arrow-circle"></i></a>
                                                </div>
                                            </div>
                                            <!-- /.info -->
                                        </div>
                                        <!-- /.body -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.property -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.properties-grid -->

                        <div class="pagination pagination-centered">
                            <ul class="unstyled">
                                <li><a href="#">First</a></li>
                                <li><a href="#">Previous</a></li>
                                <li><a href="#">1</a></li>
                                <li><a href="#">2</a></li>
                                <li class="active"><a href="#">3</a></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#">5</a></li>
                                <li><a href="#">Next</a></li>
                                <li><a href="#">Last</a></li>
                            </ul>
                        </div>


                    </div>

                    <!-- /#main -->

                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->

        </div>
    </div>
    <!-- /#content -->
    <div id="footer-wrapper">

        <div id="footer-top">
            <div id="footer-top-inner" class="container">
                <div class="row">
                    <div class="span3">
                        <div id="mostrecentproperties_widget-3" class="widget properties">

                            <h2>Most Recent Properties</h2>

                            <div class="content">
                                <div class="property clearfix">
                                    <div class="image">
                                        <a href="property-detail.html">
                                            <img width="570" height="425" src="/assets/img/property/19.jpg"
                                                class="thumbnail-image " alt="19" />
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="wrapper">
                                        <div class="title">
                                            <h3><a href="property-detail.html">643 37th Ave
                                            </a></h3>
                                        </div>
                                        <!-- /.title -->

                                        <div class="location">Burrville</div>
                                        <!-- /.location -->

                                        <div class="price">
                                            Contact us
                                        </div>
                                        <!-- /.price -->
                                    </div>
                                    <!-- /.wrapper -->
                                </div>
                                <!-- /.property -->

                                <div class="property-info clearfix">
                                    <div class="area">
                                        <i class="icon icon-normal-cursor-scale-up"></i>
                                        800m<sup>2</sup>
                                    </div>
                                    <!-- /.area -->

                                    <div class="bedrooms">
                                        <i class="icon icon-normal-bed"></i>
                                        2
                                    </div>
                                    <!-- /.bedrooms -->

                                </div>
                                <!-- /.info -->
                                <div class="property clearfix">
                                    <div class="image">
                                        <a href="property-detail.html">
                                            <img width="570" height="425" src="/assets/img/property/20.jpg"
                                                class="thumbnail-image " alt="20" />
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="wrapper">
                                        <div class="title">
                                            <h3><a href="property-detail.html">2459 Tilden St
                                            </a></h3>
                                        </div>
                                        <!-- /.title -->

                                        <div class="location">Judiciary Square</div>
                                        <!-- /.location -->

                                        <div class="price">
                                            500 € <span class="suffix">/ per month</span>
                                        </div>
                                        <!-- /.price -->
                                    </div>
                                    <!-- /.wrapper -->
                                </div>
                                <!-- /.property -->

                                <div class="property-info clearfix">
                                    <div class="area">
                                        <i class="icon icon-normal-cursor-scale-up"></i>
                                        1030m<sup>2</sup>
                                    </div>
                                    <!-- /.area -->

                                    <div class="bedrooms">
                                        <i class="icon icon-normal-bed"></i>
                                        12
                                    </div>
                                    <!-- /.bedrooms -->

                                    <div class="bathrooms">
                                        <i class="icon icon-normal-shower"></i>
                                        6
                                    </div>
                                    <!-- /.bathrooms -->
                                </div>
                                <!-- /.info -->
                                <div class="property clearfix">
                                    <div class="image">
                                        <a href="property-detail.html">
                                            <img width="570" height="425" src="/assets/img/property/17.jpg"
                                                class="thumbnail-image " alt="17" />
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="wrapper">
                                        <div class="title">
                                            <h3><a href="property-detail.html">677 Cottage Terrace
                                            </a></h3>
                                        </div>
                                        <!-- /.title -->

                                        <div class="location">Spring Valley</div>
                                        <!-- /.location -->

                                        <div class="price">
                                            59,600 €
                                        </div>
                                        <!-- /.price -->
                                    </div>
                                    <!-- /.wrapper -->
                                </div>
                                <!-- /.property -->

                                <div class="property-info clearfix">
                                    <div class="area">
                                        <i class="icon icon-normal-cursor-scale-up"></i>
                                        650m<sup>2</sup>
                                    </div>
                                    <!-- /.area -->

                                    <div class="bedrooms">
                                        <i class="icon icon-normal-bed"></i>
                                        1
                                    </div>
                                    <!-- /.bedrooms -->

                                    <div class="bathrooms">
                                        <i class="icon icon-normal-shower"></i>
                                        1
                                    </div>
                                    <!-- /.bathrooms -->
                                </div>
                                <!-- /.info -->
                            </div>
                            <!-- /.content -->

                        </div>
                    </div>

                    <div class="span3">
                        <div id="nav_menu-2" class="widget widget-nav_menu">
                            <h2>Helpful Links</h2>

                            <div class="menu-helpful-links-container">
                                <ul id="menu-helpful-links" class="menu">
                                    <li class="menu-item"><a
                                        href="../templates/default-left.html">Default Template</a></li>
                                    <li class="menu-item"><a
                                        href="../templates/default-right.html">Right Sidebar Template</a></li>
                                    <li class="menu-item"><a
                                        href="../templates/default-full.html">Fullwidth Template</a></li>
                                    <li class="menu-item"><a
                                        href="../properties">Properties Grid Template</a></li>
                                    <li class="menu-item"><a
                                        href="../faq.html">FAQ</a></li>
                                    <li class="menu-item"><a
                                        href="../404.html">404 page</a></li>
                                    <li class="menu-item"><a
                                        href="../login.html">Login Template</a></li>
                                    <li class="menu-item"><a
                                        href="../register.html">Register Template</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div class="span3">
                        <div id="agents_widget-2" class="widget our-agents">

                            <h2>Agents</h2>

                            <div class="content">
                                <div class="agent clearfix">
                                    <div class="image">
                                        <a href="../agents/agent-detail.html">
                                            <img src="/assets/img/agents/2.jpg" alt="Cynthia G. Stenson">
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="name">
                                        <a href="../agents/agent-detail.html">Cynthia G. Stenson</a>
                                    </div>
                                    <!-- /.name -->

                                    <div class="phone">
                                        <i class="icon icon-normal-phone"></i>
                                        985-632-254
                                    </div>
                                    <!-- /.phone -->

                                    <div class="email">
                                        <i class="icon icon-normal-mail"></i>
                                        <a href="mailto:cynthia@example.com">cynthia@example.com</a>
                                    </div>
                                    <!-- /.email -->
                                </div>
                                <!-- /.agent -->
                                <div class="agent clearfix">
                                    <div class="image">
                                        <a href="../agents/agent-detail.html">
                                            <img src="/assets/img/agents/1.jpg" alt="Stephen E. Kennedy">
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="name">
                                        <a href="../agents/agent-detail.html">Stephen E. Kennedy</a>
                                    </div>
                                    <!-- /.name -->

                                    <div class="phone">
                                        <i class="icon icon-normal-phone"></i>
                                        987-852-123
                                    </div>
                                    <!-- /.phone -->

                                    <div class="email">
                                        <i class="icon icon-normal-mail"></i>
                                        <a href="mailto:stephen@example.com">stephen@example.com</a>
                                    </div>
                                    <!-- /.email -->
                                </div>
                                <!-- /.agent -->
                                <div class="agent clearfix">
                                    <div class="image">
                                        <a href="../agents/agent-detail.html">
                                            <img src="/assets/img/agents/2.jpg" alt="Myrtle J. Metz">
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="name">
                                        <a href="../agents/agent-detail.html">Myrtle J. Metz</a>
                                    </div>
                                    <!-- /.name -->

                                    <div class="phone">
                                        <i class="icon icon-normal-phone"></i>
                                        987-963-654
                                    </div>
                                    <!-- /.phone -->

                                    <div class="email">
                                        <i class="icon icon-normal-mail"></i>
                                        <a href="mailto:myrtle@example.com">myrtle@example.com</a>
                                    </div>
                                    <!-- /.email -->
                                </div>
                                <!-- /.agent -->
                            </div>
                            <!-- /.content -->

                        </div>
                    </div>

                    <div class="span3">
                        <div id="featuredproperties_widget-2" class="widget properties">

                            <h2>Featured Properties</h2>

                            <div class="content">
                                <div class="property clearfix">
                                    <div class="image">
                                        <a href="property-detail.html">
                                            <img width="570" height="425" src="/assets/img/property/1.jpg"
                                                class="thumbnail-image " alt="1" />
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="wrapper">
                                        <div class="title">
                                            <h3><a href="property-detail.html">20th St NE
                                            </a></h3>
                                        </div>
                                        <!-- /.title -->

                                        <div class="location">Benning</div>
                                        <!-- /.location -->

                                        <div class="price">
                                            85,600 €
                                        </div>
                                        <!-- /.price -->
                                    </div>
                                    <!-- /.wrapper -->
                                </div>
                                <!-- /.property -->

                                <div class="property-info clearfix">
                                    <div class="area">
                                        <i class="icon icon-normal-cursor-scale-up"></i>
                                        450m<sup>2</sup>
                                    </div>
                                    <!-- /.area -->

                                    <div class="bedrooms">
                                        <i class="icon icon-normal-bed"></i>
                                        1
                                    </div>
                                    <!-- /.bedrooms -->

                                    <div class="bathrooms">
                                        <i class="icon icon-normal-shower"></i>
                                        2
                                    </div>
                                    <!-- /.bathrooms -->
                                </div>
                                <!-- /.info -->
                                <div class="property clearfix">
                                    <div class="image">
                                        <a href="property-detail.html">
                                            <img width="570" height="425" src="/assets/img/property/12.jpg"
                                                class="thumbnail-image " alt="12" />
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="wrapper">
                                        <div class="title">
                                            <h3><a href="property-detail.html">246 Varnum Pl NE
                                            </a></h3>
                                        </div>
                                        <!-- /.title -->

                                        <div class="location">Kingman Park</div>
                                        <!-- /.location -->

                                        <div class="price">
                                            32,500 €
                                        </div>
                                        <!-- /.price -->
                                    </div>
                                    <!-- /.wrapper -->
                                </div>
                                <!-- /.property -->

                                <div class="property-info clearfix">
                                    <div class="area">
                                        <i class="icon icon-normal-cursor-scale-up"></i>
                                        500m<sup>2</sup>
                                    </div>
                                    <!-- /.area -->

                                    <div class="bedrooms">
                                        <i class="icon icon-normal-bed"></i>
                                        2
                                    </div>
                                    <!-- /.bedrooms -->

                                    <div class="bathrooms">
                                        <i class="icon icon-normal-shower"></i>
                                        3
                                    </div>
                                    <!-- /.bathrooms -->
                                </div>
                                <!-- /.info -->
                                <div class="property clearfix">
                                    <div class="image">
                                        <a href="property-detail.html">
                                            <img width="570" height="425" src="/assets/img/property/6.jpg"
                                                class="thumbnail-image " alt="6" />
                                        </a>
                                    </div>
                                    <!-- /.image -->

                                    <div class="wrapper">
                                        <div class="title">
                                            <h3><a href="property-detail.html">Randolph St NW
                                            </a></h3>
                                        </div>
                                        <!-- /.title -->

                                        <div class="location">Civic Betterment</div>
                                        <!-- /.location -->

                                        <div class="price">
                                            97,400 €
                                        </div>
                                        <!-- /.price -->
                                    </div>
                                    <!-- /.wrapper -->
                                </div>
                                <!-- /.property -->

                                <div class="property-info clearfix">
                                    <div class="area">
                                        <i class="icon icon-normal-cursor-scale-up"></i>
                                        680m<sup>2</sup>
                                    </div>
                                    <!-- /.area -->

                                    <div class="bedrooms">
                                        <i class="icon icon-normal-bed"></i>
                                        3
                                    </div>
                                    <!-- /.bedrooms -->

                                    <div class="bathrooms">
                                        <i class="icon icon-normal-shower"></i>
                                        2
                                    </div>
                                    <!-- /.bathrooms -->
                                </div>
                                <!-- /.info -->
                            </div>
                            <!-- /.content -->

                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /#footer-top-inner -->
        </div>
        <!-- /#footer-top -->

        <div class="footer-bottom">
            <div id="footer" class="footer container">
                <div id="footer-inner">
                    <div class="row">
                        <div class="span6">
                            <div id="text-3" class="widget widget-text">
                                <div class="textwidget">&copy; 2013 Aviators, All Rights reserved</div>
                            </div>
                        </div>
                        <!-- /.copyright -->

                        <div class="span6">
                            <div id="nav_menu-3" class="widget widget-nav_menu">
                                <div class="menu-footer-links-container">
                                    <ul id="menu-footer-links" class="menu">
                                        <li class="menu-item active"><a href="../default.htm">Homepage</a></li>
                                        <li class="menu-item"><a href="../pricing.html">Pricing</a></li>
                                        <li class="menu-item"><a href="../faq.html">FAQ</a></li>
                                        <li class="menu-item"><a href="../contact.html">Contact</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- /.span6 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /#footer-inner -->
            </div>
            <!-- /#footer -->
        </div>
    </div>
    <!-- /#footer-wrapper -->
    <script type='text/javascript' src='http://maps.googleapis.com/maps/api/js?v=3&sensor=true&ver=3.6'></script>
    <script type='text/javascript' src='/assets/js/aviators-map.js'></script>
    <script type='text/javascript' src='/assets/js/gmap3.infobox.min.js'></script>
    <script type='text/javascript' src='/assets/js/bootstrap.min.js'></script>
    <script type='text/javascript' src='/assets/js/retina.js'></script>
    <script type='text/javascript' src='/assets/js/gmap3.clusterer.js'></script>
    <script type='text/javascript' src='/assets/js/jquery.ezmark.js'></script>
    <script type='text/javascript' src='/assets/js/carousel.js'></script>
    <script type='text/javascript' src='/assets/js/jquery.bxslider.js'></script>
    <script type='text/javascript' src='/assets/js/properta.js'></script>
    <script type='text/javascript' src='/assets/js/jquery.bxslider.min.js'></script>
</body>
</html>

