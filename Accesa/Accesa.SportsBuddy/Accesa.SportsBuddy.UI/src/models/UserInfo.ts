export interface LoginInfo {
    email: string;
    password: string;
}

export enum UserRoleEnum {
    TRAINEE = 1,
    TRAINER = 2,
    ADMIN = 3,
}

export enum GenderEnum {
    MALE = 'M',
    FEMALE = 'F',
}

export interface Address {
    id?: number,
    street: string,
    city: string,
    state: string,
    postalCode: string,
    country: string,
    latitude?: number,
    longitude?: number
}

export interface Role {
    id: UserRoleEnum,
    name: string
}

export interface LoginResponse {
    id: number,
    role: Role
}

export interface ActivityTrainerInfo {
    id: number;
    userFirstName: string;
    userLastName: string;
    rating: number;
}