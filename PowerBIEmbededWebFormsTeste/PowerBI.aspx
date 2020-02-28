<%@ Page Title="PowerBI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PowerBI.aspx.cs" Inherits="PowerBIEmbededWebFormsTeste.PowerBI" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <%--<h3>PowerBI page.</h3> --%>   

    <!-- Js function to assign iframe embedUrl and access token -->
    <script type="text/javascript" src="Scripts/WebForms/PowerBI.js"></script>


    <input type="hidden" id="accessTokenText" runat="server" value="" />
    <input type="hidden" id="embedUrlText" runat="server" value="" />

    <iframe id="iFrameEmbedReport" height="768" width="1024" seamless>

    </iframe>
    
</asp:Content>
