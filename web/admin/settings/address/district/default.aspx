<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="settings_address_district_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/datatable/media/css/demo_table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Semtler</span>
    </li>
    <li class="btn-group">
        <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
            <span>İşlemler
            </span>
            <i class="fa fa-angle-down"></i>
        </button>
        <ul class="dropdown-menu pull-right" role="menu">
            <li>
                <a href="data.aspx">
                    <i class="fa fa-plus-square"></i>
                    <span>Yeni Şemt Ekle</span>
                </a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">Semt Arama</div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal">
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Şehir Adı</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlCityList" runat="server" DataTextField="Key"
                                DataValueField="Value" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCityList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3">İlçe Adı</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlTownList" runat="server" DataTextField="Key" DataValueField="Value" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <div class="col-md-offset-3 col-md-9">
                    <asp:Button ID="btnSelect" runat="server" CssClass="btn green" Text="Semtleri Getir" OnClick="btnSelect_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="pnlDistrictList" runat="server" Visible="false">
        <div class="clearfix"></div>
        <h3>Semtler</h3>
        <hr />

        <asp:Repeater ID="rptDistrict" runat="server" OnItemCommand="rptDistrict_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-advance table-hover dataTable" id="districtTable">
                    <thead>
                        <tr>
                            <td>İşlem</td>
                            <td>Semt Adı</td>
                        </tr>
                    </thead>
                    <tbody id="content">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='data.aspx?district=<%#Eval("Id") %>'>
                            <i class="fa fa-list"></i>&nbsp;Detay
                        </a>
                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="delete"
                            CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('Bunu silmek istediğinize emin misiniz?')">
                                <i class="fa fa-trash-o"></i>&nbsp;Sil
                        </asp:LinkButton>
                    </td>
                    <td><%#Eval("Key") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </table>
            <div style="height: 50px;"></div>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#districtTable').dataTable({
                "bLengthChange": false,
                "sPaginationType": "full_numbers",
                "iDisplayLength": 30,
                "oLanguage": {
                    "sProcessing": "İşleniyor...",
                    "sLengthMenu": "Sayfada _MENU_ Kayıt Göster",
                    "sZeroRecords": "Eşleşen Kayıt Bulunmadı",
                    "sInfo": "  _TOTAL_ Kayıttan _START_ - _END_ Arası Kayıtlar",
                    "sInfoEmpty": "Kayıt Yok",
                    "sInfoFiltered": "( _MAX_ Kayıt İçerisinden Bulunan)",
                    "sInfoPostFix": "",
                    "sSearch": "Arama yap:",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "İlk",
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sLast": "Son"
                    }
                }
            });
        });
    </script>
</asp:Content>

