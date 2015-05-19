<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="settings_account_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Hesap Bilgilerim</span>        
    </li>
    <%--<li class="btn-group">
        <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
            <span>İşlemler
            </span>
            <i class="fa fa-angle-down"></i>
        </button>
        <ul class="dropdown-menu pull-right" role="menu">
            <li>
                <a href="data.aspx">
                    <i class="fa fa-plus-square"></i>
                    <span>Yeni Pazarlama Tipi Ekle</span>
                </a>
            </li>
        </ul>
    </li>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">Hesap Bilgilerini Düzenle</div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal">
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Adınız *</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3">Soyadınız *</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3">E-mail *</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3">Telefon *</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3">Adresiniz</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <div class="col-md-offset-3 col-md-9">
                    <button type="button" class="btn green" id="save-person">Kaydet</button>
                </div>
            </div>
        </div>
    </div>

    <%--Ask Password Modal BEGIN --%>
    <div class="modal fade" id="operation-save-modal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Şifrenizi Giriniz</h4>
                </div>
                <div class="modal-body">
                    Güvenliğiniz için lütfen şifrenizi giriniz:
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="form-control" Width="250px"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn green" Text="Kaydet" OnClick="btnSave_Click" />
                    <button type="button" class="btn default" data-dismiss="modal">Kapat</button>
                </div>
            </div>
        </div>
    </div>
    <%--Ask Password Modal END --%>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" Runat="Server">
    <script type="text/javascript" src="/admin/design/plugins/bootbox/bootbox.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#save-person').click(function () {

                var firstName = $('#<%=tbFirstName.ClientID%>').val();
                var lastName = $('#<%=tbLastName.ClientID%>').val();
                var email = $('#<%=tbEmail.ClientID%>').val();
                var phone = $('#<%=tbPhone.ClientID%>').val();

                if (firstName != '' && lastName != '' && email != '' && phone != '') {
                    $('#operation-save-modal').modal('show');
                } else {
                    bootbox.dialog({
                        message: "Lütfen * ile gösterilen alanları doldurunuz",
                        title: "Bilgiler Eksik",
                        buttons: {                      
                            danger: {
                                label: "Tamam",
                                className: "btn default",
                                callback: function () {
                                }
                            },
                        }
                    });
                }

            });

        });
    </script>
</asp:Content>

