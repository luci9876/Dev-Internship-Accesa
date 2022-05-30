import http from "../http-common"

class ActivityService {

    public static async getActivityInfo(id: number) {
        return await http.get(`/get-activity-info/${id}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
    }

    public async deleteTrainingProgram(activityId: number){
        return await http.delete(`/get-trainer-training-program/${activityId}`, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') } });
    }
}

export default new ActivityService();