// Day5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>
#include "InputParser.h"

int main()
{
	std::ifstream f("../input.txt", std::ios_base::in);

	// the input file is separated into two logical sections
	// the first denotes the starting point for the stacks
	// the second is the move list 
	// the two are separated by an empty line

	// parse the columns

	CrateStacks crateStacks;
	MoveHandler moveHandler;

	InputParser parser(crateStacks, moveHandler);

	std::string str;
	while (std::getline(f, str)) {
		parser.ParseTextLine(str);
	}

	f.close();

	moveHandler.ApplyDay2(crateStacks);

	std::cout << "Top answer was " << crateStacks.GetTopAnswer() << std::endl;
}
