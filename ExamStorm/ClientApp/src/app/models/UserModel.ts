import { BaseModel } from "./BaseModel";

export class UserModel extends BaseModel {
    constructor(id: string, email: string, fName: string, lName: string, role: string) {
        super(id);
        this.email = email;
        this.firstName = fName;
        this.lastName = lName;
        this.role = role;
    }

    email: string;
    firstName: string;
    lastName: string;
    role: string;
}