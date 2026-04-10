Feature: Cart functionality for multiple product selection
  As a user
  I want to add multiple products to the cart
  So that I can verify cart actions and proceed to checkout

Scenario: Add two products to cart and verify cart page buttons
	Given I navigate to the SauceDemo login page
	When I login with valid credentials
	Then I should land on the products page with page title "Products" and atleast two products
	When I open the first product details page
	And I add the product to the cart
	And I navigate back to the products page
	And I open the second product details page
	And I add the product to the cart
	And I navigate to the cart page
	Then I should see 2 products in the cart
	And each product should have a "Remove" button
	And I should see a "Continue Shopping" button
	And I should see a "Checkout" button