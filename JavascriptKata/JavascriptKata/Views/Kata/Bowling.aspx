<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
	
	<script language="javascript" type="text/javascript">
    
    // Javascript Code for Bowling Game

	    function runTests() {

	        module("BowlingGame");

	        test("BowlingGameTest", function() {
	            ok(false, "fail!");
	        });
	    }


	    $(runTests);
    
    </script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Bowling Coding Kata</h2>
    
    
    
    <div id="game">
    
    </div>
    
    <div id="testResults">
    
        <h1 id="qunit-header">Test Results</h1>
        <h2 id="qunit-banner"></h2>
        <h2 id="qunit-userAgent"></h2>
        <ol id="qunit-tests"></ol>
        
    </div>

</asp:Content>
