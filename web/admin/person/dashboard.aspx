<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="person_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <a href="default.aspx">Kullanıcılar</a>
    </li>
    <li>
        <i class="fa fa-angle-right"></i>
        <span><%=CurrentPerson.FullName %></span>        
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <%=CurrentPerson.FullName %> Kişi Detayı
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-md-6 row static-info">
                    <div class="col-md-6"><strong>Adı Soyadı</strong></div>
                    <div class="col-md-6"><%=CurrentPerson.FullName %></div>
                </div>
                <div class="col-md-6 row static-info">
                    <div class="col-md-6"><strong>Email</strong></div>
                    <div class="col-md-6"><%=CurrentPerson.Email%></div>
                </div>
                <div class="col-md-6 row static-info">
                    <div class="col-md-6"><strong>Telefon</strong></div>
                    <div class="col-md-6"><%=CurrentPerson.Phone%></div>
                </div>
                <div class="col-md-6 row static-info">
                    <div class="col-md-6"><strong>Hesap Türü</strong></div>
                    <div class="col-md-6"><%=CurrentPerson.AccountType.AccountTypeName%></div>
                </div>
                <div class="col-md-6 row static-info">
                    <div class="col-md-6"><strong>Aktiflik</strong></div>
                    <div class="col-md-6"><%=CurrentPerson.IsActive ? "Aktif" : "Pasif"%></div>
                </div>
                <div class="col-md-6 row static-info">
                    <div class="col-md-6"><strong>Adres</strong></div>
                    <div class="col-md-6"><%= !string.IsNullOrEmpty(CurrentPerson.Address) ? CurrentPerson.Address : "Adres bilgisi bulunamadı" %></div>
                </div>
                <div class="col-md-6 row static-info">
                    <div class="col-md-12 clearfix">
                        <asp:Button ID="btnActivate" runat="server" CssClass="btn btn-success btn-lg" Text="Kullanıcıyı Aktifleştir" 
                            OnClick="btnActivate_Click" OnClientClick="return confirm('Bu kullanıcıyı aktifleştirmek istediğinize emin misiniz?')" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-lg" Text="Kullanıcıyı Sil" 
                            OnClick="btnDelete_Click" OnClientClick="return confirm('Bu kullanıcıyı silmek istediğinize emin misiniz?')" />
                    </div>                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" Runat="Server">
</asp:Content>

