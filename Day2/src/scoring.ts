import { RPS, Strategy } from "./model/types"

export default class Scoring {

    private totalScore: number;

    constructor() {
        this.totalScore = 0;
    }

    public getTotalScore(): number {
        return this.totalScore;
    }

    private scoreChoice(choice: RPS): number {

        return <number>choice;
    }

    private gameResultScore(opponent: RPS, you: RPS): number {

        const winScore = 6;
        const lossScore = 0;
        const drawScore = 3;

        if (opponent === you) {
            return drawScore;
        }
        
        switch (opponent) {
            case RPS.Rock:
                return you == RPS.Paper ? winScore : lossScore;

            case RPS.Paper:
                return you === RPS.Scissors ? winScore : lossScore;

            case RPS.Scissors:
                return you == RPS.Rock ? winScore : lossScore;
        }
    }

    public scoreRound(opponent: RPS, you: RPS): number {

        const yourScore = this.scoreChoice(you);
        const gameResultScore = this.gameResultScore(opponent, you);

        const roundScore = yourScore + gameResultScore;

        this.totalScore += roundScore;

        return this.totalScore;
    }
};
