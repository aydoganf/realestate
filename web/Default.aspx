<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="assets/img/favicon.png" type="image/png">

    <!--[if lt IE 9]>
    <script src="assets/js/html5.js" type="text/javascript"></script>
    <![endif]-->

    <meta name='robots' content='noindex,nofollow' />

    <link rel='stylesheet' id='font-css'
        href='http://fonts.googleapis.com/css?family=Open+Sans%3A400%2C700%2C300&#038;subset=latin%2Clatin-ext&#038;ver=3.6'
        type='text/css' media='all' />


    <link rel='stylesheet' id='revolution-fullwidth' href='assets/libraries/rs-plugin/css/fullwidth.css' type='text/css' media='all' />
    <link rel='stylesheet' id='revolution-settings' href='assets/libraries/rs-plugin/css/settings.css' type='text/css' media='all' />
    <link rel='stylesheet' id='bootstrap-css' href='assets/libraries/bootstrap/css/bootstrap.min.css' type='text/css' media='all' />
    <link rel='stylesheet' id='bootstrap-responsive-css' href='assets/libraries/bootstrap/css/bootstrap-responsive.min.css' type='text/css' media='all' />

    <link rel='stylesheet' id='pictopro-normal-css' href='assets/icons/pictopro-normal/style.css' type='text/css' media='all' />
    <link rel='stylesheet' id='justvector-web-font-css' href='assets/icons/justvector-web-font/stylesheet.css' type='text/css' media='all' />
    <link rel='stylesheet' id='chosen-css' href='assets/libraries/chosen/chosen.css' type='text/css' media='all' />

    <link rel='stylesheet' id='aviators-css' href='assets/css/jquery.bxslider.css' type='text/css' media='all' />
    <link rel='stylesheet' id='properta-css' href='assets/css/properta.css' type='text/css' media='all' />
    <link rel="stylesheet" id="custom-css" href="assets/css/custom.css" type="text/css" media="all" />

    <script type='text/javascript' src='http://code.jquery.com/jquery-1.7.2.min.js'></script>
    <script type='text/javascript' src='assets/js/aviators-settings.js'></script>
    <script type='text/javascript' src='assets/libraries/chosen/chosen.jquery.min.js'></script>
    <script type='text/javascript' src='assets/libraries/rs-plugin/js/jquery.themepunch.revolution.min.js'></script>
    <script type='text/javascript' src='assets/libraries/rs-plugin/js/jquery.themepunch.plugins.min.js'></script>

    <title>RealEstate.com</title>
