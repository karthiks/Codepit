<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
	
	<script language="javascript" type="text/javascript">

	    function Game() {
	        
	        var totalPins = 0;
	        this.roll = function(pins) { totalPins += pins };
	        this.score = function() { return totalPins; };
	    }

	    function runTests() {

	        Game.prototype.rollMany = function(times, pins) {
	            for (var i = 0; i < times; i++) {
	                this.roll(pins);
	            }
	        }

	        var game = new Game();

	        module("BowlingGame");

	        test("ScoreZeroIfNoPins", function() {
	            game.rollMany(20, 0);
	            equals(game.score(), 0, "Game score S/B zero if no pins knocked down");
	        });


	        test("Score20If20Pins", function() {
	            game.rollMany(20, 1);
	            equal(game.score(), 20, "Game score s/b 20 if twenty pins knocked down");
	        });

	        test("testOneSpare", function() {
	            game.roll(5);
	            game.roll(5); // spare
	            game.roll(3);
	            game.rollMany(17, 0);
	            equal(game.score(), 16, "Game score s/b 16 with spare");
	        });
	    }

	    function PlayGame() {
	    
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
