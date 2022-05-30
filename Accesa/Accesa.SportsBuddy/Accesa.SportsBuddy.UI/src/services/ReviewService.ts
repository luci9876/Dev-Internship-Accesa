import { APIRoutes } from '../helpers/utils';
import http from '../http-common';
import { ENDPOINT_ERROR, Response } from '../models/Response';
import { Review } from '../models/Review';

class ReviewService {

    public static getReviewsByTrainingId = async (id: number): Promise<Response<Review[]>> => {
        try {
            const trainingPrograms = await http.get(`${APIRoutes.SportsBuddyAPI}/review/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
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

    public static addReview = async (review: Review, setShouldRefreshReviews: any): Promise<Response<Review>> => {
        try {
            const response = await http.post(`${APIRoutes.SportsBuddyAPI}/review`, review, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
            response && setShouldRefreshReviews(true);
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

export default ReviewService;