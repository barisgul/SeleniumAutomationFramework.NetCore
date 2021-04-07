Feature: Trello
	Simple calculator for adding two numbers

Background: Login 
	Given Open trello application on 'https://trello.com/'
	And Click on login
	And Enter username
	| username   | password |
	| baris.gul@outlook.com.tr | TrelloDemo.025 |
	And Click on 'Log in with Atlassian'
	And Enter password
	When Click on Log in 
	Then Trello dashboard should be open and 'Boards' menu should be visible

@CreateNewCard
Scenario: Create New Card 
	* Click to 'ChallangeTeam' on dashboard
	* 'ChallangeTeam' should be opened
	* Create 'To To Task' in 'To Do' list 

@CreateNewCardAndThenDelete
Scenario: Create New Card And Then Delete
	* Click to 'ChallangeTeam' on dashboard
	* 'ChallangeTeam' should be opened
	* Create 'TaskToBeDeleted' in 'Doing' list 
	* 'TaskToBeDeleted' card should be created
	* Delete 'TaskToBeDeleted' in 'Doing' list 
	* 'TaskToBeDeleted' card should be deleted


