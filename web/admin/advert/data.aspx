<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="advert_data" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/plugins/select2/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/design/plugins/jstree/themes/default/style.min.css" />
    <style>
        .table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td {
            border-top:0 !important;
        }
    </style>
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
    <div class="row">
        <div class="col-md-12">
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
                                <div class="horizontal-form">
                                    <div class="form-body">
                                        <asp:HiddenField ID="hfCurrentAdvert" runat="server" />
                                        <div class="alert alert-info">
                                            <h4>Bilgilendirme</h4>
                                            <p>
                                                * ile işaretlenen alanları doldurmak zorundasınız
                                            </p>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Parazlama Tipi *</label>
                                                    <asp:DropDownList ID="ddlMarketingType" runat="server" DataTextField="TypeName"
                                                        DataValueField="ObjectId" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label"></label>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label"></label>
                                                </div>
                                            </div>
                                        </div>

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
                                                    <label class="control-label">Emlak Tipi *</label>
                                                    <asp:HiddenField ID="hfSelectedEstateTypeId" runat="server" />
                                                    <asp:HiddenField ID="hfSelectedEstateTypeName" runat="server" />
                                                    <asp:Button ID="btnSelectBaseEstateType" runat="server" CssClass="hidden" OnClick="btnSelectBaseEstateType_Click" />
                                                    <div class="jstree-holder" style="height: 250px; overflow-y: auto">
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
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Fiyat *</label>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="tbPrice" runat="server" CssClass="form-control input-medium mask_number"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:DropDownList ID="ddlPriceCurreny" runat="server" DataTextField="CurrencyName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Depozito Fiyatı</label>
                                                    <div class="row">
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
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Emlak Alanı m<sup>2</sup> *</label>
                                                    <asp:TextBox ID="tbArea" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">İlan Sahibi</label>
                                                    <asp:DropDownList ID="ddlAdvertOwner" runat="server"
                                                        DataTextField="TypeName" DataValueField="ObjectId" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label">Takas Durumu</label>
                                                    <asp:DropDownList ID="ddlIsExchangable" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="" Selected="True">Seçiniz</asp:ListItem>
                                                        <asp:ListItem Value="1">Evet</asp:ListItem>
                                                        <asp:ListItem Value="0">Hayır</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>


                                        <!-- Tipe Göre Gelen Paneller ve Bilgileri -->
                                        <asp:Panel ID="pnlKonut" runat="server" Visible="false">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Bulunduğu Kat</label>
                                                        <asp:DropDownList ID="ddlFloorKonut" runat="server" DataTextField="FloorName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Binadaki Kat Sayısı</label>
                                                        <asp:TextBox ID="tbFloorCountKonut" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Bina Yaşı</label>
                                                        <asp:TextBox ID="tbAgeKonut" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Oda + Salon</label>
                                                        <asp:DropDownList ID="ddlRoomHallKonut" runat="server" DataTextField="RoomHallName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Banyo Sayısı</label>
                                                        <asp:TextBox ID="tbBathCountKonut" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Isınma Tipi</label>
                                                        <asp:DropDownList ID="ddlHeatingTypeKonut" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yakıt Tipi</label>
                                                        <asp:DropDownList ID="ddlFuelTypeKonut" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yapının Durumu</label>
                                                        <asp:DropDownList ID="ddlAdvertStatusKonut" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Kullanım Durumu</label>
                                                        <asp:DropDownList ID="ddlAdvertUsingKonut" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Krediye Uygunluk</label>
                                                        <asp:DropDownList ID="ddlCreditTypeKonut" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Tapu Durumu</label>
                                                        <asp:DropDownList ID="ddlDeedTypeKonut" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label"></label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label class="control-label"></label>

                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlIsyeri" runat="server" Visible="false">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Bulunduğu Kat</label>
                                                        <asp:DropDownList ID="ddlFloorIsyeri" runat="server"
                                                            DataTextField="FloorName" DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Bina Yaşı</label>
                                                        <asp:TextBox ID="tbAgeIsyeri" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Oda / Bölüm Sayısı</label>
                                                        <asp:TextBox ID="tbRoomCountIsyeri" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Isınma Tipi</label>
                                                        <asp:DropDownList ID="ddlHeatingTypeIsyeri" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yakıt Tipi</label>
                                                        <asp:DropDownList ID="ddlFuelTypeIsyeri" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yapının Durumu</label>
                                                        <asp:DropDownList ID="ddlAdvertStatusIsyeri" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Kullanım Durumu</label>
                                                        <asp:DropDownList ID="ddlAdvertUsingIsyeri" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Krediye Uygunluk</label>
                                                        <asp:DropDownList ID="ddlCreditTypeIsyeri" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Devren</label>
                                                        <asp:DropDownList ID="ddlIsSubleaseIsyeri" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="Hayır"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlArsa" runat="server" Visible="false">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Kat Karşılığı</label>
                                                        <asp:RadioButtonList ID="rdbtnIsFlatForLandMethod" runat="server">
                                                            <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="Hayır" Selected="True"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Krediye Uygunluk</label>
                                                        <asp:DropDownList ID="ddlCreditTypeArsa" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Tapu Durumu</label>
                                                        <asp:DropDownList ID="ddlDeedTypeArsa" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlDevremulk" runat="server" Visible="false">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Bulunduğu Kat</label>
                                                        <asp:DropDownList ID="ddlFloorDevremulk" runat="server"
                                                            DataTextField="FloorName" DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Bina Yaşı</label>
                                                        <asp:TextBox ID="tbAgeDevremulk" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Oda + Salon</label>
                                                        <asp:DropDownList ID="ddlRoomHallDevremulk" runat="server" DataTextField="RoomHallName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Banyo Sayısı</label>
                                                        <asp:TextBox ID="tbbathCountDevremulk" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Devren</label>
                                                        <asp:DropDownList ID="ddlIsSubleaseDevremulk" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="Hayır"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Isınma Tipi</label>
                                                        <asp:DropDownList ID="ddlHeatingTypeDevremulk" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yakıt Tipi</label>
                                                        <asp:DropDownList ID="ddlFuelTypeDevremulk" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yapının Durumu</label>
                                                        <asp:DropDownList ID="ddlAdvertStatusDevremulk" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label"></label>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlTuristik" runat="server" Visible="false">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Oda / Bölüm Sayısı</label>
                                                        <asp:TextBox ID="tbRoomCountTuristik" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yıldız Sayısı</label>
                                                        <asp:DropDownList ID="ddlStarCountTuristik" runat="server"
                                                            DataTextField="TypeName" DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Yatak Sayısı</label>
                                                        <asp:TextBox ID="tbBedCountTuristik" runat="server" CssClass="form-control mask_number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">Tapu Durumu</label>
                                                        <asp:DropDownList ID="ddlDeedTypeTuristik" runat="server" DataTextField="TypeName"
                                                            DataValueField="ObjectId" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label">İskan Durumu</label>
                                                        <asp:DropDownList ID="ddlIsSettlementTuristik" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="Hayır"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="control-label"></label>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>


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

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label"></label>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label"></label>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="control-label"></label>
                                                </div>
                                            </div>
                                        </div>

                                        <!-- Başlık & Açıklama -->
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">Başlık *</label>
                                                    <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">Açıklama *</label>
                                                    <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <!-- Ekstra Özellikler -->
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">&nbsp;</label>
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
                                                                    <div class="table-responsive">
                                                                        <asp:CheckBoxList ID="cblFeatureList" runat="server"
                                                                            RepeatDirection="Horizontal" RepeatColumns="5" RepeatLayout="Table"
                                                                            DataTextField="FeatureName" DataValueField="ObjectId" CssClass="table table-advance">
                                                                        </asp:CheckBoxList>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
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

                if ($('#<%=hfCurrentAdvert.ClientID%>').val() != '' || $('#<%=hfSelectedEstateTypeId.ClientID%>').val() != '') {
                    $('#jstree').bind("loaded.jstree", function () {
                        $('#konu-kodu-arama').val($('#<%=hfSelectedEstateTypeName.ClientID%>').val());
                        //$("#jstree").jstree("select_node", $('#<%=hfSelectedEstateTypeId.ClientID%>').val(), false).trigger("select_node.jstree");
                    });
                }

                $('#jstree').bind("select_node.jstree", function (e, data) {
                    $('#<%=hfSelectedEstateTypeId.ClientID%>').val(data.node.id);
                    $('#<%=btnSelectBaseEstateType.ClientID%>').click();
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

