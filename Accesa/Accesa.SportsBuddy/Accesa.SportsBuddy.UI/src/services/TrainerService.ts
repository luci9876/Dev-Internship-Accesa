import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { Trainer } from '../models/Trainer';
import {ENDPOINT_ERROR, Response} from '../models/Response';


class TrainerService {

    public static getAllTrainers = async (): Promise<Response<Trainer[]>> => {
        try {
            const usersResult = await http.get(`${APIRoutes.SportsBuddyAPI}/trainer`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: usersResult.data,
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

    public static getTrainerById = async (id: number): Promise<Response<Trainer>> => {
        try {
            const userResult = await http.get(`${APIRoutes.SportsBuddyAPI}/trainer/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: userResult.data,
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

    public static addTrainer = async (user: Trainer): Promise<Response<void>> => {
        try {
            const result = await http.post(`${APIRoutes.SportsBuddyAPI}/trainer`, user , { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static updateTrainer = async (user: Trainer): Promise<Response<void>> => {
        try {
            const result = await http.put(`${APIRoutes.SportsBuddyAPI}/trainer`, user , { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static deleteTrainer = async (id: number): Promise<Response<void>> => {
        try {
            const result = await http.delete(`${APIRoutes.SportsBuddyAPI}/trainer/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

export default TrainerService;