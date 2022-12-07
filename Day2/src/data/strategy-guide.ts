import { RPS, Strategy } from "../model/types";

export default class StrategyGuide {

    private guide: Array<Strategy>;

    constructor() {
        this.guide = [];
    }

    public get(): Array<Strategy> {
        return this.guide;
    }

    public getNumStrategies(): number {
        return this.guide.length;
    }

    public getStrategy(index: number): Strategy | null {
        if (index < 0 || index >= this.guide.length) {
            return null;
        }

        return this.guide[index];
    }

    public addStrategy(opponent: RPS, you: RPS) {
        this.guide.push({
            opponent,
            you
        });
    }
};