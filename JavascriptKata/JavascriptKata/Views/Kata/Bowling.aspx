<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
	
	<script language="javascript" type="text/javascript">

        // Begin Game
	    function Game() {
	        var currentRoll = 0;
	        var rolls = new Array();

	        function isSpare(frameIndex) {
	            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
	        }
	        
	        this.roll = function(pins) {
	            rolls[currentRoll++] = pins;
	        };

	        this.score = function() {
	            var score = 0;
	            var frameIndex = 0;
	            
	            for (var frame = 0; frame < 10; frame++) {

	                if (isSpare(frame)) {
	                    score += 10 + rolls[frameIndex + 2];
	                }
	                else {
	                    score += rolls[frameIndex] + rolls[frameIndex + 1];
	                }

	                frameIndex += 2;
	            }
	            return score;
	        };
	    }
	    // End Game.

	    function runTests() {

	        var game = new Game();

	        function NewGame() {
	            game = new Game();
	        }
	        
	        function rollMany(times, pins) {
	            for (var i = 0; i < times; i++) {
	                game.roll(pins);
	            }
	        }

	        function rollSpare()
	        {
	            game.roll(5);
	            game.roll(5);
	        }

            module("BowlingGame");

	        test("ScoreZeroIfNoPins", function() {
	            NewGame();
	            rollMany(20, 0);
	            equals(game.score(), 0, "Game score S/B zero if no pins knocked down");
	        });

	        test("Score20If20Pins", function() {
	            NewGame();
	            rollMany(20, 1);
	            equal(game.score(), 20, "Game score s/b 20 if twenty pins knocked down");
	        });

	        test("testOneSpare", function() {
	            NewGame();
	            rollSpare();
	            game.roll(3);
	            rollMany(17, 0);
	            equal(game.score(), 16, "Game score s/b 16 with spare");
	        });

	        test("testOneStrike", function() {
	            NewGame();
	            game.roll(10); // strike
	            game.roll(3);
	            game.roll(4);
	            rollMany(16, 0);
	            equal(game.score(), 24, "Game w/ Strike, 3 and 4 should score 24")
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
