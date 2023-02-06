Feature: GetUserTest

Scenario: Verify presence of a user 
	Given that I have sent the GET request to get users
	When I receive the response 
	Then the response should contain "Lindsay Ferguson"
