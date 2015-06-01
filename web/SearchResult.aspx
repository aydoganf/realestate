<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server"> Arama Sonuçları
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRightSide" runat="Server">
    <div id="main" class="span9 property-listing">

        <h1 class="page-header">Arama Sonuçları</h1>

        <div class="clearfix">

            <div class="properties-rows">
                <div class="row">
                    <asp:Repeater ID="rptAdverts" runat="server">
                        <ItemTemplate>
                            <div class="property span9">
                                <div class="row">
                                    <div class="span3">
                                        <div class="image">
                                            <div class="content">
                                                <a href="/ilan-detay/<%#Eval("CityName") %>/<%#Eval("TownName") %>/<%#Eval("DistrictName") %>/<%#Eval("AdvertNumber") %>/<%#Eval("Title") %>">
                                                    <img width="570" height="425" src="/uploads/<%#Eval("PrimarySmallAdvertPhoto") %>" class="thumbnail-image" alt="19">
                                                </a>
                                            </div>
                                            <!-- /.content -->
                                        </div>
                                        <!-- /.image -->
                                    </div>

                                    <div class="body span6">
                                        <div class="title-price row">
                                            <div class="title span4">
                                                <h2>
                                                    <a href="/ilan-detay/<%#Eval("CityName") %>/<%#Eval("TownName") %>/<%#Eval("DistrictName") %>/<%#Eval("AdvertNumber") %>/<%#Eval("Title") %>">
                                                        <%#Eval("Title") %>
                                                    </a>
                                                </h2>
                                            </div>
                                            <!-- /.title -->

                                            <div class="price">
                                                <%#Eval("Price") %> <%#Eval("PriceCurrency.CurrencyName") %>
                                            </div>
                                            <!-- /.price -->
                                        </div>
                                        <!-- /.title -->

                                        <div class="location"><%#Eval("CityName") %> / <%#Eval("TownName") %> / <%#Eval("DistrictName") %></div>
                                        <!-- /.location -->

                                        <div class="body">
                                            <p>
                                                <%#Eval("Description") %> ...
                                            </p>
                                        </div>
                                        <!-- /.body -->

                                        <div class="property-info clearfix">
                                            <div class="area">
                                                <i class="icon icon-normal-cursor-scale-up"></i>
                                                <%#Eval("Area") %> m<sup>2</sup>
                                            </div>
                                            <!-- /.area -->

                                            <div class="bedrooms">
                                                <i class="icon icon-normal-bed"></i><%#Eval("BathCount") %>
                                            </div>
                                            <!-- /.bedrooms -->


                                            <div class="more-info">
                                                <a href="/ilan-detay/<%#Eval("CityName") %>/<%#Eval("TownName") %>/<%#Eval("DistrictName") %>/<%#Eval("AdvertNumber") %>/<%#Eval("Title") %>">Detaylı bilgi <i class="icon icon-normal-right-arrow-circle"></i></a>
                                            </div>
                                        </div>
                                        <!-- /.info -->
                                    </div>
                                    <!-- /.body -->
                                </div>
                                <!-- /.row -->
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphJS" runat="Server">
</asp:Content>

