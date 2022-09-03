import { BaseModel } from "../BaseModel";
import { QuestionModel } from "./QuestionModel";

export class ExamModel extends BaseModel {
    title: string;
    description: string
    questions: QuestionModel[];
}