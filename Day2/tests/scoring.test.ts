import { RPS } from "../src/model/types"
import Scoring from "../src/scoring";

describe('scoring checks', () => {

    test.each([ [RPS.Rock, RPS.Paper, 8 ],
                [RPS.Paper, RPS.Rock, 1 ],
                [RPS.Scissors, RPS.Scissors, 6] ])
    ('returns correct score', ((opponent: RPS, you: RPS, score: number) => {

        const scoring = new Scoring();

        const calculatedScore = scoring.scoreRound(opponent, you);

        expect(calculatedScore).toBe(score);
    }));

    test('total score is calculated correctly', () => {

        const scoring = new Scoring();

        scoring.scoreRound(RPS.Rock, RPS.Paper);
        scoring.scoreRound(RPS.Paper, RPS.Rock);
        scoring.scoreRound(RPS.Scissors, RPS.Scissors);

        expect(scoring.getTotalScore()).toBe(15);

    });
})