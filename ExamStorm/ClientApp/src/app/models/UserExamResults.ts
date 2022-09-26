import { BaseModel } from "./BaseModel";

export class UserExamResults extends BaseModel {
    examDescription: string;
    questionsAmount: number
    correctAnswersAmount: number;
}