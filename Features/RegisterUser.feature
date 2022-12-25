Feature: RegisterUser
Register a New User

@mytag
Scenario: Register new user using post request
	Given I input Email for register "eve.holt@reqres.in"
	And I input Password for register "pistol"
	When I send Create New Account Request
	Then Validate Account is created successfully

Scenario: Register new user using post request but without password
	Given I input Email for register "eve.holt@reqres.in"
	When I send Create New Account Request
	Then Validate Err Message "Missing password"


Scenario: Delete User 
	When I send Delete User Request
	Then Validate Delete Responce

