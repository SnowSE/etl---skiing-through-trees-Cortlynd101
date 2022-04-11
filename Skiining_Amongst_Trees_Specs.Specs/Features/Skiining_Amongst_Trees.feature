Feature: Skiining_Amongst_Trees
! This program will use a text file as a mountain for someone to ski down, keeping track of the trees they run into on the way down.

@mytag
Scenario: Figure Out Rows, and Columns
	Given the file TreeMap.txt
	When reading the board
	Then the columns should be 31
	Then the rows should be 323

Scenario: Loop Tree Map Slope 1
	Given the file TreeMap.txt
	When reading the board
	Given current column is equal to 31 and current row is 2
	Given the slope (1,1)
	When position is updated
	Then position in current row starts back at column 1

Scenario: Loop Tree Map Slope 2
	Given the file TreeMap.txt
	When reading the board
	Given current column is equal to 31 and current row is 1
	Given the slope (2,1)
	When position is updated
	Then position in current row starts back at column 2

Scenario: Loop Tree Map Slope 17
	Given the file TreeMap.txt
	When reading the board
	Given current column is equal to 30 and current row is 1
	Given the slope (17,1)
	When position is updated
	Then position in current row starts back at column 16

Scenario: Ski One Row
	Given the file TreeMap.txt
	When reading the board
	Given the slope (1,1)
	When position is updated
	Then the new position should be (1,1)

Scenario: Traverse Mountain
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (3,1)
	Then the final position should be (8,323)

Scenario: Correct Amount of Hits slope 3
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (3,1)
	Then the amount of trees hit should be 164

Scenario: Correct Amount of Hits slope 1
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (1,1)
	Then the amount of trees hit should be 93

Scenario: Correct Amount of Hits slope 2
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (2,1)
	Then the amount of trees hit should be 97

Scenario: Correct Amount of Hits slope 4
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (4,1)
	Then the amount of trees hit should be 101

Scenario: Correct Amount of Hits slope 5
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (5,1)
	Then the amount of trees hit should be 82

Scenario: Correct Amount of Hits slope 6
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (6,1)
	Then the amount of trees hit should be 83

Scenario: Correct Amount of Hits slope 7
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (7,1)
	Then the amount of trees hit should be 91

Scenario: Correct Amount of Hits slope 8
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (8,1)
	Then the amount of trees hit should be 89

Scenario: Correct Amount of Hits slope 9
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (9,1)
	Then the amount of trees hit should be 89

Scenario: Correct Amount of Hits slope 10 
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (10,1)
	Then the amount of trees hit should be 85

Scenario: Correct Amount of Hits slope 15
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (15, 1)
	Then the amount of trees hit should be 75

Scenario: Correct Amount of Hits slope 22
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (22, 1)
	Then the amount of trees hit should be 93

Scenario: Finding Best Slope
	Given the file TreeMap.txt
	When reading the board
	When you find the best slope
	Then the best slope is (15, 1)