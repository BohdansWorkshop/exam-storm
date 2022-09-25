import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserModel } from "../models/UserModel";

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private readonly UserControllerURL: string = "https://localhost:44308/api/user";

    constructor(private httpClient: HttpClient) { }

    getUsersRequest() : Observable<UserModel[]>{
        return this.httpClient.get<UserModel[]>(this.UserControllerURL);
    }

    postUpdateUserRequest(userModel: UserModel): Observable<UserModel> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                //Authorization: 'my-auth-token'
            })
        };
        const updateRequestUrl = `${this.UserControllerURL}/update`;
        return this.httpClient.post<UserModel>(updateRequestUrl, JSON.stringify(userModel), httpOptions);
    }

    removeUserRequest(userId: string): Observable<boolean> {
        const removeRequestUrl = `${this.UserControllerURL}/${userId}`;
        return this.httpClient.delete<boolean>(removeRequestUrl);
    }
}