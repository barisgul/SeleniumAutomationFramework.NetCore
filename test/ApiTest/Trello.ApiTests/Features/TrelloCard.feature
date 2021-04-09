﻿Feature: TrelloCard
	This feature contains Get cards, Create card on a list, archiving a card and deleting a card through the trello rest api services

@getBoardCars
Scenario: 1) Get User Cards In A Board
	* As a developer I want to get cards from 'ChallangeTeam'
	* Call '/boards' endpoint with 'GET' method
	* Board cards should return

@updateCard
Scenario: 2) Create a Card on a list
	* As a developer I want to create a card on 'ChallangeTeam' board in 'To Do' list
	* Call '/boards' endpoint with 'POST' method for creating 'AutoGeneratedCard' on 'To Do' list
	* 'AutoGeneratedCard' card should be created

@completeCard
Scenario: 3) Move Card To Archive
	* As a developer I want to move a card to Done on 'ChallangeTeam' board 
	* Call 'endpoint' with 'PUT' method for change the description of 'AutoGeneratedCard' on 'To Do' list
	* Call '/boards' endpoint with 'POST' for moving 'AutoGeneratedCard' card from 'To Do' to 'Archive' 

@deleteCard
Scenario: 4) Delete Card 
	* As a developer I want to create a card on 'ChallangeTeam' board in 'To Do' list
	* Call '/boards' endpoint with 'POST' method for creating 'DeletableCard' on 'To Do' list
	* 'DeletableCard' card should be created
	* Call 'endpoint' with 'DELETE' method for delete the 'DeletableCard' 
	* 'DeletableCard' card should be deleted
 