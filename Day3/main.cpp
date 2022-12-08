#include <fstream>
#include <iostream>
#include <sstream>
#include <string>

char GetCommonLetter(const std::string& pack) {

    // drop to cstring for ease of iteration
    const char* szPack = pack.c_str();
    auto compartmentLength  = pack.length() / 2;

    const char* const c2Start = szPack + compartmentLength;
    const char* const c2End = szPack + compartmentLength + compartmentLength + 1;

    for (const char* c1 = szPack; c1 < c2Start; ++c1) {

        for (const char* c2 = c2Start; c2 < c2End; ++c2) {
            if (*c1 == *c2) {
                return *c1;
            }
        }
    }

    throw std::invalid_argument("Failed to find common letter");
}

char GetCommonLetter(const std::string& elf1, const std::string& elf2, const std::string& elf3) {

    // drop to cstrings for ease of iteration
    const char* szElf1 = elf1.c_str();
    const char* szElf2 = elf2.c_str();
    const char* szElf3 = elf3.c_str();

    for (const char* e1 = szElf1; *e1 != '\0'; ++e1) {
        for (const char* e2 = szElf2; *e2 != '\0'; ++e2) {

            // is the char common between the first two elves?
            if (*e1 == *e2) {
                // if the char also in elf 3?
                for (const char* e3 = szElf3; *e3 != '\0'; ++e3) {
                    if (*e1 == *e3) {
                        return *e1;
                    }
                }
            }
        }
    }

    throw std::invalid_argument("Failed to find a common letter in group of elves");
}

int ScorePriority(const char c) {

    const int A = 0x41;
    const int Z = 0x5A;

    const int a = 0x61;
    const int z = 0x7A;

    int v = (int)c;
    // uppercase A to Z is priority 27 to 52
    // so take ascii value and transform into that range
    if (c >= A && c <= Z) {
        return (c - A) + 27;
    }

    // lowercase A to Z is priority 1 to 26
    // so take ascii value and transform into that range
    if (c >= a && c <= z) {
        return (c - a) + 1;
    }

    throw std::invalid_argument("Invalid char input found");
}

int day1(const char* filePath) {

    std::ifstream f(filePath, std::fstream::in);

    std::string strPack;
    int line = 0;
    int totalScore = 0;
    while (std::getline(f, strPack)) {
        
        const char commonLetter = GetCommonLetter(strPack);
        const int score = ScorePriority(commonLetter);
        std::cout << "Pack " << line + 1 << " = " << commonLetter 
                  << " (" << score << ") pts" << std::endl;

        totalScore += score;

        ++line;
    }

    return totalScore;
};

int day2(const char* filePath) {
    std::ifstream f(filePath, std::fstream::in);

    std::string elf[3];
    int group = 0;
    int totalScore = 0;
    while (std::getline(f, elf[0])) {

        // assume that there are always groups of 3 elves 
        // (i.e. number of lines in input file is a multiple of 3)
        std::getline(f, elf[1]);
        std::getline(f, elf[2]);
        
        const char commonLetter = GetCommonLetter(elf[0], elf[1], elf[2]);
        const int score = ScorePriority(commonLetter);
        std::cout << "Group " << group + 1 << " = " << commonLetter 
                  << " (" << score << ") pts" << std::endl;

        totalScore += score;

        ++group;
    }

    return totalScore;
}

int main() {
    int totalScore = day2("input.txt");
    
    std::cout << "Total score = " << totalScore << std::endl;
}