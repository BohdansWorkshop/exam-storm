import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ExamModel } from '../models/exam/ExamModel';
import { UserModel } from '../models/UserModel';
import { ExamService } from '../services/exam.service';
import { UserService } from '../services/user.service';
import { NewExamModalComponent } from './modals/new-exam/new-exam-modal.component';

@Component({
    selector: 'app-admin-dashboard',
    templateUrl: './admin-dashboard.component.html',
    styleUrls: ['./admin-dashboard.component.css']
})

export class AdminDashboardComponent implements OnInit {
    userModels: UserModel[] = [];
    examModels: ExamModel[] = [];
    private usersEditingCache: Map<string, UserModel> = new Map<string, UserModel>();

    constructor(private userService: UserService, private examService: ExamService, public dialog: MatDialog) { }

    ngOnInit() {
        this.userService.getUsersRequest().subscribe(
            (users: UserModel[]) => {
                this.userModels = users;
            },
            (err: any) => console.log(err));

        this.examService.getExamsRequest().subscribe(
            (exams: ExamModel[]) => {
                this.examModels = exams;
            },
            (err: any) => console.log(err));
    }

    startEditUser(user: UserModel) {
        this.usersEditingCache.set(user.id, new UserModel(user.id, user.firstName, user.lastName, user.role));
    }

    exitEditMode(userId: string) {
        this.usersEditingCache.delete(userId);
    }

    updateUser(user: UserModel) {
        this.userService.postUpdateUserRequest(user).subscribe(
            (updatedUserModel: UserModel) => {
                const userIdx = this.userModels.findIndex(x => x.id == user.id);
                if (userIdx > -1) {
                    this.userModels[userIdx] = updatedUserModel;
                }
                this.exitEditMode(updatedUserModel.id)
            },
            (err: any) => console.log(err)
        );
    }

    removeUser(user: UserModel) {
        this.userService.removeUserRequest(user.id).subscribe(
            (res: boolean) => {
                if (res) {
                    this.userModels.splice(this.userModels.indexOf(user), 1);
                }
            },
            (err: any) => console.log(err)
        );
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
                const examIdx= this.examModels.findIndex(x => x.id == updatedExam.id);
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