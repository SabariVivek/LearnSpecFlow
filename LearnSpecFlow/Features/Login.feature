Feature: Login Page
	
@Dev @Test
Scenario: To check the login functionality of the Customer with Valid Data
	Given User should launch the application in the edge browser
	And User should enter the value for Username as "sabarivivek7@gmail.com" and Password as "Sabari@123"
	When User clicks on the SignIn Button
	Then The application should navigate the user to My Account page

@Sanity
Scenario: To check the login functionality of the Customer with Invalid Data
	Given User should launch the application in the edge browser
	And User should enter the value for Username as "sabarivivek777@gmail.com" and Password as "Sabari@123"
	When User clicks on the SignIn Button
	Then The application should not navigate the user to My Account page