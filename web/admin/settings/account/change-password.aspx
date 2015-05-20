<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="change-password.aspx.cs" Inherits="admin_settings_account_change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">Hesap Bilgilerim</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Şifre Değiştirme</span>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:Panel ID="pnlOperationStatus" runat="server" Visible="false">
        <h4 id="h4StatusTitle" runat="server"></h4>
        <p id="pStatusInfo" runat="server"></p>
    </asp:Panel>

    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">Şifre Değiştir</div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal">
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Şuanki şifreniz *</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbOldPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group"> 
                        <label class="control-label col-md-3">Yeni şifreniz *</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3">Yeni şifre tekrarı *</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbNewPassword2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" runat="Server">
</asp:Content>

