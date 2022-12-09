#include "CrateStacks.h"
#include <stdexcept>
#include <sstream>

void CrateStacks::AddStack(int id)
{
	_stacks[id] = CrateStack();
}

void CrateStacks::AddCrate(int stack, char crate)
{
	auto iter = _stacks.find(stack);
	if (iter == _stacks.end())
	{
		throw std::invalid_argument("Attempt to add crate to invalid stack");
	}

	iter->second.Add(crate);
}

int CrateStacks::GetCrateCount(int stack) const
{
	auto iter = _stacks.find(stack);
	if (iter == _stacks.end())
	{
		throw std::invalid_argument("Attempt to add crate to invalid stack");
	}

	return iter->second.Count();
}

bool CrateStacks::MoveCrate(int stackFromId, int stackToId)
{
	auto stackFrom = _stacks.find(stackFromId);
	auto stackTo = _stacks.find(stackToId);

	if (stackFrom == _stacks.end() || stackTo == _stacks.end())
	{
		throw std::invalid_argument("Unknown stack specified when moving crates");
	}

	if (stackFrom->second.Count() == 0)
	{
		return false;
	}

	char crate = stackFrom->second.Pop();
	stackTo->second.AddToTop(crate);

	return true;
}

std::string CrateStacks::GetTopAnswer() const
{
	std::stringstream answer;
	
	for (auto iter = _stacks.begin(); iter != _stacks.end(); ++iter) {
		answer << iter->second.GetTop();
	}

	return answer.str();
}