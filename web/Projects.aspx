<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.master" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    Projeler
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRightSide" runat="Server">

    <div id="main" class="span9">
        <h1 class="page-header">Projeler</h1>
        <div class="properties-grid">
            <asp:Repeater ID="rptRecentProjects" runat="server">
                <HeaderTemplate>
                    <div class="row-fluid">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="span3">
                        <div class="property">
                            <div class="image">
                                <div class="content">
                                    <a href="">
                                        <img src="/uploads/<%#Eval("PrimarySmallProjectPhoto") %>">
                                    </a>
                                </div>
                                <%--<div class="rent-sale">
                                    
                                </div>--%>
                                <%--<div class="price">
                                    <%# FormatPrice(Eval("Price")) %> <%#Eval("PriceCurrency.CurrencyName") %>
                                </div>--%>
                            </div>

                            <div class="info">
                                <div class="title clearfix">
                                    <h2>
                                        <a href="">
                                            <%#Eval("ProjectName") %>
                                        </a>
                                    </h2>
                                </div>
                                <div class="location"><%#Eval("CityName") %>/<%#Eval("TownName") %></div>
                            </div>
                        </div>
                        <div class="property-info clearfix">
                            <div class="area">
                                <i class="icon icon-normal-cursor-scale-up"></i>
                                <%#Eval("ProjectTotalArea") %> m<sup>2</sup>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <div class="clearfix"></div>
        <%--<div class="pagination pagination-centered" id="divPagination" runat="server">
            <ul class="unstyled">
                <asp:HiddenField ID="hfLastPageNumber" runat="server" />
                <asp:HiddenField ID="hfCurrentAdvertPageNumber" runat="server" />
                <asp:Repeater ID="rptPagination" runat="server" OnItemDataBound="rptPagination_ItemDataBound">
                    <HeaderTemplate>
                        <li><a id="aPageItemFirst">İlk</a></li>
                        <li><a id="aPageItemPrev">Önceki</a></li>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li id="liPaginationItem" runat="server"><a href="/anasayfa?p=<%# Container.ItemIndex + 1 %>"><%# Container.ItemIndex + 1 %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        <li><a id="aPageItemNext">Sonraki</a></li>
                        <li><a id="aPageItemLast">Son</a></li>
                    </FooterTemplate>
                </asp:Repeater>
            </ul>
        </div>--%>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphJS" runat="Server">
</asp:Content>

