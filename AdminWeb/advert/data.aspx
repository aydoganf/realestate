<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="advert_data" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/design/plugins/select2/select2_metro.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">İlanlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>İlan Ekle/Düzenle</span>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">İlan Ekle/Düzenle</div>
        </div>
        <div class="portlet-body form">
            <div class="portlet-tabs">
                <ul class="nav nav-tabs">
                    <li>
                        <a href="#tab2" data-toggle="tab">
                            <i class="fa fa-picture-o"></i>
                            <span>İlan Fotoğrafları</span>
                        </a>
                    </li>
                    <li class="active">
                        <a href="#tab1" data-toggle="tab">
                            <i class="fa fa-home"></i>
                            <span>İlan Bilgileri</span>
                        </a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="tab1">
                        <div class="form-horizontal">
                            <div class="form-body">
                                <asp:HiddenField ID="hfCurrentAdvert" runat="server" />
                                <div class="alert alert-info">
                                    <h4>Bilgilendirme</h4>
                                    <p>
                                        * ile işaretlenen alanları doldurmak zorundasınız
                                    </p>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Başlık *</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Açıklama *</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Emlak Alanı m<sup>2</sup> *</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbArea" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Emlak Yaşı *</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbAge" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Banyo Sayısı</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbBathCount" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Binadaki Kat Sayısı</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbFloorCount" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Kaçıncı Kat</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlFloor" runat="server" DataTextField="FloorName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Isınma Türü</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlHeatingType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Oda + Salon Bilgisi</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlRoomHall" runat="server" DataTextField="RoomHallName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Emlak Tipi *</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlEstateType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Pazarlama Tipi *</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlMarketingType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Depozito Fiyatı</label>
                                    <div class="col-md-6 row">
                                        <div class="col-md-6">
                                            <asp:TextBox ID="tbDeposit" runat="server" CssClass="form-control input-medium mask_number"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlDepositCurrency" runat="server"
                                                DataTextField="CurrencyName" DataValueField="ObjectId" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Fiyat *</label>
                                    <div class="col-md-6 row">
                                        <div class="col-md-6">
                                            <asp:TextBox ID="tbPrice" runat="server" CssClass="form-control input-medium mask_number"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlPriceCurreny" runat="server" DataTextField="CurrencyName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">İl *</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlCity" runat="server" DataTextField="CityName"
                                            DataValueField="ObjectId" CssClass="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" EnableViewState="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">İlçe *</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlTown" runat="server" DataTextField="TownName"
                                            DataValueField="ObjectId" CssClass="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlTown_SelectedIndexChanged" EnableViewState="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Semt *</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" DataTextField="DistrictName"
                                            DataValueField="ObjectId" CssClass="form-control" EnableViewState="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Lokasyon Seçiniz</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbGAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                        <div id="location" style="width: 100%; height: 400px;"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">İç Özellikler</label>
                                    <div class="col-md-6">
                                        <asp:CheckBoxList ID="cblIcOzellikler" runat="server"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Dış Özellikler</label>
                                    <div class="col-md-6">
                                        <asp:CheckBoxList ID="cblDisOzellikler" runat="server"></asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Konum Özellikleri</label>
                                    <div class="col-md-6">
                                        <asp:CheckBoxList ID="cblKonumOzellikleri" runat="server"></asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:HiddenField ID="hfLat" runat="server" />
                                <asp:HiddenField ID="hfLong" runat="server" />
                                <asp:HiddenField ID="hfAddress" runat="server" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn green" Text="Kaydet" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="tab2">

                        <asp:Panel ID="pnlNoAdvert" runat="server" CssClass="alert alert-danger" Visible="false">
                            <h4>Uyarı !</h4>
                            <p>
                                Öncelikle bir ilan eklemelisiniz.
                            </p>
                        </asp:Panel>

                        <asp:Panel ID="pnlAdvertPhoto" runat="server" Visible="false">
                            
                            <asp:Panel ID="pnlAdvertAdded" runat="server" CssClass="alert alert-success" Visible="false">
                                <h4>Bilgi</h4>
                                <p>
                                    İlan başarıyla eklendi. Şimdi ilana fotoğraf ekleyebilirsiniz.
                                </p>
                            </asp:Panel>

                            <asp:Panel ID="pnlAdvertPhotoAdded" runat="server" CssClass="alert alert-success" Visible="false">
                                <h4>Bilgi</h4>
                                <p>
                                    Fotoğraf başarıyla eklenmiştir. Daha fazla fotoğraf ekleyebilirsiniz.
                                </p>
                            </asp:Panel>

                            <div class="form-horizontal">
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="control-label col-md-3">Fotoğraf *</label>
                                        <div class="col-md-6">
                                            <asp:FileUpload ID="fuPic" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <div class="col-md-offset-3 col-md-9">
                                <asp:Button ID="btnSavePicture" runat="server" CssClass="btn green" Text="Kaydet" OnClick="btnSavePicture_Click" />
                            </div>
                            </div>
                        </asp:Panel>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" runat="Server">
    <script type="text/javascript" src="/design/plugins/select2/select2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('select').select2();
            $(".mask_number").inputmask({
                "mask": "9",
                "repeat": 10,
                "greedy": false
            });
        });
    </script>
    <script type="text/javascript" src='http://maps.google.com/maps/api/js?sensor=false&libraries=places'></script>
    <script type="text/javascript" src="/design/plugins/locationpicker/location.picker.min.js"></script>
    <script type="text/javascript" src="/design/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
    <script type="text/javascript">
        var lat;
        var long;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                if ($('#<%=hfCurrentAdvert.ClientID%>').val() == '') {
                    lat = position.coords.latitude;
                    long = position.coords.longitude;
                } else {
                    lat = $('#<%=hfLat.ClientID%>').val();
                    long = $('#<%=hfLong.ClientID%>').val();
                }

                $("#location").locationpicker({
                    location: { latitude: lat, longitude: long, },
                    locationName: "",
                    radius: 300,
                    zoom: 14,
                    scrollwheel: false,
                    inputBinding: {
                        latitudeInput: $("#<%=hfLat.ClientID%>"),
                        longitudeInput: $("#<%=hfLong.ClientID%>"),
                        radiusInput: null,
                        locationNameInput: $("#<%=tbGAddress.ClientID%>")
                    },
                    enableAutocomplete: true,
                    onchanged: function (currentLocation, radius, isMarkerDropped) {
                        var location = $(this).locationpicker('map').location;
                        $("#<%=hfLat.ClientID%>").val(location.latitude);
                        $("#<%=hfLong.ClientID%>").val(location.longitude);
                        $("#<%=hfAddress.ClientID%>").val(location.formattedAddress);
                        console.log(location);
                    }
                });
            });
        }
    </script>
    <script type="text/javascript">
        function setTab(tabId) {
            $('a[href="#' + tabId + '"]').trigger("click");
        }
    </script>
</asp:Content>