</head>
<body class="home page page-template">
    <form id="form1" runat="server">
        <div class="top">
            <div class="container">
                <div class="top-inner inverted">
                    <div class="header clearfix">
                        <%-- // LOGO ve Site Adı --%>
                        <div class="branding pull-left">
                            <div class="logo">
                                <a href="default.htm" title="Home">
                                    <img src="assets/img/logo.png" alt="Home">
                                </a>
                            </div>
                            <!-- /.logo -->

                            <div class="site-name">
                                <a href="default.htm" title="Home" class="brand">Properta
                                </a>
                            </div>
                            <!-- /.site-name -->
                        </div>
                        <%-- LOGO ve Site Adı // --%>

                        <div class="contact-top">
                            <ul class="menu nav">
                                <li class="first leaf facebook"><a href="http://www.facebook.com" class="facebook"><i>F</i></a></li>
                                <li class="leaf google-plus"><a href="http://plus.google.com" class="google"><i>g</i></a></li>
                                <li class="leaf twitter"><a href="http://www.twitter.com" class="twitter"><i>T</i></a></li>
                            </ul>
                        </div>

                        <div class="user-area pull-right">
                            <div class="menu-anonymous-container">
                                <ul id="menu-anonymous" class="nav nav-pills">
                                    <li class="menu-item"><a href="register.html">Register</a></li>
                                    <li class="menu-item"><a href="login.html">Login</a></li>
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
                                        <a href="default.htm">Homepage</a>
                                        <ul class="sub-menu">
                                            <li class="menu-item"><a href="frontpage-slider.html">Revolution slider</a></li>
                                            <li class="menu-item"><a href="frontpage-map-vertical.html.html">Homepage - Vertical filter</a></li>
                                            <li class="menu-item"><a href="default.htm">Homepage - Horizontal filter</a></li>
                                        </ul>
                                    </li>

                                    <li class="menu-item menu-item-parent">
                                        <a href="#">Listings</a>

                                        <ul class="sub-menu">
                                            <li class="menu-item"><a href="properties/default.htm">Properties listing</a></li>
                                            <li class="menu-item"><a href="properties/property-detail.html">Property detail</a></li>

                                            <li class="menu-item"><a href="agencies/default.htm">Agencies listing</a></li>
                                            <li class="menu-item"><a href="agencies/agency-detail.html">Agencies detail</a></li>

                                            <li class="menu-item"><a href="agents/default.htm">Agents listing</a></li>
                                            <li class="menu-item"><a href="agents/agent-detail.html">Agent detail</a></li>

                                            <li class="menu-item"><a href="register.html">Register</a></li>
                                            <li class="menu-item"><a href="login.html">Login</a></li>
                                        </ul>
                                    </li>

                                    <li class="menu-item menu-item-parent">
                                        <a href="#">Pages</a>
                                        <ul class="sub-menu">
                                            <li class="menu-item"><a href="404.html">404 page</a></li>
                                            <li class="menu-item"><a href="faq.html">FAQ page</a></li>
                                            <li class="menu-item"><a href="pricing.html">Pricing</a></li>
                                        </ul>
                                    </li>

                                    <li class="menu-item menu-item-parent">
                                        <a href="#">Submissions</a>
                                        <ul class="sub-menu">
                                            <li class="menu-item"><a href="submissions/default.htm">List submissions</a></li>
                                            <li class="menu-item"><a href="submissions/add.html">Add submission</a></li>
                                            <li class="menu-item"><a href="submissions/edit.html">Edit submission</a></li>
                                        </ul>
                                    </li>

                                    <li class="menu-item menu-item-parent">
                                        <a href="#">Templates</a>
                                        <ul class="sub-menu">
                                            <li class="menu-item"><a href="templates/default-left.html">Left sidebar</a></li>
                                            <li class="menu-item"><a href="templates/default-right.html">Right sidebar</a></li>
                                            <li class="menu-item"><a href="templates/default-full.html">Full width</a></li>
                                        </ul>
                                    </li>

                                    <li class="menu-item">
                                        <a href="contact.html">Contact</a>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <%--<div class="pull-right">
                            <div class="list-property">
                                <a href="submissions/default.htm">List your property<div class="ribbon"><span class="icon icon-normal-circle-plus"></span></div>
                                </a>
                            </div>
                            <!-- /.list-property -->
                        </div>--%>
                        <!-- /.pull-right -->

                    </div>

                    <div class="breadcrumb pull-left">
                        <!-- Breadcrumb NavXT 4.4.0 -->
                        <a title="Anasayfa" href="javascript:;" class="home">Anasayfa</a>
                    </div>

                    <!-- /.breadcrumb -->
                </div>
            </div>
        </div>

        <div id="content" class="clearfix">
            <div class="map-wrapper">
                <div class="map">
                    <div class="container" style="height: 0px;">
                        <div class="row">
                            <div class="span3">
                                <div class="property-filter widget property-type-list">
                                    <div class="content">
                                        <div class="property-types-custom">
                                            <asp:Repeater ID="rptBaseEstateTypes" runat="server">
                                                <ItemTemplate>
                                                    <a href="/<%#Eval("TypeKey") %>">
                                                        <div class="property-type-custom">
                                                            <%#Eval("TypeName") %>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <script type="text/javascript">

                        var infoBoxes = [];

                        var property1 = '<div class="infobox clearfix"><div class="close"><img src="assets/img/close.png" alt=""></div><div class="image"><a href="properties/property-detail" ><img src="assets/img/property/17.jpg" alt="677 Cottage Terrace" width="130px"></a><div class="contract-type">For sale</div></div><div class="info"><div class="title"><a href="properties/property-detail">677 Cottage Terrace</a></div><div class="location">Spring Valley</div><div class="property-info clearfix"><div class="area"><i class="icon icon-normal-cursor-scale-up"></i>650m<sup>2</sup></div><div class="bedrooms"><i class="icon icon-normal-bed"></i>1</div><div class="bathrooms"><i class="icon icon-normal-shower"></i>1</div></div><div class="price">59,600 €</div><div class="link"><a href="properties/property-detail">View more</a></div></div></div>';
                        var property2 = '<div class="infobox clearfix"><div class="close"><img src="assets/img/close.png" alt=""></div><div class="image"><a href="properties/property-detail"><img src="assets/img/property/19.jpg" alt="643 37th Ave" width="130px"></a><div class="contract-type">For sale</div></div><div class="info"><div class="title"><a href="properties/property-detail">643 37th Ave</a></div><div class="location">Burrville</div><div class="property-info clearfix"><div class="area"><i class="icon icon-normal-cursor-scale-up"></i>800m<sup>2</sup></div><div class="bedrooms"><i class="icon icon-normal-bed"></i>2</div><div class="bathrooms"><i class="icon icon-normal-shower"></i>2</div></div><div class="price">Contact us</div><div class="link"><a href="properties/property-detail">View more</a></div></div></div>';
                        var property3 = '<div class="infobox clearfix"><div class="close"><img src="assets/img/close.png" alt=""></div><div class="image"><a href="properties/property-detail" ><img src="assets/img/property/17.jpg" alt="677 Cottage Terrace" width="130px"></a>                  <div class="contract-type">For sale</div></div><div class="info"><div class="title"><a href="properties/property-detail">677 Cottage Terrace</a></div><div class="location">Spring Valley</div><div class="property-info clearfix"><div class="area"><i class="icon icon-normal-cursor-scale-up"></i>650m<sup>2</sup></div><div class="bedrooms"><i class="icon icon-normal-bed"></i>1</div><div class="bathrooms"><i class="icon icon-normal-shower"></i>1</div></div><div class="price">59,600 €</div><div class="link"><a href="properties/property-detail">View more</a></div></div></div>';

                        for (var i = 0; i < 15 ; i++) {
                            infoBoxes.push(property1);
                            infoBoxes.push(property2);
                            infoBoxes.push(property3);
                        }

                        jQuery(document).ready(function ($) {
                            var map = $('#map').aviators_map({
                                locations: new Array([38.951399, -76.958463], [38.942855, -76.959149], [38.935945, -76.954085], [38.924194, -76.962497], [38.929335, -76.966402], [38.950131, -76.975286], [38.941386, -76.976745], [38.912975, -76.973269], [38.927266, -76.985156], [38.936813, -76.987173], [38.941653, -76.995885], [38.929235, -76.995627], [38.922024, -77.001378], [38.920788, -77.020304], [38.926531, -77.007558], [38.939384, -77.018115], [38.939217, -77.070257], [38.931539, -77.103517], [38.942454, -77.05352], [38.930571, -77.086007], [38.947194, -77.109696], [38.949864, -77.094762], [38.940685, -77.095964], [38.932474, -77.026441], [38.932941, -77.034165], [38.932641, -77.044079], [38.932908, -77.061674], [38.931372, -77.07781], [38.926665, -77.101457], [38.929135, -77.101671], [38.919086, -77.108538], [38.910103, -77.104504], [38.920221, -77.084033], [38.915513, -77.089741], [38.918752, -77.095105], [38.912073, -77.00597], [38.90486, -77.024724], [38.918418, -77.010605], [38.928868, -77.021377], [38.920154, -77.010562], [38.915847, -77.069699], [38.926164, -77.056739], [38.925045, -77.040063], [38.922591, -77.034291]),
                                types: new Array('family-house', 'villa', 'cottage', 'single-home', 'family-house', 'cottage', 'apartment', 'building-area', 'apartment', 'family-house', 'villa', 'family-house', 'villa', 'single-home', 'cottage', 'villa', 'condo', 'apartment', 'single-home', 'cottage', 'family-house', 'villa', 'apartment', 'apartment', 'villa', 'villa', 'apartment', 'cottage', 'villa', 'family-house', 'building-area', 'family-house', 'family-house', 'cottage', 'apartment', 'cottage', 'family-house', 'villa', 'cottage', 'condo', 'building-area', 'family-house', 'single-home', 'apartment'),
                                contents: infoBoxes,
                                transparentMarkerImage: 'assets/img/marker-transparent.png',
                                transparentClusterImage: 'assets/img/markers/cluster-transparent.png',
                                zoom: 14,
                                center: {
                                    latitude: 38.932307,
                                    longitude: -77.034258
                                },
                                filterForm: '.map-filtering',
                                enableGeolocation: '',
                                pixelOffsetX: -75,
                                pixelOffsetY: -200
                            });
                        });
                    </script>
                    <div id="map" class="map-inner" style="height: 750px"></div>
                </div>
            </div>
            <%-- Map Wrapper Bitti --%>

            <%-- Content Başlangıç --%>
            <div class="container">
                <div class="row">
                    <div class="sidebar span3">
                        <h2>Hızlı Arama</h2>
                        <div class="property-filter widget">
                            <div class="content">                                
                                <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="upSearchLeft" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="location control-group">
                                            <label class="control-label">
                                                Lokasyon
                                            </label>

                                            <div class="controls">
                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="make-chosen"
                                                    DataTextField="CityName" DataValueField="ObjectId" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <asp:Panel ID="pnlTownLocationSearch" runat="server" Visible="false" CssClass="location control-group">
                                            <label class="control-label">
                                                İlçeler
                                            </label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlTown" runat="server" CssClass="make-chosen"
                                                    DataTextField="TownName" DataValueField="ObjectId" AutoPostBack="true" OnSelectedIndexChanged="ddlTown_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </asp:Panel>

                                        <asp:Panel ID="pnlDistrictLocationSearch" runat="server" Visible="false" CssClass="location control-group">
                                            <label class="control-label">
                                                Semtler
                                            </label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="make-chosen"
                                                    DataTextField="DistrictName" DataValueField="ObjectId">
                                                </asp:DropDownList>
                                            </div>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCity" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlTown" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <script type="text/javascript">
                                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                                    var postBackElement;

                                    prm.add_initializeRequest(InitializeRequest);
                                    prm.add_endRequest(EndRequest);

                                    function InitializeRequest(sender, args) {
                                        postBackElement = args.get_postBackElement();
                                    }

                                    function EndRequest(sender, args) {
                                        if (postBackElement.id == 'ddlCity') {
                                            $('#ddlCity').chosen({
                                                disable_search_threshold: 20
                                            });
                                            $('#ddlTown').chosen({
                                                disable_search_threshold: 20
                                            });
                                        } else if (postBackElement.id == 'ddlTown') {
                                            $('#ddlCity').chosen({
                                                disable_search_threshold: 20
                                            });
                                            $('#ddlTown').chosen({
                                                disable_search_threshold: 20
                                            });
                                            $('#ddlDistrict').chosen({
                                                disable_search_threshold: 20
                                            });
                                        }
                                    }
                                </script>
                                <div class="type control-group">
                                    <label class="control-label">
                                        Emlak Tipi
                                    </label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlMarketingType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-chosen"></asp:DropDownList>                                        
                                    </div>
                                </div>
                                <div class="type control-group">
                                    <label class="control-label">                                        
                                    </label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlEstateType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-chosen"></asp:DropDownList>
                                    </div>
                                </div>
                                                                
                                <div class="rent control-group">
                                    <label class="control-label">
                                        Metrekare
                                    </label>
                                    <div class="controls" style="padding-right:5px;">
                                        <asp:TextBox ID="tbAreaFrom" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="sale control-group">
                                    <label class="control-label">
                                        &nbsp;
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="tbAreaTo" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="rent control-group">
                                    <label class="control-label">
                                        Fiyat Aralığı
                                    </label>
                                    <div class="controls" style="padding-right:5px;">
                                        <asp:TextBox ID="tbPriceFrom" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="sale control-group">
                                    <label class="control-label">
                                        &nbsp;
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="tbPriceTo" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="type control-group">
                                    <label class="control-label">                                        
                                    </label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlCurrencyList" runat="server" DataTextField="CurrencyName" DataValueField="ObjectId" CssClass="make-chosen"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-large" Text="Arama yap" OnClick="btnSearch_Click" />
                                    <a href="/detayli-arama">Detaylı Ara</a>
                                </div>
                            </div>
                        </div>
                        <div id="mostrecentproperties_widget-2" class="widget properties">
                            <h2>Son Eklenen İlanlar</h2>
                            <div class="content">
                                <!-- Son ilanlar -->
                                <asp:Repeater ID="rptLastProperties" runat="server">
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="property clearfix">
                                            <div class="image">
                                                <a href="/ilan-detay/<%#Eval("CityName") %>/<%#Eval("TownName") %>/<%#Eval("DistrictName") %>/<%#Eval("AdvertNumber") %>/<%#Eval("Title") %>">
                                                    <img width="570" height="425" src="/uploads/<%#Eval("PrimarySmallAdvertPhoto") %>"
                                                        class="thumbnail-image " alt="19" />
                                                </a>
                                            </div>
                                            <div class="wrapper">
                                                <div class="title">
                                                    <h3>
                                                        <a href="/ilan-detay/<%#Eval("CityName") %>/<%#Eval("TownName") %>/<%#Eval("DistrictName") %>/<%#Eval("AdvertNumber") %>/<%#Eval("Title") %>">
                                                            <%#Eval("Title") %>
                                                        </a>
                                                    </h3>
                                                </div>
                                                <div class="location"><%#Eval("CityName") %>/<%#Eval("TownName") %></div>
                                                <div class="price">
                                                    <%# FormatPrice(Eval("Price")) %> <%#Eval("PriceCurrency.CurrencyName") %>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="property-info clearfix">
                                            <div class="area">
                                                <i class="icon icon-normal-cursor-scale-up"></i>
                                                <%#Eval("Area") %> m<sup>2</sup>
                                            </div>
                                            <div class="bedrooms">
                                                <i class="icon icon-normal-bed"></i><%#Eval("BathCount") %>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>

                    <div id="main" class="span9">
                        <h1 class="page-header">Emlak İlanları</h1>
                        <div class="properties-grid">
                            <asp:Repeater ID="rptRecentProperties" runat="server">
                                <HeaderTemplate>
                                    <div class="row-fluid">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="span3">
                                        <div class="property">
                                            <div class="image">
                                                <div class="content">
                                                    <a href="/IlanDetay/<%#Eval("CityName") %>/<%#Eval("TownName") %>/<%#Eval("DistrictName") %>/<%#Eval("AdvertNumber") %>/<%#Eval("Title") %>">
                                                        <img src="/uploads/<%#Eval("PrimarySmallAdvertPhoto") %>" alt="<%#Eval("Title") %>">
                                                    </a>
                                                </div>
                                                <div class="rent-sale">
                                                    <%#Eval("MarketingType.TypeName") %>
                                                </div>
                                                <div class="price">
                                                    <%# FormatPrice(Eval("Price")) %> <%#Eval("PriceCurrency.CurrencyName") %>
                                                </div>
                                            </div>

                                            <div class="info">
                                                <div class="title clearfix">
                                                    <h2>
                                                        <a href="/IlanDetay/<%#Eval("CityName") %>/<%#Eval("TownName") %>/<%#Eval("DistrictName") %>/<%#Eval("AdvertNumber") %>/<%#Eval("Title") %>">
                                                            <%#Eval("Title") %>
                                                        </a>
                                                    </h2>
                                                </div>
                                                <div class="location"><%#Eval("CityName") %>/<%#Eval("TownName") %></div>
                                            </div>
                                        </div>
                                        <div class="property-info clearfix">
                                            <div class="area">
                                                <i class="icon icon-normal-cursor-scale-up"></i>
                                                <%#Eval("Area") %> m<sup>2</sup>
                                            </div>
                                            <div class="bedrooms">
                                                <i class="icon icon-normal-bed"></i><%#Eval("BathCount") %>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Content Bitiş --%>
        </div>
    </form>
    <script type='text/javascript' src='http://maps.googleapis.com/maps/api/js?v=3&#038;sensor=true&#038;ver=3.6'></script>
    <script type='text/javascript' src='assets/js/aviators-map.js'></script>
    <script type='text/javascript' src='assets/js/gmap3.infobox.min.js'></script>
    <script type='text/javascript' src='assets/js/bootstrap.min.js'></script>
    <script type='text/javascript' src='assets/js/retina.js'></script>
    <script type='text/javascript' src='assets/js/gmap3.clusterer.js'></script>
    <script type='text/javascript' src='assets/js/jquery.ezmark.js'></script>
    <script type='text/javascript' src='assets/js/carousel.js'></script>
    <script type='text/javascript' src='assets/js/jquery.bxslider.js'></script>
    <script type='text/javascript' src='assets/js/properta.js'></script>
    <script type='text/javascript' src='assets/js/jquery.bxslider.min.js'></script>
</body>
</html>
