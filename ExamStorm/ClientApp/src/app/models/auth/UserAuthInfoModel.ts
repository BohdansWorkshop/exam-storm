import { UserModel } from "../UserModel";

export class UserAuthInfoModel {
    user: UserModel;
    accessToken: string;
    refreshToken: string;
}