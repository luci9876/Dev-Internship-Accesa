import { DEFAULT_TRAINEE, Trainee } from "./Trainee";
import { Address } from "./UserInfo";
import {Admin} from './Admin';

export interface Event {
    id: number;
    authorId: number;
    title: string;
    description: string;
    goal: string;
    addressId: number;
    address: Address;
    startDate: Date;
    duration: string;
    author: Trainee | Admin;
};

export const DEFAULT_EVENT = {
    id: 0,
    authorId: 1,
    title: '',
    description: '',
    goal: '',
    addressId: 0,
    address: {
        id: 0,
        street: '',
        city: '',
        state: '',
        postalCode: '',
        country: '',
    },
    author: DEFAULT_TRAINEE,
    startDate: new Date(),
    duration: ''
}

export interface JoinEvent {
    eventId: number;
    userId: number;
}

export interface EventExtended {
    event: Event;
    eventId: number;
    userId : number;
    user: Trainee;
}