import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { Event, JoinEvent, EventExtended  } from '../models/Event';
import { ENDPOINT_ERROR, Response} from '../models/Response';

class JoinSportCenterEventService {

    public static getAllEvents = async (): Promise<Response<EventExtended[]>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/JoinSportCenterEvent`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static getEventById = async (userId: number, eventId: number): Promise<Response<Event>> => {
        try {
            const result = await http.get(`${APIRoutes.SportsBuddyAPI}/JoinSportCenterEvent/${userId}/${eventId}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static addEvent = async (event: JoinEvent): Promise<Response<Event>> => {
        try {
            const result = await http.post(`${APIRoutes.SportsBuddyAPI}/JoinSportCenterEvent`, event, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static deleteEvent = async (userId: number, eventId: number): Promise<Response<Event>> => {
        try {
            const result = await http.delete(`${APIRoutes.SportsBuddyAPI}/JoinSportCenterEvent/${userId}/${eventId}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

export default JoinSportCenterEventService;