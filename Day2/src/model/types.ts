
export enum RPS {
    Rock = 1,
    Paper = 2,
    Scissors = 3
};

export enum ExpectedOutcome {
    YouLose,
    Draw,
    YouWin
};

export type Strategy = {
    opponent: RPS;
    you: RPS;
};