Feature: UpdateUserTest

@positive
Scenario: Verify updating a user
	Given I input name "Morpheus"
	And I input role "Student"
	When I send update user request
	Then validate user is updated