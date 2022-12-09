#include "CrateStack.h"

void CrateStack::Add(char crate)
{
	_crates.push_back(crate);
}

void CrateStack::AddToTop(char crate)
{
	_crates.push_front(crate);
}

char CrateStack::Pop()
{
	char crate = _crates.front();
	_crates.pop_front();
	return crate;
}

int CrateStack::Count() const
{
	return _crates.size();
}

char CrateStack::GetTop() const
{
	return _crates.front();
}
