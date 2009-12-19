<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="JavascriptKata.Controllers"%>
<%@ Import Namespace="JavascriptKata.Extensions"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    <p>
        This is a quick site thrown together to exercise my Javascript muscles :)
    </p>
    
    <ul>
        <li><%= Html.ActionLink<KataController>("Bowling Game Kata", c => c.Bowling()) %></li>
    </ul>
</asp:Content>
