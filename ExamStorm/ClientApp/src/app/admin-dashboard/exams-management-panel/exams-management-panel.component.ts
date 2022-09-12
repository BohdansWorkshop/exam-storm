import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ExamModel } from '../../models/exam/ExamModel';
import { ExamService } from '../../services/exam.service';
import { NewExamModalComponent } from '../modals/new-exam/new-exam-modal.component';

@Component({
    selector: 'exams-management-panel',
    templateUrl: './exams-management-panel.component.html',
    styleUrls: ['./exams-management-panel.component.css']
})
export class ExamsManagementPanelComponent implements OnInit {
    examModels: ExamModel[] = [];

    constructor(private examService: ExamService, public dialog: MatDialog) { }

    ngOnInit() {
        this.examService.getExamsRequest().subscribe(
            (exams: ExamModel[]) => {
                this.examModels = exams;
            },
            (err: any) => console.log(err));
    }

    openNewExamDialog(): void {
        const config = new MatDialogConfig();
        config.width = "500px";
        config.autoFocus = true;

        const openedDialogRef = this.dialog.open(NewExamModalComponent, config);
        openedDialogRef.afterClosed().subscribe((newExamModel: ExamModel) => {
            this.examService.postAddNewExamModelRequest(newExamModel).subscribe((res: ExamModel) => {
                console.log(res);
            })
        });
    }

    startEditExam(examModel: ExamModel) {
        const config = new MatDialogConfig();
        config.width = "500px";
        config.autoFocus = true;
        config.data = {
            examModel: examModel
        }

        const openedDialogRef = this.dialog.open(NewExamModalComponent, config);
        openedDialogRef.afterClosed().subscribe((examModel: ExamModel) => {
            this.examService.postUpdateExamRequest(examModel).subscribe((updatedExam: ExamModel) => {
                const examIdx = this.examModels.findIndex(x => x.id == updatedExam.id);
                if (examIdx > -1) {
                    this.examModels[examIdx] = updatedExam;
                }
            })
        });
    }

    removeExam(examModel: ExamModel) {
        this.examService.removeExamRequest(examModel.id).subscribe(
            (res: boolean) => {
                if (res) {
                    this.examModels.splice(this.examModels.indexOf(examModel), 1);
                }
            },
            (err: any) => console.log(err)
        );
    }

}
