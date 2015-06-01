<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_settings_housing_owner_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/datatable/media/css/demo_table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>İlan Sahibi Bilgileri</span>        
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
                    <span>Yeni İlan Sahibi Bilgisi Ekle</span>
                </a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Repeater ID="rptAdvertOwner" runat="server" OnItemCommand="rptAdvertOwner_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped table-bordered table-advance table-hover dataTable" id="advertOwnerTable">
                <thead>
                    <tr>
                        <td>İşlem</td>
                        <td>Adı</td>
                        <td>Anahtarı</td>                        
                    </tr>
                </thead>
                <tbody id="content">
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                        <td>
                            <a href='data.aspx?owner=<%#Eval("ObjectId") %>'>
                                <i class="fa fa-list"></i>&nbsp;Detay
                            </a>
                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="delete" 
                                CommandArgument='<%#Eval("ObjectId") %>' OnClientClick="return confirm('Bunu silmek istediğinize emin misiniz?')">
                                <i class="fa fa-trash-o"></i>&nbsp;Sil
                            </asp:LinkButton>
                        </td>
                        <td><%#Eval("TypeName") %></td>
                        <td><%#Eval("TypeKey") %></td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
            <div style="height: 50px;"></div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#advertOwnerTable').dataTable({
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

