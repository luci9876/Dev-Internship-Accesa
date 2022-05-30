export interface Review {
    id?: number;
    rating: number;
    comment: string;
    traineeId: number;
    traineeFirstName: string;
    traineeLastName: string;
    trainingId: number;
    createdAt: Date

}