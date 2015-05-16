<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="settings_address_city_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/design/datatable/media/css/demo_table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">Şehirler</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Şehir Ekle/Düzenle</span>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">Şehir Ekle/Düzenle</div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal">
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Şehir Adı</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbCityName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <div class="col-md-offset-3 col-md-9">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn green" Text="Kaydet" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="pnlTownList" runat="server" Visible="false">
        <div class="clearfix"></div>
        <h3>İlçeler</h3>
        <hr />

        <asp:Repeater ID="rptTown" runat="server" OnItemCommand="rptTown_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-advance table-hover dataTable" id="townTable">
                    <thead>
                        <tr>
                            <td>İşlem</td>
                            <td>İlçe Adı</td>
                        </tr>
                    </thead>
                    <tbody id="content">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='../town/data.aspx?town=<%#Eval("ObjectId") %>'>
                            <i class="fa fa-list"></i>&nbsp;Detay
                        </a>
                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="delete"
                            CommandArgument='<%#Eval("ObjectId") %>' OnClientClick="return confirm('Bunu silmek istediğinize emin misiniz?')">
                                <i class="fa fa-trash-o"></i>&nbsp;Sil
                        </asp:LinkButton>
                    </td>
                    <td><%#Eval("TownName") %></td>
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
            $('#townTable').dataTable({
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

