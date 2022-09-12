import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { UserService } from './services/user.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatDialogModule, MatGridListModule, MatIconModule, MatInputModule, MatProgressSpinnerModule, MatTabsModule } from '@angular/material';
import { ExaminationComponent } from './examination/examination.component';
import { QuestionWidgetComponent } from './examination/question-widget/question-widget.component';
import { ExamService } from './services/exam.service';
import { NewExamModalComponent } from './admin-dashboard/modals/new-exam/new-exam-modal.component';
import { UsersManagementPanelComponent } from './admin-dashboard/users-management-panel/users-management-panel.component';
import { ExamsManagementPanelComponent } from './admin-dashboard/exams-management-panel/exams-management-panel.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        AdminDashboardComponent,
        ExaminationComponent,
        QuestionWidgetComponent,
        NewExamModalComponent,
        UsersManagementPanelComponent,
        ExamsManagementPanelComponent
    ],
    entryComponents: [NewExamModalComponent],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'admin-dashboard', component: AdminDashboardComponent },
            { path: 'examination', component: ExaminationComponent },
        ]),
        MatTabsModule,
        MatButtonModule,
        MatInputModule,
        MatCardModule,
        MatGridListModule,
        BrowserAnimationsModule,
        MatProgressSpinnerModule,
        MatDialogModule
    ],
    providers: [UserService, ExamService],
    bootstrap: [AppComponent]
})
export class AppModule { }
