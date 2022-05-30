import { GenderEnum, Role, Address, UserRoleEnum } from './UserInfo';

export interface Trainee {
    id?: number;
    firstName: string;
    lastName: string;
    email: string;
    password?: string;
    addressNavigation?: Address;
    birthDate: Date;
    gender?: GenderEnum;
    phoneNumber: string;
    createdAt?: Date;
    role: Role;
    score?:number;
    picture?: string;
}

export const DEFAULT_TRAINEE = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    addressNavigation: {
        id: 0,
        street: '',
        city: '',
        state: '',
        postalCode: '',
        country: '',
    },
    birthDate: new Date("2021-08-18T00:00:00"),
    gender: GenderEnum.MALE,
    phoneNumber: '',
    role: {
        id: UserRoleEnum.TRAINEE,
        name: ''
    }
}

//export type TraineeRegister = Omit<Trainee, 'addressNavigation'>;

