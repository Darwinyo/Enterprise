import { UserDetailsModel } from './../user-details/user-details.model';
export interface UserLoginModel {
    userLoginId: string;
    userLogin: string;
    email: string;
    phoneNumber: number;
    password: string;
    userDetailId: string;

    userDetails: UserDetailsModel;
}
