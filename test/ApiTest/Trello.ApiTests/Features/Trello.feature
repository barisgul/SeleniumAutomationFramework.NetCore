Feature: Trello
	Simple calculator for adding two numbers

@getBoard
Scenario: Get User Boards
	Given I make a rest request with below criteria
	| method   | endpoint |
	| GET |     /members/barisgul8/boards |	
	Then Board information should return