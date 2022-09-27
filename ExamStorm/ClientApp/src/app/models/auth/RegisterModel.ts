import { UserModel } from "../UserModel";

export class RegisterModel extends UserModel {
    password: string;
    constructor(email: string, fName: string, lName: string, password: string) {
        super(undefined, email, fName, lName, undefined);
        this.password = password;
    }
}