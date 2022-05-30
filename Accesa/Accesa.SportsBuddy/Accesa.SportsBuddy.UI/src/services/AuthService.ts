import { Trainee } from '../models/Trainee';
import { LoginInfo } from '../models/UserInfo';
import { Admin } from '../models/Admin';
import { APIRoutes } from '../helpers/utils';
import { ENDPOINT_ERROR, Response } from '../models/Response';
import { LoginModel } from '../models/LoginModel';
import http from '../http-common';
//REGISTER SERVICE

export default class AuthService {

    public static registerUser = async (user: Trainee) => {
        try {
            const response = await http.post(`${APIRoutes.SportsBuddyAPI}/authenticate/register`, user);
            return {
                data: response.status === 200,
                hasError: false,
            }
        }
        catch (error : any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : 'Endpoint cannot be accesed'
            };
        }
    }


    public static registerAdmin = async (user: Admin) => {
        try {
            const response = await http.post(`${APIRoutes.SportsBuddyAPI}/authenticate/register-admin`, user);
            return {
                data: response.status === 200,
                hasError: false,
            }
        }
        catch (error : any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }
    
    
    public static userLogin = async (loginData: LoginInfo): Promise<Response<LoginModel>> => {
        try {
            const response = await http.post(`${APIRoutes.SportsBuddyAPI}/authenticate/login`, loginData,{headers: {'Authorization' : 'Bearer ' + localStorage.getItem('token')}});
            localStorage.setItem('User', JSON.stringify(response.data.user));
            localStorage.setItem('token',response.data.token);
            localStorage.setItem('accountExists',JSON.stringify(true));
            return {
                data: response.data,
                hasError: false,
            }
        }
        catch (error : any) {
            console.log(error);
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }

    public static adminLogin = async (loginData: LoginInfo): Promise<Response<LoginModel>> => {
        try {
            const response = await http.post(`${APIRoutes.SportsBuddyAPI}/authenticate/login`, loginData,{headers: {'Authorization' : 'Bearer ' + localStorage.getItem('token')}});
            localStorage.setItem('User', JSON.stringify(response.data.user));
            localStorage.setItem('token',response.data.token);
            return {
                data: response.data,
                hasError: false,
            }
        }
        catch (error : any) {
            return {
                hasError: true,
                errorCode: error.response.status,
                errorMessage: error.response ? error.response.data : ENDPOINT_ERROR
            };
        }
    }
}