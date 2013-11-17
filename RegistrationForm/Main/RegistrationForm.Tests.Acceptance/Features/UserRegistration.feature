Feature: UserRegistration
	In order to use the features only available to members
	As a Guest user 
	I want to register a new account

@Browser:Firefox
@Browser:Safari
@Browser:IE
@Browser:Chrome
Scenario:  User signs up with valid details
	Given I am on the home page
	And I am not logged in
	When I click the register button
	And fill of the registration form with the following details
	| field				| value				|
	| UserName			| Jonesm			|
	| Password			| password1			|
	| ConfirmPassword	| password1			|
	And I submit the form
	Then I redirected to the home page
	And I will be logged in

@Browser:Firefox
@Browser:Safari
@Browser:IE
@Browser:Chrome
Scenario:  User signs up with differing passwords 
	Given I am on the home page
	And I am not logged in
	When I click the register button
	And fill of the registration form with the following details
	| field				| value				|
	| UserName			| Jonesm			|
	| Password			| password1			|
	| ConfirmPassword	| pasword1			|
	And  I submit the form
	Then I will see the message the password and password confirmation do not match

