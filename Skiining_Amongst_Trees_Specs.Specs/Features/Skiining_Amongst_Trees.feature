Feature: Skiining_Amongst_Trees
! This program will use a text file as a mountain for someone to ski down, keeping track of the trees they run into on the way down.

@mytag
Scenario: Figure Out Rows, and Columns
	Given the file TreeMap.txt
	When reading the board
	Then the columns should be 31
	Then the rows should be 323
	

Scenario: Loop Tree Map
	Given the file TreeMap.txt
	When reading the board
	Given current column is equal to 32
	When position is updated
	Then position in current row starts back at column 0

Scenario: Ski to Bottom
	Given the file TreeMap.txt
	When reading the board
	Given the slope (1,1)
	When position is updated
	Then the new position should be (1,1)


Scenario: Use Correct Slope


Scenario: Non-Hit if '.'

Scenario: Hit if '#'

Scenario: Correct Amount of Hits