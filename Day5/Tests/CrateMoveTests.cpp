#include "pch.h"
#include "CppUnitTest.h"

#include "../Day5/CrateStacks.h"
#include "../Day5/MoveHandler.h"
#include "../Day5/InputParser.h"
#include "TestData.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace Tests
{
	TEST_CLASS(CrateMoveTests)
	{
	public:

		TEST_METHOD(CanApplyASingleMove)
		{
			CrateStacks stacks;
			stacks.AddStack(1);
			stacks.AddStack(2);
			stacks.AddCrate(1, 'a');

			MoveHandler moveHandler;
			Move move;
			move.numCrates = 1;
			move.fromColumn = 1;
			move.toColumn = 2;
			moveHandler.AddMove(move);

			moveHandler.Apply(stacks);

			Assert::AreEqual(0, stacks.GetCrateCount(1));
			Assert::AreEqual(1, stacks.GetCrateCount(2));
		}

		TEST_METHOD(CanApplyMultipleMoves)
		{
			CrateStacks stacks;
			stacks.AddStack(1);
			stacks.AddStack(2);
			stacks.AddCrate(1, 'a');
			stacks.AddCrate(1, 'b');
			stacks.AddCrate(2, 'x');

			MoveHandler moveHandler;
			Move move;
			move.numCrates = 2;
			move.fromColumn = 1;
			move.toColumn = 2;
			moveHandler.AddMove(move);

			Move move2;
			move2.numCrates = 1;
			move2.fromColumn = 2;
			move2.toColumn = 1;
			moveHandler.AddMove(move2);

			moveHandler.Apply(stacks);

			Assert::AreEqual(1, stacks.GetCrateCount(1));
			Assert::AreEqual(2, stacks.GetCrateCount(2));
		}

		TEST_METHOD(CanMoveMoreThanOneCrate)
		{
			CrateStacks stacks;
			stacks.AddStack(1);
			stacks.AddStack(2);
			stacks.AddCrate(1, 'a');
			stacks.AddCrate(1, 'b');
			stacks.AddCrate(1, 'c');
			stacks.AddCrate(2, 'x');
			stacks.AddCrate(2, 'y');

			MoveHandler moveHandler;
			Move move;
			move.numCrates = 2;
			move.fromColumn = 1;
			move.toColumn = 2;
			moveHandler.AddMove(move);

			moveHandler.Apply(stacks);

			Assert::AreEqual(1, stacks.GetCrateCount(1));
			Assert::AreEqual(4, stacks.GetCrateCount(2));
		}
	};
}
