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
    @Input() examService: ExamService;

    questionIdToAnswerMap: Map<string, AnswerModel> = new Map<string, AnswerModel>();
    questionIdToResultMap: Map<string, boolean> = new Map<string, boolean>();

    questions: QuestionModel[];
    curQuestionIdx: number = 0;

    ngOnInit() {
        this.questions = this.exam.questions;
    }

    setAnswer(answer: AnswerModel) {
        this.questionIdToAnswerMap.set(this.questions[this.curQuestionIdx].id, answer);
    }

    moveToNextQuestion(id: string) {
        this.curQuestionIdx++;
        if (this.curQuestionIdx == this.questions.length) {
            this.showResult();
        }
    }

    showResult() {
        const questionIdToAnswerIdMap = new Map<string, string>();
        this.questionIdToAnswerMap.forEach((value: AnswerModel, key: string) => {
            questionIdToAnswerIdMap.set(key, value.id);
        });
        this.examService.checkExamAnswers(new ExamResultsDTO(this.exam.id, questionIdToAnswerIdMap))
            .subscribe(res => {
                this.questionIdToResultMap = res;
                //Object.keys(res).forEach(k => this.questionIdToResultMap.set(k[0], k[1]));
                console.log(res);
            });
    }
}
