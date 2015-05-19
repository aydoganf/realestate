<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="form-group">
                        <label class="control-label col-md-3">Lokasyon Seçiniz</label>
                        <div class="col-md-6">
                            <input type="text" id="us2-address" class="form-control" />
                            <div id="location" style="width: 100%; height: 400px;"></div>
                            <div class="location-details">
                                <asp:TextBox ID="tbGAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                <input type="text" name="formatted_address" />
                                <input type="text" name="street_address" />
                            </div>
                        </div>
                    </div><asp:HiddenField ID="hfLat" runat="server" />
                    <asp:HiddenField ID="hfLong" runat="server" />
                    <asp:HiddenField ID="hfAddress" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" Runat="Server">
    <script type="text/javascript" src='http://maps.google.com/maps/api/js?sensor=false&libraries=places'></script>
    <script type="text/javascript" src="/admin/design/plugins/locationpicker/location.picker.min.js"></script>
    <script>$('#location').locationpicker({
    location: { latitude: 46.15242437752303, longitude: 2.7470703125 },
    radius: 300,
    inputBinding: {
        latitudeInput: $("#<%=hfLat.ClientID%>"),
        longitudeInput: $("#<%=hfLong.ClientID%>"),
        radiusInput: null,
        locationNameInput: $('#us2-address')
    },
    enableAutocomplete: true
});
</script>
    <%--<script type="text/javascript">
        var lat;
        var long;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                lat = position.coords.latitude;
                long = position.coords.longitude;

                $("#location").locationpicker({
                    location: { latitude: lat, longitude: long },
                    locationName: "",
                    radius: 300,
                    zoom: 14,
                    scrollwheel: true,
                    inputBinding: {
                        latitudeInput: $("#<%=hfLat.ClientID%>"),
                        longitudeInput: $("#<%=hfLong.ClientID%>"),
                        radiusInput: null,
                        locationNameInput: $("#address")
                    },
                    onchanged: function (currentLocation, radius, isMarkerDropped) {
                        var location = $(this).locationpicker('map').location;
                        $("#<%=hfLat.ClientID%>").val(location.latitude);
                        $("#<%=hfLong.ClientID%>").val(location.longitude);
                        $("#<%=hfAddress.ClientID%>").val(location.formattedAddress);
                    }
                });
            });
        }
        });
    </script>--%>
</asp:Content>

