import StrategyGuideParser from "../src/data/strategy-guide-parser";
import playGame from "../src/play-game";

describe('playing a game according to a strategy', () => {

    test('playing strategy gives correct score', () => {

        const parser = new StrategyGuideParser();
        parser.parse([
            'A Y',
            'B X',
            'C Z'
        ]);
        const guide = parser.getGuide();

        const score = playGame(guide);
        
        expect(score).toBe(15);
    });

});