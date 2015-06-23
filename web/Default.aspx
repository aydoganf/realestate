<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
    <link rel="stylesheet" id="custom-css" href="/assets/css/custom.css" type="text/css" media="all" />

    <script type='text/javascript' src='http://code.jquery.com/jquery-1.7.2.min.js'></script>
    <%--<script type='text/javascript' src='/assets/js/aviators-settings.js'></script>--%>
    <script type='text/javascript' src='/assets/libraries/chosen/chosen.jquery.min.js'></script>
    <script type='text/javascript' src='/assets/libraries/rs-plugin/js/jquery.themepunch.revolution.min.js'></script>
    <script type='text/javascript' src='/assets/libraries/rs-plugin/js/jquery.themepunch.plugins.min.js'></script>

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
                                    <img src="/assets/img/logo.png" alt="Home">
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

                    </div>
                    <!-- /.header -->
                    <div class="navigation navbar clearfix">
                        <%--<div class="pull-left">
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
                        </div>--%>

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
                                            <asp:Repeater ID="rptBaseEstateTypes" runat="server" OnItemDataBound="rptBaseEstateTypes_ItemDataBound">
                                                <ItemTemplate>
                                                    <a id="aQuick" runat="server">
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
                    <div style="display: none">
                        <asp:HiddenField ID="hfLatCenter" runat="server" />
                        <asp:HiddenField ID="hfLongCenter" runat="server" />
                        <p class="infoBoxes">
                            <asp:Repeater ID="rptMapInfo" runat="server">
                                <ItemTemplate>
                                    <div class="realEstateMapItem">
                                        <p class="realEstateMapItem-price"><%# FormatPrice(Eval("Price").ToString()) %></p>
                                        <p class="realEstateMapItem-priceCurrency"><%# Eval("PriceCurrency.CurrencyName") %></p>
                                        <p class="realEstateMapItem-title"><%#Eval("Title") %></p>
                                        <p class="realEstateMapItem-shortTitle"><%#Eval("Title").ToString().Substring(0,25) %></p>
                                        <p class="realEstateMapItem-picture"><%#Eval("PrimarySmallAdvertPhoto") %></p>
                                        <p class="realEstateMapItem-area"><%#Eval("Area") %></p>
                                        <p class="realEstateMapItem-estateType"><%#Eval("EstateType.TypeName") %></p>
                                        <p class="realEstateMapItem-parentEstateType"><%#Eval("EstateType.ParentEstateType.TypeName") %></p>
                                        <p class="realEstateMapItem-link"><%# FormatAdvertLink(Container.DataItem as DBLayer.Advert) %></p>
                                        <p class="realEstateMapItem-latitude"><%#Eval("Latitude") %></p>
                                        <p class="realEstateMapItem-longitude"><%#Eval("Longitude") %></p>
                                        <p class="realEstateMapItem-marketingType"><%#Eval("MarketingType.TypeName") %></p>
                                        <p class="realEstateMapItem-townName"><%#Eval("TownName") %></p>
                                        <p class="realEstateMapItem-districtName"><%#Eval("DistrictName") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>

                    </div>

                    <script type="text/javascript">

                        var infoBoxes = [];
                        var coords = [];
                        var icons = [];
                        var latCenter = $('#<%=hfLatCenter.ClientID%>').val();
                        var longCenter = $('#<%=hfLongCenter.ClientID%>').val();

                        $(document).ready(function () {
                            $('.realEstateMapItem').each(function () {
                                debugger;
                                var rPrice = $(this).find('.realEstateMapItem-price').text();
                                var rPriceCurrency = $(this).find('.realEstateMapItem-priceCurrency').text();
                                var rTitle = $(this).find('.realEstateMapItem-title').text();
                                var rShortTitle = $(this).find('.realEstateMapItem-shortTitle').text();
                                var rPicture = $(this).find('.realEstateMapItem-picture').text();
                                var rArea = $(this).find('.realEstateMapItem-area').text();
                                var rEstateType = $(this).find('.realEstateMapItem-estateType').text();
                                var rParentEstateType = $(this).find('.realEstateMapItem-parentEstateType').text();
                                var rLink = $(this).find('.realEstateMapItem-link').text();
                                var rLatitude = $(this).find('.realEstateMapItem-latitude').text();
                                var rLongitude = $(this).find('.realEstateMapItem-longitude').text();
                                var rMarketingType = $(this).find('.realEstateMapItem-marketingType').text();
                                var rTownName = $(this).find('.realEstateMapItem-townName').text();
                                var rDistrictName = $(this).find('.realEstateMapItem-districtName').text();

                                var marker = '';
                                switch (rParentEstateType) {
                                    case 'Konut':
                                        marker = 'single-home';
                                        break;
                                    case 'İşyeri':
                                        marker = 'condo';
                                        break;
                                    case 'Arsa':
                                        marker = 'building-area';
                                        break;
                                    case 'Devremülk':
                                        marker = 'cottage';
                                        break;
                                    case 'Turistik İşletme':
                                        marker = 'villa';
                                        break;
                                    default:
                                        break;
                                }

                                var info = '<div class="infobox clearfix"><div class="close"><img src="/assets/img/close.png" alt=""></div><div class="image"><a href="' + rLink + '" ><img src="/uploads/' + rPicture + '" alt="" width="130px"></a><div class="contract-type">' + rMarketingType + '</div></div><div class="info"><div class="title"><a href="' + rLink + '">' + rShortTitle + '</a></div><div class="location">' + rDistrictName + '/' + rTownName + '</div><div class="property-info clearfix"><div class="area"><i class="icon icon-normal-cursor-scale-up"></i>' + rArea + ' m<sup>2</sup></div></div><div class="price">' + rPrice + ' ' + rPriceCurrency + '</div><div class="link"><a href="' + rLink + '">Detaylı bilgi</a></div></div></div>';
                                infoBoxes.push(info);
                                var coord = [];
                                coord = [rLatitude, rLongitude];
                                coords.push(coord);
                                icons.push(marker);

                            });

                            var map = $('#map').aviators_map({
                                locations: coords,
                                types: icons,
                                contents: infoBoxes,
                                transparentMarkerImage: '/assets/img/marker-transparent.png',
                                transparentClusterImage: '/assets/img/markers/cluster-transparent.png',
                                zoom: 14,
                                center: {
                                    latitude: latCenter,
                                    longitude: longCenter
                                },
                                filterForm: '.map-filtering',
                                enableGeolocation: '',
                                pixelOffsetX: -75,
                                pixelOffsetY: -200
                            });

                        });

                        function getMapData() {
                            $.ajax({
                                type: 'POST',
                                url: '/service/service.aspx/GetMapAdverts',
                                data: '',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (result) {

                                    if (result.d.StatusCode == 0) {
                                        for (var i = 0; i < result.d.EstateList.length; i++) {
                                            var info = '<div class="infobox clearfix"><div class="close"><img src="/assets/img/close.png" alt=""></div><div class="image"><a href="' + result.d.EstateList[i].Link + '" ><img src="/uploads/' + result.d.EstateList[i].Picture + '" alt="" width="130px"></a><div class="contract-type">' + result.d.EstateList[i].MarketingType + '</div></div><div class="info"><div class="title"><a href="' + result.d.EstateList[i].Link + '">' + result.d.EstateList[i].ShortTitle + '</a></div><div class="location">Spring Valley</div><div class="property-info clearfix"><div class="area"><i class="icon icon-normal-cursor-scale-up"></i>' + result.d.EstateList[i].Area + '<sup>2</sup></div><div class="bedrooms"><i class="icon icon-normal-bed"></i>1</div><div class="bathrooms"><i class="icon icon-normal-shower"></i>1</div></div><div class="price">59,600 €</div><div class="link"><a href="properties/property-detail">View more</a></div></div></div>';
                                            infoBoxes.push(info);

                                            var coord = [];
                                            coord = [result.d.EstateList[i].Latitude, result.d.EstateList[i].Longitude];
                                            coords[i] = coord;

                                        }
                                        longCenter = result.d.LongCenter.replace(',', '.');
                                        latCenter = result.d.LatCenter.replace(',', '.');
                                    }

                                    console.log(infoBoxes);

                                },
                                error: function (result) {
                                    alert(result.get_messages());
                                },
                                complete: function () {
                                    var map = $('#map').aviators_map({
                                        locations: coords,
                                        types: new Array('family-house', 'villa', 'cottage', 'single-home', 'family-house', 'cottage', 'apartment', 'building-area', 'apartment', 'family-house', 'villa', 'family-house', 'villa', 'single-home', 'cottage', 'villa', 'condo', 'apartment', 'single-home', 'cottage', 'family-house', 'villa', 'apartment', 'apartment', 'villa', 'villa', 'apartment', 'cottage', 'villa', 'family-house', 'building-area', 'family-house', 'family-house', 'cottage', 'apartment', 'cottage', 'family-house', 'villa', 'cottage', 'condo', 'building-area', 'family-house', 'single-home', 'apartment'),
                                        contents: infoBoxes,
                                        transparentMarkerImage: '/assets/img/marker-transparent.png',
                                        transparentClusterImage: '/assets/img/markers/cluster-transparent.png',
                                        zoom: 14,
                                        center: {
                                            latitude: latCenter,
                                            longitude: longCenter
                                        },
                                        filterForm: '.map-filtering',
                                        enableGeolocation: '',
                                        pixelOffsetX: -75,
                                        pixelOffsetY: -200
                                    });
                                }
                            });

                        }
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
                                    <div class="controls" style="padding-right: 5px;">
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
                                    <div class="controls" style="padding-right: 5px;">
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
                                                <a href="<%# FormatAdvertLink(Container.DataItem as DBLayer.Advert) %>">
                                                    <img width="570" height="425" src="/uploads/<%#Eval("PrimarySmallAdvertPhoto") %>"
                                                        class="thumbnail-image " alt="19" />
                                                </a>
                                            </div>
                                            <div class="wrapper">
                                                <div class="title">
                                                    <h3>
                                                        <a href="<%# FormatAdvertLink(Container.DataItem as DBLayer.Advert) %>">
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
                                                    <a href="<%# FormatAdvertLink(Container.DataItem as DBLayer.Advert) %>">
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
                                                        <a href="<%# FormatAdvertLink(Container.DataItem as DBLayer.Advert) %>">
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

                        <div class="clearfix"></div>
                        <div class="pagination pagination-centered" id="divPagination" runat="server">
                            <ul class="unstyled">
                                <asp:HiddenField ID="hfLastPageNumber" runat="server" />
                                <asp:HiddenField ID="hfCurrentAdvertPageNumber" runat="server" />
                                <asp:Repeater ID="rptPagination" runat="server" OnItemDataBound="rptPagination_ItemDataBound">
                                    <HeaderTemplate>
                                        <li><a id="aPageItemFirst">İlk</a></li>
                                        <li><a id="aPageItemPrev">Önceki</a></li>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li id="liPaginationItem" runat="server"><a href="/anasayfa?p=<%# Container.ItemIndex + 1 %>"><%# Container.ItemIndex + 1 %></a></li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <li><a id="aPageItemNext">Sonraki</a></li>
                                        <li><a id="aPageItemLast">Son</a></li>
                                    </FooterTemplate>
                                </asp:Repeater>                                
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Content Bitiş --%>
        </div>
    </form>
    <script type='text/javascript' src='http://maps.googleapis.com/maps/api/js?v=3&#038;sensor=true&#038;ver=3.6'></script>
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
    <script type="text/javascript">

        $(document).ready(function () {

            var currentPage = parseInt($('#<%=hfCurrentAdvertPageNumber.ClientID%>').val());
            var totalPage = parseInt($('#<%=hfLastPageNumber.ClientID%>').val());

            if (currentPage != 1) {
                $('#aPageItemFirst').attr('href', '/anasayfa');
                $('#aPageItemPrev').attr('href', '/anasayfa?p=' + (currentPage - 1));
            }

            if (currentPage != totalPage) {
                $('#aPageItemNext').attr('href', '/anasayfa?p=' + (currentPage + 1));
                $('#aPageItemLast').attr('href', '/anasayfa?p=' + totalPage);
            }
        });

    </script>
</body>
</html>
