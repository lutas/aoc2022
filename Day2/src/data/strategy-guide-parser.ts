import { ExpectedOutcome, RPS, Strategy } from '../model/types';
import StrategyGuide from './strategy-guide';

export default class StrategyGuideParser {
    protected guide: StrategyGuide;

    constructor() {
        this.guide = new StrategyGuide();
    }

    public getGuide(): StrategyGuide { 
        return this.guide;
    }

    protected getChoice(character: string): RPS {
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

    private static getExpectedOutcome(character: string): ExpectedOutcome {
        switch (character) {
            case 'X':
                return ExpectedOutcome.YouLose;
            
            case 'Y':
                return ExpectedOutcome.Draw;

            case 'Z':
                return ExpectedOutcome.YouWin;
        }

        throw 'Unexpected outcome file character';
    }

    protected parseStrategyText(strategyTextLine: string): void {
        if (strategyTextLine.length !== 3) {
            throw 'Text line not long enough';
        }

        const lhs = strategyTextLine.at(0)!;
        const space = strategyTextLine.at(1)!;
        if (space !== ' ') {
            throw 'Space character not present.';
        }        
        const rhs = strategyTextLine.at(2)!;

        this.guide.addStrategy(this.getChoice(lhs), this.getChoice(rhs));
    }

    public parse(textLines: Array<string>): number {

        textLines.forEach(this.parseStrategyText.bind(this));

        return this.guide.getNumStrategies();
    }
}