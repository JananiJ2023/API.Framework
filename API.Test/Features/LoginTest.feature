Feature: LoginTest

@positive
Scenario: Verify status description for successful login
	Given I have a valid email "loginusername" and password "loginpassword"
	When I post a request to login endpoint
	Then I should receive "OK" for login API status description
	Then I should receive token

@negative
Scenario: Verify error message when no email id 
	Given I have a valid email "loginusername" only
	When I post a request to login endpoint
	Then I should receive "Missing password" Error message for login
