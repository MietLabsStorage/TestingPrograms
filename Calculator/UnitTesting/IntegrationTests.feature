Feature: IntegrationTests
	integration tests for calculaor

@integration_test_sum
Scenario: Add two numbers
	Given init calculator
	Given A is <a>
	And B is <b>
	When click to sum
	Then result is <result>
	And close calculator

Examples: 
| a        | b       | result          |
| 1        | 2       | 3               |
| -1       | -2      | -3              |
| -1       | 2       | 1               |
| 1        | -2      | -1              |
| 0.3      | 0.3     | 0.6             |
| -1.7E308 | 1.7E308 | 0               |
| x        | y       | 0               |
| x        | 1       | 1               |
| 1        | y       | 1               |
|          |         | Empty parameter |
|          | 1       | Empty parameter |
| 1        |         | Empty parameter |


@integration_test_minus
Scenario: Substract two numbers
	Given init calculator
	Given A is <a>
	And B is <b>
	When click to minus
	Then result is <result>
	And close calculator
Examples: 
| a        | b        | result          |
| 1        | 2        | -1              |
| -1       | -2       | 1               |
| -1       | 2        | -3              |
| 1        | -2       | 3               |
| 0.3      | 0.6      | -0.3            |
| -1.7E308 | -1.7E308 | 0               |
| 1.7E308  | 1.7E308  | 0               |
| x        | y        | 0               |
| x        | 1        | -1              |
| 1        | y        | 1               |
|          |          | Empty parameter |
|          | 1        | Empty parameter |
| 1        |          | Empty parameter |


@integration_test_multiply
Scenario: Multiply two numbers
	Given init calculator
	Given A is <a>
	And B is <b>
	When click to multiply
	Then result is <result>
	And close calculator
Examples: 
| a        | b   | result          |
| 1        | 2   | 2               |
| -1       | -2  | 2               |
| -1       | 2   | -2              |
| 1        | -2  | -2              |
| 0.3      | 0.3 | 0.09            |
| -1.7E307 | 10  | -1.7E+308       |
| 1.7E307  | 10  | 1.7E+308        |
| x        | y   | 0               |
| x        | 1   | 0               |
| 1        | y   | 0               |
|          |     | Empty parameter |
|          | 1   | Empty parameter |
| 1        |     | Empty parameter |


@integration_test_division
Scenario: Divide two numbers
	Given init calculator
	Given A is <a>
	And B is <b>
	When click to division
	Then result is <result>
	And close calculator
Examples: 
| a        | b            | result           |
| 1        | 2            | 0.5              |
| -1       | -2           | 0.5              |
| -1       | 2            | -0.5             |
| 1        | -2           | -0.5             |
| 0.3      | 0.3          | 1                |
| -1.7E308 | 10           | -1.7E+307        |
| 1.7E308  | 10           | 1.7E+307         |
| x        | y            | Division by zero |
| x        | 1            | 0                |
| 1        | y            | Division by zero |
|          |              | Empty parameter  |
|          | 1            | Empty parameter  |
| 1        |              | Empty parameter  |
| 12       | 0            | Division by zero |
| 12       | 0.00000001   | Division by zero |
| 12       | 0.000000009  | Division by zero |
| 12       | -0.00000001  | Division by zero |
| 12       | -0.000000009 | Division by zero |