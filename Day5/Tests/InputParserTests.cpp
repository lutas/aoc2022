#include "pch.h"
#include "CppUnitTest.h"
#include "../Day5/CrateStacks.h"
#include "../Day5/MoveHandler.h"
#include "../Day5/InputParser.h"

#include "TestData.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace Tests
{
	TEST_CLASS(InputParserTests)
	{
	public:
		
		TEST_METHOD(CanDifferentiateBetweenStacksAndMoves)
		{
			CrateStacks stacks;
			MoveHandler moveHandler;
			InputParser parser(stacks, moveHandler);

			auto lines = TestData::GetTestLineData();
			
			for (auto iter = lines.begin(); iter != lines.end(); ++iter) {
				parser.ParseTextLine(*iter);
			}

			Assert::IsTrue(parser.IsProcessingMoves());
		}

		TEST_METHOD(CanParseStacks)
		{
			CrateStacks stacks;
			MoveHandler moveHandler;
			InputParser parser(stacks, moveHandler);

			auto lines = TestData::GetTestLineData();

			for (auto iter = lines.begin(); iter != lines.end(); ++iter) {
				parser.ParseTextLine(*iter);
			}

			Assert::AreEqual(3, stacks.StackCount());
		}

		TEST_METHOD(CanParseCrateData)
		{
			CrateStacks stacks;
			MoveHandler moveHandler;
			InputParser parser(stacks, moveHandler);

			auto lines = TestData::GetTestLineData();

			for (auto iter = lines.begin(); iter != lines.end(); ++iter) {
				parser.ParseTextLine(*iter);
			}

			Assert::AreEqual(2, stacks.GetCrateCount(1));
			Assert::AreEqual(3, stacks.GetCrateCount(2));
			Assert::AreEqual(1, stacks.GetCrateCount(3));
		}

		TEST_METHOD(CanParseMoveData)
		{
			CrateStacks stacks;
			MoveHandler moveHandler;
			InputParser parser(stacks, moveHandler);

			auto lines = TestData::GetTestLineData();

			for (auto iter = lines.begin(); iter != lines.end(); ++iter) {
				parser.ParseTextLine(*iter);
			}

			Assert::AreEqual(4, moveHandler.Count());
		}
	};
}
