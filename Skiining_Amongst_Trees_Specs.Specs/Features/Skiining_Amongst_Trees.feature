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
	Given current column is equal to 32 and current row is 2
	Given the slope (1,1)
	When position is updated
	Then position in current row starts back at column 1

Scenario: Loop Tree Map Slope 2
	Given the file TreeMap.txt
	When reading the board
	Given current column is equal to 32 and current row is 1
	Given the slope (2,1)
	When position is updated
	Then position in current row starts back at column 2

Scenario: Loop Tree Map Slope 17
	Given the file TreeMap.txt
	When reading the board
	Given current column is equal to 30 and current row is 1
	Given the slope (17,1)
	When position is updated
	Then position in current row starts back at column 15

Scenario: Ski One Row
	Given the file TreeMap.txt
	When reading the board
	Given the slope (1,1)
	When position is updated
	Then the new position should be (1,1)

Scenario: Traverse Mountain
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (1,1)
	Then the final position should be (3,323)

Scenario: Non-Hit if '.'
	Given the file TreeMap.txt
	When reading the board
	Given the slope (1,1)
	When position is updated
	Then the new position should be (1,1)
	Then we do not hit a tree in that position

Scenario: Hit if '#'
	Given the file TreeMap.txt
	When reading the board
	Given the slope (1,1)
	When position is updated
	Then the new position should be (1,1)
	Then we do hit a tree in that position

Scenario: Correct Amount of Hits
	Given the file TreeMap.txt
	When reading the board
	When you traverse the mountain with slope (3,1)
	Then the final position should be (3,323)
	Then the amount of trees hit should be 164