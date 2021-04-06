Feature: Login
	Login to Trello with specified credentials in the scenario

@login
Scenario: Login 
	* Open trello application on 'https://trello.com/'
	* Click on login
	* Enter username
	| username   | password |
	| baris.gul@outlook.com.tr | TrelloDemo.025 |
	* Click on 'Log in with Atlassian'
	* Enter password
	* Click on Log in 
	* Trello dashboard should be open and 'Boards' menu should be visible
	* Click on logout button
	* Logout should be succeded