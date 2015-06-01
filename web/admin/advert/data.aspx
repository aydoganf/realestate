<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="advert_data" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/plugins/select2/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/design/plugins/jstree/themes/default/style.min.css" />
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

                    <asp:Panel ID="pnlOperationStatus" runat="server" Visible="false">
                        <h4 id="h4StatusTitle" runat="server"></h4>
                        <p id="pStatusInfo" runat="server"></p>
                    </asp:Panel>

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
                                        <asp:HiddenField ID="hfSelectedEstateTypeId" runat="server" />
                                        <asp:HiddenField ID="hfSelectedEstateTypeName" runat="server" />
                                        <div class="jstree-holder" style="height:250px; overflow-y:auto">
                                            <div class="kk-arama">
                                                <div class="input-group">
                                                    <input type="text" id="konu-kodu-arama" 
                                                        autocomplete="off" onkeydown="if(event.keyCode==13) { $('#kk-ara').click(); return false; }" class="form-control" />
                                                    <span class="input-group-btn">
                                                        <button type="button" id="kk-ara" class="btn blue">arama yap</button>
                                                    </span>
                                                </div>
                                            </div>
                                            <div id="jstree"></div>
                                        </div>
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

                            <asp:Repeater ID="rptAdvertPhotos" runat="server" OnItemCommand="rptAdvertPhotos_ItemCommand">
                                <HeaderTemplate>
                                    <div class="row">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="col-md-3 margin-bottom-10">
                                        <img src="/uploads/<%#Eval("PhotoName") %>" class="img-responsive" />
                                        <div class="text-center">
                                            <asp:LinkButton ID="lbtnDeletePhoto" runat="server" CssClass="btn btn-danger"
                                                CommandName="deletePhoto" CommandArgument='<%#Eval("ObjectId") %>'
                                                OnClientClick="return confirm('Bu fotoğrafı silmek istediğinize emin misiniz?');">
                                                <i class="fa fa-trash-o"></i>&nbsp;Sil
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    <%# (Container.ItemIndex) % 4 == 3 ? "</div><div class='row'>" : ""  %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>

                            <div class="clearfix margin-bottom-25"></div>
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
    <script type="text/javascript" src="/admin/design/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="/admin/design/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$('.bxslider').bxSlider();
            $('select').select2();
            $(".mask_number").inputmask({
                "mask": "9",
                "repeat": 10,
                "greedy": false
            });
        });
    </script>
    <script type="text/javascript" src='http://maps.google.com/maps/api/js?sensor=false&libraries=places'></script>
    <script type="text/javascript" src="/admin/design/plugins/locationpicker/location.picker.min.js"></script>
    <script type="text/javascript" src="/admin/design/plugins/jstree/jstree.min.js"></script>
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
        $(document).ready(function () {
            $('#konu-kodu-arama').keyup(function () {
                if ($(this).val() == '') {
                    $('#kk-ara').click();
                }
            });

            UITree.init();
        });

        var UITree = function () {

            var handleUnitJSTree = function () {
                //Unit Tree
                $('#jstree').jstree({
                    'plugins': ["wholerow", "search", "checkbox", "types"],
                    'core': {
                        "themes": {
                            "responsive": true,
                            "icons": false
                        },
                        "multiple": false,
                        "data": {
                            "type": "POST",
                            "dataType": "json",
                            "contentType": "application/json; charset=utf-8",
                            "url": "<%=Page.ResolveUrl("~/service/service.aspx/GetEstateTypeTreeList")%>",

                            "success": function (retval) {
                                return retval.d;
                            },
                            "failure": function (retval) {
                                OnError(retval);
                                return false;
                            },
                        },
                    },
                    'search': {
                        "show_only_matches": true,
                        "fuzzy": false,
                    },
                    'checkbox': {
                        "three_state": false
                    },


                }).on('check_node.jstree', function (e, data) {

                });

                if ($('#<%=hfCurrentAdvert.ClientID%>').val() != '') {
                    $('#jstree').bind("loaded.jstree", function () {
                        $('#konu-kodu-arama').val($('#<%=hfSelectedEstateTypeName.ClientID%>').val());
                        $("#jstree").jstree("select_node", $('#<%=hfSelectedEstateTypeId.ClientID%>').val(), false).trigger("select_node.jstree");                        
                    });
                }

                $('#jstree').bind("select_node.jstree", function (e, data) {
                    $('#<%=hfSelectedEstateTypeId.ClientID%>').val(data.node.id);
                });

                $('#jstree').bind("deselect_node.jstree", function (e, data) {
                    $('#<%=hfSelectedEstateTypeId.ClientID%>').val('');
                });

                var to = false;
                $('#kk-ara').click(function () {
                    if (to) { clearTimeout(to); }
                    to = setTimeout(function () {
                        var v = $('#konu-kodu-arama').val();
                        $('#jstree').jstree(true).search(v);
                    }, 500);
                });
                //Tree
            }

            return {
                //main function to initiate the module
                init: function () {
                    handleUnitJSTree();
                }

            };

        }();

        function setTab(tabId) {
            $('a[href="#' + tabId + '"]').trigger("click");
        }
    </script>
</asp:Content>

