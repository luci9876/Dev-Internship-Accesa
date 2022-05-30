import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { Trainee } from '../models/Trainee';
import { ENDPOINT_ERROR, Response } from '../models/Response';
import axios from 'axios';

class TraineeService {

    public static getAllTrainees = async (): Promise<Response<Trainee[]>> => {
        try {
            const usersResult = await http.get(`${APIRoutes.SportsBuddyAPI}/trainee`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: usersResult.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status!,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static getTraineeById = async (id: number): Promise<Response<Trainee>> => {
        try {
            const userResult = await http.get(`${APIRoutes.SportsBuddyAPI}/trainee/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: userResult.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status!,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static getTraineesScore = async (): Promise<Response<Trainee[]>> => {
        try {
            const usersResult = await http.get(`${APIRoutes.SportsBuddyAPI}/trainee/trainees/score`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: usersResult.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status!,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static addTrainee = async (user: Trainee): Promise<Response<Trainee>> => {
        try {
            const result = await http.post(`${APIRoutes.SportsBuddyAPI}/trainee`, user, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static updateTrainee = async (user: Trainee): Promise<Response<Trainee>> => {
        try {
            const result = await http.put(`${APIRoutes.SportsBuddyAPI}/trainee`, user, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static updateTraineeScore = async (id: number): Promise<Response<Trainee>> => {
        try {
            const result = await http.put(`${APIRoutes.SportsBuddyAPI}/trainee/trainee-score/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static deleteTrainee = async (id: number): Promise<Response<Trainee>> => {
        try {
            const result = await http.delete(`${APIRoutes.SportsBuddyAPI}/trainee`, {
                headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') },
                data: id
            });
            return {
                data: result.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

}

export default TraineeService;