<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="settings_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
    <li>
        <i class="fa fa-angle-right"></i>
        <span>Ayarlar</span>        
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="row">
        <div class="col-md-4">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-user"></i>Hesap Bilgileri
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemdeki bilgilerinizi buradan değiştirebilirsiniz.</h5>
                    <ul class="list-inline">
                        <li class="li-first">
                            <a href="account/" class="btn blue a-item">
                                <i class="fa fa-search"></i>Hesap Bilgilerim </a>
                        </li>                        
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-tasks"></i>Pazarlama Bilgileri
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemde tanımlı pazarlama tiplerini buradan yönetebilirsiniz. Ör:(Kiralık, Satılık)</h5>
                    <ul class="list-inline">
                        
                        <li class="li-first">
                            <a href="marketing/" class="btn blue a-item">
                                <i class="fa fa-tasks"></i>Pazarlama </a>
                        </li>
                        
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-tasks"></i>Emlak Tipi Bilgileri
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemde tanımlı emlak tiplerini buradan yönetebilirsiniz. Ör:(Arsa, Daire, İşyeri)</h5>
                    <ul class="list-inline">
                        
                        <li class="li-first">
                            <a href="estatetype/" class="btn blue a-item">
                                <i class="fa fa-tasks"></i>Emlak Tipleri </a>
                        </li>
                        
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-4">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-book"></i>Adres Bilgileri
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemde kayıtlı adres bilgileri verilerini buradan yönetebilirsiniz.</h5>
                    <ul class="list-inline">
                        <li class="li-outdent">
                            <a href="address/city/" class="btn green a-item">
                                <i class="fa fa-outdent"></i>Şehirler </a>
                        </li>
                        <li class="li-outdent">
                            <a href="address/town/" class="btn green a-item">
                                <i class="fa fa-reorder"></i>İlçeler </a>
                        </li>
                        <li class="li-outdent">
                            <a href="address/district/" class="btn green a-item">
                                <i class="fa fa-reorder"></i>Semtler </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-book"></i>Para Birimi Bilgileri
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemde kayıtlı para birimi verilerini buradan yönetebilirsiniz.</h5>
                    <ul class="list-inline">
                        <li class="li-outdent">
                            <a href="currency/" class="btn green a-item">
                                <i class="fa fa-outdent"></i>Para Birimleri </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-book"></i>Konut Bilgileri
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemde kayıtlı konut bilgileri verilerini buradan yönetebilirsiniz.</h5>
                    <ul class="list-inline">
                        <li class="li-outdent">
                            <a href="housing/heating" class="btn green a-item">
                                <i class="fa fa-outdent"></i>Isınma Türleri </a>
                        </li>
                        <li class="li-outdent">
                            <a href="housing/roomhall" class="btn green a-item">
                                <i class="fa fa-outdent"></i>Oda Sayıları </a>
                        </li>
                        <li class="li-outdent">
                            <a href="housing/floor" class="btn green a-item">
                                <i class="fa fa-outdent"></i>Kat Bilgileri </a>
                        </li>
                        <li class="li-outdent">
                            <a href="housing/extra" class="btn green a-item">
                                <i class="fa fa-outdent"></i>Extra Özellikler</a>
                        </li>
                        <li class="li-outdent">
                            <a href="housing/extratype" class="btn green a-item">
                                <i class="fa fa-outdent"></i>Extra Özellikler Tipleri</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" Runat="Server">
</asp:Content>

