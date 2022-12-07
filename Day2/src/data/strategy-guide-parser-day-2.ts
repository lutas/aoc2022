import { ExpectedOutcome, RPS, Strategy } from '../model/types';
import StrategyGuide from './strategy-guide';
import StrategyGuideParser from './strategy-guide-parser';

export default class StrategyGuideParserDay2 extends StrategyGuideParser {

    constructor() {
        super();        
    }

    private getExpectedOutcome(character: string): ExpectedOutcome {
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

    protected getYourMove(opponentsChoice: RPS, expectedOutcome: ExpectedOutcome): RPS {

        if (expectedOutcome === ExpectedOutcome.Draw) {
            return opponentsChoice;
        }

        if (expectedOutcome === ExpectedOutcome.YouLose) {
            switch (opponentsChoice) {
                case RPS.Rock: return RPS.Scissors;
                case RPS.Paper: return RPS.Rock;
                case RPS.Scissors: return RPS.Paper;
            }
        }

        if (expectedOutcome === ExpectedOutcome.YouWin) {
            switch (opponentsChoice) {
                case RPS.Rock: return RPS.Paper;
                case RPS.Paper: return RPS.Scissors;
                case RPS.Scissors: return RPS.Rock;
            }
        }

        throw 'Unable to determine your next move';
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

        const outcome = this.getExpectedOutcome(rhs);
        const opponentChoice = this.getChoice(lhs);
        const yourMove = this.getYourMove(opponentChoice, outcome);

        this.guide.addStrategy(opponentChoice, yourMove);
    }
}