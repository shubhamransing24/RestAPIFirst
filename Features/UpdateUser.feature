Feature: Update User 


@mytag
Scenario: Update user Records
	Given I Input Name For Update "morpheus"
	And I Input Job For Update "zion resident"
	When I Send Request For Update
	Then  I Validate the Response

	Scenario: Update user Records using Patch
	Given I Input Name For Update "morpheus"
	And I Input Job For Update "zion resident"
	When I Send Request For Update using Patch
	Then  I Validate the Response 