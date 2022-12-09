#pragma once

#include <vector>
#include <string>

#include "CrateStacks.h"
#include "MoveHandler.h"

class InputParser
{
public:
	InputParser(CrateStacks& stacks, MoveHandler& moveHandler);

	void ParseTextLine(const std::string& line);

	inline bool IsProcessingMoves() const {
		return _hasProcessedStacks;
	}

private:
	void ParseStack(const std::string& line);
	void ParseMove(const std::string& line);

	void CreateStackFromMatrix();

	bool _hasProcessedStacks;
	CrateStacks *_pStacks;
	MoveHandler *_pMoveHandler;

	std::vector<std::vector<char>> _stackMatrix;

	InputParser();
};

