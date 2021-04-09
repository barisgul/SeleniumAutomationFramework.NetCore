Feature: TrelloBoard
	This feature contains Create, Get, Update and Delete Trello Board Through Trello Rest Api Services

@createBoard
Scenario: 1) Create Board  
	* As a developer I want to create a board named 'RestApiBoard'
	* Call '/boards' endpoint with 'POST' method
	* 'RestApiBoard' should be created

@getBoard
Scenario: 2) Get User Boards
	Given I make a rest request with below criteria
	| method   | endpoint |
	| GET |     /members/barisgul8/boards |	
	Then Board information should return

@updateBoard
Scenario: 3) Update Board Name If Exist
	* As a developer i want to rename 'RestApiBoard' board 
	* Call '/boards' endpoint with 'PUT' method for update 'RestApiBoard' board as 'RenamedRestApiBoard'
	* board should be renamed as 'RenamedRestApiBoard'

@deleteBoard
Scenario: 4) Delete Board If Exist
	* As a developer i want to remove a board named 'RenamedRestApiBoard'
	* Call '/boards' endpoint with 'DELETE' method for deletiton
	* Board should be deleted
	 