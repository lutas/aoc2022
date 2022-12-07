import StrategyGuide from "./data/strategy-guide";
import Scoring from "./scoring";

const playGame = (guide: StrategyGuide): number => {

    const numGames = guide.getNumStrategies();

    const scoring = new Scoring();
    for (let g = 0; g < numGames; ++g) {

        const strategy = guide.getStrategy(g)!;

        scoring.scoreRound(strategy.opponent, strategy.you);
    }

    return scoring.getTotalScore();
};

export default playGame;