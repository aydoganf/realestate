<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="settings_housing_extra_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">Ekstra Özellikler</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Ekstra Özellik Ekle/Düzenle</span>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">Ekstra Özellik Ekle/Düzenle</div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal">
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Özellik Tipi</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlFeatureType" runat="server" 
                                DataTextField="TypeName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">Özellik Adı</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbFeatureName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CheckBox ID="cbMulti" runat="server" Text="Çoklu ekle" />
                            <div id="multi" style="display:none">
                                <asp:TextBox ID="tbFeatureNameMulti" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" ></asp:TextBox>
                                <div>
                                    <i class="fa fa-info-circle"></i> Özellik isimlerinin arasına virgül koyunuz
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-body" id="singleKey">
                    <div class="form-group">
                        <label class="control-label col-md-3">Özellik Anahtarı</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbFeatureKey" runat="server" CssClass="form-control"></asp:TextBox>
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
    <script type="text/javascript">

        $(document).ready(function () {

            $('#<%=cbMulti.ClientID%>').change(function () {

                if ($(this).is(':checked')) {
                    $('#<%=tbFeatureName.ClientID%>').hide();
                    $('#singleKey').hide();
                    $('#multi').show();
                } else {
                    $('#<%=tbFeatureName.ClientID%>').show();
                    $('#singleKey').show();
                    $('#multi').hide();
                }

            });

        });

    </script>
</asp:Content>

