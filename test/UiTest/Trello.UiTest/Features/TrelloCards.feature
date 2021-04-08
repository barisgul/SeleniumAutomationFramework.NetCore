Feature: TrelloCards
	This feature contains create card, update status, delete and complete scenarios.
	All scenarios execute the Login steps before start to own scenario.
	Login steps are type of Given-When-Then notation and the core scenario steps are type of Mark-Down notation. Supports both of them.

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
	* Create 'To Do Task' in 'To Do' list 
	* 'To Do Task' card should be created in 'Doing' list

@CreateNewCardAndThenDelete
Scenario: Create New Card And Then Delete
	* Click to 'ChallangeTeam' on dashboard
	* 'ChallangeTeam' should be opened
	* Create 'TaskToBeDeleted' in 'Blocked' list 
	* 'TaskToBeDeleted' card should be created in 'Blocked' list
	* Delete 'TaskToBeDeleted' in 'Blocked' list  

@CreateNewCardAndThenMove
Scenario: Create New Card And Then Move
	* Click to 'ChallangeTeam' on dashboard
	* 'ChallangeTeam' should be opened
	* Create 'TaskToBeMoved' in 'Doing' list 
	* 'TaskToBeMoved' card should be created in 'Doing' list
	* Enter 'Sample card description' to description and Move 'TaskToBeMoved' to 'Done' list
	* 'TaskToBeMoved' card should be moved

@CreateNewCardAndUpdateThenComplete
Scenario: Create New Card and Update Then Complete
	* Click to 'ChallangeTeam' on dashboard
	* 'ChallangeTeam' should be opened
	* Create 'Complete this card' in 'To Do' list 
	* Enter 'Set as doing' to description and Move 'Complete this card' to 'Doing' list
	* 'Complete this card' card should be moved
	* Enter 'set as completed' to description and Move 'Complete this card' to 'Done' list
	* 'Complete this card' card should be moved to 'Done' list