#pragma once

#include <deque>

class CrateStack
{
public:
	void Add(char crate);
	void AddToTop(char crate);
	char Pop();

	int Count() const;

	char GetTop() const;

private:
	std::deque<char> _crates;
};

