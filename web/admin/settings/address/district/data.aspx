<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="data.aspx.cs" Inherits="settings_address_district_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="../../">Ayarlar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">Semtler</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Semt Ekle/Düzenle</span>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">Semt Ekle/Düzenle</div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal">
                <div class="form-body">
                    <div class="form-group">
                        <label class="control-label col-md-3">İl</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlCityList" runat="server" DataTextField="CityName" 
                                DataValueField="ObjectId" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCityList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3">İlçe</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlTownList" runat="server" DataTextField="TownName" DataValueField="ObjectId" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group" id="divAddUnique">
                        <label class="control-label col-md-3">Semt Adı</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="tbDistrictName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Panel ID="pnlAddPart" runat="server" CssClass="form-group" Visible="false">
                        <label class="control-label col-md-3">Çoklu Ekle</label>
                        <div class="col-md-6">
                            <asp:CheckBox ID="cbAddMultiple" runat="server" />
                            <div class="hidden" id="divAddMultiple">
                                <i>Semtler arasına virgül koyunuz</i>
                                <asp:TextBox ID="tbDistricts" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
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

            $('#<%=cbAddMultiple.ClientID%>').change(function () {
                console.log($(this).is(':checked'));
                if ($(this).is(':checked'))
                    $('#divAddMultiple').removeClass('hidden');
                else
                    $('#divAddMultiple').addClass('hidden');

            });

        });
    </script>
</asp:Content>

