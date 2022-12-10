#include <stdio.h>
#include <stdbool.h>
#include <assert.h>

#define NUM_DIFFERENT_CHARS 14

bool isUnique(const char* chars, int num) {
    for (int x = 0; x < num; ++x) {
        for (int y = x + 1; y < num; ++y) {
            if (chars[x] == chars[y]) {
                return false;
            }
        }
    }

    return true;
}

int getNonRepeatingSequenceIndex(const char* const buff) {

    char pattern[NUM_DIFFERENT_CHARS];
    strncpy(pattern, buff, NUM_DIFFERENT_CHARS);
    unsigned int index = 0;

    const int length = strlen(buff);
    for (const char* p = buff; *p != '\0'; ++p) {
        pattern[index] = *p;
        
        ++index;
        index = index % NUM_DIFFERENT_CHARS;

        // test that pattern is unique
        if (isUnique(pattern, NUM_DIFFERENT_CHARS)) {
            return p - buff + 1;
        }

    }

    return -1;
}

void day1Tests() {

    int answers[] = { 
        getNonRepeatingSequenceIndex("mjqjpqmgbljsphdztnvjfqwrcgsmlb"),
        getNonRepeatingSequenceIndex("bvwbjplbgvbhsrlpgdmjqwftvncz"),
        getNonRepeatingSequenceIndex("nppdvjthqldpwncqszvftbrmjlhg"),
        getNonRepeatingSequenceIndex("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"),
        getNonRepeatingSequenceIndex("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")
    };

    int expectedAnswers[] = { 7, 5, 6, 10, 11 };

    for (int i = 0; i < 5; ++i) {
        char result[16];
        sprintf(result, "Answer %d: %d\n", (i + 1), answers[i]);
        printf(result);

        assert(answers[i] == expectedAnswers[i]);
    }
}


void day2Tests() {

    int answers[] = { 
        getNonRepeatingSequenceIndex("mjqjpqmgbljsphdztnvjfqwrcgsmlb"),
        getNonRepeatingSequenceIndex("bvwbjplbgvbhsrlpgdmjqwftvncz"),
        getNonRepeatingSequenceIndex("nppdvjthqldpwncqszvftbrmjlhg"),
        getNonRepeatingSequenceIndex("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"),
        getNonRepeatingSequenceIndex("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")
    };

    int expectedAnswers[] = { 19, 23, 23, 29, 26 };

    for (int i = 0; i < 5; ++i) {
        char result[16];
        sprintf(result, "Answer %d: %d\n", (i + 1), answers[i]);
        printf(result);

        assert(answers[i] == expectedAnswers[i]);
    }
}

int main() {

    day2Tests();

    FILE* file = fopen("input.txt", "r");
    // file size
    fseek(file, 0, SEEK_END);
    long fsize = ftell(file);
    rewind(file);

    // file contents
    char *buf = (char*)malloc(fsize + 1);
    fread(buf, fsize, 1, file);
    fclose(file);    

    int answer = getNonRepeatingSequenceIndex(buf);

    free(buf);

    char result[16];
    sprintf(result, "Answer Day 1: %d\n", answer);
    printf(result);

    return 1;
}