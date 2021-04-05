Feature: Trello
	Simple calculator for adding two numbers

Background: Login
* Open trello application on 'https://trello.com/'
* Click on login
* Enter username
| username   | password |
| baris.gul@outlook.com.tr | TrelloDemo.025 |
* Click on 'Log in with Atlassian'
* Enter password
* Click on Log in 
* 'AssignmentBoard' should be opened

@CreateNewCard
Scenario: Create New Card
	* Open trello application board
	* 'AssignmentBoard' should be opened
	* Click on 'Add a card' in 'To Do' list
	* Type 'Sample Task' 
	* Click on 'Add card' button
	* Card should be created


