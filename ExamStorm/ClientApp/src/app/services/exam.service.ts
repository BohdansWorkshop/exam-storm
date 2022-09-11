import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ExamModel } from "../models/exam/ExamModel";
import { ExamResultsDTO } from "../models/exam/ExamResultsDTO";

@Injectable({
    providedIn: 'root'
})
export class ExamService {
    readonly ExamControllerURL: string = "https://localhost:44308/api/exam";

    constructor(private httpClient: HttpClient) { }

    getExamsRequest(): Observable<ExamModel[]> {
        return this.httpClient.get<ExamModel[]>(this.ExamControllerURL);
    }

    postAddNewExamModelRequest(examModel: ExamModel): Observable<ExamModel> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                //Authorization: 'my-auth-token'
            })
        };

        const addRequestUrl = `${this.ExamControllerURL}/Add`;
        return this.httpClient.post<ExamModel>(addRequestUrl, JSON.stringify(examModel, this.replacer), httpOptions);
    }

    postUpdateExamRequest(examModel: ExamModel): Observable<ExamModel> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                //Authorization: 'my-auth-token'
            })
        };
        const updateRequestUrl = `${this.ExamControllerURL}/update`;
        return this.httpClient.post<ExamModel>(updateRequestUrl, JSON.stringify(examModel), httpOptions);
    }

    removeExamRequest(examId: string): Observable<boolean> {
        const removeRequestUrl = `${this.ExamControllerURL}/${examId}`;
        return this.httpClient.delete<boolean>(removeRequestUrl);
    }

    checkExamAnswers(examResults: ExamResultsDTO): Observable<any> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                //Authorization: 'my-auth-token'
            })
        };

        const updateRequestUrl = `${this.ExamControllerURL}/CheckAnswers`;
        return this.httpClient.post<any>(updateRequestUrl, JSON.stringify(examResults.ToJSON()), httpOptions);
    }

    replacer(key, value): any {
        if (key == "id") return undefined;
        else return value;
    }
}