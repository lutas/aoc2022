import StrategyGuideParserDay2 from "../src/data/strategy-guide-parser-day-2";
import playGame from "../src/play-game";

describe('playing a game according to a outcome', () => {

    test('suggested data', () => {

        const parser = new StrategyGuideParserDay2();
        parser.parse([
            'A Y',
            'B X',
            'C Z'
        ]);
        const guide = parser.getGuide();

        const score = playGame(guide);
        
        expect(score).toBe(12);
    });

});