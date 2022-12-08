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

const data = fs.readFileSync('input.txt', 'utf-8').split('\n');
let score = 0;
data.forEach(line => {
    [ range1, range2 ] = parseTextLine(line);

    if (isRangeContained(range1, range2)) {
        ++score;
    }
});

console.info('Total assignment pairs where contained', score);