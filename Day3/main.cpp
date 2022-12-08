#include <fstream>
#include <iostream>
#include <sstream>
#include <string>

char GetCommonLetter(const std::string& pack) {

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

int ScorePriority(const char c) {

    std::cout << "Scoring letter " << c;

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

int main() {

    std::ifstream f("input.txt", std::fstream::in);

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

    std::cout << "Total score = " << totalScore << std::endl;
};