import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LoginModel } from "../models/auth/LoginModel";
import { RegisterModel } from "../models/auth/RegisterModel";
import { UserAuthInfoModel } from "../models/auth/UserAuthInfoModel";
import { UserExamResults } from "../models/UserExamResults";

@Injectable({
    providedIn: 'root'
})
export class AccountService {
    private readonly AccountControllerURL: string = "https://localhost:44308/api/account";

    constructor(private httpClient: HttpClient) { }

    register(registerModel: RegisterModel) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        const registerRequestUrl = `${this.AccountControllerURL}/register`;
        return this.httpClient.post<UserAuthInfoModel>(registerRequestUrl, JSON.stringify(registerModel), httpOptions);
    }

    login(loginInfo: LoginModel) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        const loginRequestUrl = `${this.AccountControllerURL}/login`;
        return this.httpClient.post<UserAuthInfoModel>(loginRequestUrl, JSON.stringify(loginInfo), httpOptions);
    }

    logout() {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("jwtToken")
            })
        };
        const logoutRequestUrl = `${this.AccountControllerURL}/logout`;
        return this.httpClient.post(logoutRequestUrl, null, httpOptions);
    }

    getExamResults() {
        const httpOptions = {
            headers: new HttpHeaders({
                'Authorization': 'Bearer ' + localStorage.getItem("jwtToken")
            })
        };
        const logoutRequestUrl = `${this.AccountControllerURL}/examResults`;
        return this.httpClient.get<UserExamResults[]>(logoutRequestUrl, httpOptions);
    }
}