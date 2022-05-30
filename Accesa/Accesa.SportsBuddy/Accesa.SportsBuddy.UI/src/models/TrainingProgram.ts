import { SportsCenter } from "./SportsCenter";
import { ActivityTrainerInfo } from "./UserInfo";

export interface TrainingProgram {
    trainingProgramId: number;
    trainingProgramName: string;
    trainingProgramDifficulty: string;
    trainingProgramDescription: string;
    trainingProgramRecommendedSteps: string[];
    trainingProgramDuration: string;
    trainingProgramLocation: string;
    trainingProgramSportCenter?: SportsCenter;
    trainer: ActivityTrainerInfo;
    trainingProgramRating: number;
}