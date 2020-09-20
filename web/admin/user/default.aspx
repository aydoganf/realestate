<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" 
    Inherits="user_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/datatable/media/css/demo_table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Kullanıcılar</span>
    </li>
    <li class="btn-group">
        <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
            <span>İşlemler
            </span>
            <i class="fa fa-angle-down"></i>
        </button>
        <ul class="dropdown-menu pull-right" role="menu">
            <li>
                <a href="create.aspx">
                    <i class="fa fa-plus-square"></i>
                    <span>Yeni Kullanıcı Ekle</span>
                </a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:Panel ID="pnlOperationStatus" runat="server" Visible="false">
        <h4 id="h4StatusTitle" runat="server"></h4>
        <p id="pStatusInfo" runat="server"></p>
    </asp:Panel>

    <asp:Repeater ID="rptPerson" runat="server" OnItemDataBound="rptPerson_ItemDataBound" OnItemCommand="rptPerson_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped table-bordered table-advance table-hover dataTable" id="personTable">
                <thead>
                    <tr>
                        <td>İşlem</td>
                        <td>Adı</td>
                        <td>Soyadı</td>
                        <td>Email Adresi</td>
                        <td>Telefon</td>
                        <td>Hesap Türü</td>
                        <td>Aktivasyon Durumu</td>
                    </tr>
                </thead>
                <tbody id="content">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='dashboard.aspx?person=<%#Eval("Id") %>' class="btn btn-xs blue">
                        <i class="fa fa-list"></i>&nbsp;Detay
                    </a>
                    <asp:LinkButton ID="lbtnDeactivate" runat="server" CssClass="btn btn-xs yellow" Visible="false"
                        CommandName="deactivate" CommandArgument='<%#Eval("Id") %>'
                        OnClientClick="return confirm('Pasife almak istediğinize emin misiniz?');">
                            <i class="fa fa-exclamation"></i>&nbsp;Pasife Al
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtnActivate" runat="server" CssClass="btn btn-xs green" Visible="false"
                        CommandName="activate" CommandArgument='<%#Eval("Id") %>'
                        OnClientClick="return confirm('Aktife almak istediğinize emin misiniz?');">
                            <i class="fa fa-flash"></i>&nbsp;Aktife Al
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-xs red"
                        CommandName="delete" CommandArgument='<%#Eval("Id") %>'
                        OnClientClick="return confirm('Silmek istediğinize emin misiniz?');">
                            <i class="fa fa-trash-o"></i>&nbsp;Sil
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtnAdmin" runat="server" CssClass="btn btn-xs green" Visible="false"
                        CommandName="admin" CommandArgument='<%#Eval("Id") %>' 
                        OnClientClick="return confirm('Admin yapmak istediğinize emin misiniz?');">
                        <i class="fa fa-star"></i>&nbsp;Admin Yap
                    </asp:LinkButton>
                </td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("Surname") %></td>
                <td><%#Eval("Email") %></td>
                <td><%#Eval("Phone") %></td>
                <td><%#Eval("AccountType") %></td>
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
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#personTable').dataTable({
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
                    "sSearch": "Bu tabloda arama yap:",
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

