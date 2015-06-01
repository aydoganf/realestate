<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdvencedSearch.aspx.cs" Inherits="AdvencedSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCSS" runat="Server">
    <link href="/assets/libraries/sumoselect/sumoselect.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNavigation" runat="Server">
    Detaylı Arama
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRightSide" runat="Server">
    <div id="main" class="span9 property-listing">

        <h1 class="page-header">Detaylı Arama</h1>

        <div class="clearfix"></div>

        <div class="row">
            <div class="span3">
                <label>Pazarlama Tipi</label>
                <asp:DropDownList ID="ddlMarketingType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-sumo"></asp:DropDownList>
            </div>
            <div class="span3">
                <label>Emlak Tipi</label>
                <asp:DropDownList ID="ddlEstateType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-sumo"></asp:DropDownList>
            </div>
            <div class="span3">
                <label><asp:Label ID="lblEstateTypeText" runat="server"></asp:Label> Tipi</label>                
                <asp:ListBox ID="lbSubEstateType" runat="server" DataTextField="TypeName" DataValueField="ObjectId" placeholder="Seçiniz"
                    SelectionMode="Multiple" CssClass="make-multi-sumo"></asp:ListBox>
            </div>
        </div>

        <div class="clearfix mb-20"></div>

        <div class="row">
            <div class="span3">
                <label>İl</label>
                <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-sumo"></asp:DropDownList>
            </div>
            <div class="span3">
                <label>İlçe</label>
                <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="TypeName" DataValueField="ObjectId" CssClass="make-sumo"></asp:DropDownList>
            </div>
            <div class="span3">
                <label>Semt</label>                
                <asp:ListBox ID="ListBox1" runat="server" DataTextField="TypeName" DataValueField="ObjectId" placeholder="Seçiniz"
                    SelectionMode="Multiple" CssClass="make-multi-sumo"></asp:ListBox>
            </div>
        </div>


        <div class="clearfix mb-20"></div>

        <div class="row">
            <div class="span9">
                <asp:Label ID="lbl" runat="server"></asp:Label>
                <asp:Button ID="btnSearch" runat="server" Text="Arama Yap" CssClass="btn btn-primary btn-large" OnClick="btnSearch_Click" />
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphJS" runat="Server">
    <script src="/assets/libraries/sumoselect/jquery.sumoselect.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {            
            $('.make-sumo').SumoSelect();
            $('.make-multi-sumo').SumoSelect({ selectAll: true });
        });
    </script>
</asp:Content>

