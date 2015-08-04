<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="settings_estatetype_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/design/datatable/media/css/demo_table.css" />
    <link href="../../design/plugins/jstree/themes/default/style.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Emlak Tipi</span>        
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
                    <span>Yeni Emlak Tipi Ekle</span>
                </a>
            </li>
        </ul>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <input type="text" id="search_box" class="form-control" placeholder="ara" />
    <div id="jstree"></div>

    <asp:Repeater ID="rptEstateType" runat="server" OnItemCommand="rptEstateType_ItemCommand" Visible="false">
        <HeaderTemplate>
            <table class="table table-striped table-bordered table-advance table-hover dataTable" id="estatetypeTable">
                <thead>
                    <tr>
                        <td>İşlem</td>
                        <td>Adı</td>
                        <td>Anahtarı</td> 
                        <td>Üst Emlak Tipi</td>                    
                    </tr>
                </thead>
                <tbody id="content">
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                        <td>
                            <a href='data.aspx?estatetype=<%#Eval("ObjectId") %>'>
                                <i class="fa fa-list"></i>&nbsp;Detay
                            </a>
                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="delete" 
                                CommandArgument='<%#Eval("ObjectId") %>' OnClientClick="return confirm('Bunu silmek istediğinize emin misiniz?')">
                                <i class="fa fa-trash-o"></i>&nbsp;Sil
                            </asp:LinkButton>
                        </td>
                        <td><%#Eval("TypeName") %></td>
                        <td><%#Eval("TypeKey") %></td>
                        <td><%#Eval("ParentEstateType.TypeName") %></td>
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
    <script src="../../design/plugins/jstree/jstree.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#estatetypeTable').dataTable({
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

            UITree.init();

        });

        var UITree = function () {
            var handleUnitJSTree = function () {
                //Tree
                $('#jstree').jstree({
                    'plugins': ["search", "types"],
                    'core': {
                        "themes": {
                            "responsive": false,
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
                        "three_state": true,
                    }
                });

                $('#jstree').bind('check_node.jstree', function (e, data) {
                    return false;
                });

                $('#jstree').bind("select_node.jstree", function (e, data) {
                    var href_address = "data.aspx?estatetype=" + data.node.id;
                    window.location.href = href_address;
                });

                $('#jstree').bind("search.jstree", function (nodes, str, res) {
                    var s = []
                    $("#jstree .jstree-node").each(function () {
                        if ($(this).css("display") == "block") {
                            debugger;
                            s.push($(this).attr("id"));
                        }
                    });
                });


                $('#unit_jstree').bind("clear_search.jstree", function (nodes, str, res) {
                    var i = 0;
                    $(".jstree-grid-table").find("td").each(function () {
                        if (i != 0) {
                            $(this).find("div").each(function () {
                                $(this).show();
                            });
                        }
                        i++;
                    });
                });
                
                var to = false;
                $('#search_box').keyup(function () {
                    if (to) { clearTimeout(to); }
                    to = setTimeout(function () {
                        var v = $('#search_box').val();
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
    </script>
</asp:Content>

