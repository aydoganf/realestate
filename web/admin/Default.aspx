<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphForCSS" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="row">
        <div class="col-md-4">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-user"></i>Kullanıcılar
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemdeki kullanıcı bilgilerini buradan yönetebilirsiniz.</h5>
                    <ul class="list-inline">
                        <li class="li-first">
                            <a href="person/" class="btn blue a-item">
                                <i class="fa fa-user"></i>Kullanıcılar </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-tasks"></i>İlanlar
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemdeki ilan bilgilerini buradan yönetebilirsiniz.</h5>
                    <ul class="list-inline">

                        <li class="li-first">
                            <a href="advert/" class="btn blue a-item">
                                <i class="fa fa-sitemap"></i>İlanlar </a>
                        </li>

                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-tasks"></i>Ayarlar
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemde tanımlı ayarları buradan yönetebilirsiniz.</h5>
                    <ul class="list-inline">

                        <li class="li-first">
                            <a href="settings/" class="btn blue a-item">
                                <i class="fa fa-briefcase"></i>Ayarlar </a>
                        </li>

                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-tasks"></i>Projeler
                    </div>
                </div>
                <div class="portlet-body">
                    <h5 class="block">Sistemde tanımlı projeleri buradan yönetebilirsiniz.</h5>
                    <ul class="list-inline">

                        <li class="li-first">
                            <a href="project/" class="btn blue a-item">
                                <i class="fa fa-briefcase"></i>Projeler </a>
                        </li>

                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageScripts" Runat="Server">
</asp:Content>

