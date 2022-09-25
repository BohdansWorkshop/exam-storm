import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { AnswerModel } from "../../../../models/exam/AnswerModel";
import { ExamModel } from "../../../../models/exam/ExamModel";
import { QuestionModel } from "../../../../models/exam/QuestionModel";

@Component({
    selector: 'new-exam-modal',
    templateUrl: 'new-exam-modal.html',
})
export class NewExamModalComponent {
    model: ExamModel = new ExamModel();
    isEditMode: boolean = false;
    constructor(public dialogRef: MatDialogRef<NewExamModalComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
        if (data && data.examModel) {
            this.model = data.examModel;
            this.isEditMode = true;
        }
    }

    submit() {
        this.dialogRef.close('data');
    }

    addQuestion() {
        this.model.questions.push(new QuestionModel());
    }

    addAnswer(question: QuestionModel) {
        question.answers.push(new AnswerModel());
    }

    createNewExam() {
        this.dialogRef.close(this.model);
    }
}