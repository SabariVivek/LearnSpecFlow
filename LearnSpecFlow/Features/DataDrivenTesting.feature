Feature: Data Driven Testing

Scenario Outline: To check the login functionality of Magento Customer with Data Driven
	Given User should launch the application
	And User should enter the value as "<Username>" and "<Password>"
	When User clicks on Login Button
	Then Verify the output with "<Type>" data

	@Smoke @Test @Dev
	Examples: 
	| Username                 | Password   | Type    |
	| sabarivivek7@gmail.com   | Sabari@123 | Valid   |

	@Regression @UAT @QA
	Examples: 
	| Username                 | Password   | Type    |
	| sabarivivek7@gmail.com   | Sabari@123 | Valid   |