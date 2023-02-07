Feature: SuccessRegistrationTest

	@positive
Scenario: Verify successful registration
	Given I have a valid email "eve.holt@reqres.in" and password "pistol"
	When I post a request
	Then I should receive "OK" status description

	@negative
Scenario: Verify unsuccessful registration
	Given I have a invalid email "sydney@fife" and password "pistol"
	When I post a request 
	Then I should receive "Bad Request" status description

	@negative
Scenario: Verify error message when no email id 
	Given I have a valid email "eve.holt@reqres.in" only
	When I post a request 
	Then I should receive "Missing password" Error message