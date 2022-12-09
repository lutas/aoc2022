#include "pch.h"
#include "CppUnitTest.h"

#include "../Day5/CrateStacks.h"
#include "../Day5/MoveHandler.h"
#include "../Day5/InputParser.h"
#include "TestData.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace Tests
{
	TEST_CLASS(EndToEndTests)
	{
	public:

		TEST_METHOD(GivesExpectedAnswer)
		{
			CrateStacks stacks;
			MoveHandler moveHandler;
			InputParser parser(stacks, moveHandler);

			auto lines = TestData::GetTestLineData();

			for (auto iter = lines.begin(); iter != lines.end(); ++iter) {
				parser.ParseTextLine(*iter);
			}

			moveHandler.Apply(stacks);

			std::string answer = stacks.GetTopAnswer();

			Assert::AreEqual(TestData::GetTestExpectedAnswer(), answer);
		}

	};
}
