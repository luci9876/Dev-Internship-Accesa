import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { Challenge } from '../models/Challenge';
import { ENDPOINT_ERROR, Response} from '../models/Response';

class ChallengeService {

    public static getAllChallenges = async (): Promise<Response<Challenge[]>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/challenge`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static getChallengeById = async (id: number): Promise<Response<Challenge>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/challenge/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static addChallenge = async (challenge: Challenge): Promise<Response<Challenge>> => {
        try {
            const result = await http.post(`${APIRoutes.SportsBuddyAPI}/challenge`, challenge, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static updateChallenge = async (challenge: Challenge): Promise<Response<Challenge>> => {
        try {
            const result = await http.put(`${APIRoutes.SportsBuddyAPI}/challenge`, challenge, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static deleteChallenge = async (id: number): Promise<Response<Challenge>> => {
        try {
            const result = await http.delete(`${APIRoutes.SportsBuddyAPI}/challenge/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static getChallengeByAuthor = async (id: number): Promise<Response<Challenge[]>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/challenge/author/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

export default ChallengeService;