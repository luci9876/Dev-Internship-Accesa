import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { TrainingProgram } from '../models/TrainingProgram';
import { ENDPOINT_ERROR, Response } from '../models/Response';

class TrainingProgramService {
    
    public static getTraningsInfo = async (): Promise<Response<TrainingProgram[]>> => {
        try {
            const trainingPrograms = await http.get(`${APIRoutes.SportsBuddyAPI}/trainer-training-program`);
            return {
                data: trainingPrograms.data,
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

    public static getTraningInfoByTrainerId = async (id: number): Promise<Response<TrainingProgram[]>> => {
        try {
            const trainingPrograms = await http.get(`${APIRoutes.SportsBuddyAPI}/trainer-training-program/trainer/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: trainingPrograms.data,
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

    public static GetTrainingsInfoByTrainerId = async (id: number): Promise<Response<TrainingProgram[]>> => {
        try {
            const trainingPrograms = await http.get(`${APIRoutes.SportsBuddyAPI}/trainer-training-program/trainer/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: trainingPrograms.data,
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

    public static getTraningInfoByTrainingId = async (id: number): Promise<Response<TrainingProgram>> => {
        try {
            const trainingPrograms = await http.get(`${APIRoutes.SportsBuddyAPI}/trainer-training-program/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: trainingPrograms.data,
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

    public static GetTrainingInfoById = async (id: number): Promise<Response<TrainingProgram>> => {
        try {
            const trainingProgram = await http.get(`${APIRoutes.SportsBuddyAPI}/trainer-training-program/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: trainingProgram.data,
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

    public static addTrainingProgram = async (trainingProgram: TrainingProgram): Promise<Response<TrainingProgram>> => {
        try {
            const response = await http.post(`${APIRoutes.SportsBuddyAPI}/trainer-training-program`, trainingProgram, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: response.data,
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

    public static updateTrainingProgram = async (trainingProgram: TrainingProgram): Promise<Response<TrainingProgram>> => {
        try {
            const response = await http.put(`${APIRoutes.SportsBuddyAPI}/training-program`, trainingProgram, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: response.data,
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

    public static deleteTrainingProgram = async (id: number): Promise<Response<void>> => {
        try {
            const response = await http.delete(`${APIRoutes.SportsBuddyAPI}/training-program/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: response.data,
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

export default TrainingProgramService;