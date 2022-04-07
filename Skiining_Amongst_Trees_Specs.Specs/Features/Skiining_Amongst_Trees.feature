Feature: Skiining_Amongst_Trees
! This program will use a text file as a mountain for someone to ski down, keeping track of the trees they run into on the way down.

@mytag
Scenario: Figure Out Rows, and Columns
	Given the file TreeMap.txt
	When reading the board
	Then the columns should be 31
	Then the rows should be 322
	

Scenario: Loop Tree Map

Scenario: Ski to Bottom

Scenario: Use Correct Slope

Scenario: Non-Hit if '.'

Scenario: Hit if '#'

Scenario: Correct Amount of Hits