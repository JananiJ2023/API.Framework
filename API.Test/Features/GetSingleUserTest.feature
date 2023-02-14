Feature: GetSingleUserTest

To test the SINGLE USER GET Method


Scenario Outline: Verify response data for Single User
	Given that I have sent the GET request to get single user
	When I receive the response
	Then the response should have <id>, <email>, <first_name> and <last_name>

	Examples: 
	| id | email | first_name | last_name | 
	| 2 | janet.weaver@reqres.in | Janet | Weaver | 
