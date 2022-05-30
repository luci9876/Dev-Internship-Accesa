import { Trainee } from './Trainee';
import { Trainer } from './Trainer';
import { Admin } from './Admin';

export interface LoginModel {
    token: string;
    expiration: Date;
    user: Trainee | Trainer | Admin;
}