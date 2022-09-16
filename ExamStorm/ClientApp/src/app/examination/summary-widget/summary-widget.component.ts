import { Component, Input, OnInit } from '@angular/core';
import { AnswerModel } from '../../models/exam/AnswerModel';
import { ExamModel } from '../../models/exam/ExamModel';
import { ExamResultsDTO } from '../../models/exam/ExamResultsDTO';
import { ExamService } from '../../services/exam.service';

@Component({
    selector: 'summary-widget',
    templateUrl: './summary-widget.component.html',
    styleUrls: ['./summary-widget.component.css']
})
export class SummaryWidgetComponent implements OnInit {
    @Input() exam: ExamModel;
    @Input() questionIdToAnswerMap: Map<string, AnswerModel> = new Map<string, AnswerModel>();

    questionIdToResultMap: Map<string, boolean> = new Map<string, boolean>();
    correctAnswersAmount: number = 0;

    constructor(public examService: ExamService) { }

    ngOnInit() {
        const questionIdToAnswerIdMap = new Map<string, string>();
        this.questionIdToAnswerMap.forEach((value: AnswerModel, key: string) => {
            questionIdToAnswerIdMap.set(key, value.id);
        });

        this.examService.checkExamAnswers(new ExamResultsDTO(this.exam.id, questionIdToAnswerIdMap))
            .subscribe((res: Map<string, boolean>) => {
                this.questionIdToResultMap = res;
                this.countCorrectAnswers();
                console.log(res);
            });
    }

    private countCorrectAnswers() {
        for (let [key, value] of Object.entries(this.questionIdToResultMap)) {
            if (value) {
                this.correctAnswersAmount++;
            }
        }
    }
}
