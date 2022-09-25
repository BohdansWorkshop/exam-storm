import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { UserService } from './services/user.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatDialogModule, MatIconModule, MatInputModule, MatListModule, MatProgressSpinnerModule, MatTabsModule } from '@angular/material';
import { ExamService } from './services/exam.service';
import { AccountService } from './services/account.service';
import { ExaminationComponent } from './components/examination/examination.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { QuestionWidgetComponent } from './components/examination/question-widget/question-widget.component';
import { UsersManagementPanelComponent } from './components/admin-dashboard/users-management-panel/users-management-panel.component';
import { NewExamModalComponent } from './components/admin-dashboard/modals/new-exam/new-exam-modal.component';
import { ExamsManagementPanelComponent } from './components/admin-dashboard/exams-management-panel/exams-management-panel.component';
import { SummaryWidgetComponent } from './components/examination/summary-widget/summary-widget.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';

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
        ExamsManagementPanelComponent,
        SummaryWidgetComponent,
        UserProfileComponent
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
            { path: 'profile', component: UserProfileComponent },
        ]),
        MatTabsModule,
        MatButtonModule,
        MatInputModule,
        MatCardModule,
        MatListModule,
        BrowserAnimationsModule,
        MatProgressSpinnerModule,
        MatDialogModule,
        MatIconModule,
        ReactiveFormsModule
    ],
    providers: [AccountService, UserService, ExamService],
    bootstrap: [AppComponent]
})
export class AppModule { }
