import { Trainee } from './Trainee';
import { GenderEnum, UserRoleEnum } from './UserInfo';

export interface Trainer extends Trainee {
    trainerId: number,
    rating: number,
    isAvailable: boolean
}

export const DEFAULT_TRAINER =  {
    trainerId: 0,
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    addressNavigation: {
        id: 0,
        street: '',
        city: '',
        state: '',
        postalCode: '',
        country: '',
    },
    birthDate: new Date(),
    gender: GenderEnum.MALE,
    phoneNumber: '',
    createdAt: new Date(),
    role: {
        id: UserRoleEnum.TRAINER,
        name: ''
    },
    rating: 0,
    isAvailable: true,
}