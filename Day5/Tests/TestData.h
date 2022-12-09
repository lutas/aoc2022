#pragma once

#include <vector>
#include <string>

namespace TestData {

	inline std::vector<std::string> GetTestLineData() {

		std::vector<std::string> lines = {
				"    [D]    ",
				"[N] [C]    ",
				"[Z] [M] [P]",
				" 1   2   3",
				"",
				"move 1 from 2 to 1",
				"move 3 from 1 to 3",
				"move 2 from 2 to 1",
				"move 1 from 1 to 2"
		};

		return lines;
	}

	inline std::string GetTestExpectedAnswer() {
		return "CMZ";
	}

}