import axios from 'axios';
import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { SportsCenter } from '../models/SportsCenters';
import { ENDPOINT_ERROR, Response } from '../models/Response';

class CenterService {

    public static getAllCenters = async (): Promise<Response<SportsCenter[]>> => {
        try {
            const sportCenters = await axios.get(`${APIRoutes.SportsBuddyAPI}/sport-center`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: sportCenters.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.status : ENDPOINT_ERROR
            }

        }

    }
    public static async getCenterById(id: number): Promise<Response<SportsCenter>> {
        try {
            const centerResult = await axios.get(`${APIRoutes.SportsBuddyAPI}/sport-center/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: centerResult.data,
                hasError: false,
            }
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.status : ENDPOINT_ERROR
            }
        }
    }

    public static deleteCenterById = async (id: number): Promise<Response<SportsCenter>> => {
        try {
            return await http.delete(`${APIRoutes.SportsBuddyAPI}/sport-center/${id}`, { data: id });
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.status : ENDPOINT_ERROR
            }
        };
    }

    public static addCenter = async (sportsCenter: SportsCenter): Promise<Response<SportsCenter>> => {
        try {
            return await http.post(`${APIRoutes.SportsBuddyAPI}/sport-center`, sportsCenter, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.status : ENDPOINT_ERROR
            }
        }

    }

    public static updateCenter = async (id: number, sportsCenter: SportsCenter): Promise<Response<SportsCenter>> => {
        try {
            return await http.put(`${APIRoutes.SportsBuddyAPI}/sport-center/${id}`, sportsCenter, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
        }
        catch (error: any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.status : ENDPOINT_ERROR
            }
        }

    }

}
export default CenterService;