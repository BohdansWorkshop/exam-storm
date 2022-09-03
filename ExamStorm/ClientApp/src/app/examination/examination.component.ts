import { Component, OnInit } from '@angular/core';
import { ExamModel } from '../models/exam/ExamModel';
import { ExamService } from '../services/exam.service';

@Component({
    selector: 'app-examination',
    templateUrl: './examination.component.html',
    styleUrls: ['./examination.component.css']
})
export class ExaminationComponent implements OnInit {

    exams: ExamModel[] = [];
    startedExam: ExamModel;
    constructor(public examService: ExamService) { }

    ngOnInit() {
        this.examService.getExamsRequest().subscribe(
            (exams: ExamModel[]) => {
                this.exams = exams;
            },
            (err: any) => {
                console.log(err);
            }
        );
    }

    startExam(exam: ExamModel) {
        this.startedExam = exam;
    }
}
