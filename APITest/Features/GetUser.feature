Feature: GetUser
2.	Verify that a GET request can be posted to the API to get the expected details of single user
3.	Verify that a GET request can be posted to the API to get the expected details of the list of users
5.	Verify that a GET request can be posted to the API to return a single user not found, which should return a “404” response. 

Scenario: Verify if I can get details of a single user through GET
	Given I perform "GET" operation for  "api/users/{id}"
	When I send the 'id' as '2' in the request
	Then I should see the result should have 'id' of '2'


Scenario Outline: Verify if I can get details of mulitple users through GET
	Given I perform "GET" operation for  "api/unknown"
	Then I should see that the result should have 'id' of '<ids>' and '<names>'
	Examples: 
	| ids | names        |
	| 1   | cerulean     |
	| 2   | fuchsia rose |
	| 3   | true red     |

Scenario: Verify 404 is returned when the user is not found
	Given I perform "GET" operation for  "api/unknown/23"
	Then I should see the result should have status code of '404'