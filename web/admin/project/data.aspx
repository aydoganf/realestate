<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="admin_project_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/plugins/select2/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/design/plugins/jstree/themes/default/style.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">Projeler</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Proje Ekle/Düzenle</span>
    </li>
    <li class="btn-group">
        <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
            <span>İşlemler
            </span>
            <i class="fa fa-angle-down"></i>
        </button>
        <ul class="dropdown-menu pull-right" role="menu">
            <li>
                <asp:LinkButton ID="lbntActivate" runat="server" Visible="false" OnClick="lbntActivate_Click">
                    <i class="fa fa-bolt"></i> Yayına Al
                </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lbtnDeactivate" runat="server" Visible="false" OnClick="lbtnDeactivate_Click">
                    <i class="fa fa-bolt"></i> Yayından Kaldır
                </asp:LinkButton>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">

    <div class="row">
        <div class="col-md-12">

            <asp:Panel ID="pnlActiveStatus" runat="server" CssClass="text-center" 
                style="background-color:red; color:white; margin-bottom:10px; font-size:18px; padding:15px;" Visible="false">
                Proje henüz yayına alınmamış. Yayına almak için sağ üstten 'İşlemler' kısmından yayına alabilirsiniz.
            </asp:Panel>

            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">Proje Ekle/Düzenle</div>
                </div>
                <div class="portlet-body form">

                    <div class="portlet-tabs">

                        <ul class="nav nav-tabs">
                            <li>
                                <a href="#tab3" data-toggle="tab">
                                    <i class="fa fa-picture-o"></i>
                                    <span>İlgili Konutlar</span>
                                </a>
                            </li>
                            <li>
                                <a href="#tab2" data-toggle="tab">
                                    <i class="fa fa-picture-o"></i>
                                    <span>Proje Fotoğrafları</span>
                                </a>
                            </li>
                            <li class="active">
                                <a href="#tab1" data-toggle="tab">
                                    <i class="fa fa-home"></i>
                                    <span>Proje Bilgileri</span>
                                </a>
                            </li>
                        </ul>

                        <div class="tab-content">

                            <asp:Panel ID="pnlOperationStatus" runat="server" Visible="false">
                                <h4 id="h4StatusTitle" runat="server"></h4>
                                <p id="pStatusInfo" runat="server"></p>
                            </asp:Panel>

                            <div class="tab-pane active" id="tab1">

                                <div class="horizontal-form">
                                    <asp:HiddenField ID="hfCurrentProject" runat="server" />
                                    <div class="form-body">

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">İl *</label>
                                                    <asp:DropDownList ID="ddlCity" runat="server" DataTextField="CityName"
                                                        DataValueField="ObjectId" CssClass="form-control"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" EnableViewState="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">İlçe *</label>
                                                    <asp:DropDownList ID="ddlTown" runat="server" DataTextField="TownName"
                                                        DataValueField="ObjectId" CssClass="form-control"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlTown_SelectedIndexChanged" EnableViewState="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Semt *</label>
                                                    <asp:DropDownList ID="ddlDistrict" runat="server" DataTextField="DistrictName"
                                                        DataValueField="ObjectId" CssClass="form-control" EnableViewState="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Proje Adı</label>
                                                    <asp:TextBox ID="tbProjectName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Projedeki Konut Sayısı</label>
                                                    <asp:TextBox ID="tbProjectHousingCount" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Toplam Proje Alanı</label>
                                                    <asp:TextBox ID="tbProjectTotalArea" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Metrekare Aralığı</label>
                                                    <asp:TextBox ID="tbAreaRange" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Oda Seçenekleri</label>
                                                    <asp:TextBox ID="tbRoomOptions" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Teslim Tarihi</label>
                                                    <asp:TextBox ID="tbDeliveryDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">Açıklama</label>
                                                    <asp:TextBox ID="tbProjectDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <!-- Google Lokasyon Bilgisi -->
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label"></label>
                                                    <asp:TextBox ID="tbGAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <div id="location" style="width: 100%; height: 400px;"></div>
                                                </div>
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
                            <div class="tab-pane" id="tab3">

                                <asp:Panel ID="pnlNoProject" runat="server" CssClass="alert alert-danger" Visible="false">
                                    <h4>Uyarı !</h4>
                                    <p>
                                        Öncelikle bir proje eklemelisiniz.
                                    </p>
                                </asp:Panel>

                                <asp:Panel ID="pnlProjectAdvert" runat="server" Visible="false">

                                    <asp:Panel ID="pnlProjectAdded" runat="server" CssClass="alert alert-success" Visible="false">
                                        <h4>Bilgi</h4>
                                        <p>
                                            Proje başarıyla eklendi. Şimdi projeye bağlantılı ilanları belirleyebilirsiniz.
                                        </p>
                                    </asp:Panel>


                                    <asp:Repeater ID="rptProjectAdvert" runat="server" OnItemCommand="rptProjectAdvert_ItemCommand">
                                        <HeaderTemplate>
                                            <div class="row">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="col-md-3 margin-bottom-10">
                                                <%#Eval("HousingTypeName") %><br />
                                                <a href="../advert/data.aspx?advert=<%#Eval("Advert.ObjectId") %>"><img src="/uploads/<%#Eval("Advert.PrimaryAdvertPhoto") %>" class="img-responsive" /></a>
                                                <div class="text-center">
                                                    <%#Eval("Advert.Title") %><br />
                                                    <asp:LinkButton ID="lbtnDeleteProjectAdvert" runat="server" CssClass="btn btn-danger"
                                                        CommandName="deleteProjectAdvert" CommandArgument='<%#Eval("ObjectId") %>'
                                                        OnClientClick="return confirm('Bu konutu projeden kaldırmak istediğinize emin misiniz?');">
                                                        <i class="fa fa-trash-o"></i>&nbsp;Kaldır
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
                                    <div class="horizontal-form">
                                        <div class="form-body">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label">Konut Çeşidi (Ör: 2+1 Daire)</label>
                                                        <asp:TextBox runat="server" ID="tbProjectAdvertHousingName" CssClass="form-control" />
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label">İlgili İlan (İlan numarası giriniz)</label>
                                                        <asp:TextBox ID="tbProjectAdvertRelated" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button ID="btnSaveProjectAdvertRelation" runat="server" CssClass="btn green" Text="Kaydet" OnClick="btnSaveProjectAdvertRelation_Click" />                                        
                                    </div>

                                </asp:Panel>

                            </div>
                            <div class="tab-pane" id="tab2">

                                <asp:Panel ID="pnlNoProjectForPhoto" runat="server" CssClass="alert alert-danger" Visible="false">
                                    <h4>Uyarı !</h4>
                                    <p>
                                        Öncelikle bir proje eklemelisiniz.
                                    </p>
                                </asp:Panel>

                                <asp:Panel ID="pnlProjectPhoto" runat="server" Visible="false">                                                                       

                                    <asp:Panel ID="pnlProjectPhotoAdded" runat="server" CssClass="alert alert-success" Visible="false">
                                        <h4>Bilgi</h4>
                                        <p>
                                            Fotoğraf başarıyla eklenmiştir. Daha fazla fotoğraf ekleyebilirsiniz.
                                        </p>
                                    </asp:Panel>

                                    <asp:Repeater ID="rptProjectPhotos" runat="server" OnItemCommand="rptProjectPhotos_ItemCommand">
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
                                            <asp:Button ID="btnSavePicture" runat="server" CssClass="btn green" Text="Fotoğrafı Kaydet" OnClick="btnSavePicture_Click" />                                            
                                        </div>
                                    </div>
                                </asp:Panel>

                            </div>
                        </div>

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
        function setTab(tabId) {
            $('a[href="#' + tabId + '"]').trigger("click");
        }

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
    <script type="text/javascript" src="/admin/design/plugins/locationpicker/location.picker.min.js"></script>
    <script type="text/javascript">
        var lat;
        var long;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                if ($('#<%=hfCurrentProject.ClientID%>').val() == '') {
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
</asp:Content>

