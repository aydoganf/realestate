<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.master" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCSS" runat="Server">
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    <asp:Label ID="lblNavigation" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRightSide" runat="Server">

    <div id="main" class="span9">
        <h1 class="page-header">
            <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
        </h1>
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
                                    <a href="/proje/<%#Eval("ObjectId") %>">
                                        <img src="/uploads/<%#Eval("PrimarySmallProjectPhoto") %>">
                                    </a>
                                </div>
                            </div>

                            <div class="info">
                                <div class="title clearfix">
                                    <h2>
                                        <a href="/proje/<%#Eval("ObjectId") %>">
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


            <asp:Panel ID="pnlEmpty" runat="server" Visible="false" CssClass="span8 clearfix emptyPanel">

            </asp:Panel>

            <asp:Repeater ID="rptSearchedProjects" runat="server" Visible="false">
                <HeaderTemplate>
                    <div class="row-fluid">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="span3">
                        <div class="property">
                            <div class="image">
                                <div class="content">
                                    <a href="/proje/<%#Eval("ObjectId") %>">
                                        <img src="/uploads/<%#Eval("PrimarySmallProjectPhoto") %>">
                                    </a>
                                </div>
                            </div>

                            <div class="info">
                                <div class="title clearfix">
                                    <h2>
                                        <a href="/proje/<%#Eval("ObjectId") %>">
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

