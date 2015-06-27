<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    İletişim
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRightSide" runat="Server">
    <div id="main" class="span9">
        <article class="clearfix page type-page">
            <header class="entry-header">

                <h1 class="page-header entry-title">İletişim
                </h1>


            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <div class="row">
                    <div class="span1"><b>Adres:</b></div>
                    <div class="span6">Batı Mah. Ortanca Cad. No:13/B Pendik-İSTANBUL </div>
                </div>
                <div class="row">
                    <div class="span1"><b>Telefon:</b></div>
                    <div class="span6">0(216) 491 11 65 </div>
                </div>
                <div class="row">
                    <div class="span1"><b>Fax:</b></div>
                    <div class="span6">0(216) 491 11 66 </div>
                </div>
                <div class="row">
                    <div class="span1"><b>Gsm:</b></div>
                    <div class="span6">0554 563 98 38 </div>
                </div>

                <div class="mb-10 clearfix">&nbsp;</div>
                <div class="row">
                    <div class="span9">
                        <div id="map" style="position: relative; background-color: rgb(229, 227, 223); overflow: hidden; -webkit-transform: translateZ(0); height:400px"></div>
                    </div>
                </div>
                

                <div class="mb-20 clearfix">&nbsp;</div>

                <asp:Panel ID="pnlStatus" runat="server" Visible="false" CssClass="mb-20">

                </asp:Panel>

                <h2>Bize Mesaj Gönderin</h2>

                <div class="contact-form">

                        <div class="controls">
                            <div class="row">
                                <div class="span4">
                                    <label>Adınız soyadınız</label>
                                    <span class="your-name">
                                        <asp:TextBox ID="tbName" runat="server" size="40"></asp:TextBox>
                                    </span>
                                </div>
                                <div class="span5">
                                    <label>E-mail adresiniz</label>
                                    <span class="your-email">
                                        <asp:TextBox ID="tbEmail" runat="server" size="40"></asp:TextBox>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <div class="controls">
                            <label>Mesajınız</label>
                            <span class="your-message">
                                <asp:TextBox ID="tbMessage" runat="server" TextMode="MultiLine" Columns="40" Rows="10" CssClass="span7"></asp:TextBox>
                            </span>
                        </div>

                        <div class="controls">
                            <asp:Button ID="btnSendMessage" runat="server" CssClass="btn btn-primary input-medium" OnClick="btnSendMessage_Click" Text="Gönder" />
                        </div>
                </div>


            </div>
            <!-- .entry-content -->
        </article>
        <!-- /#post -->


    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphJS" runat="Server">
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            var long = 29.230991;
            var lat = 40.877022;

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

                var map = new google.maps.Map(document.getElementById('map'), mapOptions);

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

            document.getElementById("map").addEventListener("touchstart", thisTouchStart, true);
            document.getElementById("map").addEventListener("touchend", thisTouchEnd, true);
            document.getElementById("map").addEventListener("touchmove", thisTouchMove, true);


            $('#<%=btnSendMessage.ClientID%>').click(function () {

                var name = $('#<%=tbName.ClientID%>').val();
                var email = $('#<%=tbEmail.ClientID%>').val();
                var message = $('#<%=tbMessage.ClientID%>').val();

                if (name == '' || email == '' || message == '') {
                    alert('Lütfen bütün alanları eksiksiz doldurunuz.');
                    return false;
                }

            });
        });
    </script>
</asp:Content>

