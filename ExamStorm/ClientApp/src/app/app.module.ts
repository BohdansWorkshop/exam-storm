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
import { MatButtonModule, MatCardModule, MatGridListModule, MatIconModule, MatInputModule, MatProgressSpinnerModule, MatTabsModule } from '@angular/material';
import { ExaminationComponent } from './examination/examination.component';
import { QuestionWidgetComponent } from './examination/question-widget/question-widget.component';
import { ExamService } from './services/exam.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        AdminDashboardComponent,
        ExaminationComponent,
        QuestionWidgetComponent
    ],
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
        MatProgressSpinnerModule
    ],
    providers: [UserService, ExamService],
    bootstrap: [AppComponent]
})
export class AppModule { }
