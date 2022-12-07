import { RPS, Strategy } from '../model/types';
import StrategyGuide from './strategy-guide';

export default class StrategyGuideParser {
    private guide: StrategyGuide;

    constructor() {
        this.guide = new StrategyGuide();
    }

    public getGuide(): StrategyGuide { 
        return this.guide;
    }

    private static getChoice(character: string): RPS {
        switch (character) {
            case 'A':
            case 'X':
                return RPS.Rock;

            case 'B':
            case 'Y':
                return RPS.Paper;

            case 'C':
            case 'Z':
                return RPS.Scissors;
        }

        throw 'Unexpected strategy file character';
    }

    private parseStrategyText(strategyTextLine: string): void {
        if (strategyTextLine.length !== 3) {
            throw 'Text line not long enough';
        }

        const lhs = strategyTextLine.at(0)!;
        const space = strategyTextLine.at(1)!;
        if (space !== ' ') {
            throw 'Space character not present.';
        }        
        const rhs = strategyTextLine.at(2)!;

        this.guide.addStrategy(StrategyGuideParser.getChoice(lhs), StrategyGuideParser.getChoice(rhs));
    }

    public parse(textLines: Array<string>): number {

        textLines.forEach(this.parseStrategyText.bind(this));

        return this.guide.getNumStrategies();
    }
}