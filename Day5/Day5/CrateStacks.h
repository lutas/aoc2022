#pragma once


#include "CrateStack.h"
#include <map>
#include <stdexcept>

class CrateStacks
{
public: 
	void AddStack(int id);

	inline int StackCount() {
		return _stacks.size();
	}

	void AddCrate(int stack, char crate);
	int GetCrateCount(int index) const;

	bool MoveCrate(int stackFrom, int stackTo);

	std::string GetTopAnswer() const;

private:
	std::map<int, CrateStack> _stacks;
};

