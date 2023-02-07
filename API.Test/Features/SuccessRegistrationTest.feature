Feature: SuccessRegistrationTest

	@tag=positive
Scenario: Verify successful registration
	Given I have a valid email "eve.holt@reqres.in" and password "pistol"
	When I post a request
	Then I should receive "OK" status description

	@tag=negative
Scenario: Verify unsuccessful registration
	Given I have a valid email "sydney@fife" and password "pistol"
	When I post a request 
	Then I should receive "Bad Request" status description

	@tag=negative
Scenario: Verify error message when no email id 
	Given I have a valid email "eve.holt@reqres.in" only
	When I post a request 
	Then I should receive "Missing password" Error message