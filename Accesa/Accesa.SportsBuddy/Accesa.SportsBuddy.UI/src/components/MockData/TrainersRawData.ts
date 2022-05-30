import { UserRoleEnum } from "../../models/UserInfo";

export const TrainerData={
    id: 1,
    firstName: "Iancu",
    lastName: "Ardelean",
    email: "iancu.ardelean@gmail.com",
    password: "parola",
    addressNavigation: {
        id: 22,
        street: "Atlanta Hwy",
        city: "McKinney",
        state: "Texas",
        postalCode: "19002",
        country: "United States",
        latitude: 4.232000,
        longitude: 4.312300
    },
    birthDate: 1988-1-22,
    gender: 'M',
    phoneNumber: "0743890567",
    createdAt: 2021-2-9,
    role:{
        id: UserRoleEnum.TRAINER,
        name: 'trainer'
    },
    picture: "imfd.jpg",
    trainerId:1,
    rating: 0,
    availability: true
}