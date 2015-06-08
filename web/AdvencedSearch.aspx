<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdvencedSearch.aspx.cs" Inherits="AdvencedSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCSS" runat="Server">
    <link href="/assets/libraries/sumoselect/sumoselect.css" rel="stylesheet" />
    <link href="/assets/css/components.css" rel="stylesheet" />
    <style>
        .property-listing input[type="text"], select {
            border-color: #A4A4A4;
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            border-top: 0 !important;
        }

        .tab-content label {
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    Detaylı Arama
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRightSide" runat="Server">
    <div id="main" class="span9 property-listing" runat="server">

        <h1 class="page-header">Detaylı Arama</h1>

        <div class="clearfix"></div>

        <div class="row">
            <div class="span3">
                <label>Pazarlama Tipi</label>
                <asp:DropDownList ID="ddlMarketingType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-sumo"></asp:DropDownList>
            </div>
            <div class="span3">
                <label>Emlak Tipi</label>
                <asp:DropDownList ID="ddlEstateType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-sumo"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlEstateType_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="span3">
                <label>
                    <asp:Label ID="lblEstateTypeText" runat="server"></asp:Label>
                    Tipi</label>
                <asp:ListBox ID="lbSubEstateType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" placeholder="Seçiniz"
                    SelectionMode="Multiple" CssClass="make-multi-sumo"></asp:ListBox>
            </div>
        </div>

        <div class="clearfix mb-20"></div>

        <div class="row">
            <div class="span3">
                <label>İl</label>
                <asp:DropDownList ID="ddlCity" runat="server" DataTextField="CityName" DataValueField="ObjectId" CssClass="make-sumo"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="span3">
                <label>İlçe</label>
                <asp:DropDownList ID="ddlTown" runat="server" DataTextField="TownName" DataValueField="ObjectId" CssClass="make-sumo"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlTown_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="span3">
                <label>Semt</label>
                <asp:ListBox ID="lbDistrict" runat="server" DataTextField="DistrictName" DataValueField="ObjectId" placeholder="Seçiniz"
                    SelectionMode="Multiple" CssClass="make-multi-sumo"></asp:ListBox>
            </div>
        </div>

        <div class="clearfix mb-20"></div>

        <div class="row">
            <div class="span3">
                <label>Fiyat Aralığı</label>
                <div class="left-fifty">
                    <asp:TextBox ID="tbPriceFrom" runat="server" CssClass="mask-number"></asp:TextBox>
                </div>
                <div class="right-fifty">
                    <asp:TextBox ID="tbPriceTo" runat="server" CssClass="mask-number"></asp:TextBox>
                </div>
                <div>
                    <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="make-sumo" DataTextField="CurrencyName" DataValueField="ObjectId"></asp:DropDownList>
                </div>
            </div>
            <div class="span3">
                <label>Metrekare Aralığı</label>
                <div class="left-fifty">
                    <asp:TextBox ID="tbAreaFrom" runat="server" CssClass="mask-number"></asp:TextBox>
                </div>
                <div class="right-fifty">
                    <asp:TextBox ID="tbAreaTo" runat="server" CssClass="mask-number"></asp:TextBox>
                </div>
            </div>
            <div class="span3">
                <label>Takas Durumu</label>
                <asp:DropDownList ID="ddlIsExchangable" runat="server" CssClass="make-sumo">
                    <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Yapılır"></asp:ListItem>
                    <asp:ListItem Value="0" Text="Yapılmaz"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="clearfix mb-20"></div>

        <asp:Panel ID="pnlKonutBilgileri" runat="server" Visible="false">

            <div class="row">
                <div class="span3">
                    <label>Bulunduğu Kat</label>
                    <asp:ListBox ID="lbFloorKonut" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="FloorName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Bina Yaşı</label>
                    <div class="left-fifty">
                        <asp:TextBox ID="tbAgeFromKonut" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                    <div class="right-fifty">
                        <asp:TextBox ID="tbAgeToKonut" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                </div>
                <div class="span3">
                    <label>Oda + Salon</label>
                    <asp:ListBox ID="lbRoomHallKonut" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="RoomHallName" DataValueField="ObjectId"></asp:ListBox>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Banyo Sayısı</label>
                    <asp:DropDownList ID="ddlBathCountKonut" runat="server" CssClass="make-sumo">
                        <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                        <asp:ListItem Value="6" Text="6"></asp:ListItem>
                        <asp:ListItem Value="7" Text="7"></asp:ListItem>
                        <asp:ListItem Value="8" Text="8"></asp:ListItem>
                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Isınma Tipi</label>
                    <asp:ListBox ID="lbHeatingTypeKonut" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="TypeName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Yakıt Tipi</label>
                    <asp:ListBox ID="lbFuelTypeKonut" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="TypeName" DataValueField="ObjectId"></asp:ListBox>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Yapının Durumu</label>
                    <asp:DropDownList ID="ddlAdvertStatusTypeKonut" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Kullanım Durumu</label>
                    <asp:DropDownList ID="ddlAdvertUsingTypeKonut" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Krediye Uygunluk</label>
                    <asp:DropDownList ID="ddlCreditTypeKonut" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Tapu Durumu</label>
                    <asp:DropDownList ID="ddlDeedTypeKonut" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-sumo" DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label></label>
                </div>
                <div class="span3">
                    <label></label>
                </div>
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlIsyeriBilgileri" runat="server" Visible="false">

            <div class="row">
                <div class="span3">
                    <label>Bulunduğu Kat</label>
                    <asp:ListBox ID="lbFloorIsyeri" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="FloorName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Bina Yaşı</label>
                    <div class="left-fifty">
                        <asp:TextBox ID="tbAgeFromIsyeri" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                    <div class="right-fifty">
                        <asp:TextBox ID="tbAgeToIsyeri" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                </div>
                <div class="span3">
                    <label>Oda / Bölüm Sayısı</label>
                    <div class="left-fifty">
                        <asp:TextBox ID="tbRoomCountFromIsyeri" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                    <div class="right-fifty">
                        <asp:TextBox ID="tbRoomCountToIsyeri" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Isınma Tipi</label>
                    <asp:ListBox ID="lbHeatingTypeIsyeri" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="TypeName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Yakıt Tipi</label>
                    <asp:ListBox ID="lbFuelTypeIsyeri" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="TypeName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Yapının Durumu</label>
                    <asp:DropDownList ID="ddlAdvertStatusTypeIsyeri" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Kullanım Durumu</label>
                    <asp:DropDownList ID="ddlAdvertUsingTypeIsyeri" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Kerdiye Uygunluk</label>
                    <asp:DropDownList ID="ddlCreditTypeIsyeri" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Devren</label>
                    <asp:DropDownList ID="ddlIsSubleaseIsyeri" runat="server" CssClass="make-sumo">
                        <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                        <asp:ListItem Value="0" Text="Hayır"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlArsaBilgileri" runat="server" Visible="false">

            <div class="row">
                <div class="span3">
                    <label>Kat Karşılığı</label>
                    <asp:DropDownList ID="ddlIsFlatForLandMethodArsa" runat="server" CssClass="make-sumo">
                        <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                        <asp:ListItem Value="0" Text="Hayır"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Krediye Uygunluk</label>
                    <asp:DropDownList ID="ddlCreditTypeArsa" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Tapu Durumu</label>
                    <asp:DropDownList ID="ddlDeedTypeArsa" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-sumo" DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlDevremulkBilgileri" runat="server" Visible="false">

            <div class="row">
                <div class="span3">
                    <label>Bulunduğu Kat</label>
                    <asp:ListBox ID="lbFloorDevremulk" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="FloorName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Bina Yaşı</label>
                    <div class="left-fifty">
                        <asp:TextBox ID="tbAgeFromDevremulk" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                    <div class="right-fifty">
                        <asp:TextBox ID="tbAgeToDevremulk" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                </div>
                <div class="span3">
                    <label>Oda + Salon</label>
                    <asp:ListBox ID="lbRoomHallDevremulk" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="RoomHallName" DataValueField="ObjectId"></asp:ListBox>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Banyo Sayısı</label>
                    <asp:DropDownList ID="ddlBathCountDevremulk" runat="server" CssClass="make-sumo">
                        <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                        <asp:ListItem Value="6" Text="6"></asp:ListItem>
                        <asp:ListItem Value="7" Text="7"></asp:ListItem>
                        <asp:ListItem Value="8" Text="8"></asp:ListItem>
                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Devren</label>
                    <asp:DropDownList ID="ddlIsSubleaseDevremulk" runat="server" CssClass="make-sumo">
                        <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                        <asp:ListItem Value="0" Text="Hayır"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>Isınma Tipi</label>
                    <asp:ListBox ID="lbHeatingTypeDevremulk" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="TypeName" DataValueField="ObjectId"></asp:ListBox>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Yakıt Tipi</label>
                    <asp:ListBox ID="lbFuelTypeDevremulk" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="TypeName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Yapının Durumu</label>
                    <asp:DropDownList ID="ddlAdvertStatusTypeDevremulk" runat="server" CssClass="make-sumo"
                        DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label></label>
                </div>
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlTuristikBilgileri" runat="server" Visible="false">

            <div class="row">
                <div class="span3">
                    <label>Oda / Bölüm Sayısı</label>
                    <div class="left-fifty">
                        <asp:TextBox ID="tbRoomCountFromTuristik" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                    <div class="right-fifty">
                        <asp:TextBox ID="tbRoomCountToTuristik" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                </div>
                <div class="span3">
                    <label>Yıldız Sayısı</label>
                    <asp:ListBox ID="lbStarCountTuristik" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-multi-sumo" DataTextField="TypeName" DataValueField="ObjectId"></asp:ListBox>
                </div>
                <div class="span3">
                    <label>Yatak Sayısı</label>
                    <div class="left-fifty">
                        <asp:TextBox ID="tbBedCountFromTuristik" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                    <div class="right-fifty">
                        <asp:TextBox ID="tbBedCountToTuristik" runat="server" CssClass="mask-number"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix mb-20"></div>
            <div class="row">
                <div class="span3">
                    <label>Tapu Durumu</label>
                    <asp:DropDownList ID="ddlDeedTypeTuristik" runat="server" placeholder="Seçiniz"
                        SelectionMode="Multiple" CssClass="make-sumo" DataTextField="TypeName" DataValueField="ObjectId">
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label>İskan Durumu</label>
                    <asp:DropDownList ID="ddlIsSettlementTuristik" runat="server" CssClass="make-sumo">
                        <asp:ListItem Value="" Text="Seçiniz" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Evet"></asp:ListItem>
                        <asp:ListItem Value="0" Text="Hayır"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="span3">
                    <label></label>
                </div>
            </div>

        </asp:Panel>

        <div class="clearfix mb-20"></div>
        <div class="clearfix mb-20"></div>
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
                                RepeatDirection="Horizontal" RepeatColumns="4" RepeatLayout="Table"
                                DataTextField="FeatureName" DataValueField="ObjectId" CssClass="table table-advance">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="clearfix mb-20"></div>

        <div class="row">
            <div class="span9 text-center">
                <asp:Button ID="btnSearch" runat="server" Text="DETAYLI ARA" CssClass="btn btn-primary btn-large" OnClick="btnSearch_Click" />
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphJS" runat="Server">
    <script src="/assets/libraries/sumoselect/jquery.sumoselect.js"></script>
    <script type="text/javascript" src="/admin/design/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.make-sumo').SumoSelect();
            $('.make-multi-sumo').SumoSelect({ selectAll: true });
            $(".mask-number").inputmask({
                "mask": "9",
                "repeat": 10,
                "greedy": false
            });
        });
    </script>
</asp:Content>

