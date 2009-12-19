<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    <p>
        This site is a quick site thrown together to exercise my Javascript muscles :)
    </p>
    
    <ul>
        <li><%= Html.ActionLink("Bowling Game Kata", "Bowling", "Kata") %></li>
    </ul>
</asp:Content>
