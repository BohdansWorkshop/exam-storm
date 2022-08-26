export class UserModel {
    constructor(id: string, fName: string, lName: string, role: string) {
        this.id = id;
        this.firstName = fName;
        this.lastName = lName;
        this.role = role;
    }
    
    id: string;
    firstName: string;
    lastName: string;
    role: string;
}