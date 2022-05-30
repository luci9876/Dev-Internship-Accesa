import { Admin } from "./Admin";
import { Trainee } from "./Trainee";
import { GenderEnum, UserRoleEnum } from "./UserInfo";

export const TRAINEE_ID = 1;

export const DEFAULT_TRAINER_AUTHOR: Trainee = {
    id: 1,
    firstName: 'John',
    lastName: 'Doe',
    email: 'john.doe@test.com',
    addressNavigation: {
        id: 1,
        street: 'Main St',
        city: 'New York',
        state: 'NY',
        postalCode: '13545',
        country: 'United States',
    },
    birthDate: new Date("2021-08-18T00:00:00"),
    gender: GenderEnum.MALE,
    phoneNumber: '1234567890',
    role: {
        id: UserRoleEnum.TRAINER,
        name: 'Trainer'
    }
}

export const DEFAULT_ADMIN_AUTHOR: Admin = {
    id: 1,
    name: 'John',
    email: 'john@test.com',
    password: '12345',
    phoneNumber: '1234567890',
    role:{
        id: UserRoleEnum.ADMIN,
        name: 'Admin'
    },
    birthDate: new Date("2021-08-18T00:00:00"),
}

export const ROLE = {
    id: UserRoleEnum.TRAINER,
    name: "Trainer"
};
