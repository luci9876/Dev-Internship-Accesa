import { Role, UserRoleEnum } from "./UserInfo";
export interface Admin {
  id?: number;
  name: string;
  email: string;
  password: string;
  birthDate: Date;
  phoneNumber: string;
  role: Role;
  picture?: string;
}

export const DEFAULT_ADMIN = {
  name: "",
  email: "",
  password: "",
  birthDate: new Date(),
  phoneNumber: "",
  role: {
    id: UserRoleEnum.ADMIN,
    name: "Admin"
  }
}