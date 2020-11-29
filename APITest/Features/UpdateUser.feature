Feature: UpdateUser
4.	Verify that a PUT request can be posted to the API to update the single user and assert that the expected update was made. 

Scenario: Verify if I can update details of a single user through PUT
	Given I perform "PUT" operation for  "api/users/{id}"
	When I send the 'id' as '2' in the request
	When I send the "<Username>" and "<Job>" in the request
	Then I should see the the result should have "<Username>" and "<Job>" in 'name' and 'job'

	Examples:
	| Username | Job       |
	| Test1    | Tester    |
