Feature: Repeated Steps In Login Functionlity

Background: 
	Given User should launch the application in edge browser

@Regression
Scenario: To check the login functionality of Magento Customer with Valid Data
	And User should enter the value for Username and Password as "sabarivivek7@gmail.com" and "Sabari@123"
	When User clicks on SignIn Button
	Then The application should navigate the user to the My Account page

@UAT
Scenario: To check the login functionality of Magento Customer with Invalid Data
	And User should enter the value for Username and Password as "sabarivivek777@gmail.com" and "Sabari@123"
	When User clicks on SignIn Button
	Then The application should not navigate the user to the My Account page