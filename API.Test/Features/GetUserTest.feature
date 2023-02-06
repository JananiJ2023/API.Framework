Feature: GetUserTest

Scenario: Verify presence of a user 
	Given list user request is sent
	Then verify if "Lindsay" "Ferguson" is present in the list
