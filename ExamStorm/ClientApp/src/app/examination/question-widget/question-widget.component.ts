import { Component, Input, OnInit } from '@angular/core';
import { AnswerModel } from '../../models/exam/AnswerModel';
import { ExamModel } from '../../models/exam/ExamModel';
import { ExamResultsDTO } from '../../models/exam/ExamResultsDTO';
import { QuestionModel } from '../../models/exam/QuestionModel';
import { ExamService } from '../../services/exam.service';

@Component({
    selector: 'app-question-widget',
    templateUrl: './question-widget.component.html',
    styleUrls: ['./question-widget.component.css']
})
export class QuestionWidgetComponent implements OnInit {
    @Input() exam: ExamModel;

    questionIdToAnswerMap: Map<string, AnswerModel> = new Map<string, AnswerModel>();
    correctAnswersAmount: number = 0;
    timeLeft: number;

    questions: QuestionModel[]
    curQuestionIdx: number = 0;
    isFinishedTest: boolean;

    ngOnInit() {
        this.questions = this.exam.questions;

        if (this.exam.timeInSeconds > 0) {
            this.timeLeft = this.exam.timeInSeconds;
            this.startTimer();
        }
    }

    setAnswer(answer: AnswerModel) {
        this.questionIdToAnswerMap.set(this.questions[this.curQuestionIdx].id, answer);
    }

    moveToNextQuestion() {
        this.curQuestionIdx++;
        if (this.curQuestionIdx == this.questions.length) {
            this.isFinishedTest = true;
        }
    }

    private startTimer() {
        setInterval(() => {
            if (this.timeLeft > 0) {
                this.timeLeft--;
            } else {
                this.isFinishedTest = true;
            }
        }, 1000);
    }
}
