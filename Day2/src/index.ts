import fs from 'fs';
import StrategyGuide from './data/strategy-guide';
import StrategyGuideParser from './data/strategy-guide-parser';
import StrategyGuideParserDay2 from './data/strategy-guide-parser-day-2';
import playGame from './play-game';

const loadData = (pathName: string): StrategyGuide => {

    // const parser = new StrategyGuideParser();
    const parser = new StrategyGuideParserDay2();
    const fileData = fs.readFileSync(pathName, 'utf-8').split('\n');
    
    const numStrategiesParsed = parser.parse(fileData);
    console.log(`Parsed ${numStrategiesParsed} from file ${pathName}`);

    return parser.getGuide();
};

console.info('Loading data for day 2');
const guide = loadData('./input.txt');

const score = playGame(guide);
console.info(`Score for game is ${score}`);

