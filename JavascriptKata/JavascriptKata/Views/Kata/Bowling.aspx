<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
	
	<script language="javascript" type="text/javascript">

        // Begin Game
	    function Game() {
	        var currentRoll = 0;
	        var rolls = new Array();

	        function isSpare(frameIndex) {
	            return rollsValue(frameIndex) + rollsValue(frameIndex + 1) == 10;
	        }

	        function isStrike(frameIndex) {
	            return rollsValue(frameIndex) == 10;
	        }

	        function rollsValue(frameIndex) {
	            var parse = parseInt(rolls[frameIndex]);
	            if (isNaN(parse))
	                return 0;
	            else
	                return parse;
	        }

	        function sumOfPinsInFrame(frameIndex) {
	            return rollsValue(frameIndex) + rollsValue(frameIndex + 1);
	        }

	        function strikeBonus(frameIndex) {
	            return 10 +
	                rollsValue(frameIndex + 1) +
	                rollsValue(frameIndex + 2);
	        }

	        function spareBonus(frameIndex) {
	            return 10 + rollsValue(frameIndex + 2);
	        }
	        
	        this.roll = function(pins) {
	            rolls[currentRoll++] = pins;
	        };

	        this.score = function() {
	            var score = 0;
	            var frameIndex = 0;

	            for (var frame = 0; frame < 10; frame++) {

	                if (isStrike(frame)) {
	                    score += strikeBonus(frameIndex);
	                    frameIndex++;
	                }
	                else if (isSpare(frame)) {
	                    score += spareBonus(frameIndex);
	                    frameIndex += 2;
	                }
	                else {
	                    score += sumOfPinsInFrame(frameIndex);
	                    frameIndex += 2;	                    
	                }
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

	        function rollStrike() {
	            game.roll(10);
	        }

            module("BowlingGame");

	        test("20 0-Pin Rolls Scores Zero", function() {
	            NewGame();
	            rollMany(20, 0);
	            equals(game.score(), 0);
	        });

	        test("20 1-Pin Rolls Scores 20", function() {
	            NewGame();
	            rollMany(20, 1);
	            equal(game.score(), 20);
	        });

	        test("Game with One Spare and 3 Returns 16", function() {
	            NewGame();
	            rollSpare();
	            game.roll(3);
	            rollMany(17, 0);
	            equal(game.score(), 16);
	        });

	        test("Game with One Strike, 3 and 4 Scores 24", function() {
	            NewGame();
	            rollStrike();
	            game.roll(3);
	            game.roll(4);
	            rollMany(16, 0);
	            equal(game.score(), 24)
	        });

	        test("Can Calculate Score for Incomplete Game", function() {
	            NewGame();
	            game.roll(3);
	            equal(game.score(), 3);
	        });

	        test("Perfect Game Scores 300", function() {
	            NewGame();
	            rollMany(12, 10);
	            equal(game.score(), 300);
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
