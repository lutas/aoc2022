#pragma once
#include "Move.h"

#include "CrateStacks.h"
#include <queue>

class MoveHandler
{
public:
	void AddMove(const Move& move);

	void Apply(CrateStacks& stacks);
	void ApplyDay2(CrateStacks& stacks);

	inline int Count() const {
		return _moves.size();
	}

private:
	std::queue<Move> _moves;
};

