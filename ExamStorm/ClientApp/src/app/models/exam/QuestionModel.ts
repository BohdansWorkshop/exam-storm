import { BaseModel } from "../BaseModel";
import { AnswerModel } from "./AnswerModel";

export class QuestionModel extends BaseModel {
    question: string;
    explanation: string;
    answers: AnswerModel[] = [];
}