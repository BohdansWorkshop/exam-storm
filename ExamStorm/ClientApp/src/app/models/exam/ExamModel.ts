import { BaseModel } from "../BaseModel";
import { QuestionModel } from "./QuestionModel";

export class ExamModel extends BaseModel {
    title: string;
    timeInSeconds: number;
    description: string;
    questions: QuestionModel[] = [];
}