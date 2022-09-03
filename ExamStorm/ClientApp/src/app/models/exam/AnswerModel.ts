import { BaseModel } from "../BaseModel";

export class AnswerModel extends BaseModel {
    description: string;
    isCorrect: boolean;
}