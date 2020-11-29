Feature: AddUser
	1.	Verify that a POST request can be posted to the API to create the single user and assert that the single user is createds

@mytag
Scenario Outline: Verify creation of a single user through POST
	Given I perform "POST" operation for  "api/users"
	When I send the "<Username>" and "<Job>" in the request
	Then I should see the the result should have "<Username>" and "<Job>" in 'name' and 'job'
	Examples:
	| Username | Job       |
	| Test1    | Tester    |
	| Test2    | Developer |