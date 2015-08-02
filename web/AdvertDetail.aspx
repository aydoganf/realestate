<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdvertDetail.aspx.cs" Inherits="AdvertDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCSS" runat="Server">
    <style type="text/css">
        .single-property .property-detail ul li {
            padding-bottom: 0 !important;
            margin-bottom: 0 !important;
        }

        .tab-content {
            background-color: white !important;
            padding: 0 !important;
            -webkit-box-shadow: none !important;
        }

        .nav-tabs {
            /*border-bottom:none !important;*/
        }

        .nav {
            margin-bottom: 10px !important;
        }

        .tabbable.tabbable-custom.tabbable-full-width {
            /*margin-left: 30px !important;*/
        }

        .single-property .property-detail ul li {
            padding-left: 0 !important;
            font-size: 12px;
        }

        .single-property .property-detail ul .checked, .single-property .property-detail ul .plain {
            padding-left: 30px !important;
        }

        .single-property .property-detail .overview table tbody tr th {
            font-size:12px !important;
        }

        .single-property .property-detail .overview table tbody tr td {
            font-size:12px !important;
        }

        .single-property .property-detail .overview table tbody tr .price {
            font-size:22px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <asp:Label ID="lblNavigation" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRightSide" runat="Server">
    <div id="main" class="span9 single-property">

        <h1 class="page-header fl"><%=CurrentAdvert.Title %></h1>

        <div class="property-detail">

            <div class="row">
                <div class="span6 gallery">
                    <div class="preview">
                        <img src="/uploads/<%=CurrentAdvert.PrimaryAdvertPhoto %>" alt="">
                    </div>

                    <div class="content">
                        <ul>
                            <asp:Repeater ID="rptPhotos" runat="server">
                                <ItemTemplate>
                                    <li class="<%#Container.ItemIndex == 0 ? "active" : "" %>">
                                        <div class="thumb">
                                            <a href="#">
                                                <img src="/uploads/<%#Eval("PhotoName") %>" /></a>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!-- /.content -->
                </div>

                <div class="overview">
                    <div class="pull-right overview">
                        <div class="row">
                            <div class="span3">
                                <!-- <h2>Overview</h2> -->

                                <table>
                                    <tbody>
                                        <tr>
                                            <th></th>
                                            <td class="price"><%=FormatPrice(CurrentAdvert.Price) %> <%=CurrentAdvert.PriceCurrency.CurrencyName %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <th>İlan No:</th>
                                            <td><strong><%=CurrentAdvert.AdvertNumber %></strong></td>
                                        </tr>

                                        <tr>
                                            <th>İlan Tarihi:</th>
                                            <td><%= ((DateTime)CurrentAdvert.UpdateDate).ToString("dd.MM.yyyy") %></td>
                                        </tr>

                                        <tr>
                                            <th>Metrekare:</th>
                                            <td><%=CurrentAdvert.Area %> m<sup>2</sup></td>
                                        </tr>

                                        <tr>
                                            <th>
                                                <asp:Label ID="lblParentEstateTypeName" runat="server"></asp:Label>
                                                Tipi:</th>
                                            <td>
                                                <%=CurrentAdvert.MarketingType.TypeName %> <%=CurrentAdvert.EstateType.TypeName %>
                                            </td>
                                        </tr>

                                        <asp:Panel ID="pnlKonutBilgileri" runat="server" Visible="false">
                                            <% if (CurrentAdvert.BathCount.HasValue)
                                               {                                                   
                                                %>
                                            <tr>
                                                <th>Banyo Sayısı:</th>
                                                <td>
                                                    <%=CurrentAdvert.BathCount %>
                                                </td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.FloorCount.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Kat Sayısı:</th>
                                                <td><%=CurrentAdvert.FloorCount %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.FloorObjectId.HasValue)
                                               {
                                               %>
                                            <tr>
                                                <th>Bulunduğu Kat:</th>
                                                <td><%=CurrentAdvert.Floor.FloorName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.RoomHallObjectId.HasValue)
                                               {
                                               %>
                                            <tr>
                                                <th>Oda + Salon:</th>
                                                <td><%=CurrentAdvert.RoomHall.RoomHallName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.FuelTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Yakıt Tipi:</th>
                                                <td><%=CurrentAdvert.FuelType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.HeatingTypeObjectId.HasValue)
                                               {
                                                 %>
                                            <tr>
                                                <th>Isınma Tipi:</th>
                                                <td><%= CurrentAdvert.HeatingType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.AdvertStatusObjectId.HasValue)
                                               {
                                                 %>
                                            <tr>
                                                <th>Yapının Durumu:</th>
                                                <td><%=CurrentAdvert.AdvertStatus.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.AdvertUsingTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Kullanım Durumu:</th>
                                                <td><%=CurrentAdvert.AdvertUsingType.TypeName %></td>
                                            </tr>
                                            <% } %>
                                        </asp:Panel>
                                        
                                        <asp:Panel ID="pnlIsyeriBilgileri" runat="server" Visible="false">
                                            <% if (CurrentAdvert.RoomCount.HasValue)
                                               {
                                                   %>
                                            <tr>
                                                <th>Bölüm:</th>
                                                <td><%=CurrentAdvert.RoomCount %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.Age.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Bina Yaşı:</th>
                                                <td><%=CurrentAdvert.Age %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.FloorObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Bulunduğu Kat:</th>
                                                <td><%=CurrentAdvert.Floor.FloorName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.FloorCount.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Kat Sayısı:</th>
                                                <td><%=CurrentAdvert.FloorCount %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.HeatingTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Isınma Tipi:</th>
                                                <td><%= CurrentAdvert.HeatingType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.FuelTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Yakıt Tipi:</th>
                                                <td><%= CurrentAdvert.FuelType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.AdvertStatusObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Yapının Durumu:</th>
                                                <td><%=CurrentAdvert.AdvertStatus.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.AdvertUsingTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Kullanım Durumu:</th>
                                                <td><%=CurrentAdvert.AdvertUsingType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.CreditTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Krediye Uygunluk:</th>
                                                <td><%=CurrentAdvert.CreditType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.IsExchangable.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Takas:</th>
                                                <td><%=(bool)CurrentAdvert.IsExchangable ? "Evet" : "Hayır"  %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.IsSublease.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Devren:</th>
                                                <td><%=(bool)CurrentAdvert.IsSublease ? "Evet" : "Hayır"  %></td>
                                            </tr>
                                            <% } %>
                                        </asp:Panel>
                                        
                                        <asp:Panel ID="pnlArsaBilgileri" runat="server" Visible="false">
                                            <% if (CurrentAdvert.CreditTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Krediye Uygunluk:</th>
                                                <td><%=CurrentAdvert.CreditType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.IsFlatForLandMethod.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Kat Karşılığı</th>
                                                <td><%=(bool)CurrentAdvert.IsFlatForLandMethod ? "Evet" : "Hayır" %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.DeedTypeObjectId.HasValue)
                                               {
                                                 %>
                                            <tr>
                                                <th>Tapu Durumu</th>
                                                <td><%=CurrentAdvert.DeedType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.IsExchangable.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Takas:</th>
                                                <td><%= (bool)CurrentAdvert.IsExchangable ? "Evet" : "Hayır" %></td>
                                            </tr>
                                            <% } %>
                                        </asp:Panel>
                                        
                                        <asp:Panel ID="pnlDevremulkBilgileri" runat="server" Visible="false">
                                            <% if (CurrentAdvert.FloorObjectId.HasValue)
                                               {
                                            %>
                                            <tr>
                                                <th>Bulunduğu Kat:</th>
                                                <td><%=CurrentAdvert.Floor.FloorName %></td>
                                            </tr>
                                            <% } %>

                                            <%if (CurrentAdvert.BathCount.HasValue)
                                              {
                                               %>
                                            <tr>
                                                <th>Banyo Sayısı:</th>
                                                <td><%=CurrentAdvert.BathCount %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.RoomHallObjectId.HasValue)
                                               {
                                                 %>
                                            <tr>
                                                <th>Oda + Salon:</th>
                                                <td><%=CurrentAdvert.RoomHall.RoomHallName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.HeatingTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Isınma Tipi:</th>
                                                <td><%=CurrentAdvert.HeatingType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.FuelTypeObjectId.HasValue)
                                               {
                                                 %>
                                            <tr>
                                                <th>Yakıt Tipi:</th>
                                                <td><%=CurrentAdvert.FuelType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.AdvertStatusObjectId.HasValue)
                                               {
                                                 %>
                                            <tr>
                                                <th>Yapının Durumu:</th>
                                                <td><%=CurrentAdvert.AdvertStatus.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.IsExchangable.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Takas:</th>
                                                <td><%=(bool)CurrentAdvert.IsExchangable ? "Evet" : "Hayır" %></td>
                                            </tr>
                                            <% } %>
                                        </asp:Panel>
                                        
                                        <asp:Panel ID="pnlTuristikBilgileri" runat="server" Visible="false">
                                            <% if (CurrentAdvert.RoomCount.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Oda / Bölüm Sayısı:</th>
                                                <td><%=CurrentAdvert.RoomCount %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.StarCountObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Yıldız Sayısı:</th>
                                                <td><%=CurrentAdvert.StarCount.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.BedCount.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Yatak Sayısı:</th>
                                                <td><%=CurrentAdvert.BedCount %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.DeedTypeObjectId.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Tapu Durumu:</th>
                                                <td><%= CurrentAdvert.DeedType.TypeName %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.IsExchangable.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>Takas:</th>
                                                <td><%=(bool)CurrentAdvert.IsExchangable ? "Evet" : "Hayır" %></td>
                                            </tr>
                                            <% } %>

                                            <% if (CurrentAdvert.IsSettlement.HasValue)
                                               {
                                                %>
                                            <tr>
                                                <th>İskan Durumu:</th>
                                                <td><%=(bool)CurrentAdvert.IsSettlement ? "Evet" : "Hayır" %></td>
                                            </tr>
                                            <% } %>
                                        </asp:Panel>
                                        
                                    </tbody>
                                </table>
                            </div>
                            <!-- /.span2 -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.overview -->
                </div>
            </div>

            <div class="mb-20">&nbsp;</div>
            <h2>Emlak Bilgileri</h2>

            <p>
                <%=CurrentAdvert.Description %>
            </p>


            <div class="row">
                <div class="span9">
                    <div class="row">
                        <div class="span9">
                            <%--<h2>General amenities</h2>--%>
                            <div class="mb-20">&nbsp;</div>

                            <div class="row">
                                <div class="tabbable tabbable-custom tabbable-full-width">
                                    <ul class="nav nav-tabs">
                                        <asp:Repeater ID="rptFeatureType" runat="server">
                                            <ItemTemplate>
                                                <li class="<%#Container.ItemIndex == 0 ? "active" : "" %>">
                                                    <a href="#tabFeatureType<%#Container.ItemIndex+1 %>" data-toggle="tab">
                                                        <%#Eval("TypeName") %>
                                                    </a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <div class="tab-content">
                                    <asp:Repeater ID="rptFeatureTypeTabs" runat="server" OnItemDataBound="rptFeatureTypeTabs_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="tab-pane <%#Container.ItemIndex == 0 ? "active" : "" %>" id="tabFeatureType<%#Container.ItemIndex+1 %>">
                                                <asp:Repeater ID="rptFeatures" runat="server" OnItemDataBound="rptFeatures_ItemDataBound">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <ul class="span2">
                                                            <li id="liFeature" runat="server"><%#Eval("FeatureName") %></li>
                                                        </ul>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.span12 -->
                    </div>
                    <!-- /.row -->
                </div>

                <div class="span3">
                </div>

            </div>

            <div class="row">
                <div class="span9">
                    <div class="row">
                        <div class="span9">
                            <div class="mb-20">&nbsp;</div>
                            <h2>Harita</h2>
                            <asp:HiddenField ID="hfLong" runat="server" />
                            <asp:HiddenField ID="hfLat" runat="server" />
                            <div id="property-map"
                                style="position: relative; background-color: rgb(229, 227, 223); overflow: hidden; -webkit-transform: translateZ(0);">
                            </div>

                            <script type="text/javascript">
                                var long;
                                var lat;

                                jQuery(document).ready(function ($) {

                                    long = $('#<%=hfLong.ClientID%>').val();
                                    lat = $('#<%=hfLat.ClientID%>').val();

                                    function LoadMapProperty() {
                                        var locations = new Array(
                                          [lat, long]
                                        );
                                        var types = new Array(
                                          'family-house'
                                        );
                                        var markers = new Array();
                                        var plainMarkers = new Array();

                                        var mapOptions = {
                                            center: new google.maps.LatLng(lat, long),
                                            zoom: 16,
                                            mapTypeId: google.maps.MapTypeId.ROADMAP,
                                            scrollwheel: false
                                        };

                                        var map = new google.maps.Map(document.getElementById('property-map'), mapOptions);

                                        $.each(locations, function (index, location) {
                                            var marker = new google.maps.Marker({
                                                position: new google.maps.LatLng(location[0], location[1]),
                                                map: map,
                                                icon: '/assets/img/marker-transparent.png'
                                            });

                                            var myOptions = {
                                                draggable: true,
                                                content: '<div class="marker ' + types[index] + '"><div class="marker-inner"></div></div>',
                                                disableAutoPan: true,
                                                pixelOffset: new google.maps.Size(-21, -58),
                                                position: new google.maps.LatLng(location[0], location[1]),
                                                closeBoxURL: "",
                                                isHidden: false,
                                                // pane: "mapPane",
                                                enableEventPropagation: true
                                            };
                                            marker.marker = new InfoBox(myOptions);
                                            marker.marker.isHidden = false;
                                            marker.marker.open(map, marker);
                                            markers.push(marker);
                                        });

                                        google.maps.event.addListener(map, 'zoom_changed', function () {
                                            $.each(markers, function (index, marker) {
                                                marker.infobox.close();
                                            });
                                        });
                                    }

                                    google.maps.event.addDomListener(window, 'load', LoadMapProperty);

                                    var dragFlag = false;
                                    var start = 0, end = 0;

                                    function thisTouchStart(e) {
                                        dragFlag = true;
                                        start = e.touches[0].pageY;
                                    }

                                    function thisTouchEnd() {
                                        dragFlag = false;
                                    }

                                    function thisTouchMove(e) {
                                        if (!dragFlag) return;
                                        end = e.touches[0].pageY;
                                        window.scrollBy(0, (start - end));
                                    }

                                    document.getElementById("property-map").addEventListener("touchstart", thisTouchStart, true);
                                    document.getElementById("property-map").addEventListener("touchend", thisTouchEnd, true);
                                    document.getElementById("property-map").addEventListener("touchmove", thisTouchMove, true);
                                });

                            </script>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphJS" runat="Server">
    <script type="text/javascript">
        var li = function (text, isChecked) {
            var text = text;
            var isChecked = isChecked;
            var getText = function () {
                return this.text;
            };
            var getIsChecked = function () {
                return this.isChecked;
            };
        };

        $(document).ready(function () {

            //var col = 4;

            //$('.tab-content .tab-pane').each(function () {

            //    var elemCount = $(this).find('ul.span2 li').size();
            //    var x = Math.ceil(elemCount / col);
            //    var liSet = new Array(elemCount);

            //    var htmlLi = '<ul class="span2">';

            //    $(this).find('ul.span2 li').each(function (index) {                    
            //        var t = $(this).text();
            //        var c = $(this).data('checked');
            //        if (elemCount % x == 0) {
            //            if (elemCount != 0) {
            //                htmlLi += '</ul><ul class="span2">' + '<li>' + t + '</li>';
            //            } else {
            //                htmlLi += '<li>' + t + '</li>';
            //            }
            //        } else {
            //            htmlLi += '<li>' + t + '</li>';
            //        }
            //    });

            //    htmlLi += '</ul>';
            //    $(this).find('ul.span2').hide();
            //    $(this).html(htmlLi);

            //    console.log(htmlLi);
            //});
        });
    </script>
</asp:Content>

