Feature: LoginSuccessfull
Checking Login is working or Not

@mytag
Scenario: Login successfull using Post Request
	Given  I input Email for Login "eve.holt@reqres.in"
	And I input Password for Login "cityslicka"
	When I Send Login User Request
	Then I Validate Login Successfull