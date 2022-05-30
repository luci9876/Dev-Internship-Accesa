import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { ChallengeExtended } from '../models/Challenge';
import { ENDPOINT_ERROR, Response } from '../models/Response';

class ExtendedChallengeService {

    public static getAllChallenges = async (): Promise<Response<ChallengeExtended[]>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/trainee-challenge`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.result? error.result.status : 404,
                errorMessage: error.result ? error.result.data : ENDPOINT_ERROR
            };
        }
    }

    public static getAllChallengesByTraineeId = async (id: number): Promise<Response<ChallengeExtended[]>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/trainee-challenge/trainee/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.result? error.result.status : 404,
                errorMessage: error.result ? error.result.data : ENDPOINT_ERROR
            };
        }
    }

    public static getChallengeById = async (traineeId: number, challengeId: number): Promise<Response<ChallengeExtended>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/trainee-challenge/${traineeId}/${challengeId}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.result? error.result.status : 404,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static addChallenge = async (challenge: ChallengeExtended): Promise<Response<ChallengeExtended>> => {
        try {
            const result = await http.post(`${APIRoutes.SportsBuddyAPI}/trainee-challenge`, challenge, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.result? error.result.status : 404,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static updateChallenge = async (challenge: ChallengeExtended): Promise<Response<ChallengeExtended>> => {
        try {
            const result = await http.put(`${APIRoutes.SportsBuddyAPI}/trainee-challenge`, challenge, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.result? error.result.status : 404,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static deleteChallenge = async (traineeID: number, challengeID: number): Promise<Response<ChallengeExtended>> => {
        try {
            const result = await http.delete(`${APIRoutes.SportsBuddyAPI}/trainee-challenge/${traineeID}/${challengeID}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.result? error.result.status : 404,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }
}

export default ExtendedChallengeService;