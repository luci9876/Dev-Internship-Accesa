import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { Event } from '../models/Event';
import { ENDPOINT_ERROR, Response} from '../models/Response';

class SportCenterEventService {

    public static getAllEvents = async (): Promise<Response<Event[]>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/event-sport-center`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static getEventById = async (id: number): Promise<Response<Event>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/event-sport-center/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static addEvent = async (event: Event): Promise<Response<Event>> => {
        try {
            const result = await http.post(`${APIRoutes.SportsBuddyAPI}/event-sport-center`, event, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static updateEvent = async (event: Event): Promise<Response<Event>> => {
        try {
            const result = await http.put(`${APIRoutes.SportsBuddyAPI}/event-sport-center`, event, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static deleteEvent = async (id: number): Promise<Response<Event>> => {
        try {
            const result = await http.delete(`${APIRoutes.SportsBuddyAPI}/event-sport-center/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static getEventsByAuthor = async (id: number): Promise<Response<Event[]>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/event-sport-center/event/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

export default SportCenterEventService;