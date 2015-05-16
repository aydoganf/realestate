<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="person_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/design/datatable/media/css/demo_table.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
     <li>
        <i class="fa fa-angle-right"></i>
        <span>Kullanıcılar</span>        
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:Repeater ID="rptPerson" runat="server">
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
                            <a href='dashboard.aspx?person=<%#Eval("ObjectId") %>'>
                                <i class="fa fa-list"></i>&nbsp;Detay
                            </a>
                        </td>
                        <td><%#Eval("FirstName") %></td>
                        <td><%#Eval("LastName") %></td>
                        <td><%#Eval("Email") %></td>
                        <td><%#Eval("Phone") %></td>
                        <td><%#Eval("AccountType.AccountTypeName") %></td>
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

