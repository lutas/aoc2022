#include "InputParser.h"

#include <iostream>
#include <sstream>

namespace {
    // support methods
    std::string trim(const std::string& s) {
        std::string str = s;
        size_t first = str.find_first_not_of(' ');
        if (first == std::string::npos)
            return "";

        size_t last = str.find_last_not_of(' ');
        return str.substr(first, (last - first + 1));
    }
}

InputParser::InputParser(CrateStacks& stacks, MoveHandler& moveHandler)
	: _pStacks(&stacks),
      _pMoveHandler(&moveHandler),
      _hasProcessedStacks(false)
{
}

void InputParser::ParseTextLine(const std::string& line)
{
    if (trim(line) == "") {
        CreateStackFromMatrix();
        _hasProcessedStacks = true;
        return;
    }

    if (!_hasProcessedStacks) {
        ParseStack(line);
    }
    else {
        ParseMove(line);
    }
}

void InputParser::ParseStack(const std::string& line)
{
    // store the stack matrix
    int numColumns = (line.length() / 4) + 1;

    std::vector<char> row(numColumns);

    for (int i = 0; i < numColumns; ++i) {
        int charIndex = (i * 4) + 1;
        char data = line[charIndex];
        row[i] = data;
    }

    _stackMatrix.push_back(row);    
}

void InputParser::ParseMove(const std::string& line)
{
    if (line.find_first_of("move") != 0) {
        throw std::invalid_argument("Invalid move line when parsing");
    }

    Move move;

    std::string tmp;

    std::stringstream ss(line);
    ss >> tmp >> move.numCrates >> tmp >> move.fromColumn >> tmp >> move.toColumn;

    _pMoveHandler->AddMove(move);
}

void InputParser::CreateStackFromMatrix()
{
    // bottom row of matrix is the column numbers
    auto bottomRow = _stackMatrix.back();

    for (int column = 0; column < bottomRow.size(); ++column) {
        int id;
        std::stringstream ss;
        ss << bottomRow[column];
        ss >> id;

        _pStacks->AddStack(id);

        // loop over each row of the matrix and add the current column 
        for (auto iter = _stackMatrix.begin(); iter < std::prev(_stackMatrix.end()); ++iter) {
            char v = iter->at(column);
            if (v != ' ') {
                _pStacks->AddCrate(id, v);
            }
        }
    }
}
