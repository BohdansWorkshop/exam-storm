export abstract class BaseModel {
    constructor(id?: string) {
        this.id = id;
    }
    id?: string;
}