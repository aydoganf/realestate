﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="advert_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/datatable/media/css/demo_table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <span>İlanlar</span>
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
                    <span>Yeni İlan Ekle</span>
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

    <asp:Repeater ID="rptAdvert" runat="server" OnItemDataBound="rptAdvert_ItemDataBound" OnItemCommand="rptAdvert_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped table-bordered table-advance table-hover dataTable" id="advertTable">
                <thead>
                    <tr>
                        <td>İşlem</td>
                        <td>İlan Numarası</td>
                        <td>Adres</td>
                        <td>Pazarlama Tipi</td>
                        <td>Emlak Tipi</td>
                        <td>Ücret</td>
                        <td>Alan</td>
                        <td>Aktiflik Durumu</td>
                    </tr>
                </thead>
                <tbody id="content">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='data.aspx?advert=<%#Eval("ObjectId") %>' class="btn btn-xs blue">
                        <i class="fa fa-list"></i>&nbsp;Detay
                    </a>&nbsp;
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
                <td><%#Eval("AdvertNumber") %></td>
                <td><%# TruncateString(Eval("GAddress").ToString(), 50) %>..</td>
                <td><%#Eval("MarketingType.TypeName") %></td>
                <td><%#Eval("EstateType.TypeName") %></td>
                <td><%#Eval("Price") %> <%#Eval("PriceCurrency.CurrencyName") %></td>
                <td><%#Eval("Area") %></td>
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
            $('#advertTable').dataTable({
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
