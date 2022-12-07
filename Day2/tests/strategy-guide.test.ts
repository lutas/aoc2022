import StrategyGuideParser from "../src/data/strategy-guide-parser";

describe('loading strategy guide', () => {

    test('can load multiple strategies', () => {

        const data = 'A Y\nA Z\nB X'.split('\n');
        const parser = new StrategyGuideParser();

        const numParsed = parser.parse(data);

        expect(numParsed).toBe(3);
    });

    test('rock can be read', () => {
        const data = 'A X'.split('\n');

        const parser = new StrategyGuideParser();

        parser.parse(data);
        const strategy = parser.getGuide().getStrategy(0);

        expect(strategy).not.toBeNull();
        expect(strategy!.opponent).toBe(1);
        expect(strategy!.you).toBe(1);
    });

    test('paper can be read', () => {

        const data = 'B Y'.split('\n');

        const parser = new StrategyGuideParser();

        parser.parse(data);
        const strategy = parser.getGuide().getStrategy(0);

        expect(strategy).not.toBeNull();
        expect(strategy!.opponent).toBe(2);
        expect(strategy!.you).toBe(2);
    });

    test('scissors can be read', () => {

        const data = ['C Z'];

        const parser = new StrategyGuideParser();

        parser.parse(data);
        const strategy = parser.getGuide().getStrategy(0);

        expect(strategy).not.toBeNull();
        expect(strategy!.opponent).toBe(3);
        expect(strategy!.you).toBe(3);
    });

    test('invalid data returns exception', () => {

        const data = 'any old data'.split('\n');

        const parser = new StrategyGuideParser();

        expect(() => parser.parse(data)).toThrow(); 
    });
});