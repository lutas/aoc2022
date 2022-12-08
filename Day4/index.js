const fs = require('fs');

const getRange = (rangeText) => {

    const textSections = rangeText.split('-');
    const sections = textSections.map(section => parseInt(section));

    return {
        lower: sections[0],
        upper: sections[1]
    };
}

const parseTextLine = (line) => {

    const ranges = line.split(',').map(getRange);

    return [ranges[0], ranges[1]];
};

const isRangeContained = (src, dest) => {

    if (src.lower <= dest.lower && src.upper >= dest.upper) {
        return true;
    }

    if (dest.lower <= src.lower && dest.upper >= src.upper) {
        return true;
    }    
}

const overlaps = (src, dest) => {

    // test the lower bound of range2
    if (isRangeContained(src, { lower: dest.lower, upper: dest.lower })) {
        return true;
    }
    
    // test the upper bound of range2
    if (isRangeContained(src, { lower: dest.upper, upper: dest.upper })) {
        return true;
    }

    // test the lower bound of range1
    if (isRangeContained(dest, { lower: src.lower, upper: src.lower })) {
        return true;
    }

    // test the upper bound of range1
    if (isRangeContained(dest, { lower: src.upper, upper: src.upper})) {
        return true;
    }
}

const data = fs.readFileSync('input.txt', 'utf-8').split('\n');
let score = 0;
data.forEach(line => {
    [ range1, range2 ] = parseTextLine(line);

    if (overlaps(range1, range2)) {
        ++score;
    }
});

console.info('Total assignment pairs where contained', score);