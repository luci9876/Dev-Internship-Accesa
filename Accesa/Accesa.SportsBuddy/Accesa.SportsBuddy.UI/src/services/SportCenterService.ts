import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { SportsCenter } from '../models/SportsCenter';
import { ENDPOINT_ERROR, Response } from '../models/Response';

class SportCenterService {

    public static getAllSportCenters = async (): Promise<Response<SportsCenter[]>> => {
        try {
            const sportCenters = await http.get(`${APIRoutes.SportsBuddyAPI}/sport-center`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            return {
                data: sportCenters.data,
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

}

export default SportCenterService;