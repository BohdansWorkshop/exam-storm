import { BaseModel } from "../BaseModel";
import { AnswerModel } from "./AnswerModel";

export class QuestionModel extends BaseModel {
    description: string;
    answers: AnswerModel[];
}