import { BaseModel } from "./BaseModel";

export class UserModel extends BaseModel {
    constructor(id: string, fName: string, lName: string, role: string) {
        super(id);
        this.firstName = fName;
        this.lastName = lName;
        this.role = role;
    }
    
    firstName: string;
    lastName: string;
    role: string;
}