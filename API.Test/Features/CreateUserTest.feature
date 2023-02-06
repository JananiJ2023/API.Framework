Feature: CreateUserTest

Scenario: Add a user
	Given I input name "Jan"
	And I input role "QA"
	When I send create user request
	Then validate user is created

