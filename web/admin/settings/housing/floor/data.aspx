<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="settings_housing_floor_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">Kat Bilgileri</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Kat Bilgisi Ekle/Düzenle</span>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">Kat Bilgisi Ekle/Düzenle</div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal">
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Kat Bilgisi Adı</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbFloorName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Kat Bilgisi Anahtarı</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbFloorKey" runat="server" CssClass="form-control"></asp:TextBox>
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
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" Runat="Server">
</asp:Content>

