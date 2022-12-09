#include "MoveHandler.h"

void MoveHandler::AddMove(const Move& move)
{
	_moves.push(move);
}

void MoveHandler::Apply(CrateStacks& stacks)
{
	while (_moves.size()) {

		const Move move = _moves.front();

		for (int i = 0; i < move.numCrates; ++i)
		{
			if (!stacks.MoveCrate(move.fromColumn, move.toColumn))
			{
				throw std::invalid_argument("Attempted to move a crate that doesn't exist");
			}
		}

		_moves.pop();
	}
}

