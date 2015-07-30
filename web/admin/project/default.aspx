<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_project_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/datatable/media/css/demo_table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Projeler</span>
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
                    <span>Yeni Proje Ekle</span>
                </a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:Repeater ID="rptProject" runat="server">
        <HeaderTemplate>
            <table class="table table-striped table-bordered table-advance table-hover dataTable" id="projectTable">
                <thead>
                    <tr>
                        <td>İşlem</td>
                        <td>Proje Adı</td>
                        <td>Projedeki Konut Sayısı</td>
                        <td>Toplam Proje Alanı</td>
                        <td>Metrekare Aralığı</td>
                        <td>Oda Seçenekleri</td>
                        <td>Teslim Tarihi</td>
                        <td>Aktivasyon Durumu</td>
                    </tr>
                </thead>
                <tbody id="content">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='data.aspx?project=<%#Eval("ObjectId") %>' class="btn btn-xs blue">
                        <i class="fa fa-list"></i>&nbsp;Detay
                    </a>
                    <asp:LinkButton ID="lbtnDeactivate" runat="server" CssClass="btn btn-xs yellow" Visible="false"
                        CommandName="deactivate" CommandArgument='<%#Eval("ObjectId") %>'
                        OnClientClick="return confirm('Pasife almak istediğinize emin misiniz?');">
                            <i class="fa fa-exclamation"></i>&nbsp;Pasife Al
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtnActivate" runat="server" CssClass="btn btn-xs green" Visible="false"
                        CommandName="activate" CommandArgument='<%#Eval("ObjectId") %>'
                        OnClientClick="return confirm('Aktife almak istediğinize emin misiniz?');">
                            <i class="fa fa-flash"></i>&nbsp;Aktife Al
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-xs red"
                        CommandName="delete" CommandArgument='<%#Eval("ObjectId") %>'
                        OnClientClick="return confirm('Silmek istediğinize emin misiniz?');">
                            <i class="fa fa-trash-o"></i>&nbsp;Sil
                    </asp:LinkButton>
                </td>
                <td><%#Eval("ProjectName") %></td>
                <td><%#Eval("ProjectHousingCount") %></td>
                <td><%#Eval("ProjectTotalArea") %></td>
                <td><%#Eval("AreaRange") %></td>
                <td><%#Eval("RoomOptions") %></td>
                <td><%#Eval("DeliveryDate") %></td>
                <td><%# (bool)Eval("IsActive") ? "Aktif" : "Pasif" %></td>
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
            $('#projectTable').dataTable({
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

