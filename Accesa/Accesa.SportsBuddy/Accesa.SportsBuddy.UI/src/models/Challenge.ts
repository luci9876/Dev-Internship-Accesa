export interface Challenge {
    id: number;
    authorId: number;
    title: string;
    description: string;
    trackedOutcome: string;
}

export interface ChallengeExtended {
    traineeId: number;
    challengeId: number;
    proof: string;
    startDate: Date;
    endDate: Date | null;
    isFinished: boolean;
}

export const DEFAULT_CHALLANGE:Challenge = {
    id:0,
    authorId: 0,
    title:'',
    description:'',
    trackedOutcome:'',
}